CREATE TABLE [RBK].[PatternHierarchies] (
    [PatternHierarchyHid] [sys].[hierarchyid] NOT NULL,
    [PatternRelationId]   INT                 NOT NULL,
    [PatternTypeId]       INT                 NOT NULL,
    [HierarchyLevel]      AS                  ([PatternHierarchyHid].[GetLevel]()) PERSISTED,
    CONSTRAINT [PK_PatternHierarchies] PRIMARY KEY NONCLUSTERED ([PatternHierarchyHid] ASC) WITH (FILLFACTOR = 20, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_PatternHierarchies_PatternRelations] FOREIGN KEY ([PatternRelationId]) REFERENCES [RBK].[PatternRelations] ([PatternRelationId]),
    CONSTRAINT [FK_PatternHierarchies_PatternTypes] FOREIGN KEY ([PatternTypeId]) REFERENCES [RBK].[PatternTypes] ([PatternTypeId])
);


GO
CREATE UNIQUE CLUSTERED INDEX [IX_PatternHierarchies]
    ON [RBK].[PatternHierarchies]([PatternTypeId] ASC, [HierarchyLevel] ASC, [PatternRelationId] ASC) WITH (FILLFACTOR = 20, STATISTICS_NORECOMPUTE = ON);

