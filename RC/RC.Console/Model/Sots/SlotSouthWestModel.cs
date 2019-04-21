using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotSouthWestModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerWest
    {
        public SlotSouthWestModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerSouth, this.StickerWest };
        }
    }

}