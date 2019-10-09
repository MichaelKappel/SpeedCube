using RC.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RC.Common.Model.Stickers
{
    [DebuggerDisplay("{StickerColorType} {Index}", Name = "{StickerColorType} {Index}")]
    public struct StickerIndexModel
    {
        public StickerIndexModel(StickerColorTypes stickerColorType, Int32 index, StickerColorTypes sideStickerColorType)
        {
            this.StickerColorType = stickerColorType;
            this.Index = index;
            this.SideStickerColorType = sideStickerColorType;
        }

        public StickerColorTypes SideStickerColorType { get; set; }

        public StickerColorTypes StickerColorType { get; set; }

        public Int32 Index { get; set; }
        
    }
}
