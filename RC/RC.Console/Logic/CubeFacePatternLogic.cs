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

        public String[] GetAllFacePatterns(String original)
        {
            var resultWithDups = new List<String>();
            String[] shiftedPatterns = this.ShiftSwitchAndMirrorFacePatterns(original);
            foreach (var shiftedPattern in shiftedPatterns)
            {
                foreach (var rotatedPattern in this.RotateFacePattern(shiftedPattern))
                {
                    resultWithDups.Add(rotatedPattern);
                    resultWithDups.Add(this.ReversePattern(rotatedPattern));

                    var reversedRotatedPattern = new String(shiftedPattern.Reverse().ToArray());
                    resultWithDups.Add(reversedRotatedPattern);
                    resultWithDups.Add(this.ReversePattern(reversedRotatedPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();

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
            if (result.ToArray().Count(x => x == "A") > 9
                   || result.ToArray().Count(x => x == "B") > 9
                   || result.ToArray().Count(x => x == "C") > 9
                   || result.ToArray().Count(x => x == "a") > 9
                   || result.ToArray().Count(x => x == "b") > 9
                   || result.ToArray().Count(x => x == "c") > 9)
            {
                throw new Exception("Invalid ShiftPatternComprehensive Result: " + result);
            }

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

    }
}
