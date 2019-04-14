using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackSouthEastModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerBack, IStickerEast
    {
        public SlotBackSouthEastModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackSouthEast;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerBack, this.StickerSouth, this.StickerEast };
        }
    }
}