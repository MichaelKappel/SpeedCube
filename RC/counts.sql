
SELECT COUNT(*) FROM Patterns;

EXEC wsp_PatternRemainingAndCompleted;

--EXEC dbo.[wsp_PatternRelationStepRemainingDetailsGet] @Step=6, @MaxRecords=200