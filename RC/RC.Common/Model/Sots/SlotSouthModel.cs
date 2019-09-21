using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Sots
{
    public class SlotSouthModel : SlotMiddleModelBase, IGetStickers, IStickerSouth
    {
        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.South;

        public StickerModelBase StickerSouth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerSouth };
        }
    }
}
