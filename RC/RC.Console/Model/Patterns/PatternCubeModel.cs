using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model.Patterns
{
    public class PatternAdjacentFaceResultModel
    {
        public PatternAdjacentResultModel PatternAdjacentResult { get; set; }
        public PatternFaceResultModel PatternFaceResult { get; set; }
    }
}
