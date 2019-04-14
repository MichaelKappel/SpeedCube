using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontSouthModel : PieceSideModelBase
    {
        public PieceFrontSouthModel() : base()
        {
            this.Stickers.Add(this.StickerFrontSouthBlue);
            this.Stickers.Add(this.StickerFrontSouthYellow);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.FrontSouth;

        public StickerFrontSouthBlueModel StickerFrontSouthBlue { get; private set; } = new StickerFrontSouthBlueModel();

        public StickerFrontSouthYellowModel StickerFrontSouthYellow { get; private set; } = new StickerFrontSouthYellowModel();
    }

}