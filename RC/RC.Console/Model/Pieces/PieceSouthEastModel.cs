using RC.Enumerations;
using RC.Model.Stickers;

namespace RC.Model.Pieces
{

    public class PieceSouthEastModel : PieceSideModelBase
    {
        public PieceSouthEastModel() : base()
        {
            this.Stickers.Add(this.StickerSouthEastYellow);
            this.Stickers.Add(this.StickerSouthEastOrange);
        }

        public override PositionSideTypes InitialSideType { get; protected set; } = PositionSideTypes.SouthEast;

        public StickerSouthEastYellowModel StickerSouthEastYellow { get; private set; } = new StickerSouthEastYellowModel();

        public StickerSouthEastOrangeModel StickerSouthEastOrange { get; private set; } = new StickerSouthEastOrangeModel();
    }

}