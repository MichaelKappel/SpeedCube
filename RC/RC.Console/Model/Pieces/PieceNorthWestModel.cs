using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceNorthWestModel : PieceSideModelBase
    {
        public PieceNorthWestModel() : base()
        {
            this.Stickers.Add(this.StickerNorthWestWhite);
            this.Stickers.Add(this.StickerNorthWestRed);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.NorthWest;

        public StickerNorthWestWhiteModel StickerNorthWestWhite { get; private set; } = new StickerNorthWestWhiteModel();

        public StickerNorthWestRedModel StickerNorthWestRed { get; private set; } = new StickerNorthWestRedModel();
    }

}