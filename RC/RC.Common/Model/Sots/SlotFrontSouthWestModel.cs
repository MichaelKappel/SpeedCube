using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontSouthWestModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerFront, IStickerWest
    {
        public SlotFrontSouthWestModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontSouthWest;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerSouth, this.StickerWest };
        }
    }
}