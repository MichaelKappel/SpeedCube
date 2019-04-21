using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model.Patterns
{
    public class PatternResultModel
    {
        public PatternFaceTypes PatternFaceType { get; set; }
        public PatternAdjacentTypes PatternAdjacentType { get; set; }
    }
}
