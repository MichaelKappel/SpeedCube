using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackNorthModel : PieceSideModelBase
    {
        public PieceBackNorthModel() : base()
        {
            this.Stickers.Add(this.StickerBackNorthGreen);
            this.Stickers.Add(this.StickerBackNorthWhite);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackNorth;

        public StickerBackNorthGreenModel StickerBackNorthGreen { get; private set; } = new StickerBackNorthGreenModel();
        public StickerBackNorthWhiteModel StickerBackNorthWhite { get; private set; } = new StickerBackNorthWhiteModel();
    }

}