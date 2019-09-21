using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceBackSouthModel : PieceSideModelBase       //<PieceBackSouthModel>
    {
        public PieceBackSouthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerSouth);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackSouth;

        public StickerBackModel StickerBack { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackSouthModel(patternCubeType);

            return copy;
        }
    }

}