using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Model;

namespace RC.Interfaces
{
    public interface IGetStickers
    {
        HashSet<StickerModelBase> GetStickers();
    }
}
