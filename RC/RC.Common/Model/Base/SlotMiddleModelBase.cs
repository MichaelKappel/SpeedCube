using RC.Common.Enumerations;
using System.Collections.Generic;

namespace RC.Common.Model
{
    public abstract class SlotMiddleModelBase : SlotModelBase<PieceMiddleModelBase>
    {
        public SlotMiddleModelBase() : base()
        {

        }

        public abstract PositionMiddleTypes PositionMiddleType
        {
            get;
            protected set;
        }

        public HashSet<SlotSideModelBase> AdjacentSideSlots { get; } = new HashSet<SlotSideModelBase>(3);

        public override string ToString()
        {
            return string.Format("{0} {1}", this.PositionMiddleType.ToString(), base.ToString());
        }

    }
}