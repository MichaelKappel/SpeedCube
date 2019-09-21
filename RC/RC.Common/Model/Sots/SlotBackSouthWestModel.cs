using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotBackSouthWestModel : SlotCornerModelBase, IGetStickers, IStickerBack, IStickerSouth, IStickerWest
    {
        public SlotBackSouthWestModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackSouthWest;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerSouth, this.StickerWest };
        }
    }
}