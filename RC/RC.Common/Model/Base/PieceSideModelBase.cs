using RC.Common.Enumerations;
using RC.Common.Interfaces;
using System;
using System.Linq;

namespace RC.Common.Model
{
    public abstract class PieceSideModelBase : PieceModelBase
    {
        public PieceSideModelBase(): base()
        {

        }

        public abstract PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType);

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