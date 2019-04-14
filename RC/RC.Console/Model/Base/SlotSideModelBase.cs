using RC.Enumerations;

namespace RC.Model
{
    public abstract class SlotSideModelBase: SlotModelBase<PieceSideModelBase>
    {
        public SlotSideModelBase() : base()
        {

        }

        public abstract PositionSideTypes PositionSideType
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.PositionSideType.ToString(), base.ToString());
        }
    }
}
