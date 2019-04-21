using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
{
    public class SlotEastModel : SlotMiddleModelBase, IGetStickers, IStickerEast
    {
        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.East;

        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerEast };
        }
    }
}
