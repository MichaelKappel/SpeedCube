using RC.Enumerations;
using System;
using System.Linq;

namespace RC.Model
{
    public abstract class PieceSideModelBase : PieceModelBase
    {
        public PieceSideModelBase(): base()
        {
        }

        public abstract PositionSideTypes InitialSideType
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.InitialSideType.ToString(), base.ToString());
        }
    }
}