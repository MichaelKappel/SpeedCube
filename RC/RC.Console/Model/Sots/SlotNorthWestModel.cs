using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotNorthWestModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerWest
    {
        public SlotNorthWestModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerNorth, this.StickerWest };
        }
    }

}