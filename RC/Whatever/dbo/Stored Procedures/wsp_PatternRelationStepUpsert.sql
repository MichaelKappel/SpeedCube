

-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/23/2018
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
declare @p3 dbo.PrimaryPatternIdRelationToConnectedPatternType

insert into @p3 values(N'1',N'23',N'|E|S|E''|S''|M''|M|S''|S|M|E''|M''|E|E|S''|M''|S|M|E''|M|M''|S|E''|E|S''|',N'|E''|S''|E|S|M|M''|S|S''|M''|E|M|E''|E''|S|M|S''|M''|E|M''|M|S''|E|E''|S|',N'ZZZBBBZZZ,AAAYYYAAA,CCCCCCCCC,XXXXXXXXX,YZYYZYYZY,BABBABBAB')
insert into @p3 values(N'1',N'23',N'|U2|F2|R2|B2|D2|L2|U2|R2|F2|B2|L2|D2|F2|R2|U2|B2|L2|D2|R2|F2|U2|B2|L2|D2|',NULL,N'YYYBBBBBB,YYYYYYBBB,CCCCCCCCC,XXXXXXXXX,AZZAZZAZZ,AAZAAZAAZ')
insert into @p3 values(N'1',N'23',N'|F|U''|F''|U|R''|R|D|B|D''|B''|L''|L|F|F''|U''|R|U|R''|B''|B|D''|L|L''|D|F''|R''|R|F|U''|U|D|B''|L''|B|L|D''|U|F''|U''|R|F|R''|L|L''|D|D''|B|B''|',N'|F''|U|F|U''|R|R''|D''|B''|D|B|L|L''|F''|F|U|R''|U''|R|B|B''|D|L''|L|D''|F|R|R''|F''|U|U''|D''|B|L|B''|L''|D|U''|F|U|R''|F''|R|L''|L|D''|D|B''|B|',N'ZZZBBBBBB,YYYYYYAAA,CCCCCCCCC,XXXXXXXXX,YZZYZZYZZ,AABAABAAB')
insert into @p3 values(N'1',N'23',N'|E2|S2|M2|S2|M2|E2|S2|M2|E2|M2|E2|S2|',NULL,N'YYYBBBYYY,BBBYYYBBB,CCCCCCCCC,XXXXXXXXX,AZAAZAAZA,ZAZZAZZAZ')
insert into @p3 values(N'3',N'5',N'|F2|B2|F2|B2|',NULL,N'YYYBBBBBB,YYYYYYBBB,CCCCCCCCC,XXXXXXXXX,AZZAZZAZZ,AAZAAZAAZ')
insert into @p3 values(N'18',N'43',N'|U2|D2|',NULL,N'ZZZBBBZZZ,AAAYYYAAA,XXXCCCCCC,CCCXXXXXX,BABYZYYZY,YZYBABBAB')
insert into @p3 values(N'18',N'43',N'|F|B''|',N'|F''|B|',N'ZZZBBBBYB,YBYYYYAAA,XCXXCXXCX,CCCXXXCCC,BAAYZABAA,ZZYZABZZY')
insert into @p3 values(N'18',N'43',N'|R''|R|L''|L|',N'|R|R''|L|L''|',N'ZAZYBYZAZ,ABAZYZABA,XCXXCXYAY,CXCCXCBZB,BZBBZBXCX,YAYYAYCXC')
insert into @p3 values(N'18',N'43',N'|S''|',N'|S|',N'YYYYBYYYY,BBBBYBBBB,XXXCCCXXX,CCCXXXCCC,ZZZAZAZZZ,AAAZAZAAA')

exec dbo.[PatternRelationStepUpsert] @PatternTypeId=1,@Step=3,@data=@p3

*/
-- =============================================
CREATE PROCEDURE [dbo].[wsp_PatternRelationStepUpsert]
		@PatternTypeId	INT
	,	@Step			INT
	,	@data  dbo.PrimaryPatternIdRelationToConnectedPatternType READONLY
AS
BEGIN
	SET NOCOUNT ON;
	
PRINT '@PatternTypeId: ' + CAST(@PatternTypeId AS VARCHAR(10))	
PRINT '@Step: ' + CAST(@Step AS VARCHAR(10))	

--SELECT * FROM @data;

	-- Merge Patterns
	MERGE dbo.Patterns AS target  
	USING (SELECT DISTINCT [ConnectedPattern] FROM @data) AS source ([ConnectedPattern])  
		ON (target.PatternContent = source.[ConnectedPattern])  
	WHEN NOT MATCHED THEN  
		INSERT ([PatternContent])  
		VALUES (source.[ConnectedPattern]);
	
PRINT 'ADDED Patterns: ' + CAST(@@ROWCOUNT AS VARCHAR(10))	

	-- Merge PatternRelations
	MERGE dbo.PatternRelations AS target  
	USING (SELECT d.[ParentPatternId]			AS [PatternId]
				, insertedPattern.[PatternId]	AS [ConnectedPatternId]
				, d.[Relationship]				AS [Relationship]
			FROM @data AS d
				INNER JOIN dbo.Patterns AS insertedPattern 
					on d.[ConnectedPattern] = insertedPattern.[PatternContent])
	AS source ([PatternId], [ConnectedPatternId], [Relationship])  
		ON (target.PatternId = source.[PatternId]
			AND target.ConnectedPatternId = source.[ConnectedPatternId])
	WHEN NOT MATCHED THEN  
		INSERT ([PatternId], [ConnectedPatternId], [Relationship])  
		VALUES (source.[PatternId], source.[ConnectedPatternId], source.[Relationship]);

	-- Reverse Merge PatternRelations
	MERGE dbo.PatternRelations AS target  
	USING (SELECT insertedPattern.[PatternId]	AS [PatternId]
				, d.[ParentPatternId]			AS [ConnectedPatternId]
				, d.[ReverseRelationship]		AS [Relationship]
			FROM @data AS d
				INNER JOIN dbo.Patterns AS insertedPattern 
					on d.[ConnectedPattern] = insertedPattern.[PatternContent]
			WHERE  d.[ReverseRelationship] IS NOT NULL)
	AS source ([PatternId], [ConnectedPatternId], [Relationship])  
		ON (target.PatternId = source.[PatternId]
			AND target.ConnectedPatternId = source.[ConnectedPatternId])
	WHEN NOT MATCHED THEN  
		INSERT ([PatternId], [ConnectedPatternId], [Relationship])  
		VALUES (source.[PatternId], source.[ConnectedPatternId], source.[Relationship]);

PRINT 'ADDED PatternRelations: ' +CAST(@@ROWCOUNT AS VARCHAR(10))

	-- Merge PatternSteps
	MERGE dbo.PatternSteps AS target  
	USING (SELECT		pr.[PatternRelationId]																AS [PatternRelationId]
					,	CASE WHEN d.[ParentPatternStepId] = 0 THEN NULL ELSE d.[ParentPatternStepId] END	AS [ParentPatternStepId]
					,	@PatternTypeId																		AS [PatternTypeId]	
					,	@Step																				AS [Step]
			FROM @data AS d
				INNER JOIN dbo.Patterns AS p
					ON d.[ConnectedPattern] = p.[PatternContent]
				INNER JOIN dbo.PatternRelations AS pr
					ON	d.[ParentPatternId] = pr.[PatternId]
					AND p.[PatternId] = pr.[ConnectedPatternId])
			AS source (	[PatternRelationId], 
						[ParentPatternStepId], 
						[PatternTypeId], 
						[Step])  
			ON (target.[PatternRelationId] = source.[PatternRelationId]
				AND target.[PatternTypeId] = source.[PatternTypeId])
	WHEN NOT MATCHED THEN  
		INSERT ([ParentPatternStepId], [PatternTypeId], [PatternRelationId], [Step])  
		VALUES (source.[ParentPatternStepId], source.[PatternTypeId], source.[PatternRelationId], source.[Step]);

PRINT 'ADDED PatternSteps: ' + CAST(@@ROWCOUNT AS VARCHAR(10))

END