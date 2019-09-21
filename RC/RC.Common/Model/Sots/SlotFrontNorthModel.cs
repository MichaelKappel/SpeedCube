using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontNorthModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerFront
    {
        public SlotFrontNorthModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontNorth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerNorth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerNorth };
        }
    }

}