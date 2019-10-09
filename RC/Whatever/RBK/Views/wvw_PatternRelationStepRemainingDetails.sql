




CREATE VIEW [RBK].[wvw_PatternRelationStepRemainingDetails]
AS
	SELECT *
	FROM [Whatever].[RBK].[wvw_PatternRelationStepDetails] AS prd  WITH (NOLOCK)
	WHERE prd.ConnectedPatternId NOT IN (SELECT prd2.PrimaryPatternId
	FROM [Whatever].[RBK].[wvw_PatternRelationStepDetails] AS prd2  WITH (NOLOCK))