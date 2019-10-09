

-- =============================================
-- Author:		Michael Kappel, MCTS
-- Create date: 9/21/2019
-- Description:	Get solution for pattern
/*
	EXAMPLE:
	
	EXEC RBK.[wsp_SolutionGet] @UnsolvedPattern='AAAXBXXBX,ZCCZYYZCC,YXYCCCCAA,BBBYXYXZZ,CAAZZBBBB,ZZXYAAYXY', @SolvedPattern = 'BBBBBBBBB,YYYYYYYYY,CCCCCCCCC,XXXXXXXXX,ZZZZZZZZZ,AAAAAAAAA'
*/
-- =============================================
CREATE PROCEDURE [RBK].[wsp_SolutionGet]
	@UnsolvedPattern	VARCHAR(59),
	@SolvedPattern	VARCHAR(59)
AS
BEGIN
	SET NOCOUNT ON;

	if (@UnsolvedPattern = @SolvedPattern)
		BEGIN
			SELECT 
				0					AS	Step
			  ,	''					AS	Relationship
			  ,	@UnsolvedPattern	AS	PrimaryPattern
			  ,	@SolvedPattern		AS	ConnectedPattern
			
		END
	ELSE
		BEGIN

			DECLARE @patternTypeId AS INT;
			DECLARE @UnsolvedPatternStepId AS INT;

			SELECT	TOP 1
					@patternTypeId = pt.PatternTypeId
				FROM 
					RBK.PatternTypes AS pt
						INNER JOIN RBK.wvw_PatternRelationStepDetails AS prd
							ON pt.PatternId = prd.PrimaryPatternId
				WHERE	
					prd.PrimaryPattern = @SolvedPattern;

			SELECT	TOP 1
					@UnsolvedPatternStepId = prd.PatternStepId
				FROM 
					RBK.wvw_PatternRelationStepDetails AS prd
				WHERE	
						prd.ConnectedPattern = @UnsolvedPattern
					AND	prd.PatternTypeId = @PatternTypeId
				ORDER BY
					Step ASC;

			WITH Step_CTE AS (
				SELECT	TOP 1
						ps.ParentPatternStepId
					,	ps.PatternRelationId
					,	ps.PatternStepId
					,	ps.Step
				FROM 
						RBK.PatternSteps AS ps
				WHERE	
						ps.PatternStepId = @UnsolvedPatternStepId
		
				UNION ALL
		
				SELECT
						ps2.ParentPatternStepId
					,	ps2.PatternRelationId
					,	ps2.PatternStepId
					,	ps2.Step
				FROM
						RBK.PatternSteps AS ps2
						INNER JOIN Step_CTE AS s
							ON ps2.PatternStepId = s.ParentPatternStepId
			)

			SELECT 
				prsd.Step
			  , prsd.Relationship
			  , prsd.PrimaryPattern
			  , prsd.ConnectedPattern
			FROM
				RBK.wvw_PatternRelationStepDetails AS prsd
				INNER JOIN Step_CTE AS s
					ON prsd.PatternStepId = s.PatternStepId
	END
END