using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceBackEastModel : PieceSideModelBase       //<PieceBackEastModel>
    {
        public PieceBackEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackEast;

        public StickerBackModel StickerBack { get; private set; } 
        public StickerEastModel StickerEast { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackEastModel(patternCubeType);

            return copy;
        }

    }

}