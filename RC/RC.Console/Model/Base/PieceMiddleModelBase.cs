using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;

namespace RC.Model
{
    public abstract class PieceMiddleModelBase : PieceModelBase
    {
        public PieceMiddleModelBase()
        {

        }

        public abstract PositionMiddleTypes InitialMiddleType
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.InitialMiddleType.ToString(), base.ToString());
        }
    }
}

