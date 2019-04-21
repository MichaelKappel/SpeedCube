using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceNorthEastModel : PieceSideModelBase
    {
        public PieceNorthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.NorthEast;

        public StickerNorthModel StickerNorth { get; private set; }

        public StickerEastModel StickerEast { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceNorthEastModel(patternCubeType);

            return copy;
        }
    }

}