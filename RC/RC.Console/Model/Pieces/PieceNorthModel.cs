using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceNorthModel : PieceMiddleModelBase
    {
        public PieceNorthModel() : base()
        {
            this.Stickers.Add(this.StickerNorth);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.North;

        public StickerNorthWhiteModel StickerNorth { get; private set; } = new StickerNorthWhiteModel();
    }

}