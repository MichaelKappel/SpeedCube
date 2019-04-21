using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackSouthEastModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerBack, IStickerEast
    {
        public SlotBackSouthEastModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackSouthEast;

        public StickerModelBase StickerEast { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerBack { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerSouth, this.StickerEast };
        }
    }
}