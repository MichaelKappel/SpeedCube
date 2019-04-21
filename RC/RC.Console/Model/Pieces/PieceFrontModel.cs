using RC.Enumerations;
using RC.Model.Slots; using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceFrontModel : PieceMiddleModelBase
    {
        public PieceFrontModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.Front;

        public StickerFrontModel StickerFront { get; private set; }

        public SlotFrontNorthModel SlotFrontNorth { get; set; }

        public SlotFrontEastModel SlotFrontEast { get; set; }

        public SlotFrontSouthModel SlotFrontSouth { get; set; }

        public SlotFrontWestModel SlotFrontWest { get; set; }

        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontModel(patternCubeType);

            return copy;
        }
    }

}