CREATE TABLE [dbo].[PatternTypes] (
    [PatternTypeId]   INT            IDENTITY (1, 1) NOT NULL,
    [PatternTypeName] NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_PatternTypes] PRIMARY KEY CLUSTERED ([PatternTypeId] ASC) WITH (FILLFACTOR = 40, STATISTICS_NORECOMPUTE = ON)
);

