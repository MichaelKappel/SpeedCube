using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontSouthEastModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerFront, IStickerEast
    {
        public SlotFrontSouthEastModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontSouthEast;


        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerSouth, this.StickerEast };
        }
    }
}