using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceBackSouthWestModel : PieceCornerModelBase       //<PieceBackSouthWestModel>
    {
        public PieceBackSouthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackSouthWest;

        public StickerBackModel StickerBack { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackSouthWestModel(patternCubeType);

            return copy;
        }
    }
}