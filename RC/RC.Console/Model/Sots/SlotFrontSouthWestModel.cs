using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontSouthWestModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerFront, IStickerWest
    {
        public SlotFrontSouthWestModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontSouthWest;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerFront, this.StickerSouth, this.StickerWest };
        }
    }
}