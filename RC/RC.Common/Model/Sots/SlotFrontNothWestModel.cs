using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontNorthWestModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerFront, IStickerWest
    {
        public SlotFrontNorthWestModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontNorthWest;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerNorth, this.StickerWest };
        }
    }
}