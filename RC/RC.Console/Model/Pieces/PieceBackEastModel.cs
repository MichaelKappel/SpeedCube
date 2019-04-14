using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackEastModel : PieceSideModelBase
    {
        public PieceBackEastModel() : base()
        {
            this.Stickers.Add(this.StickerBackEastGreen);
            this.Stickers.Add(this.StickerBackEastOrange);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackEast;

        public StickerBackEastGreenModel StickerBackEastGreen { get; private set; } = new StickerBackEastGreenModel();
        public StickerBackEastOrangeModel StickerBackEastOrange { get; private set; } = new StickerBackEastOrangeModel();
    }

}