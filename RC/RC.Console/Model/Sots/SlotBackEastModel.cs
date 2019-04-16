using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackEastModel : SlotSideModelBase, IGetStickers, IStickerBack, IStickerEast
    {
        public SlotBackEastModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackNorth;

        public StickerModelBase StickerBack { get; set; } 
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerEast };
        }
    }

}