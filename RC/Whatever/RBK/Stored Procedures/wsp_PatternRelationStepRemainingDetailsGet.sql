


-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 6/28/2018
-- Description:	Get pattern remaining / completed for a step
/*
	EXEC [RBK].[wsp_PatternRelationStepRemainingDetailsGet] @Step=7, @MaxRecords=200;

	
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_PatternRelationStepRemainingDetailsGet]
	@Step INT,
	@MaxRecords INT
	WITH RECOMPILE
AS
BEGIN
	SET NOCOUNT ON;
	SET ARITHABORT ON;

	SELECT TOP (@MaxRecords) 
		[vp].[PatternStepId] AS [PatternStepId], 
		[vp].[PatternTypeId] AS [PatternTypeId], 
		[vp].[Step] AS [Step], 
		[vp].[PatternRelationId] AS [PatternRelationId], 
		[vp].[PrimaryPatternId] AS [PrimaryPatternId], 
		[vp].[ConnectedPatternId] AS [ConnectedPatternId], 
		[vp].[Relationship] AS [Relationship], 
		[vp].[PrimaryPattern] AS [PrimaryPattern], 
		[vp].[ConnectedPattern] AS [ConnectedPattern], 
		[vp].[ParentPatternStepId] AS [ParentPatternStepId]
    FROM [RBK].[wvw_PatternRelationStepRemainingDetails] AS [vp]
    WHERE [vp].[Step] = @Step - 1
	
	SET NOCOUNT OFF;
	SET ARITHABORT OFF;
END