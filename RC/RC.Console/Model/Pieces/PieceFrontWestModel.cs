using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontWestModel : PieceSideModelBase
    {
        public PieceFrontWestModel() : base()
        {
            this.Stickers.Add(this.StickerFrontWestBlue);
            this.Stickers.Add(this.StickerFrontWestRed);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontWest;

        public StickerFrontWestBlueModel StickerFrontWestBlue { get; private set; } = new StickerFrontWestBlueModel();

        public StickerFrontWestRedModel StickerFrontWestRed { get; private set; } = new StickerFrontWestRedModel();
    }

}