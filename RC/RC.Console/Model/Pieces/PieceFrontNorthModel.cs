using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontNorthModel : PieceSideModelBase
    {
        public PieceFrontNorthModel() : base()
        {
            this.Stickers.Add(this.StickerFrontNorthBlue);
            this.Stickers.Add(this.StickerFrontNorthWhite);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontNorth;

        public StickerFrontNorthBlueModel StickerFrontNorthBlue { get; private set; } = new StickerFrontNorthBlueModel();

        public StickerFrontNorthWhiteModel StickerFrontNorthWhite { get; private set; } = new StickerFrontNorthWhiteModel();
    }

}