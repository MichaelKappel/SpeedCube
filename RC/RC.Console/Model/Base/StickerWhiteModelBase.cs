using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model
{
    public abstract class StickerWhiteModel : StickerModelBase
    {
        public StickerWhiteModel() : base(StickerColorTypes.White)
        {

        }
    }
}
