using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceSouthEastModel : PieceSideModelBase       //<PieceSouthEastModel>
    {
        public PieceSouthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.SouthEast;

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerEastModel StickerEast { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceSouthEastModel(patternCubeType);

            return copy;
        }
    }

}