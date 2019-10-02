using RC.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace RC.Common.Model.Stickers
{
    public struct StickerIndexModel
    {
        public StickerIndexModel(StickerColorTypes stickerColorType, Int32 index)
        {
            this.StickerColorType = stickerColorType;
            this.Index = index;
        }

        public StickerColorTypes StickerColorType { get; set; }

        public Int32 Index { get; set; }
        
    }
}
