using System;
using System.Collections.Generic;
using RC.Interfaces;

namespace RC.Model
{
    public abstract class SlotModelBase: IGetStickers
    {
        public SlotModelBase()
        {
           
        }

        public abstract StickerModelBase[] GetStickers();
    }
}
