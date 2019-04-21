using RC.Enumerations;
using System.Collections.Generic;

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

        public HashSet<SlotCornerModelBase> AdjacentCornerSlots { get; } = new HashSet<SlotCornerModelBase>(2);
        public HashSet<SlotMiddleModelBase> AdjacentMiddlePieces { get; } = new HashSet<SlotMiddleModelBase>(2);

        public override string ToString()
        {
            return string.Format("{0} {1}", this.PositionSideType.ToString(), base.ToString());
        }
    }
}
