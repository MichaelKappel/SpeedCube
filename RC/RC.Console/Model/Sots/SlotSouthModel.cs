using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
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
