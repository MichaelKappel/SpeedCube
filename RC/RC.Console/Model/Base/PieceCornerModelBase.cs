using RC.Enumerations;
using RC.Interfaces;
using System;

namespace RC.Model
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
