using RC.Enumerations;
using System.Collections.Generic;

namespace RC.Model
{
    public abstract class SlotCornerModelBase : SlotModelBase<PieceCornerModelBase>
    {
        public SlotCornerModelBase() : base()
        {

        }


        public abstract PositionCornerTypes PositionCornerType
        {
            get;
            protected set;
        }


        public HashSet<SlotSideModelBase> AdjacentSideSlots { get; } = new HashSet<SlotSideModelBase>(3);

        public override string ToString()
        {
            return string.Format("{0} {1}", this.PositionCornerType.ToString(), base.ToString());
        }

    }
}