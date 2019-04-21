using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Model.Sots
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
