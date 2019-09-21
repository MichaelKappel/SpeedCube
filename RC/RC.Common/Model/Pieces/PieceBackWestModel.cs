using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceBackWestModel : PieceSideModelBase       //<PieceBackWestModel>
    {
        public PieceBackWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerBackModel StickerBack { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackWestModel(patternCubeType);

            return copy;
        }
    }


}