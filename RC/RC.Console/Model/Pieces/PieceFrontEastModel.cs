using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontEastModel : PieceSideModelBase       //<PieceFrontEastModel>
    {
        public PieceFrontEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontEast;

        public StickerFrontModel StickerFront { get; private set; }
        public StickerEastModel StickerEast { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontEastModel(patternCubeType);

            return copy;
        }
    }

}