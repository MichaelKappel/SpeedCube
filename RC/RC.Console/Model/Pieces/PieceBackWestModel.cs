using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackWestModel : PieceSideModelBase
    {
        public PieceBackWestModel() : base()
        {
            this.Stickers.Add(this.StickerBackWestGreen);
            this.Stickers.Add(this.StickerBackWestRed);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerBackWestGreenModel StickerBackWestGreen { get; private set; } = new StickerBackWestGreenModel();

        public StickerBackWestRedModel StickerBackWestRed { get; private set; } = new StickerBackWestRedModel();
    }


}