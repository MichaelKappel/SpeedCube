CREATE TYPE [RBK].[PatternRelationHierarchyType] AS TABLE (
    [PatternHierarchyHid] [sys].[hierarchyid] NULL,
    [ParentPatternId]     INT                 NULL,
    [Relationship]        VARCHAR (1024)      NULL,
    [ReverseRelationship] VARCHAR (1024)      NULL,
    [AFacePatternId]      INT                 NULL,
    [BFacePatternId]      INT                 NULL,
    [CFacePatternId]      INT                 NULL,
    [XFacePatternId]      INT                 NULL,
    [YFacePatternId]      INT                 NULL,
    [ZFacePatternId]      INT                 NULL);

