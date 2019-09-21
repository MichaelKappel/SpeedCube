using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Slots
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