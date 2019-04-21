using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotSouthEastModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerEast
    {
        public SlotSouthEastModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.BackWest;

        public StickerModelBase StickerSouth { get; set; }
        public StickerModelBase StickerEast { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerSouth, this.StickerEast };
        }
    }

}