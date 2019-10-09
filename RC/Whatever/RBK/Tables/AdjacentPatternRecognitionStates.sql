CREATE TABLE [RBK].[AdjacentPatternRecognitionStates] (
    [AdjacentPatternRecognitionStateId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [PatternId]                         INT      NOT NULL,
    [PatternAdjacentTypeId]             INT      NOT NULL,
    [Color]                             CHAR (1) NOT NULL,
    CONSTRAINT [PK_AdjacentPatternRecognitionStates] PRIMARY KEY CLUSTERED ([AdjacentPatternRecognitionStateId] ASC) WITH (FILLFACTOR = 60, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_AdjacentPatternRecognitionStates_Patterns] FOREIGN KEY ([PatternId]) REFERENCES [RBK].[Patterns] ([PatternId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AdjacentPatternRecognitionStates]
    ON [RBK].[AdjacentPatternRecognitionStates]([PatternId] ASC, [PatternAdjacentTypeId] ASC, [Color] ASC) WITH (FILLFACTOR = 60, STATISTICS_NORECOMPUTE = ON);

