﻿




-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/23/2019
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC [wsp_PatternsWithoutAdjacentRecognitionGet] 100
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternsWithoutAdjacentRecognitionGet]
	@PageSize INT WITH RECOMPILE
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP(@PageSize) 
			p.PatternId,
			p.AFacePatternId,	
			p.BFacePatternId,	
			p.CFacePatternId,	
			p.XFacePatternId,	
			p.YFacePatternId,	
			p.ZFacePatternId
	FROM
			RBK.Patterns AS p WITH  (NOLOCK)  
	WHERE 
			p.PatternId NOT IN (SELECT s.PatternId FROM AdjacentPatternRecognitionStates AS s WITH  (NOLOCK))

END