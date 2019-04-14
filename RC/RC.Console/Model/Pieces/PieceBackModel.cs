using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackModel : PieceMiddleModelBase
    {
        public PieceBackModel() : base()
        {
            this.Stickers.Add(this.StickerBack);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.Back;

        public StickerBackGreenModel StickerBack { get; private set; } = new StickerBackGreenModel();
    }

}