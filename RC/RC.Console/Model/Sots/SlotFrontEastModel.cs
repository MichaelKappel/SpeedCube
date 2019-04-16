using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontEastModel : SlotSideModelBase, IGetStickers, IStickerFront, IStickerEast
    {
        public SlotFrontEastModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackNorth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerEast };
        }
    }

}