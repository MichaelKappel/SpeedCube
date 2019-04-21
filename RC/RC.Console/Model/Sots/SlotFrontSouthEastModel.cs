using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
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