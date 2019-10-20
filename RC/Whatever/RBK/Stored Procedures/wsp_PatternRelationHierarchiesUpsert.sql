





-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/23/2018
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
declare @p3 [RBK].[PatternRelationHierarchyType]

insert into @p3 values(N'1',N'23',N'|E|S|E''|S''|M''|M|S''|S|M|E''|M''|E|E|S''|M''|S|M|E''|M|M''|S|E''|E|S''|',N'|E''|S''|E|S|M|M''|S|S''|M''|E|M|E''|E''|S|M|S''|M''|E|M''|M|S''|E|E''|S|',N'ZZZBBBZZZ,AAAYYYAAA,CCCCCCCCC,XXXXXXXXX,YZYYZYYZY,BABBABBAB')
insert into @p3 values(N'1',N'23',N'|U2|F2|R2|B2|D2|L2|U2|R2|F2|B2|L2|D2|F2|R2|U2|B2|L2|D2|R2|F2|U2|B2|L2|D2|',NULL,N'YYYBBBBBB,YYYYYYBBB,CCCCCCCCC,XXXXXXXXX,AZZAZZAZZ,AAZAAZAAZ')
insert into @p3 values(N'1',N'23',N'|F|U''|F''|U|R''|R|D|B|D''|B''|L''|L|F|F''|U''|R|U|R''|B''|B|D''|L|L''|D|F''|R''|R|F|U''|U|D|B''|L''|B|L|D''|U|F''|U''|R|F|R''|L|L''|D|D''|B|B''|',N'|F''|U|F|U''|R|R''|D''|B''|D|B|L|L''|F''|F|U|R''|U''|R|B|B''|D|L''|L|D''|F|R|R''|F''|U|U''|D''|B|L|B''|L''|D|U''|F|U|R''|F''|R|L''|L|D''|D|B''|B|',N'ZZZBBBBBB,YYYYYYAAA,CCCCCCCCC,XXXXXXXXX,YZZYZZYZZ,AABAABAAB')
insert into @p3 values(N'1',N'23',N'|E2|S2|M2|S2|M2|E2|S2|M2|E2|M2|E2|S2|',NULL,N'YYYBBBYYY,BBBYYYBBB,CCCCCCCCC,XXXXXXXXX,AZAAZAAZA,ZAZZAZZAZ')
insert into @p3 values(N'3',N'5',N'|F2|B2|F2|B2|',NULL,N'YYYBBBBBB,YYYYYYBBB,CCCCCCCCC,XXXXXXXXX,AZZAZZAZZ,AAZAAZAAZ')
insert into @p3 values(N'18',N'43',N'|U2|D2|',NULL,N'ZZZBBBZZZ,AAAYYYAAA,XXXCCCCCC,CCCXXXXXX,BABYZYYZY,YZYBABBAB')
insert into @p3 values(N'18',N'43',N'|F|B''|',N'|F''|B|',N'ZZZBBBBYB,YBYYYYAAA,XCXXCXXCX,CCCXXXCCC,BAAYZABAA,ZZYZABZZY')
insert into @p3 values(N'18',N'43',N'|R''|R|L''|L|',N'|R|R''|L|L''|',N'ZAZYBYZAZ,ABAZYZABA,XCXXCXYAY,CXCCXCBZB,BZBBZBXCX,YAYYAYCXC')
insert into @p3 values(N'18',N'43',N'|S''|',N'|S|',N'YYYYBYYYY,BBBBYBBBB,XXXCCCXXX,CCCXXXCCC,ZZZAZAZZZ,AAAZAZAAA')

exec RBK.[PatternRelationHierarchiesUpsert] @PatternTypeId=1,@Hierarchies=3,@data=@p3

*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRelationHierarchiesUpsert]
		@PatternTypeId	INT
	,	@data  [RBK].[PatternRelationHierarchyType] READONLY
AS
BEGIN
	SET NOCOUNT ON;
	
PRINT '@PatternTypeId: ' + CAST(@PatternTypeId AS VARCHAR(10));

--SELECT * FROM @data;

	-- Merge Patterns
	MERGE [RBK].[Patterns] AS target  
	USING (SELECT DISTINCT [AFacePatternId], [BFacePatternId],[CFacePatternId], [XFacePatternId], [YFacePatternId], [ZFacePatternId] FROM @data) 
				AS source ([AFacePatternId], [BFacePatternId],[CFacePatternId], [XFacePatternId], [YFacePatternId], [ZFacePatternId])  
		ON (target.[AFacePatternId] = source.[AFacePatternId] 
		AND target.[BFacePatternId] = source.[BFacePatternId] 
		AND target.[CFacePatternId] = source.[CFacePatternId] 
		AND target.[XFacePatternId] = source.[XFacePatternId] 
		AND target.[YFacePatternId] = source.[YFacePatternId] 
		AND target.[ZFacePatternId] = source.[ZFacePatternId])
	WHEN NOT MATCHED THEN  
		INSERT ([AFacePatternId], [BFacePatternId],[CFacePatternId], [XFacePatternId], [YFacePatternId], [ZFacePatternId])  
		VALUES (source.[AFacePatternId],source.[BFacePatternId],source.[CFacePatternId],source.[XFacePatternId],source.[YFacePatternId],source.[ZFacePatternId]);
	
PRINT 'ADDED Patterns: ' + CAST(@@ROWCOUNT AS VARCHAR(10))	

	-- Merge PatternRelations
	MERGE RBK.PatternRelations AS target  
	USING (SELECT d.[ParentPatternId]			AS [PatternId]
				, insertedPattern.[PatternId]	AS [ConnectedPatternId]
				, d.[Relationship]				AS [Relationship]
			FROM @data AS d
				INNER JOIN RBK.Patterns AS insertedPattern 
					on d.[AFacePatternId] = insertedPattern.[AFacePatternId] 
					AND d.[BFacePatternId] = insertedPattern.[BFacePatternId] 
					AND d.[CFacePatternId] = insertedPattern.[CFacePatternId] 
					AND d.[XFacePatternId] = insertedPattern.[XFacePatternId] 
					AND d.[YFacePatternId] = insertedPattern.[YFacePatternId] 
					AND d.[ZFacePatternId] = insertedPattern.[ZFacePatternId])
	AS source ([PatternId], [ConnectedPatternId], [Relationship])  
		ON (target.PatternId = source.[PatternId]
			AND target.ConnectedPatternId = source.[ConnectedPatternId])
	WHEN MATCHED THEN  
		  UPDATE SET [Relationship] = source.[Relationship]
	WHEN NOT MATCHED THEN  
		INSERT ([PatternId], [ConnectedPatternId], [Relationship])  
		VALUES (source.[PatternId], source.[ConnectedPatternId], source.[Relationship]);;

	-- Reverse Merge PatternRelations
	MERGE RBK.PatternRelations AS target  
	USING (SELECT insertedPattern.[PatternId]	AS [PatternId]
				, d.[ParentPatternId]			AS [ConnectedPatternId]
				, d.[ReverseRelationship]		AS [Relationship]
			FROM @data AS d
				INNER JOIN RBK.Patterns AS insertedPattern 
					on d.[AFacePatternId] = insertedPattern.[AFacePatternId] 
					AND d.[BFacePatternId] = insertedPattern.[BFacePatternId] 
					AND d.[CFacePatternId] = insertedPattern.[CFacePatternId] 
					AND d.[XFacePatternId] = insertedPattern.[XFacePatternId] 
					AND d.[YFacePatternId] = insertedPattern.[YFacePatternId] 
					AND d.[ZFacePatternId] = insertedPattern.[ZFacePatternId]
			WHERE  d.[ReverseRelationship] IS NOT NULL)
	AS source ([PatternId], [ConnectedPatternId], [Relationship])  
		ON (target.PatternId = source.[PatternId]
			AND target.ConnectedPatternId = source.[ConnectedPatternId])
	WHEN MATCHED THEN  
		  UPDATE SET [Relationship] = source.[Relationship]
	WHEN NOT MATCHED THEN  
		INSERT ([PatternId], [ConnectedPatternId], [Relationship])  
		VALUES (source.[PatternId], source.[ConnectedPatternId], source.[Relationship]);

PRINT 'ADDED PatternRelations: ' +CAST(@@ROWCOUNT AS VARCHAR(10))

	-- Merge PatternHierarchies
	MERGE RBK.PatternHierarchies AS target  
	USING (SELECT	
						d.[PatternHierarchyHid]		AS [PatternHierarchyHid]																
					,	pr.[PatternRelationId]		AS [PatternRelationId]
					,	@PatternTypeId				AS [PatternTypeId]	
			FROM @data AS d
				INNER JOIN RBK.Patterns AS p
					ON d.[AFacePatternId] = p.[AFacePatternId] 
					AND d.[BFacePatternId] = p.[BFacePatternId] 
					AND d.[CFacePatternId] = p.[CFacePatternId] 
					AND d.[XFacePatternId] = p.[XFacePatternId] 
					AND d.[YFacePatternId] = p.[YFacePatternId] 
					AND d.[ZFacePatternId] = p.[ZFacePatternId]
				INNER JOIN RBK.PatternRelations AS pr
					ON	d.[ParentPatternId] = pr.[PatternId]
					AND p.[PatternId] = pr.[ConnectedPatternId])
			AS source ([PatternHierarchyHid],
						[PatternRelationId],  
						[PatternTypeId])  
			ON (target.[PatternRelationId] = source.[PatternRelationId]
				AND target.[PatternTypeId] = source.[PatternTypeId])
	WHEN NOT MATCHED THEN  
		INSERT ([PatternHierarchyHid], [PatternTypeId], [PatternRelationId])  
		VALUES (source.[PatternHierarchyHid], source.[PatternTypeId], source.[PatternRelationId]);

PRINT 'ADDED PatternHierarchies: ' + CAST(@@ROWCOUNT AS VARCHAR(10))

END