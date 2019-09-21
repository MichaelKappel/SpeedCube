using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Sots
{
    public class SlotFrontModel : SlotMiddleModelBase, IGetStickers, IStickerFront
    {
        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.Front;

        public StickerModelBase StickerFront { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerFront };
        }
    }
}
