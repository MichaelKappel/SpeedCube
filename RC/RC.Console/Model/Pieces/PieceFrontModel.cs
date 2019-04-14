using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceFrontModel : PieceMiddleModelBase
    {
        public PieceFrontModel() : base()
        {
            this.Stickers.Add(this.StickerFront);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.Front;

        public StickerFrontBlueModel StickerFront { get; private set; } = new StickerFrontBlueModel();
    }

}