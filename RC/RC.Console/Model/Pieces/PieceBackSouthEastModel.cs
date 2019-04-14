using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackSouthEastModel : PieceCornerModelBase
    {
        public PieceBackSouthEastModel() : base()
        {
            this.Stickers.Add(this.StickerBackSouthEastGreen);
            this.Stickers.Add(this.StickerBackSouthEastYellow);
            this.Stickers.Add(this.StickerBackSouthEastOrange);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackSouthEast;

        public StickerBackSouthEastGreenModel StickerBackSouthEastGreen { get; private set; } = new StickerBackSouthEastGreenModel();

        public StickerBackSouthEastYellowModel StickerBackSouthEastYellow { get; private set; } = new StickerBackSouthEastYellowModel();

        public StickerBackSouthEastOrangeModel StickerBackSouthEastOrange { get; private set; } = new StickerBackSouthEastOrangeModel();
    }
}