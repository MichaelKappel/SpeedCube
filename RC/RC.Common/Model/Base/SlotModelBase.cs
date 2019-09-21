using System;
using System.Collections.Generic;
using RC.Common.Interfaces;

namespace RC.Common.Model
{
    public abstract class SlotModelBase: IGetStickers
    {
        public SlotModelBase()
        {
           
        }

        public abstract StickerModelBase[] GetStickers();
    }
}
