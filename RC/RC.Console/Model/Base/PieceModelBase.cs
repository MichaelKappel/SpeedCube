using System;
using System.Collections.Generic;
using RC.Enumerations;

namespace RC.Model
{
    public abstract class PieceModelBase
    {


        public PieceModelBase()
        {

        }

        public HashSet<StickerModelBase> Stickers { get; private set; } = new HashSet<StickerModelBase>();

        public override string ToString()
        {
            string stickerString = String.Empty;
            foreach (var s in this.Stickers)
            {
                stickerString += s.ToString() + " ";
            }
            return stickerString;
        }
    }
}
