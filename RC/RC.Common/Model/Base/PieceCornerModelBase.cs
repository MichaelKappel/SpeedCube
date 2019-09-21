using RC.Common.Enumerations;
using RC.Common.Interfaces;
using System;

namespace RC.Common.Model
{
    public abstract class PieceCornerModelBase : PieceModelBase, ICopyCornerPieceModel
    {
        public PieceCornerModelBase() : base()
        {

        }
        
        public abstract PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType);

        public abstract PositionCornerTypes InitialCornerType
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.InitialCornerType.ToString(), base.ToString());
        }

    }
}
