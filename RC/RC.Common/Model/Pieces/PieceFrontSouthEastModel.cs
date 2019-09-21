using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceFrontSouthEastModel : PieceCornerModelBase       //<PieceFrontSouthEastModel>
    {
        public PieceFrontSouthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontSouthEast;

        public StickerFrontModel StickerFront { get; private set; }

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerEastModel StickerEast { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontSouthEastModel(patternCubeType);

            return copy;
        }
    }
}