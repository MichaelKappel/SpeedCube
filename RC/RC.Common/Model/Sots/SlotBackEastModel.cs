using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Slots
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