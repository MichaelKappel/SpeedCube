using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
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
