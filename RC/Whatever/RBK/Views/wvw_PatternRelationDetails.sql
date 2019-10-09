




CREATE VIEW [RBK].[wvw_PatternRelationDetails]
AS
SELECT        
	pr.PatternRelationId
	,pr.PatternId AS PrimaryPatternId
	,pr.ConnectedPatternId
	,pr.Relationship
	,p.PatternContent AS PrimaryPattern
	,cp.PatternContent AS ConnectedPattern
FROM           
	RBK.PatternRelations AS pr  WITH (NOLOCK)
	INNER JOIN RBK.Patterns AS p  WITH (NOLOCK)
		ON p.PatternId = pr.PatternId
	INNER JOIN RBK.Patterns AS cp  WITH (NOLOCK)
		ON cp.PatternId = pr.ConnectedPatternId