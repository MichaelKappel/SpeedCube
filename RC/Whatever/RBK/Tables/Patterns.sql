CREATE TABLE [RBK].[Patterns] (
    [PatternId]      INT IDENTITY (1, 1) NOT NULL,
    [AFacePatternId] INT NOT NULL,
    [BFacePatternId] INT NOT NULL,
    [CFacePatternId] INT NOT NULL,
    [XFacePatternId] INT NOT NULL,
    [YFacePatternId] INT NOT NULL,
    [ZFacePatternId] INT NOT NULL,
    CONSTRAINT [PK_Patterns] PRIMARY KEY CLUSTERED ([PatternId] ASC) WITH (FILLFACTOR = 30, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_Patterns_FacePatterns_A] FOREIGN KEY ([AFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId]),
    CONSTRAINT [FK_Patterns_FacePatterns_B] FOREIGN KEY ([BFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId]),
    CONSTRAINT [FK_Patterns_FacePatterns_C] FOREIGN KEY ([CFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId]),
    CONSTRAINT [FK_Patterns_FacePatterns_X] FOREIGN KEY ([XFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId]),
    CONSTRAINT [FK_Patterns_FacePatterns_Y] FOREIGN KEY ([YFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId]),
    CONSTRAINT [FK_Patterns_FacePatterns_Z] FOREIGN KEY ([ZFacePatternId]) REFERENCES [RBK].[FacePatterns] ([FacePatternId])
);






GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Patterns]
    ON [RBK].[Patterns]([AFacePatternId] ASC, [BFacePatternId] ASC, [CFacePatternId] ASC, [XFacePatternId] ASC, [YFacePatternId] ASC, [ZFacePatternId] ASC) WITH (FILLFACTOR = 30, STATISTICS_NORECOMPUTE = ON);





