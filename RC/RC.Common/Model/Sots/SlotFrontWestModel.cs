using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontWestModel : SlotSideModelBase, IGetStickers, IStickerFront, IStickerWest
    {
        public SlotFrontWestModel() : base()
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