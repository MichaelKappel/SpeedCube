using System.Collections.Generic;
using RC.Enumerations;

namespace RC.Model
{
    public abstract class StickerModelBase 
    {
        public StickerModelBase(StickerColorTypes stickerColorType, PositionMiddleTypes positionMiddleType) 
        {
            this.StickerColorType = stickerColorType;
            this.PositionMiddleType = positionMiddleType;
        }

        public StickerColorTypes StickerColorType
        {
            get;
            protected set;
        }

        public PositionMiddleTypes PositionMiddleType
        {
            get;
            set;
        }


    public override string ToString()
        {
            return this.StickerColorType.ToString();
        }
    }
}
