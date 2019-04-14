using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotBackSouthWestModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerBack, IStickerWest
    {
        public SlotBackSouthWestModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackSouthWest;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerBack, this.StickerSouth, this.StickerWest };
        }
    }
}