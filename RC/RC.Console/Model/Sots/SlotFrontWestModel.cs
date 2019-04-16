using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontWestModel : SlotSideModelBase, IGetStickers, IStickerFront, IStickerWest
    {
        public SlotFrontWestModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontWest;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerWest };
        }
    }

}