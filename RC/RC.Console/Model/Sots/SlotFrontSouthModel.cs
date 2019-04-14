using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontSouthModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerFront
    {
        public SlotFrontSouthModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontSouth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }

        public override HashSet<StickerModelBase> GetStickers()
        {
            return new HashSet<StickerModelBase>() { this.StickerFront, this.StickerSouth };
        }
    }

}