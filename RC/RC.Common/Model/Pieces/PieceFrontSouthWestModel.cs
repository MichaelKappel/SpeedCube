using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceFrontSouthWestModel : PieceCornerModelBase       //<PieceFrontSouthWestModel>
    {
        public PieceFrontSouthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontSouthWest;

        public StickerFrontModel StickerFront { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontSouthWestModel(patternCubeType);

            return copy;
        }
    }
}