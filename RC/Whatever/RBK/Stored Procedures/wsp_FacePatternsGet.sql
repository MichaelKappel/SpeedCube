

-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/6/2018
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC [RBK].[wsp_FacePatternsGet] 
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_FacePatternsGet]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT pf.FacePatternId
			,	pf.FacePatternContent
	FROM RBK.FacePatterns AS pf
END