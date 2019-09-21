using RC.Logic;
using RC.Common.Model;
using System;

namespace RC.Common.Extensions
{
    public static class CubePatternExtensions
    {
        public static String GetPattern(this CubeModel cube)
        {
            return (new CubePatternLogic()).GetCubePattern(cube);
        }
    }
}
