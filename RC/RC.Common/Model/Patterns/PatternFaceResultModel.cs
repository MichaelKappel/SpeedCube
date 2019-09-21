using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;

namespace RC.Common.Model.Patterns
{
    public class PatternFaceResultModel: PatternResultModelBase<PatternFaceTypes>
    {
        public PatternFaceResultModel()
        {
            this.Pattern = PatternFaceTypes.Unknown;
        }

        public StickerColorTypes MiddleColorType { get; set; }

        public override string ToString()
        {
            return this.Pattern.ToString();
        }
    }
}
