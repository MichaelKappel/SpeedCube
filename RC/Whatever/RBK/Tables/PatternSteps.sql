CREATE TABLE [RBK].[PatternSteps] (
    [PatternStepId]       INT                 IDENTITY (1, 1) NOT NULL,
    [ParentPatternStepId] INT                 NULL,
    [PatternTypeId]       INT                 NOT NULL,
    [PatternRelationId]   INT                 NOT NULL,
    [Step]                INT                 NOT NULL,
    [PatternHid]          [sys].[hierarchyid] NULL,
    CONSTRAINT [PK_PatternSteps] PRIMARY KEY CLUSTERED ([PatternStepId] ASC) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_PatternSteps_PatternSteps] FOREIGN KEY ([ParentPatternStepId]) REFERENCES [RBK].[PatternSteps] ([PatternStepId])
);


GO
CREATE NONCLUSTERED INDEX [IX_PatternSteps_PatternRelationId_Step]
    ON [RBK].[PatternSteps]([PatternRelationId] ASC)
    INCLUDE([Step]) WITH (FILLFACTOR = 40, PAD_INDEX = ON, STATISTICS_NORECOMPUTE = ON);


GO
CREATE NONCLUSTERED INDEX [IX_PatternSteps_ParentPatternStepId]
    ON [RBK].[PatternSteps]([Step] ASC)
    INCLUDE([ParentPatternStepId], [PatternTypeId], [PatternRelationId]) WITH (FILLFACTOR = 40, PAD_INDEX = ON, STATISTICS_NORECOMPUTE = ON);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PatternSteps]
    ON [RBK].[PatternSteps]([PatternTypeId] ASC, [Step] ASC, [PatternRelationId] ASC)
    INCLUDE([ParentPatternStepId]) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON);

