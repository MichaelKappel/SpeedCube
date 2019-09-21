using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;

namespace RC.Common.Model.Stickers
{
    public class StickerNorthModel : StickerModelBase
    {
        public StickerNorthModel(StickerColorTypes stickerColorType) : base(stickerColorType, PositionMiddleTypes.North)
        {

        }
    }
}
