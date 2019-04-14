using System.Collections.Generic;
using RC.Enumerations;

namespace RC.Model
{
    public abstract class StickerModelBase 
    {
        public StickerModelBase(StickerColorTypes stickerColorType) 
        {
            this.StickerColorType = stickerColorType;
        }

        public StickerColorTypes StickerColorType
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return StickerColorType.ToString();
        }
    }
}
