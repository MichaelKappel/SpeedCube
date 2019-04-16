using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotBackSouthModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerBack
    {
        public SlotBackSouthModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackSouth;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerSouth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerSouth };
        }
    }
}