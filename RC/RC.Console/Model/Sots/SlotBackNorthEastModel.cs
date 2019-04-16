using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackNorthEastModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerBack, IStickerEast
    {
        public SlotBackNorthEastModel()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackNorthEast;

        public StickerModelBase StickerNorth { get; set; }

        public StickerModelBase StickerBack { get; set; } 

        public StickerModelBase StickerEast{ get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerNorth, this.StickerEast };
        }

    }

}