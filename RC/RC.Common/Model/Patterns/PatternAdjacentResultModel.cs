using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;

namespace RC.Common.Model.Patterns
{
    public class PatternAdjacentResultModel: PatternResultModelBase<PatternAdjacentTypes>
    {
        public PatternAdjacentResultModel()
        {
            this.Pattern = PatternAdjacentTypes.Unknown;
        }

        public StickerColorTypes MiddleColorTypeEast { get; set; }
        public StickerColorTypes MiddleColorTypeWest { get; set; }

        public override string ToString()
        {
            return this.Pattern.ToString();
        }
    }
}
