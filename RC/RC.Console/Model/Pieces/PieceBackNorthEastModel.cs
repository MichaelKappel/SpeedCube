using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackNorthEastModel : PieceCornerModelBase
    {
        public PieceBackNorthEastModel() : base()
        {
            this.Stickers.Add(this.StickerBackNorthEastGreen);
            this.Stickers.Add(this.StickerBackNorthEastWhite);
            this.Stickers.Add(this.StickerBackNorthEastOrange);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackNorthEast;


        public StickerBackNorthEastGreenModel StickerBackNorthEastGreen { get; private set; } = new StickerBackNorthEastGreenModel();

        public StickerBackNorthEastWhiteModel StickerBackNorthEastWhite { get; private set; } = new StickerBackNorthEastWhiteModel();

        public StickerBackNorthEastOrangeModel StickerBackNorthEastOrange { get; private set; } = new StickerBackNorthEastOrangeModel();
    }

}