using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotBackSouthModel : SlotSideModelBase, IGetStickers, IStickerBack, IStickerSouth
    {
        public SlotBackSouthModel() : base()
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