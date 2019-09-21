using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceNorthWestModel : PieceSideModelBase       //<PieceNorthWestModel>
    {
        public PieceNorthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.NorthWest;

        public StickerNorthModel StickerNorth { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceNorthWestModel(patternCubeType);

            return copy;
        }
    }

}