using RC.Common.Interfaces;
using System;

namespace RC.Common.Model
{
    public abstract class SlotModelBase<T> : SlotModelBase, ICloneable where T : PieceModelBase
    {
        public SlotModelBase()
            : base()
        {

        }

        public T Piece { get; set; }

        public Object Clone()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return this.Piece.ToString();
        }
    }
}
