using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontSouthEastModel : PieceCornerModelBase
    {
        public PieceFrontSouthEastModel() : base()
        {
            this.Stickers.Add(this.StickerFrontSouthEastBlue);
            this.Stickers.Add(this.StickerFrontSouthEastYellow);
            this.Stickers.Add(this.StickerFrontSouthEastOrange);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontSouthEast;

        public StickerFrontSouthEastBlueModel StickerFrontSouthEastBlue { get; private set; } = new StickerFrontSouthEastBlueModel();

        public StickerFrontSouthEastYellowModel StickerFrontSouthEastYellow { get; private set; } = new StickerFrontSouthEastYellowModel();

        public StickerFrontSouthEastOrangeModel StickerFrontSouthEastOrange { get; private set; } = new StickerFrontSouthEastOrangeModel();
    }
}