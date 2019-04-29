using RC.Logic;
using RC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Extensions
{
    public static class CubePatternExtensions
    {
        public static String GetPattern(this CubeModel cube)
        {
            return (new CubePatternLogic()).GetCubePattern(cube);
        }
    }
}
