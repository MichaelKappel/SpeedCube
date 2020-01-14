










CREATE VIEW [RBK].[wvw_PatternRelationHierarchyRemainingDetails]
AS
	SELECT  
			  prd.[PatternHierarchyHid]
			, prd.[PatternRelationId]
			, prd.[PatternTypeId]
			, prd.[HierarchyLevel]
			, prd.[PrimaryPatternId]
			, prd.[ConnectedPatternId]
			, prd.[Relationship]
			, prd.[PrimaryAFacePatternId]		AS [PrimaryAFacePatternId] 
			, prd.[PrimaryBFacePatternId] 		AS [PrimaryBFacePatternId] 
			, prd.[PrimaryCFacePatternId] 		AS [PrimaryCFacePatternId] 
			, prd.[PrimaryXFacePatternId] 		AS [PrimaryXFacePatternId] 
			, prd.[PrimaryYFacePatternId] 		AS [PrimaryYFacePatternId] 
			, prd.[PrimaryZFacePatternId]		AS [PrimaryZFacePatternId]
			, prd.[ConnectedAFacePatternId] 	AS [ConnectedAFacePatternId] 
			, prd.[ConnectedBFacePatternId] 	AS [ConnectedBFacePatternId] 
			, prd.[ConnectedCFacePatternId] 	AS [ConnectedCFacePatternId] 
			, prd.[ConnectedXFacePatternId] 	AS [ConnectedXFacePatternId] 
			, prd.[ConnectedYFacePatternId] 	AS [ConnectedYFacePatternId] 
			, prd.[ConnectedZFacePatternId]		AS [ConnectedZFacePatternId]
	FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyDetails] AS prd  WITH (NOLOCK)
	WHERE prd.ConnectedPatternId NOT IN (SELECT prd2.PrimaryPatternId
	FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyDetails] AS prd2  WITH (NOLOCK))