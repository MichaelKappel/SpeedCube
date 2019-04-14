using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceSouthModel : PieceMiddleModelBase
    {
        public PieceSouthModel() : base()
        {
            this.Stickers.Add(this.StickerSouth);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.South;

        public StickerSouthYellowModel StickerSouth { get; private set; } = new StickerSouthYellowModel();
    }

}