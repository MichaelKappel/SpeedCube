using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontSouthModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerFront
    {
        public SlotFrontSouthModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontSouth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerSouth };
        }
    }

}