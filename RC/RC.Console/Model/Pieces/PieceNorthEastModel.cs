using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceNorthEastModel : PieceSideModelBase
    {
        public PieceNorthEastModel() : base()
        {
            this.Stickers.Add(this.StickerNorthEastWhite);
            this.Stickers.Add(this.StickerNorthEastOrange);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.NorthEast;

        public StickerNorthEastWhiteModel StickerNorthEastWhite { get; private set; } = new StickerNorthEastWhiteModel();

        public StickerNorthEastOrangeModel StickerNorthEastOrange { get; private set; } = new StickerNorthEastOrangeModel();

    }

}