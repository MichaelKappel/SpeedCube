CREATE TABLE [RBK].[FacePatternRecognitionStates] (
    [FacePatternRecognitionStateId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [PatternId]                     INT      NOT NULL,
    [PatternFaceTypeId]             INT      NOT NULL,
    [Color]                         CHAR (1) NOT NULL,
    CONSTRAINT [PK_FacePatternRecognitionStates] PRIMARY KEY CLUSTERED ([FacePatternRecognitionStateId] ASC) WITH (FILLFACTOR = 60, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_FacePatternRecognitionStates_Patterns] FOREIGN KEY ([PatternId]) REFERENCES [RBK].[Patterns] ([PatternId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_FacePatternRecognitionStates]
    ON [RBK].[FacePatternRecognitionStates]([PatternId] ASC, [PatternFaceTypeId] ASC, [Color] ASC) WITH (FILLFACTOR = 60, STATISTICS_NORECOMPUTE = ON);

