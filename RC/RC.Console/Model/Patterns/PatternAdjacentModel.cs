using RC.Enumerations;
using RC.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Model.Patterns
{
    public class PatternAdjacentModel
    {
        public PatternAdjacentModel(PatternAdjacentFlipTypes patternAdjacentFlipType, PatternAdjacentBitModel patternAdjacentBitModel)
        {
            this.PatternAdjacentFlipType = patternAdjacentFlipType;
            this.PatternAdjacentBitModel = patternAdjacentBitModel;
        }

        public PatternAdjacentFlipTypes PatternAdjacentFlipType { get; set; }

        public PatternAdjacentBitModel PatternAdjacentBitModel { get; set; }

        public override string ToString()
        {
            return $" {PatternAdjacentFlipType}   {PatternAdjacentBitModel} ";
        }
    }
}
