













CREATE VIEW [RBK].[wvw_PatternRelationHierarchyDetails]
AS
SELECT   
		ph.PatternHierarchyHid
		,	ph.PatternRelationId       
		,	ph.PatternTypeId    
		,	ph.HierarchyLevel     
		,	pr.PatternId				AS PrimaryPatternId
		,	pr.ConnectedPatternId
		,	pr.Relationship
		,	[P].[AFacePatternId]		AS [PrimaryAFacePatternId] 
		,	[P].[BFacePatternId] 		AS [PrimaryBFacePatternId] 
		,	[P].[CFacePatternId] 		AS [PrimaryCFacePatternId] 
		,	[P].[XFacePatternId] 		AS [PrimaryXFacePatternId] 
		,	[P].[YFacePatternId] 		AS [PrimaryYFacePatternId] 
		,	[P].[ZFacePatternId]		AS [PrimaryZFacePatternId]
		,	[CP].[AFacePatternId] 		AS [ConnectedAFacePatternId] 
		,	[CP].[BFacePatternId] 		AS [ConnectedBFacePatternId] 
		,	[CP].[CFacePatternId] 		AS [ConnectedCFacePatternId] 
		,	[CP].[XFacePatternId] 		AS [ConnectedXFacePatternId] 
		,	[CP].[YFacePatternId] 		AS [ConnectedYFacePatternId] 
		,	[CP].[ZFacePatternId]		AS [ConnectedZFacePatternId]
FROM     
	RBK.PatternHierarchies AS ph
	INNER JOIN RBK.PatternRelations AS pr  WITH (NOLOCK)
		ON ph.PatternRelationId = pr.PatternRelationId
	INNER JOIN RBK.Patterns AS p  WITH (NOLOCK)
		ON p.PatternId = pr.PatternId
	INNER JOIN RBK.Patterns AS cp  WITH (NOLOCK)
		ON pr.ConnectedPatternId = cp.PatternId