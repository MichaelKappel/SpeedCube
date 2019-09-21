using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceBackSouthEastModel : PieceCornerModelBase       //<PieceBackSouthEastModel>
    {
        public PieceBackSouthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackSouthEast;

        public StickerBackModel StickerBack { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerEastModel StickerEast { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackSouthEastModel(patternCubeType);

            return copy;
        }
    }
}