using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{
    public class PieceFrontNorthEastModel : PieceCornerModelBase       //<PieceFrontNorthEastModel>
    {
        public PieceFrontNorthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontNorthEast;

        public StickerFrontModel StickerFront { get; private set; }
        public StickerNorthModel StickerNorth { get; private set; }
        public StickerEastModel StickerEast { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontNorthEastModel(patternCubeType);

            return copy;
        }
    }
}