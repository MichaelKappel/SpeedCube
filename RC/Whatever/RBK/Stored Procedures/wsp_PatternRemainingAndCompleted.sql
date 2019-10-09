


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

	SELECT	steps.Step AS Step
		,	tTotal.[Count] AS [Total]
		,	ISNULL(CAST(tTotal.[Count] AS DECIMAL) - CAST(tRemaining.[Count] AS DECIMAL),tTotal.[Count]) AS [Completed]
		,	ISNULL(100.0 - (CAST(tRemaining.[Count] AS DECIMAL) / CAST(tTotal.[Count] AS DECIMAL) * 100.0), 100.0) AS [% Completed]
		,	ISNULL(tRemaining.[Count], 0)  AS [Remaining]
		,	ISNULL(CAST(tRemaining.[Count] AS DECIMAL) / CAST(tTotal.[Count] AS DECIMAL) * 100.0, 0)  AS [% Remaining]
		 FROM (SELECT DISTINCT ps.[Step] FROM RBK.[PatternSteps] AS ps WITH (NOLOCK)) AS steps
			INNER JOIN (SELECT COUNT(*) AS [Count], prd.Step
						FROM [Whatever].[RBK].[wvw_PatternRelationStepDetails] AS prd WITH (NOLOCK)
						GROUP BY prd.Step) AS tTotal
					ON steps.[Step] = tTotal.[Step]
			LEFT JOIN (SELECT COUNT(*) AS [Count], prd.Step AS [Step] 
							FROM [Whatever].[RBK].[wvw_PatternRelationStepRemainingDetails] AS prd  WITH (NOLOCK)
							GROUP BY prd.Step) AS tRemaining
					ON steps.[Step] = tRemaining.[Step]
	ORDER BY  steps.[Step] ASC


END