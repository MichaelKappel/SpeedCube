

-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/6/2018
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC [RBK].[wsp_FacePatternGet] 'BBBBBBBBB'
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_FacePatternGet]
	@PatternFaceContent CHAR(8)
AS
BEGIN
	SET NOCOUNT ON;

	SET @PatternFaceContent = REPLACE(@PatternFaceContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'a', 'Z');
	
	SET @PatternFaceContent = REPLACE(@PatternFaceContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'b', 'Y');
	
	SET @PatternFaceContent = REPLACE(@PatternFaceContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'c', 'X');

	SELECT TOP 1 pf.FacePatternId
			,	pf.FacePatternContent
	FROM RBK.FacePatterns AS pf
	WHERE pf.FacePatternContent = @PatternFaceContent;

	PRINT '@PatternFaceContent:' + @PatternFaceContent

END