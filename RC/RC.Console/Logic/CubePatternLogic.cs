using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;
using RC.Model.Patterns;
using RC.Model.Pieces;
using RC.Model.Slots;

namespace RC.Logic
{
    public class CubePatternLogic
    {
        public const String SideX = "a";
        public const String SideXn ="b";
        public const String SideY ="c";
        public const String SideYn ="d";
        public const String SideZ ="e";
        public const String SideZn = "f";

        public String[] Sides = new string[] { SideX, SideXn, SideY, SideYn, SideX, SideXn };

        public CubePatternLogic()
        {

        }

        public CubePatternModel GetPattern(String pattern)
        {
            String[] stickersRaw = pattern.Split(' ');

            var stickers = new List<PaternStickerTypes>(54);

            foreach (var stickerRaw in stickersRaw)
            {
                switch (stickerRaw)
                {
                    case SideX:
                        stickers.Add(PaternStickerTypes.X);
                        break;
                    case SideXn:
                        stickers.Add(PaternStickerTypes.Xn);
                        break;
                    case SideY:
                        stickers.Add(PaternStickerTypes.Y);
                        break;
                    case SideYn:
                        stickers.Add(PaternStickerTypes.Yn);
                        break;
                    case SideZ:
                        stickers.Add(PaternStickerTypes.Z);
                        break;
                    case SideZn:
                        stickers.Add(PaternStickerTypes.Zn);
                        break;

                }
            }

            return new CubePatternModel(
                stickers[0], stickers[1], stickers[2],
                stickers[3], stickers[4], stickers[5],
                stickers[6], stickers[7], stickers[8],

                stickers[9], stickers[10], stickers[11],
                stickers[12], stickers[13], stickers[14],
                stickers[15], stickers[16], stickers[17],

                stickers[18], stickers[19], stickers[20],
                stickers[21], stickers[22], stickers[23],
                stickers[24], stickers[25], stickers[26],

                stickers[27], stickers[28], stickers[29],
                stickers[30], stickers[31], stickers[32],
                stickers[33], stickers[34], stickers[35],

                stickers[36], stickers[37], stickers[38],
                stickers[39], stickers[40], stickers[41],
                stickers[42], stickers[43], stickers[44],

                stickers[45], stickers[46], stickers[47],
                stickers[48], stickers[49], stickers[50],
                stickers[51], stickers[52], stickers[53]);
        }

        //public PatternResultModel GetCompletenessDictionary()
        //{
        //    var result = new  PatternResultModel(6);

        //    result.Add(StickerColorTypes.Blue, new PatternResultModel());
        //    result.Add(StickerColorTypes.Green, new PatternResultModel());
        //    result.Add(StickerColorTypes.Orange, new PatternResultModel());
        //    result.Add(StickerColorTypes.Red, new PatternResultModel());
        //    result.Add(StickerColorTypes.White, new PatternResultModel());
        //    result.Add(StickerColorTypes.Yellow, new PatternResultModel());

        //    return result;
        //}

        public PatternResultModel GetCompleteness(StickerColorTypes colorToCheck,
            StickerColorTypes t52, StickerColorTypes t60, StickerColorTypes t7,
            StickerColorTypes t15, StickerColorTypes t0, StickerColorTypes t22,
            StickerColorTypes t30, StickerColorTypes t37, StickerColorTypes t45)
        {
            var result = new PatternResultModel();
            if (t52 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t60 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t7 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t15 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t0 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t22 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t30 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }
            if (t37 == colorToCheck)
            {
                result.TotalMatchingStickers += 1;
            }


            // TotalMatchingStickers

            return result;
        }
        public PatternResultModel GetWhiteCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Yellow,
                cube.NorthWest.StickerNorth.StickerColorType,
                cube.NorthEast.StickerNorth.StickerColorType,
                cube.FrontNorth.StickerNorth.StickerColorType,
                cube.BackNorth.StickerNorth.StickerColorType,
                cube.North.StickerNorth.StickerColorType,
                cube.FrontNorthEast.StickerNorth.StickerColorType,
                cube.BackNorthEast.StickerNorth.StickerColorType,
                cube.BackNorthWest.StickerNorth.StickerColorType,
                cube.FrontNorthWest.StickerNorth.StickerColorType
            );
        }

        public PatternResultModel GetYellowCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Yellow,
                cube.SouthEast.StickerSouth.StickerColorType,
                cube.SouthWest.StickerSouth.StickerColorType,
                cube.FrontSouth.StickerSouth.StickerColorType,
                cube.BackSouth.StickerSouth.StickerColorType,
                cube.South.StickerSouth.StickerColorType,
                cube.FrontSouthEast.StickerSouth.StickerColorType,
                cube.FrontSouthWest.StickerSouth.StickerColorType,
                cube.BackSouthEast.StickerSouth.StickerColorType,
                cube.BackSouthWest.StickerSouth.StickerColorType
            );
        }

        public PatternResultModel GetRedCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Red,
                cube.NorthWest.StickerWest.StickerColorType,
                cube.SouthWest.StickerWest.StickerColorType,
                cube.FrontWest.StickerWest.StickerColorType,
                cube.BackWest.StickerWest.StickerColorType,
                cube.West.StickerWest.StickerColorType,
                cube.FrontSouthWest.StickerWest.StickerColorType,
                cube.FrontNorthWest.StickerWest.StickerColorType,
                cube.BackSouthWest.StickerWest.StickerColorType,
                cube.BackNorthWest.StickerWest.StickerColorType
            );
        }

        public PatternResultModel GetOrangeCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Orange,
                cube.NorthEast.StickerEast.StickerColorType,
                cube.SouthEast.StickerEast.StickerColorType,
                cube.FrontEast.StickerEast.StickerColorType,
                cube.BackEast.StickerEast.StickerColorType,
                cube.East.StickerEast.StickerColorType,
                cube.FrontNorthEast.StickerEast.StickerColorType,
                cube.FrontSouthEast.StickerEast.StickerColorType,
                cube.BackNorthEast.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerEast.StickerColorType
            );
        }


        public PatternResultModel GetBlueCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Blue,
                cube.FrontNorth.StickerFront.StickerColorType,
                cube.FrontSouth.StickerFront.StickerColorType,
                cube.FrontWest.StickerFront.StickerColorType,
                cube.FrontEast.StickerFront.StickerColorType,
                cube.Front.StickerFront.StickerColorType,
                cube.FrontNorthEast.StickerFront.StickerColorType,
                cube.FrontSouthEast.StickerFront.StickerColorType,
                cube.FrontSouthWest.StickerFront.StickerColorType,
                cube.FrontNorthWest.StickerFront.StickerColorType
            );
        }

        public PatternResultModel GetGreenCompleteness(CubeModel cube)
        {
            return this.GetCompleteness(StickerColorTypes.Green,
                cube.BackNorth.StickerBack.StickerColorType,
                cube.BackSouth.StickerBack.StickerColorType,
                cube.BackWest.StickerBack.StickerColorType,
                cube.BackEast.StickerBack.StickerColorType,
                cube.Back.StickerBack.StickerColorType,
                cube.BackNorthEast.StickerBack.StickerColorType,
                cube.BackSouthEast.StickerBack.StickerColorType,
                cube.BackSouthWest.StickerBack.StickerColorType,
                cube.BackNorthWest.StickerBack.StickerColorType
            );
        }



        public KeyValuePair<StickerColorTypes, Int32> GetHighestCompleteness(Dictionary<StickerColorTypes, Int32> side)
        {
            Int32 max = 0;

            var result = default(KeyValuePair<StickerColorTypes, Int32>);
            foreach (KeyValuePair<StickerColorTypes, Int32> kvp in side)
            {
                if (kvp.Value > max)
                {
                    result = kvp;
                }
            }

            return result;
        }

        //public KeyValuePair<StickerColorTypes, Int32> GetHighestCompleteness(Dictionary<StickerColorTypes, Int32> side)
        //{
        //    Int32 max = 0;

        //    var result = default(KeyValuePair<StickerColorTypes, Int32>);
        //    foreach (KeyValuePair<StickerColorTypes, Int32> kvp in side)
        //    {
        //        if (kvp.Value > max)
        //        {
        //            result = kvp;
        //        }
        //    }

        //    return result;
        //}

        public void GetSideCompleteness(CubeModel cube)
        {
            var sideColorTotals = new Dictionary<StickerColorTypes, PatternResultModel>();

            sideColorTotals[StickerColorTypes.White] = this.GetWhiteCompleteness(cube);
            sideColorTotals[StickerColorTypes.Yellow] = this.GetYellowCompleteness(cube);

            sideColorTotals[StickerColorTypes.Blue] = this.GetBlueCompleteness(cube);
            sideColorTotals[StickerColorTypes.Green] = this.GetGreenCompleteness(cube);

            sideColorTotals[StickerColorTypes.Red] = this.GetRedCompleteness(cube);
            sideColorTotals[StickerColorTypes.Orange] = this.GetOrangeCompleteness(cube);

        }

        //public StickerColorTypes GetMostCompleteSide(CubeModel cube)
        //{
            
        //    foreach (String side in this.Sides)
        //    {


        //    }

            
        //    if (cube.NorthEast.StickerNorth.StickerColorType  == StickerColorTypes.)
        //    cube.NorthWest.StickerNorth =
        //    cube.FrontNorth.StickerNorth =
        //    cube.BackNorth.StickerNorth =

        //    cube.FrontNorthEast.StickerNorth =
        //    cube.BackNorthEast.StickerNorth =
        //    cube.BackNorthWest.StickerNorth =
        //    cube.FrontNorthWest.StickerNorth =


        //    cube.SouthEast.StickerSouth =
        //    cube.SouthWest.StickerSouth =
        //    cube.FrontSouth.StickerSouth =
        //    cube.BackSouth.StickerSouth =


        //    cube.FrontSouthEast.StickerSouth =
        //    cube.FrontSouthWest.StickerSouth =
        //    cube.BackSouthEast.StickerSouth =
        //    cube.BackSouthWest.StickerSouth =

        //    cube.NorthWest.StickerWest =
        //    cube.SouthWest.StickerWest =
        //    cube.FrontWest.StickerWest =
        //    cube.BackWest.StickerWest =

        //    cube.FrontSouthWest.StickerWest =
        //    cube.FrontNorthWest.StickerWest =
        //    cube.BackSouthWest.StickerWest =
        //    cube.BackNorthWest.StickerWest =


        //    cube.NorthEast.StickerEast =
        //    cube.SouthEast.StickerEast =
        //    cube.FrontEast.StickerEast =
        //    cube.BackEast.StickerEast =

        //    cube.FrontNorthEast.StickerEast =
        //    cube.FrontSouthEast.StickerEast =
        //    cube.BackNorthEast.StickerEast =
        //    cube.BackSouthEast.StickerEast =


        //    cube.FrontNorth.StickerFront =
        //    cube.FrontSouth.StickerFront =
        //    cube.FrontWest.StickerFront =
        //    cube.FrontEast.StickerFront =

        //    cube.FrontNorthEast.StickerFront =
        //    cube.FrontSouthEast.StickerFront =
        //    cube.FrontSouthWest.StickerFront =
        //    cube.FrontNorthWest.StickerFront =


        //    cube.BackNorth.StickerBack =
        //    cube.BackSouth.StickerBack =
        //    cube.BackWest.StickerBack =
        //    cube.BackEast.StickerBack =


        //    cube.BackNorthEast.StickerBack =
        //    cube.BackSouthEast.StickerBack =
        //    cube.BackSouthWest.StickerBack =
        //    cube.BackNorthWest.StickerBack =
        //}

        public CubePatternModel GetPattern(CubeModel cube)
        {

            StickerColorTypes mostCompleteSide;
            

            var stickers = new List<PaternStickerTypes>(54);

            return new CubePatternModel(
                stickers[0], stickers[1], stickers[2],
                stickers[3], stickers[4], stickers[5],
                stickers[6], stickers[7], stickers[8],

                stickers[9], stickers[10], stickers[11],
                stickers[12], stickers[13], stickers[14],
                stickers[15], stickers[16], stickers[17],

                stickers[18], stickers[19], stickers[20],
                stickers[21], stickers[22], stickers[23],
                stickers[24], stickers[25], stickers[26],

                stickers[27], stickers[28], stickers[29],
                stickers[30], stickers[31], stickers[32],
                stickers[33], stickers[34], stickers[35],

                stickers[36], stickers[37], stickers[38],
                stickers[39], stickers[40], stickers[41],
                stickers[42], stickers[43], stickers[44],

                stickers[45], stickers[46], stickers[47],
                stickers[48], stickers[49], stickers[50],
                stickers[51], stickers[52], stickers[53]);

        }

        public String SavePattern(CubePatternModel cubePattern)
        {
            String result = " " +
            cubePattern.North52 + " " +
            cubePattern.North60 + " " +
            cubePattern.North7 + " " +
            cubePattern.North15 + " " +
            cubePattern.North0 + " " +
            cubePattern.North22 + " " +
            cubePattern.North30 + " " +
            cubePattern.North37 + " " +
            cubePattern.North45 + " " +

            cubePattern.South52 + " " +
            cubePattern.South60 + " " +
            cubePattern.South7 + " " +
            cubePattern.South15 + " " +
            cubePattern.South0 + " " +
            cubePattern.South22 + " " +
            cubePattern.South30 + " " +
            cubePattern.South37 + " " +
            cubePattern.South45 + " " +

            cubePattern.East52 + " " +
            cubePattern.East60 + " " +
            cubePattern.East7 + " " +
            cubePattern.East15 + " " +
            cubePattern.East0 + " " +
            cubePattern.East22 + " " +
            cubePattern.East30 + " " +
            cubePattern.East37 + " " +
            cubePattern.East45 + " " +

            cubePattern.West52 + " " +
            cubePattern.West60 + " " +
            cubePattern.West7 + " " +
            cubePattern.West15 + " " +
            cubePattern.West0 + " " +
            cubePattern.West22 + " " +
            cubePattern.West30 + " " +
            cubePattern.West37 + " " +
            cubePattern.West45 + " " +

            cubePattern.Front52 + " " +
            cubePattern.Front60 + " " +
            cubePattern.Front7 + " " +
            cubePattern.Front15 + " " +
            cubePattern.Front0 + " " +
            cubePattern.Front22 + " " +
            cubePattern.Front30 + " " +
            cubePattern.Front37 + " " +
            cubePattern.Front45 + " " +

            cubePattern.Back52 + " " +
            cubePattern.Back60 + " " +
            cubePattern.Back7 + " " +
            cubePattern.Back15 + " " +
            cubePattern.Back0 + " " +
            cubePattern.Back22 + " " +
            cubePattern.Back30 + " " +
            cubePattern.Back37 + " " +
            cubePattern.Back45;

            return result;
        }
    }
}



//var sideColorTotals = new Dictionary<StickerColorTypes, Dictionary<StickerColorTypes, PatternModel>>();

//sideColorTotals.Add(StickerColorTypes.Blue, this.GetFrontCompleteness(cube));
//sideColorTotals.Add(StickerColorTypes.Green, this.GetBackCompleteness(cube));
//sideColorTotals.Add(StickerColorTypes.Orange, this.GetEastCompleteness(cube));
//sideColorTotals.Add(StickerColorTypes.Red, this.GetWestCompleteness(cube));
//sideColorTotals.Add(StickerColorTypes.White, this.GetNorthCompleteness(cube));
//sideColorTotals.Add(StickerColorTypes.Yellow, this.GetSouthCompleteness(cube));


//KeyValuePair<StickerColorTypes, Int32> kvpFront = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Blue]);
//KeyValuePair<StickerColorTypes, Int32> kvpGreen = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Green]);
//KeyValuePair<StickerColorTypes, Int32> kvpOrange = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Orange]);
//KeyValuePair<StickerColorTypes, Int32> kvpRed = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Red]);
//KeyValuePair<StickerColorTypes, Int32> kvpWhite = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.White]);
//KeyValuePair<StickerColorTypes, Int32> kvpYellow = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Yellow]);


//KeyValuePair<StickerColorTypes, Int32> kvpBlue = sideColorTotals[StickerColorTypes.Blue].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
//KeyValuePair<StickerColorTypes, Int32> kvpGreen = sideColorTotals[StickerColorTypes.Green].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
//KeyValuePair<StickerColorTypes, Int32> kvpOrange = sideColorTotals[StickerColorTypes.Orange].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
//KeyValuePair<StickerColorTypes, Int32> kvpRed = sideColorTotals[StickerColorTypes.Red].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
//KeyValuePair<StickerColorTypes, Int32> kvpWhite = sideColorTotals[StickerColorTypes.White].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
//KeyValuePair<StickerColorTypes, Int32> kvpYellow = sideColorTotals[StickerColorTypes.Yellow].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);