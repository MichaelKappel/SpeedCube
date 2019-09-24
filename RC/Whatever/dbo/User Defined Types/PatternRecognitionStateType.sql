CREATE TYPE [dbo].[PatternRecognitionStateType] AS TABLE (
    [PatternId]     INT      NOT NULL,
    [PatternTypeId] INT      NOT NULL,
    [Color]         CHAR (1) NOT NULL);

