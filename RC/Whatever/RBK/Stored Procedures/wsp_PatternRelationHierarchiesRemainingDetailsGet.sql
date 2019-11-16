








-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/28/2018
-- Description:	Get pattern remaining / completed for a step
/*
	EXEC [RBK].[wsp_PatternRelationHierarchiesRemainingDetailsGet] @HierarchyLevel=7, @MaxRecords=200;

	
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRelationHierarchiesRemainingDetailsGet]
	@HierarchyLevel INT,
	@MaxRecords INT
	WITH RECOMPILE
AS
BEGIN
	SET NOCOUNT ON;
	SET ARITHABORT ON;

		--DECLARE @PatternRelationHierarchyRemainingDetails TABLE (
		--		[PatternHierarchyHid]		HIERARCHYID
		--	,	[PatternTypeId]				INT
		--	,	[HierarchyLevel]			SMALLINT
		--	,	[PatternRelationId]			INT
		--	,	[PrimaryPatternId]			INT
		--	,	[ConnectedPatternId]		INT
		--	,	[Relationship]				varchar(1024)
		--	,	[PrimaryAFacePatternId]		INT
		--	,	[PrimaryBFacePatternId] 	INT
		--	,	[PrimaryCFacePatternId] 	INT
		--	,	[PrimaryXFacePatternId] 	INT
		--	,	[PrimaryYFacePatternId] 	INT
		--	,	[PrimaryZFacePatternId]		INT
		--	,	[ConnectedAFacePatternId] 	INT
		--	,	[ConnectedBFacePatternId] 	INT
		--	,	[ConnectedCFacePatternId] 	INT
		--	,	[ConnectedXFacePatternId] 	INT
		--	,	[ConnectedYFacePatternId] 	INT
		--	,	[ConnectedZFacePatternId]	INT
		--	,	[RandomGuid]				UNIQUEIDENTIFIER
		--);

		--INSERT INTO @PatternRelationHierarchyRemainingDetails
		SELECT TOP (@MaxRecords) --(@MaxRecords * 20)
				[vp].[PatternHierarchyHid]			AS [PatternHierarchyHid]
			,	[vp].[PatternTypeId]				AS [PatternTypeId]
			,	[vp].[HierarchyLevel]				AS [HierarchyLevel]
			,	[vp].[PatternRelationId]			AS [PatternRelationId]
			,	[vp].[PrimaryPatternId]				AS [PrimaryPatternId]
			,	[vp].[ConnectedPatternId]			AS [ConnectedPatternId]
			,	[vp].[Relationship]					AS [Relationship] 
			,	[vp].[PrimaryAFacePatternId]		AS [PrimaryAFacePatternId] 
			,	[vp].[PrimaryBFacePatternId] 		AS [PrimaryBFacePatternId] 
			,	[vp].[PrimaryCFacePatternId] 		AS [PrimaryCFacePatternId] 
			,	[vp].[PrimaryXFacePatternId] 		AS [PrimaryXFacePatternId] 
			,	[vp].[PrimaryYFacePatternId] 		AS [PrimaryYFacePatternId] 
			,	[vp].[PrimaryZFacePatternId]		AS [PrimaryZFacePatternId]
			,	[vp].[ConnectedAFacePatternId]		AS [ConnectedAFacePatternId] 
			,	[vp].[ConnectedBFacePatternId]		AS [ConnectedBFacePatternId] 
			,	[vp].[ConnectedCFacePatternId]		AS [ConnectedCFacePatternId] 
			,	[vp].[ConnectedXFacePatternId]		AS [ConnectedXFacePatternId] 
			,	[vp].[ConnectedYFacePatternId]		AS [ConnectedYFacePatternId] 
			,	[vp].[ConnectedZFacePatternId]		AS [ConnectedZFacePatternId]
			--,	NEWID()								AS [RandomGuid]
		FROM [RBK].[wvw_PatternRelationHierarchyRemainingDetails] AS [vp]  WITH (NOLOCK)
		WHERE [vp].[HierarchyLevel] = @HierarchyLevel;


		--SELECT TOP (@MaxRecords) * FROM @PatternRelationHierarchyRemainingDetails
		--ORDER BY [RandomGuid] ASC;
	
	SET NOCOUNT OFF;
	SET ARITHABORT OFF;
END