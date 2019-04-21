using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotBackWestModel : SlotSideModelBase, IGetStickers, IStickerBack, IStickerWest
    {
        public SlotBackWestModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerWest };
        }
    }

}