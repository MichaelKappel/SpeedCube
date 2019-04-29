using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Interfaces;
using RC.Model;
using RC.Model.Pieces;
using RC.Model.Sots;

namespace RC.Model
{
    public abstract class PieceMiddleModelBase : PieceModelBase
    {
        public PieceMiddleModelBase() : base()
        {

        }

        public abstract PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType);

        public abstract PositionMiddleTypes InitialMiddleType
        {
            get;
            protected set;
        }

        public HashSet<SlotSideModelBase> AdjacentSideSlots { get; } = new HashSet<SlotSideModelBase>();

        public override string ToString()
        {
            return string.Format("{0} {1}", this.InitialMiddleType.ToString(), base.ToString());
        }

    }
}

 