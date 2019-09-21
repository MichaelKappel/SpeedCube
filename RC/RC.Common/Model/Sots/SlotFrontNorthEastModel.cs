using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontNorthEastModel : SlotCornerModelBase, IGetStickers, IStickerNorth, IStickerFront, IStickerEast
    {
        public SlotFrontNorthEastModel() : base()
        {

        }

        public override PositionCornerTypes PositionCornerType { get; protected set; } = PositionCornerTypes.FrontNorthEast;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerNorth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerNorth, this.StickerEast };
        }
    }
}