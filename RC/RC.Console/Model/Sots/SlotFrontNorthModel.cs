﻿using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;

namespace RC.Model.Slots
{

    public class SlotFrontNorthModel : SlotSideModelBase, IGetStickers, IStickerNorth, IStickerFront
    {
        public SlotFrontNorthModel()
        {

        }

        public override PositionSideTypes PositionSideType { get; protected set; } = PositionSideTypes.FrontNorth;

        public StickerModelBase StickerFront { get; set; }
        public StickerModelBase StickerNorth { get; set; }

        public override StickerModelBase[] GetStickers()
        {
            return new [] { this.StickerFront, this.StickerNorth };
        }
    }

}