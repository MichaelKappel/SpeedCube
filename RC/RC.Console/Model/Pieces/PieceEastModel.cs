using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceEastModel : PieceMiddleModelBase
    {
        public PieceEastModel() : base()
        {
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.East;

        public StickerEastOrangeModel StickerEast { get; private set; } = new StickerEastOrangeModel();
    }

}