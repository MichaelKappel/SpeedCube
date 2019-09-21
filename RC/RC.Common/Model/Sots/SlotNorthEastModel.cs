using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotNorthEastModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerEast
    {
        public SlotNorthEastModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerNorth, this.StickerEast };
        }
    }

}