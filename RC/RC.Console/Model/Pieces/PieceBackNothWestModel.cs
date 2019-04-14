using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackNorthWestModel : PieceCornerModelBase
    {
        public PieceBackNorthWestModel() : base()
        {
            this.Stickers.Add(this.StickerBackNorthWestGreen);

            this.Stickers.Add(this.StickerBackNorthWestWhite);

            this.Stickers.Add(this.StickerBackNorthWestRed);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackNorthWest;

        public StickerBackNorthWestGreenModel StickerBackNorthWestGreen { get; private set; } = new StickerBackNorthWestGreenModel();
        public StickerBackNorthWestWhiteModel StickerBackNorthWestWhite { get; private set; } = new StickerBackNorthWestWhiteModel();
        public StickerBackNorthWestRedModel StickerBackNorthWestRed { get; private set; } = new StickerBackNorthWestRedModel();
    }
}