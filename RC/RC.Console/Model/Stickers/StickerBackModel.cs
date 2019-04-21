using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model.Stickers
{
    public class StickerBackModel : StickerModelBase
    {
        public StickerBackModel(StickerColorTypes stickerColorType) : base(stickerColorType, PositionMiddleTypes.Back)
        {

        }
    }
}
