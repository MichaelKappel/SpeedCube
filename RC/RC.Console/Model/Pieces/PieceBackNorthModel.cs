using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceBackNorthModel : PieceSideModelBase       //<PieceBackNorthModel>
    {
        public PieceBackNorthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerNorth);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackNorth;

        public StickerBackModel StickerBack { get; private set; }
        public StickerNorthModel StickerNorth { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackNorthModel(patternCubeType);

            return copy;
        }
    }

}