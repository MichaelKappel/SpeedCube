using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
{
    public class SlotWestModel : SlotMiddleModelBase, IGetStickers, IStickerWest
    {
        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.West;

        public StickerModelBase StickerWest { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerWest };
        }
    }
}
