using RC.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Common.Model.Patterns
{
    public class PatternFaceWithAdjacentsModel
    {
        public PatternAdjacentModel Middle { get; set; }

        public PatternAdjacentModel North { get; set; }
        public PatternAdjacentModel East { get; set; }
        public PatternAdjacentModel South { get; set; }
        public PatternAdjacentModel West { get; set; }

        public override string ToString()
        {
            return $@"
           [North: {North}]
[West: {West} ][Middle: {Middle}][East: {East}]
           [South: {South} ]
";
                   
        }
    }
}