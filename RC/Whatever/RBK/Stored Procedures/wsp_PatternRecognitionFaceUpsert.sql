





-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/21/2019
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	

*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRecognitionFaceUpsert]
	@data  RBK.PatternRecognitionStateType READONLY
AS
BEGIN
	SET NOCOUNT ON;
	

--SELECT * FROM @data;

	-- Merge Patterns
	MERGE RBK.FacePatternRecognitionStates AS target  
	USING (SELECT DISTINCT [PatternId], [PatternTypeId], [Color] FROM @data) AS source ([PatternId], [PatternTypeId],  [Color])  
		ON (	
				target.[PatternId]				= source.[PatternId] 
			AND target.[PatternFaceTypeId]	= source.[PatternTypeId]
			AND target.[Color]					=  source.[Color]
			)
	WHEN NOT MATCHED THEN  
		INSERT ([PatternId], [PatternFaceTypeId], [Color])  
		VALUES (source.[PatternId], source.[PatternTypeId], source.[Color]);
	
END