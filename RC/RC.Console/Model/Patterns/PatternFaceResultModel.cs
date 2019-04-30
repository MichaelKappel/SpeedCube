using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;

namespace RC.Model.Patterns
{
    public class PatternFaceResultModel: PatternResultModelBase<PatternFaceTypes>
    {
        public override string ToString()
        {
            return this.Pattern.ToString();
        }
    }
}
