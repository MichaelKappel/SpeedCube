using RC.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Model.Patterns
{
    public class PatternFaceWithAdjacentsModel
    {

        PatternAdjacentModel PatternFaceType { get; set; }

        PatternAdjacentModel North { get; set; }
        PatternAdjacentModel East { get; set; }
        PatternAdjacentModel South { get; set; }
        PatternAdjacentModel West { get; set; }

    }
}