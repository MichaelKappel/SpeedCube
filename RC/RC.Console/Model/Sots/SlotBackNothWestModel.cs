using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackNorthWestModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerBack, IStickerWest
    {
        public SlotBackNorthWestModel()
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