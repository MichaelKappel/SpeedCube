using RC.Enumerations;

namespace RC.Model
{
    public abstract class PieceCornerModelBase : PieceModelBase
    {
        public PieceCornerModelBase() : base()
        {

        }

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
