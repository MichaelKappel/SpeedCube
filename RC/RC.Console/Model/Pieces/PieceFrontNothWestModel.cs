using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontNorthWestModel : PieceCornerModelBase
    {
        public PieceFrontNorthWestModel() : base()
        {
            this.Stickers.Add(this.StickerFrontNorthWestBlue);
            this.Stickers.Add(this.StickerFrontNorthWestWhite);
            this.Stickers.Add(this.StickerFrontNorthWestRed);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.FrontNorthWest;

        public StickerFrontNorthWestBlueModel StickerFrontNorthWestBlue { get; private set; } = new StickerFrontNorthWestBlueModel();

        public StickerFrontNorthWestWhiteModel StickerFrontNorthWestWhite { get; private set; } = new StickerFrontNorthWestWhiteModel();

        public StickerFrontNorthWestRedModel StickerFrontNorthWestRed { get; private set; } = new StickerFrontNorthWestRedModel();
    }
}