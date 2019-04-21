using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceFrontWestModel : PieceSideModelBase       //<PieceFrontWestModel>
    {
        public PieceFrontWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontWest;

        public StickerFrontModel StickerFront { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontWestModel(patternCubeType);

            return copy;
        }
    }

}