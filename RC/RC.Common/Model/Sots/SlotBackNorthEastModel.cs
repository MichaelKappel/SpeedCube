using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Slots
{

    public class SlotBackNorthEastModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerBack, IStickerEast
    {
        public SlotBackNorthEastModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.BackNorthEast;

        public StickerModelBase StickerBack { get; set; }

        public StickerModelBase StickerNorth { get; set; }

        public StickerModelBase StickerEast{ get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerBack, this.StickerNorth, this.StickerEast };
        }

    }

}