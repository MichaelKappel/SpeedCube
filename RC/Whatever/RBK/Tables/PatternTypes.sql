CREATE TABLE [RBK].[PatternTypes] (
    [PatternTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [PatternTypeName] NVARCHAR (500) NOT NULL,
    [PatternId]       INT            NOT NULL,
    CONSTRAINT [PK_PatternTypes] PRIMARY KEY CLUSTERED ([PatternTypeId] ASC) WITH (FILLFACTOR = 20, STATISTICS_NORECOMPUTE = ON)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PatternId]
    ON [RBK].[PatternTypes]([PatternId] ASC) WITH (FILLFACTOR = 20, STATISTICS_NORECOMPUTE = ON);



