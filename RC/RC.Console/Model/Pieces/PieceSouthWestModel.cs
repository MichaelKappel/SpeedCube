using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceSouthWestModel : PieceSideModelBase
    {
        public PieceSouthWestModel() : base()
        {
            this.Stickers.Add(this.StickerSouthWestYellow);
            this.Stickers.Add(this.StickerSouthWestRed);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.SouthWest;

        public StickerSouthWestYellowModel StickerSouthWestYellow { get; private set; } = new StickerSouthWestYellowModel();

        public StickerSouthWestRedModel StickerSouthWestRed { get; private set; } = new StickerSouthWestRedModel();
    }

}