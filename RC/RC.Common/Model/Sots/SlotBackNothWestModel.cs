using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Slots
{

    public class SlotBackNorthWestModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerBack, IStickerWest
    {
        public SlotBackNorthWestModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackNorthWest;


        public StickerModelBase StickerBack { get; set; } 
        public StickerModelBase StickerNorth { get; set; } 
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerNorth, this.StickerWest };
        }
    }
}