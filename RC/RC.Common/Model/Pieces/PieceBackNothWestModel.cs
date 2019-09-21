using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceBackNorthWestModel : PieceCornerModelBase       //<PieceBackNorthWestModel>
    {
        public PieceBackNorthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackNorthWest;

        public StickerBackModel StickerBack { get; private set; }
        public StickerNorthModel StickerNorth { get; private set; }
        public StickerWestModel StickerWest { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackNorthWestModel(patternCubeType);

            return copy;
        }
    }
}