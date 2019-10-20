using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Model;

namespace RC.Logic
{
    public class CubeFacePatternLogic: PatternLogicBase
    {


        public String VisualizeSide(String pattern)
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
            
            return new String[] { east, north, front, west, south, back };
        }

        public string[] GetCubeFacePatterns(String cubePattern)
        {
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

            return new String[] { east, north, front, west, south, back };
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
                    resultsWithDups.Add(this.ReversePattern(rotatedPattern));                }
            }

            String[] results = resultsWithDups.Distinct().ToArray();

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
                .Replace("A", "D").Replace("B", "E").Replace("C", "F")
                .Replace("X", "U").Replace("Y", "V").Replace("Z", "W");

            var resultsRaw = new List<String>();

            resultsRaw.Add(codedOriginal.Replace("D", "B").Replace("U", "Y").Replace("E", "A").Replace("V", "X"));
            resultsRaw.Add(codedOriginal.Replace("D", "C").Replace("U", "Z").Replace("F", "A").Replace("W", "X"));

            resultsRaw.Add(codedOriginal.Replace("E", "C").Replace("V", "Z").Replace("F", "B").Replace("W", "Y"));
            resultsRaw.Add(codedOriginal.Replace("E", "A").Replace("V", "X").Replace("D", "B").Replace("U", "Y"));

            resultsRaw.Add(codedOriginal.Replace("F", "A").Replace("W", "X").Replace("D", "C").Replace("U", "Z"));
            resultsRaw.Add(codedOriginal.Replace("F", "B").Replace("W", "Y").Replace("E", "C").Replace("V", "Z"));

            foreach (var resultRaw in resultsRaw)
            {
                var result = resultRaw.Replace("D", "A").Replace("E", "B").Replace("F", "C").Replace("U", "X").Replace("V", "Y").Replace("W", "Z");

                results.Add(result);
            }

            return this.NormalizeCubes(results.Distinct().ToArray());
        }
       
        public String[] ShiftPatternComprehensive(String original)
        {
            String codedOriginal = original
                .Replace("A", "D").Replace("B", "E").Replace("C", "F")
                .Replace("X", "U").Replace("Y", "V").Replace("Z", "W");

            var result1 = codedOriginal.Replace("D", "B").Replace("E", "C").Replace("F", "X").Replace("U", "Y").Replace("V", "Z").Replace("W", "A");
            var result2 = codedOriginal.Replace("D", "C").Replace("E", "X").Replace("F", "Y").Replace("U", "Z").Replace("V", "A").Replace("W", "B");
            var result3 = codedOriginal.Replace("D", "X").Replace("E", "Y").Replace("F", "Z").Replace("U", "A").Replace("V", "B").Replace("W", "C");
            var result4 = codedOriginal.Replace("D", "Y").Replace("E", "Z").Replace("F", "A").Replace("U", "B").Replace("V", "C").Replace("W", "X");
            var result5 = codedOriginal.Replace("D", "Z").Replace("E", "A").Replace("F", "B").Replace("U", "C").Replace("V", "X").Replace("W", "Y");

            var rawResults = (new string[] { original, result1, result2, result3, result3, result4, result5 }).Distinct().ToArray();

            return this.NormalizeCubes(rawResults);
        }


        public String ReversePattern(String original)
        {
            var result = original
                .Replace("A", "D").Replace("B", "E").Replace("C", "F")
                .Replace("X", "U").Replace("Y", "V").Replace("Z", "W")
                .Replace("D", "X").Replace("E", "Y").Replace("F", "Z")
                .Replace("U", "A").Replace("V", "B").Replace("W", "C");

            return this.NormalizeCube(result);
        }

        public String NormalizeCube(String rawCube)
        {
            Int32 startingPoint = 0;
            string[] resultSegments = rawCube.ToLookup(c => Math.Floor(startingPoint++ / 9M))
                .Select(e => new String(e.ToArray())).ToArray();

            String segment1 = String.Empty;
            String segment2 = String.Empty;
            String segment3 = String.Empty;
            String segment4 = String.Empty;
            String segment5 = String.Empty;
            String segment6 = String.Empty;

            for (var i = 0; i < 6; i++)
            {
                switch (resultSegments[i].ToCharArray()[4])
                {
                    case 'A':
                        segment1 = resultSegments[i];
                        break;
                    case 'B':
                        segment2 = resultSegments[i];
                        break;
                    case 'C':
                        segment3 = resultSegments[i];
                        break;
                    case 'X':
                        segment4 = resultSegments[i];
                        break;
                    case 'Y':
                        segment5 = resultSegments[i];
                        break;
                    case 'Z':
                        segment6 = resultSegments[i];
                        break;
                    default:
                        throw new Exception("Unknown Char");
                }
            }

            return $"{segment1}{segment2}{segment3}{segment4}{segment5}{segment6}";
        }


        public String[] NormalizeCubes(String[] rawCubs)
        {
            var results = new List<String>();

            foreach (String rawCubeSide in rawCubs)
            {
                results.Add(this.NormalizeCube(rawCubeSide));
            }

            return results.ToArray();
        }
    }
}
