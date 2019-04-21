using RC.Enumerations;
using RC.Model.Slots; using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceWestModel : PieceMiddleModelBase
    {
        public PieceWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerWest);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.West;

        public StickerWestModel StickerWest { get; private set; }


        public SlotNorthWestModel SlotNorthWest { get; set; }

        public SlotFrontWestModel SlotFrontWest { get; set; }

        public SlotSouthWestModel SlotSouthWest { get; set; }

        public SlotBackWestModel SlotBackWest { get; set; }

        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceWestModel(patternCubeType);

            return copy;
        }
    }

}