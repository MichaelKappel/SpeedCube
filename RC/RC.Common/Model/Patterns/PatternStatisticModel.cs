using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;

namespace RC.Common.Model.Patterns
{
    public class PatternStatisticModel
    {
        public IList<PatternAdjacentResultModel> PatternAdjacentResults { get; set; }
        public IList<PatternFaceResultModel> PatternFaceResults { get; set; }

        public override string ToString()
        {
            return PatternAdjacentResults.ToString() + "|" + PatternFaceResults.ToString();
        }
    }
}
