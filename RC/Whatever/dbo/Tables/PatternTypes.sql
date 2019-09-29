CREATE TABLE [dbo].[PatternTypes] (
    [PatternTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [PatternTypeName] NVARCHAR (500) NOT NULL,
    [PatternId]       INT            NOT NULL,
    CONSTRAINT [PK_PatternTypes] PRIMARY KEY CLUSTERED ([PatternTypeId] ASC) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON),
    CONSTRAINT [FK_PatternTypes_Patterns] FOREIGN KEY ([PatternId]) REFERENCES [dbo].[Patterns] ([PatternId])
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_PatternId]
    ON [dbo].[PatternTypes]([PatternId] ASC);

