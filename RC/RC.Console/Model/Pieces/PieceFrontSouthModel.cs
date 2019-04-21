using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceFrontSouthModel : PieceSideModelBase       //<PieceFrontSouthModel>
    {
        public PieceFrontSouthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerSouth);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontSouth;

        public StickerFrontModel StickerFront { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontSouthModel(patternCubeType);

            return copy;
        }
    }

}