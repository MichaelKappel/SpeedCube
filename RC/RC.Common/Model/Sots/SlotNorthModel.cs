using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Sots
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
