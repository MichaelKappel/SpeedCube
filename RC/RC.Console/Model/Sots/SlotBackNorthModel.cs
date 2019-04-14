using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Slots
{

    public class SlotBackNorthModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerBack
    {
        public SlotBackNorthModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackNorth;

        public StickerModelBase StickerBack { get; set; }
        public StickerModelBase StickerNorth { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerBack, this.StickerNorth, };
        }
    }

}