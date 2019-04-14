using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontSouthEastModel : SlotCornerModelBase, IGetStickers, IStickerSouth, IStickerFront, IStickerEast
    {
        public SlotFrontSouthEastModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontSouthEast;


        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerFront, this.StickerSouth, this.StickerEast };
        }
    }
}