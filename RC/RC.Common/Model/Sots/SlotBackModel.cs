using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;
using RC.Common.Model.Pieces;

namespace RC.Common.Model.Sots
{
    public class SlotBackModel : SlotMiddleModelBase, IGetStickers, IStickerBack
    {
        public SlotBackModel() : base()
        {

        }

        public override PositionMiddleTypes PositionMiddleType { get; protected set; } = PositionMiddleTypes.Back;

        public StickerModelBase StickerBack { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new[] { this.StickerBack };
        }
    }
}
