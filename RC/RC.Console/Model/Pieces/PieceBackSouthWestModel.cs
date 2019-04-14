using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackSouthWestModel : PieceCornerModelBase
    {
        public PieceBackSouthWestModel() : base()
        {
            this.Stickers.Add(this.StickerBackSouthWestGreen);

            this.Stickers.Add(this.StickerBackSouthWestYellow);

            this.Stickers.Add(this.StickerBackSouthWestRed);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackSouthWest;

        public StickerBackSouthWestGreenModel StickerBackSouthWestGreen { get; private set; } = new StickerBackSouthWestGreenModel();

        public StickerBackSouthWestYellowModel StickerBackSouthWestYellow { get; private set; } = new StickerBackSouthWestYellowModel();

        public StickerBackSouthWestRedModel StickerBackSouthWestRed { get; private set; } = new StickerBackSouthWestRedModel();
    }
}