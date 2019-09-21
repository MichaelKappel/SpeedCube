using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotSouthWestModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerWest
    {
        public SlotSouthWestModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerSouth, this.StickerWest };
        }
    }

}