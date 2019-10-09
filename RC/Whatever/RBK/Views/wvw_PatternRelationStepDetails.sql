







CREATE VIEW [RBK].[wvw_PatternRelationStepDetails]
AS
SELECT   
		ps.PatternHid
	,	ps.PatternStepId
	,	ps.ParentPatternStepId       
	,	ps.PatternTypeId    
	,	ps.Step     
	,	pr.PatternRelationId
	,	pr.PatternId AS PrimaryPatternId
	,	pr.ConnectedPatternId
	,	pr.Relationship
	,	p.PatternContent AS PrimaryPattern
	,	cp.PatternContent AS ConnectedPattern
FROM     
	RBK.PatternSteps AS ps
	INNER JOIN RBK.PatternRelations AS pr  WITH (NOLOCK)
		ON pr.PatternRelationId = ps.PatternRelationId
	INNER JOIN RBK.Patterns AS p  WITH (NOLOCK)
		ON p.PatternId = pr.PatternId
	INNER JOIN RBK.Patterns AS cp  WITH (NOLOCK)
		ON cp.PatternId = pr.ConnectedPatternId