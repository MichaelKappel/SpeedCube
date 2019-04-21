using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
{
    public class SlotNorthModel : SlotMiddleModelBase, IGetStickers, IStickerNorth
    {
        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.North;

        public StickerModelBase StickerNorth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerNorth };
        }
    }
}
