CREATE TABLE [RBK].[PatternRelations] (
    [PatternRelationId]  INT            IDENTITY (1, 1) NOT NULL,
    [PatternId]          INT            NOT NULL,
    [ConnectedPatternId] INT            NOT NULL,
    [Relationship]       VARCHAR (1024) NOT NULL,
    CONSTRAINT [PK_PatternRelations] PRIMARY KEY CLUSTERED ([PatternRelationId] ASC) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_PatternRelations_Patterns] FOREIGN KEY ([PatternId]) REFERENCES [RBK].[Patterns] ([PatternId]),
    CONSTRAINT [FK_PatternRelations_Patterns1] FOREIGN KEY ([ConnectedPatternId]) REFERENCES [RBK].[Patterns] ([PatternId])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PatternRelations]
    ON [RBK].[PatternRelations]([PatternId] ASC, [ConnectedPatternId] ASC) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON);

