using RC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Logic
{
    public class CubeFacePatternLogic: PatternLogicBase
    {


        public String Visualize(String pattern)
        {

            var s = pattern.ToCharArray();


            String result = $@" 
                    [0:{s[0]}|1:{s[1]}|2:{s[2]}]
                    [3:{s[3]}|4:{s[4]}|5:{s[5]}]
                    [6:{s[6]}|7:{s[7]}|8:{s[8]}]
";

            return result;

        }

        public string[] GetCubeFacePatterns(CubeModel cube)
        {
            String north = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.NorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.North.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.NorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthEast.StickerNorth.StickerColorType)}";
            String south = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.SouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.South.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.SouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthEast.StickerSouth.StickerColorType)}";
            String front = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.Front.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthEast.StickerFront.StickerColorType)}";
            String back = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.Back.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthEast.StickerBack.StickerColorType)}";
            String west = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.NorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.West.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.SouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthWest.StickerWest.StickerColorType)}";
            String east = $"{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.NorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.East.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.FrontSouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.SouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(GetXyzCubeType(cube), cube.BackSouthEast.StickerEast.StickerColorType)}";

            return new string[] { north, south, front, back, west, east };
        }

        public string[] GetCubeFacePatterns(String cubePattern)
        {
                //Debug.WriteLine("GetCubePatternNorthBackToFront");

                var originalStickers = cubePattern.ToCharArray();

                var north = $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";
                north += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
                north += $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";

                var south = $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";
                south += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
                south += $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";

                var front = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
                front += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
                front += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

                var back = $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";
                back += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
                back += $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";

                var west = $"{originalStickers[36]}{originalStickers[37]}{originalStickers[38]}";
                west += $"{originalStickers[39]}{originalStickers[40]}{originalStickers[41]}";
                west += $"{originalStickers[42]}{originalStickers[43]}{originalStickers[44]}";

                var east = $"{originalStickers[45]}{originalStickers[46]}{originalStickers[47]}";
                east += $"{originalStickers[48]}{originalStickers[49]}{originalStickers[50]}";
                east += $"{originalStickers[51]}{originalStickers[52]}{originalStickers[53]}";

            

                return new String[] {north,south,front,back,west,east};
        }

        public String[] GetAllFacePatterns(String original)
        {
            var resultsWithDups = new List<String>();
            String[] shiftedPatterns = this.ShiftSwitchAndMirrorFacePatterns(original);
            foreach (var shiftedPattern in shiftedPatterns)
            {
                foreach (var rotatedPattern in this.RotateFacePattern(shiftedPattern))
                {
                    resultsWithDups.Add(rotatedPattern);
                    resultsWithDups.Add(this.ReversePattern(rotatedPattern));

                    var reversedRotatedPattern = new String(shiftedPattern.Reverse().ToArray());
                    resultsWithDups.Add(reversedRotatedPattern);
                    resultsWithDups.Add(this.ReversePattern(reversedRotatedPattern));
                }
            }

            var normalizedResultsWithDups = new List<String>();

            foreach(var resultWithDups in resultsWithDups)
            {
                normalizedResultsWithDups.Add(this.Normalize(resultWithDups));
            }

            String[] results = normalizedResultsWithDups.Distinct().ToArray();

            return results;
        }

        public String[] ShiftSwitchAndMirrorFacePatterns(String original)
        {
            var resultWithDups = new List<String>();

            foreach (var shiftedPattern in ShiftPatternComprehensive(original))
            {
                foreach (var switchedOutPattern in this.SwitchOutPatternComprehensive(shiftedPattern))
                {
                    resultWithDups.AddRange(this.GetFacePatternMirrors(switchedOutPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();
            return results;
        }

        public String[] GetFacePatternMirrors(String original)
        {
            var originalStickers = original.ToCharArray();

            var topToBottom = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            topToBottom += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            topToBottom += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var leftToRight = $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";
            leftToRight += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            leftToRight += $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";

            var leftToRightAndTopToBottom = $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";
            leftToRightAndTopToBottom += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            leftToRightAndTopToBottom += $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";

            return new string[] { original, topToBottom, leftToRight, leftToRightAndTopToBottom };
        }

        public String[] RotateFacePattern(String original)
        {
            var originalStickers = original.ToCharArray();

            var clockwise = $"{originalStickers[6]}{originalStickers[3]}{originalStickers[0]}";
            clockwise += $"{originalStickers[7]}{originalStickers[4]}{originalStickers[1]}";
            clockwise += $"{originalStickers[8]}{originalStickers[5]}{originalStickers[2]}";

            var clockwise2 = $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";
            clockwise2 += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            clockwise2 += $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";

            var clockwise3 = $"{originalStickers[2]}{originalStickers[5]}{originalStickers[8]}";
            clockwise3 += $"{originalStickers[1]}{originalStickers[4]}{originalStickers[7]}";
            clockwise3 += $"{originalStickers[0]}{originalStickers[3]}{originalStickers[6]}";

            return new string[] { original, clockwise, clockwise2, clockwise3 };
        }

        public String[] SwitchOutPatternComprehensive(String original)
        {

            var results = new List<String>() { original };

            String codedOriginal = original
                .Replace("A", "A1").Replace("B", "B1").Replace("C", "C1")
                .Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            var resultsRaw = new List<String>();

            resultsRaw.Add(codedOriginal.Replace("A1", "B").Replace("a1", "b").Replace("B1", "A").Replace("b1", "a"));
            resultsRaw.Add(codedOriginal.Replace("A1", "C").Replace("a1", "c").Replace("C1", "A").Replace("c1", "a"));

            resultsRaw.Add(codedOriginal.Replace("B1", "C").Replace("b1", "c").Replace("C1", "B").Replace("c1", "b"));
            resultsRaw.Add(codedOriginal.Replace("B1", "A").Replace("b1", "a").Replace("A1", "B").Replace("a1", "b"));

            resultsRaw.Add(codedOriginal.Replace("C1", "A").Replace("c1", "a").Replace("A1", "C").Replace("a1", "c"));
            resultsRaw.Add(codedOriginal.Replace("C1", "B").Replace("c1", "b").Replace("B1", "C").Replace("b1", "c"));

            foreach (var resultRaw in resultsRaw)
            {
                var result = resultRaw.Replace("A1", "A").Replace("B1", "B").Replace("C1", "C").Replace("a1", "a").Replace("b1", "b").Replace("c1", "c");

                results.Add(result);
            }

            return results.Distinct().ToArray();
        }

        public String[] ShiftPatternComprehensive(String original)
        {
            String codedOriginal = original
                .Replace("A", "A1").Replace("B", "B1").Replace("C", "C1")
                .Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            var result1 = codedOriginal.Replace("A1", "B").Replace("B1", "C").Replace("C1", "a").Replace("a1", "b").Replace("b1", "c").Replace("c1", "A");
            var result2 = codedOriginal.Replace("A1", "C").Replace("B1", "a").Replace("C1", "b").Replace("a1", "c").Replace("b1", "A").Replace("c1", "B");
            var result3 = codedOriginal.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c").Replace("a1", "A").Replace("b1", "B").Replace("c1", "C");
            var result4 = codedOriginal.Replace("A1", "b").Replace("B1", "c").Replace("C1", "A").Replace("a1", "B").Replace("b1", "C").Replace("c1", "a");
            var result5 = codedOriginal.Replace("A1", "c").Replace("B1", "A").Replace("C1", "B").Replace("a1", "C").Replace("b1", "a").Replace("c1", "b");

            var result = new string[] { original, result1, result2, result3, result3, result4, result5 };
          
            return result.Distinct().ToArray();
        }


        public String ReversePattern(String original)
        {
            var result = original;
            result = result.Replace("A", "A1").Replace("B", "B1").Replace("C", "C1");
            result = result.Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            result = result.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c");
            result = result.Replace("a1", "A").Replace("b1", "B").Replace("c1", "C");

            return result;
        }


        public String Normalize(String pattern)
        {
            String resultRaw = pattern.Replace("A", "X").Replace("a".ToString(), "x")
                .Replace("B", "Y").Replace("b".ToString(), "y")
                .Replace("C", "Z").Replace("c", "z");

            if (pattern[4] == 'A')
            {
                return pattern;
            }
            if (pattern[4] == 'a')
            {
                return resultRaw.Replace("x", "A").Replace("X", "a")
                         .Replace("y", "B").Replace("Y", "b")
                         .Replace("z", "C").Replace("Z", "c");
            }
            else if (pattern[4] == 'B')
            {
                return resultRaw.Replace("X", "B").Replace("x", "b")
                         .Replace("Y", "A").Replace("y", "a")
                         .Replace("Z", "C").Replace("z", "c");
            }
            else if (pattern[4] == 'b')
            {
                return resultRaw.Replace("x", "B").Replace("X", "b")
                         .Replace("y", "A").Replace("Y", "a")
                         .Replace("z", "C").Replace("Z", "c");
            }
            else if (pattern[4] == 'C')
            {
                return resultRaw.Replace("X", "C").Replace("x", "c")
                         .Replace("Y", "B").Replace("y", "b")
                         .Replace("Z", "A").Replace("z", "a");
            }
            else if (pattern[4] == 'c')
            {
                return resultRaw.Replace("x", "c").Replace("X", "C")
                         .Replace("y", "B").Replace("Y", "B")
                         .Replace("z", "A").Replace("Z", "a");
            }

            throw new Exception($"Unexpected char {pattern[4]}");

        }
    }
}
