﻿using System.Collections.Generic;
using RC.Common.Enumerations;
using RC.Common.Interfaces;
using RC.Common.Model;

namespace RC.Common.Model.Slots
{

    public class SlotFrontSouthModel : SlotSideModelBase, IGetStickers, IStickerSouth, IStickerFront
    {
        public SlotFrontSouthModel() : base()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontSouth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerSouth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerSouth };
        }
    }

}