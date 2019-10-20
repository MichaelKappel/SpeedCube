








CREATE VIEW [RBK].[wvw_PatternRelationHierarchyRemainingDetails]
AS
	SELECT  
			  [PatternHierarchyHid]
			, [PatternRelationId]
			, [PatternTypeId]
			, [HierarchyLevel]
			, [PrimaryPatternId]
			, [ConnectedPatternId]
			, [Relationship]
			, [PrimaryAFacePatternId]		AS [PrimaryAFacePatternId] 
			, [PrimaryBFacePatternId] 		AS [PrimaryBFacePatternId] 
			, [PrimaryCFacePatternId] 		AS [PrimaryCFacePatternId] 
			, [PrimaryXFacePatternId] 		AS [PrimaryXFacePatternId] 
			, [PrimaryYFacePatternId] 		AS [PrimaryYFacePatternId] 
			, [PrimaryZFacePatternId]		AS [PrimaryZFacePatternId]
			, [ConnectedAFacePatternId] 	AS [ConnectedAFacePatternId] 
			, [ConnectedBFacePatternId] 	AS [ConnectedBFacePatternId] 
			, [ConnectedCFacePatternId] 	AS [ConnectedCFacePatternId] 
			, [ConnectedXFacePatternId] 	AS [ConnectedXFacePatternId] 
			, [ConnectedYFacePatternId] 	AS [ConnectedYFacePatternId] 
			, [ConnectedZFacePatternId]		AS [ConnectedZFacePatternId]
	FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyDetails] AS prd  WITH (NOLOCK)
	WHERE prd.ConnectedPatternId NOT IN (SELECT prd2.PrimaryPatternId
	FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyDetails] AS prd2  WITH (NOLOCK))