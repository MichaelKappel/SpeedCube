using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{
    public class PieceFrontNorthEastModel : PieceCornerModelBase
    {
        public PieceFrontNorthEastModel() : base()
        {
            this.Stickers.Add(this.StickerFrontNorthEastBlue);
            this.Stickers.Add(this.StickerFrontNorthEastWhite);
            this.Stickers.Add(this.StickerFrontNorthEastOrange);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontNorthEast;

        public StickerFrontNorthEastBlueModel StickerFrontNorthEastBlue { get; private set; } = new StickerFrontNorthEastBlueModel();
        public StickerFrontNorthEastWhiteModel StickerFrontNorthEastWhite { get; private set; } = new StickerFrontNorthEastWhiteModel();
        public StickerFrontNorthEastOrangeModel StickerFrontNorthEastOrange { get; private set; } = new StickerFrontNorthEastOrangeModel();
    }
}