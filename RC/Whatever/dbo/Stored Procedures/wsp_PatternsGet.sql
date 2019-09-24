
-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/21/2019
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC [wsp_PatternsGet] 1000, 1
*/
-- =============================================
CREATE PROCEDURE [dbo].[wsp_PatternsGet]
	@PageSize INT,
	@PageNumber INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	p.PatternId,	
			p.PatternContent
	FROM
			dbo.Patterns AS p
	WHERE 
			p.PatternId NOT IN (SELECT PatternId FROM AdjacentPatternRecognitionStates)
		AND p.PatternId NOT IN (SELECT PatternId FROM FacePatternRecognitionStates)
	ORDER BY 
			p.PatternId
    OFFSET
			@PageSize * (@PageNumber - 1) ROWS
    FETCH NEXT 
			@PageSize ROWS ONLY OPTION (RECOMPILE);

END