

-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/23/2019
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC [wsp_PatternsWithoutFaceRecognitionGet] 100
*/
-- =============================================
CREATE PROCEDURE [dbo].[wsp_PatternsWithoutFaceRecognitionGet] 
	@PageSize INT WITH RECOMPILE
AS
BEGIN 
	SET NOCOUNT ON;

	SELECT TOP(@PageSize) 
			p.PatternId,	
			p.PatternContent
	FROM
			dbo.Patterns AS p WITH  (NOLOCK)  
	WHERE 
			p.PatternId NOT IN (SELECT s.PatternId FROM FacePatternRecognitionStates AS s WITH  (NOLOCK))

END