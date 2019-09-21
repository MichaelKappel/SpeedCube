using RC.Common.Enumerations;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceFrontNorthModel : PieceSideModelBase       //<PieceFrontNorthModel>
    {
        public PieceFrontNorthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerFront = new StickerFrontModel(this.GetFrontStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerFront);
            this.Stickers.Add(this.StickerNorth);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontNorth;

        public  StickerFrontModel StickerFront { get; private set; }

        public StickerNorthModel StickerNorth { get; private set; }

        public override PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceFrontNorthModel(patternCubeType);

            return copy;
        }
    }

}