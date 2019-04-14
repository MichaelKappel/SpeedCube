using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontEastModel : PieceSideModelBase
    {
        public PieceFrontEastModel() : base()
        {
            this.Stickers.Add(this.StickerFrontEastBlue);
            this.Stickers.Add(this.StickerFrontEastOrange);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontEast;

        public StickerFrontEastBlueModel StickerFrontEastBlue { get; private set; } = new StickerFrontEastBlueModel();
        public StickerFrontEastOrangeModel StickerFrontEastOrange { get; private set; } = new StickerFrontEastOrangeModel();
    }

}