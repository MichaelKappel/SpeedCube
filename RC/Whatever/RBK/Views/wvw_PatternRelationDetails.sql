





CREATE VIEW [RBK].[wvw_PatternRelationDetails]
AS
SELECT        
	pr.PatternRelationId
	,pr.PatternId AS PrimaryPatternId
	,pr.ConnectedPatternId
	,pr.Relationship
	,fpa.FacePatternContent + ',' + fpb.FacePatternContent + ',' + fpc.FacePatternContent + ',' + fpx.FacePatternContent + ',' + fpy.FacePatternContent + ',' + fpz.FacePatternContent AS PrimaryPattern
	,cfpa.FacePatternContent + ',' + cfpb.FacePatternContent + ',' + cfpc.FacePatternContent + ',' + cfpx.FacePatternContent + ',' + cfpy.FacePatternContent + ',' + cfpz.FacePatternContent AS ConnectedPattern
FROM	RBK.PatternRelations AS pr  WITH (NOLOCK)
	INNER JOIN RBK.Patterns AS p  WITH (NOLOCK)
		ON pr.PatternId = p.PatternId
	INNER JOIN RBK.Patterns AS cp WITH (NOLOCK)
		ON pr.ConnectedPatternId = cp.PatternId
	INNER JOIN RBK.FacePatterns AS cfpa  WITH (NOLOCK)
		ON cp.AFacePatternId = cfpa.FacePatternId
	INNER JOIN RBK.FacePatterns AS cfpb  WITH (NOLOCK)
		ON cp.BFacePatternId = cfpb.FacePatternId
	INNER JOIN RBK.FacePatterns AS cfpc  WITH (NOLOCK)
		ON cp.CFacePatternId = cfpc.FacePatternId
	INNER JOIN RBK.FacePatterns AS cfpx  WITH (NOLOCK)
		ON cp.XFacePatternId = cfpx.FacePatternId
	INNER JOIN RBK.FacePatterns AS cfpy  WITH (NOLOCK)
		ON cp.YFacePatternId = cfpy.FacePatternId
	INNER JOIN RBK.FacePatterns AS cfpz  WITH (NOLOCK)
		ON cp.ZFacePatternId = cfpz.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpa  WITH (NOLOCK)
		ON p.AFacePatternId = fpa.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpb  WITH (NOLOCK)
		ON p.BFacePatternId = fpb.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpc  WITH (NOLOCK)
		ON p.CFacePatternId = fpc.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpx  WITH (NOLOCK)
		ON p.XFacePatternId = fpx.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpy  WITH (NOLOCK)
		ON p.YFacePatternId = fpy.FacePatternId
	INNER JOIN RBK.FacePatterns AS fpz  WITH (NOLOCK)
		ON p.ZFacePatternId = fpz.FacePatternId