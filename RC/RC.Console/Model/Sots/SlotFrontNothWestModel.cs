using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontNorthWestModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerFront, IStickerWest
    {
        public SlotFrontNorthWestModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontNorthWest;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerFront, this.StickerNorth, this.StickerWest };
        }
    }
}