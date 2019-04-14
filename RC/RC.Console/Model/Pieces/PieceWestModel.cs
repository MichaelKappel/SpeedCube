using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceWestModel : PieceMiddleModelBase
    {
        public PieceWestModel() : base()
        {
            this.Stickers.Add(this.StickerWest);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.West;

        public StickerWestRedModel StickerWest { get; private set; } = new StickerWestRedModel();
    }

}