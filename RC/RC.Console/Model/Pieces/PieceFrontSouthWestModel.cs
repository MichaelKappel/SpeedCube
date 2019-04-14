using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontSouthWestModel : PieceCornerModelBase
    {
        public PieceFrontSouthWestModel() : base()
        {
            this.Stickers.Add(this.StickerFrontSouthWestBlue);
            this.Stickers.Add(this.StickerFrontSouthWestYellow);
            this.Stickers.Add(this.StickerFrontSouthWestRed);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontSouthWest;

        public StickerFrontSouthWestBlueModel StickerFrontSouthWestBlue { get; private set; } = new StickerFrontSouthWestBlueModel();

        public StickerFrontSouthWestYellowModel StickerFrontSouthWestYellow { get; private set; } = new StickerFrontSouthWestYellowModel();

        public StickerFrontSouthWestRedModel StickerFrontSouthWestRed { get; private set; } = new StickerFrontSouthWestRedModel();
    }
}