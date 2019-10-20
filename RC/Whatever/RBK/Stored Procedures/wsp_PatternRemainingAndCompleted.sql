


-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/23/2018
-- Description:	Get pattern remaining / completed for a step
/*
	EXEC [RBK].[wsp_PatternRemainingAndCompleted];
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRemainingAndCompleted] WITH RECOMPILE
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	steps.HierarchyLevel AS HierarchyLevel
		,	tTotal.[Count] AS [Total]
		,	ISNULL(CAST(tTotal.[Count] AS DECIMAL) - CAST(tRemaining.[Count] AS DECIMAL),tTotal.[Count]) AS [Completed]
		,	ISNULL(100.0 - (CAST(tRemaining.[Count] AS DECIMAL) / CAST(tTotal.[Count] AS DECIMAL) * 100.0), 100.0) AS [% Completed]
		,	ISNULL(tRemaining.[Count], 0)  AS [Remaining]
		,	ISNULL(CAST(tRemaining.[Count] AS DECIMAL) / CAST(tTotal.[Count] AS DECIMAL) * 100.0, 0)  AS [% Remaining]
		 FROM (SELECT DISTINCT ph.[HierarchyLevel] FROM RBK.[PatternHierarchies] AS ph WITH (NOLOCK)) AS steps
			INNER JOIN (SELECT COUNT(*) AS [Count], prd.HierarchyLevel
						FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyDetails] AS prd WITH (NOLOCK)
						GROUP BY prd.HierarchyLevel) AS tTotal
					ON steps.[HierarchyLevel] = tTotal.[HierarchyLevel]
			LEFT JOIN (SELECT COUNT(*) AS [Count], prd.HierarchyLevel AS [HierarchyLevel] 
							FROM [Whatever].[RBK].[wvw_PatternRelationHierarchyRemainingDetails] AS prd  WITH (NOLOCK)
							GROUP BY prd.HierarchyLevel) AS tRemaining
					ON steps.[HierarchyLevel] = tRemaining.[HierarchyLevel]
	ORDER BY  steps.[HierarchyLevel] ASC


END