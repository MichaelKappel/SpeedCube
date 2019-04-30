using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model.Patterns
{
    public class PatternAdjacentResultModel: PatternResultModelBase<PatternAdjacentTypes>
    {
        public override string ToString()
        {
            return this.Pattern.ToString();
        }
    }
}
