





CREATE VIEW [dbo].[wvw_PatternRelationStepDetails]
AS
SELECT   
		ps.PatternStepId
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
	dbo.PatternSteps AS ps
	INNER JOIN dbo.PatternRelations AS pr  WITH (NOLOCK)
		ON pr.PatternRelationId = ps.PatternRelationId
	INNER JOIN dbo.Patterns AS p  WITH (NOLOCK)
		ON p.PatternId = pr.PatternId
	INNER JOIN dbo.Patterns AS cp  WITH (NOLOCK)
		ON cp.PatternId = pr.ConnectedPatternId