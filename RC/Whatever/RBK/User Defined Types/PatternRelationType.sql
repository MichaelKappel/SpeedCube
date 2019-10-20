CREATE TYPE [RBK].[PatternRelationType] AS TABLE (
    [ParentPatternId]     INT            NULL,
    [ParentPatternStepId] INT            NULL,
    [Relationship]        VARCHAR (1024) NULL,
    [ReverseRelationship] VARCHAR (1024) NULL,
    [ConnectedPattern]    VARCHAR (59)   NULL);

