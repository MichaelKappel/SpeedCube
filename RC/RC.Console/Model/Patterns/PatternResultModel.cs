using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Model.Patterns
{
    public class PatternResultModel
    {

        public Boolean IsComplete { get; set; }

        public Boolean IsCenterMatch { get; set; }

        public Int32 Sides { get; set; }

        public Int32 Corners { get; set; }

        public Int32 CompletedSideRows { get; set; }

        public Int32 CompletedCenterRow { get; set; }

        public Int32 ConnectedSideRows { get; set; }

        public Int32 TotalMatchingStickers { get; set; }

    }
}
