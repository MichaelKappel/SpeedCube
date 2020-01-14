

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
 @AFacePatternId AS INT,
 @BFacePatternId AS INT,
 @CFacePatternId AS INT,
 @XFacePatternId AS INT,
 @YFacePatternId AS INT,
 @ZFacePatternId AS INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1 
			[p].[PatternId]
		,	[p].[AFacePatternId]
		,	[p].[BFacePatternId]
		,	[p].[CFacePatternId]
		,	[p].[XFacePatternId]
		,	[p].[YFacePatternId]
		,	[p].[ZFacePatternId]
	FROM Patterns AS [p]
	WHERE	[AFacePatternId] = @AFacePatternId
		AND [BFacePatternId] = @BFacePatternId
		AND [CFacePatternId] = @CFacePatternId
		AND [XFacePatternId] = @XFacePatternId
		AND [YFacePatternId] = @YFacePatternId
		AND [ZFacePatternId] = @ZFacePatternId


END