using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceBackSouthModel : PieceSideModelBase
    {
        public PieceBackSouthModel() : base()
        {
            this.Stickers.Add(this.StickerBackSouthGreen);
            this.Stickers.Add(this.StickerBackSouthYellow);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.BackSouth;

        public StickerBackSouthGreenModel StickerBackSouthGreen { get; private set; } = new StickerBackSouthGreenModel();

        public StickerBackSouthYellowModel StickerBackSouthYellow { get; private set; } = new StickerBackSouthYellowModel();

    }

}