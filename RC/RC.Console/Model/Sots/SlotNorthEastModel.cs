using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotNorthEastModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerEast
    {
        public SlotNorthEastModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerNorth, this.StickerEast };
        }
    }

}