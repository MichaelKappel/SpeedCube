using RC.Common.Enumerations;
using RC.Common.Model.Slots;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceBackModel : PieceMiddleModelBase
    {
        public PieceBackModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.Stickers.Add(this.StickerBack);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.Back;

        public StickerBackModel StickerBack { get; private set; } 


        public SlotBackNorthModel SlotBackNorth { get; set; }

        public SlotBackEastModel SlotBackEast { get; set; }

        public SlotBackSouthModel SlotBackSouth { get; set; }

        public SlotBackWestModel SlotBackWest { get; set; }

        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackModel(patternCubeType);

            return copy;
        }
    }

}