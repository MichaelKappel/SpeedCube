





-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/22/2019
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	

*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRecognitionAdjacentInsert]
	@data  RBK.PatternRecognitionStateType READONLY
AS
BEGIN
	SET NOCOUNT ON;
	
		INSERT INTO AdjacentPatternRecognitionStates ([PatternId], [PatternAdjacentTypeId], [Color])
		SELECT [PatternId], [PatternTypeId], [Color] FROM @data
	
END