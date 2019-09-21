using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceFrontNorthWestModel : PieceCornerModelBase       //<PieceFrontNorthWestModel>
    {
        public PieceFrontNorthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontNorthWest;

        public StickerFrontModel StickerFront { get; private set; }

        public StickerNorthModel StickerNorth { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontNorthWestModel(patternCubeType);

            return copy;
        }
    }
}