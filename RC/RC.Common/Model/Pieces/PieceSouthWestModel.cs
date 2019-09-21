using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceSouthWestModel : PieceSideModelBase       //<PieceSouthWestModel>
    {
        public PieceSouthWestModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));
            this.StickerWest = new StickerWestModel(this.GetWestStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerSouth);
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.SouthWest;

        public StickerSouthModel StickerSouth { get; private set; }

        public StickerWestModel StickerWest { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceSouthWestModel(patternCubeType);

            return copy;
        }
    }

}