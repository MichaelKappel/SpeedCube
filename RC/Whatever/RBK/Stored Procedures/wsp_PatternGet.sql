
-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/6/2018
-- Description:	Get pattern info based on Pattern Content
/*
	EXAMPLE:
	
	EXEC PatternGet 'BBBBBBBBBbbbbbbbbbCCCCCCCCCcccccccccaaaaaaaaaAAAAAAAAA'
	BBBBBBBBBYYYYYYYYYCCCCCCCCCXXXXXXXXXZZZZZZZZZAAAAAAAAA
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternGet]
	@PatternContent VARCHAR(54)
AS
BEGIN
	SET NOCOUNT ON;

	SET @PatternContent = REPLACE(@PatternContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'a', 'Z');
	
	SET @PatternContent = REPLACE(@PatternContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'b', 'Y');
	
	SET @PatternContent = REPLACE(@PatternContent COLLATE SQL_Latin1_General_CP1_CS_AS, 'c', 'X');

	SELECT TOP 1 PatternId
			,	PatternContent
	FROM Patterns
	WHERE PatternContent = @PatternContent;

	PRINT '@PatternContent:' + @PatternContent

END