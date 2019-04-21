//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using RC.Enumerations;
//using RC.Model;
//using RC.Model.Patterns;
//using RC.Model.Slots; using RC.Model.Stickers;

//namespace RC.Logic
//{
//    public class CubePatternLogic
//    {
//        public const String SideX = "a";
//        public const String SideXn ="b";
//        public const String SideY ="c";
//        public const String SideYn ="d";
//        public const String SideZ ="e";
//        public const String SideZn = "f";

//        public String[] Sides = new string[] { SideX, SideXn, SideY, SideYn, SideX, SideXn };

//        public CubePatternLogic()
//        {

//        }

//        //public CubePatternModel GetPattern(String pattern)
//        //{
//        //    String[] stickersRaw = pattern.Split(' ');

//        //    var stickers = new List<PaternStickerTypes>(54);

//        //    foreach (var stickerRaw in stickersRaw)
//        //    {
//        //        switch (stickerRaw)
//        //        {
//        //            case SideX:
//        //                stickers.Add(PaternStickerTypes.X);
//        //                break;
//        //            case SideXn:
//        //                stickers.Add(PaternStickerTypes.Xn);
//        //                break;
//        //            case SideY:
//        //                stickers.Add(PaternStickerTypes.Y);
//        //                break;
//        //            case SideYn:
//        //                stickers.Add(PaternStickerTypes.Yn);
//        //                break;
//        //            case SideZ:
//        //                stickers.Add(PaternStickerTypes.Z);
//        //                break;
//        //            case SideZn:
//        //                stickers.Add(PaternStickerTypes.Zn);
//        //                break;

//        //        }
//        //    }

//        //    return new CubePatternModel(
//        //        stickers[0], stickers[1], stickers[2],
//        //        stickers[3], stickers[4], stickers[5],
//        //        stickers[6], stickers[7], stickers[8],

//        //        stickers[9], stickers[10], stickers[11],
//        //        stickers[12], stickers[13], stickers[14],
//        //        stickers[15], stickers[16], stickers[17],

//        //        stickers[18], stickers[19], stickers[20],
//        //        stickers[21], stickers[22], stickers[23],
//        //        stickers[24], stickers[25], stickers[26],

//        //        stickers[27], stickers[28], stickers[29],
//        //        stickers[30], stickers[31], stickers[32],
//        //        stickers[33], stickers[34], stickers[35],

//        //        stickers[36], stickers[37], stickers[38],
//        //        stickers[39], stickers[40], stickers[41],
//        //        stickers[42], stickers[43], stickers[44],

//        //        stickers[45], stickers[46], stickers[47],
//        //        stickers[48], stickers[49], stickers[50],
//        //        stickers[51], stickers[52], stickers[53]);
//        //}

//        public Dictionary<StickerColorTypes, PatternResultModel> GetCompletenessDictionary()
//        {
//            var result = new Dictionary<StickerColorTypes, PatternResultModel>(6);

//            result.Add(StickerColorTypes.Blue, new PatternResultModel());
//            result.Add(StickerColorTypes.Green, new PatternResultModel());
//            result.Add(StickerColorTypes.Orange, new PatternResultModel());
//            result.Add(StickerColorTypes.Red, new PatternResultModel());
//            result.Add(StickerColorTypes.White, new PatternResultModel());
//            result.Add(StickerColorTypes.Yellow, new PatternResultModel());

//            return result;
//        }

//        public CubePatternFaceModel GetCompleteness(CubeModel cube, StickerColorTypes colorToCheck)
//        {

//        }

//        public PatternResultModel GetCompleteness(CubeModel cube, StickerColorTypes colorToCheck)
//        {
//            var result = new PatternResultModel();

//            result.PatternFaceType = this.GetFaceCompleteness(cube.North.AdjacentSideSlots.);
//            result.PatternAdjacentType = this.GetAdjacentCompleteness(cube.North, colorToCheck);

//            return result;
//        }


//        public PatternNorthFaceResultModel GetFaceCompleteness(PieceNorthModel pieceMiddle, StickerColorTypes colorToCheck)
//        {
//            StickerColorTypes f00 = pieceMiddle.Stickers.Single().StickerColorType;

//            StickerColorTypes f52;
//            StickerColorTypes f60;
//            StickerColorTypes f07;
//            StickerColorTypes f15;
//            StickerColorTypes f22;
//            StickerColorTypes f30;
//            StickerColorTypes f37;
//            StickerColorTypes f45;

//            var slotSideCount = new Dictionary<SlotSideModelBase, Int32>();

//            foreach (SlotSideModelBase slotSide in pieceMiddle.AdjacentSideSlots)
//            {
//                slotSide.AdjacentCornerSlots.Where(x => x.AdjacentSideSlots.)

//                foreach (SlotCornerModelBase slotCorner in slotSide.AdjacentCornerSlots)
//                {
//                    slotCorner.GetStickers();

//                    foreach (SlotSideModelBase slotCornerSide in slotCorner.AdjacentSideSlots)
//                    {
//                        slotCornerSide.GetStickers();

//                    }
//                }
//            }
//        }

//        public PatternFaceResultModel GetFaceCompleteness(StickerColorTypes colorToCheck,
//            StickerColorTypes t52, StickerColorTypes t60, StickerColorTypes t07,
//            StickerColorTypes t15, StickerColorTypes t00, StickerColorTypes t22,
//            StickerColorTypes t30, StickerColorTypes t37, StickerColorTypes t45)
//        {
//            var result = new PatternFaceResultModel();
//            if (t52 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (t60 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (t07 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (t15 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (t00 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Middles += 1;
//            }
//            if (t22 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (t30 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (t37 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (t45 == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }


//            if (result.Stickers == 0)
//            {
//                result.Pattern = PatternFaceTypes.None;
//            }
//            else if (result.Stickers == 1)
//            {
//                if (result.Corners == 1)
//                {
//                    result.Pattern = PatternFaceTypes.A1;
//                }
//                else if (result.Sides == 1)
//                {
//                    result.Pattern = PatternFaceTypes.A2;
//                }
//                else
//                {
//                    result.Pattern = PatternFaceTypes.A3;

//                }
//            }
//            else if (result.Stickers == 2)
//            {
//                if (result.Middles > 0)
//                {
//                    if (result.Corners == 1)
//                    {
//                        result.Pattern = PatternFaceTypes.B1;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternFaceTypes.B2;
//                    }
//                }
//                else if (result.Sides == 2)
//                {
//                    if (
//                           (t60 == colorToCheck && (t45 == colorToCheck || t15 == colorToCheck))
//                        || (t15 == colorToCheck && (t60 == colorToCheck || t30 == colorToCheck))
//                        || (t30 == colorToCheck && (t15 == colorToCheck || t45 == colorToCheck))
//                        || (t45 == colorToCheck && (t30 == colorToCheck || t60 == colorToCheck))
//                      )
//                    {
//                        result.Pattern = PatternFaceTypes.B3;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternFaceTypes.B4;
//                    }
//                }
//                else
//                {
//                    if (
//                             (t07 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
//                          || (t22 == colorToCheck && (t07 == colorToCheck || t37 == colorToCheck))
//                          || (t37 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
//                          || (t52 == colorToCheck && (t37 == colorToCheck || t07 == colorToCheck))
//                        )
//                    {
//                        result.Pattern = PatternFaceTypes.B5;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternFaceTypes.B6;
//                    }
//                }
//            }
//            else if (result.Stickers == 3)
//            {
//                if (result.Middles > 0)
//                {
//                    if (result.Sides == 2)
//                    {
//                        if (
//                               (t60 == colorToCheck && (t45 == colorToCheck || t15 == colorToCheck))
//                            || (t15 == colorToCheck && (t60 == colorToCheck || t30 == colorToCheck))
//                            || (t30 == colorToCheck && (t15 == colorToCheck || t45 == colorToCheck))
//                            || (t45 == colorToCheck && (t30 == colorToCheck || t60 == colorToCheck))
//                          )
//                        {
//                            result.Pattern = PatternFaceTypes.C1;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternFaceTypes.C2;
//                        }
//                    }
//                    else if (result.Corners == 2)
//                    {
//                        if (
//                                 (t07 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
//                              || (t22 == colorToCheck && (t07 == colorToCheck || t37 == colorToCheck))
//                              || (t37 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
//                              || (t52 == colorToCheck && (t37 == colorToCheck || t07 == colorToCheck))
//                            )
//                        {
//                            result.Pattern = PatternFaceTypes.C3;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternFaceTypes.C4;
//                        }
//                    }
//                    else
//                    {
//                        if (
//                                (t07 == colorToCheck && (t15 == colorToCheck || t60 == colorToCheck))
//                             || (t22 == colorToCheck && (t15 == colorToCheck || t30 == colorToCheck))
//                             || (t37 == colorToCheck && (t30 == colorToCheck || t45 == colorToCheck))
//                             || (t52 == colorToCheck && (t45 == colorToCheck || t60 == colorToCheck))
//                           )
//                        {
//                            result.Pattern = PatternFaceTypes.C5;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternFaceTypes.C6;
//                        }
//                    }
//                }
//                else
//                {
//                    if (result.Sides == 3)
//                    {
//                        result.Pattern = PatternFaceTypes.C7;
//                    }
//                    else if (result.Corners == 3)
//                    {
//                        result.Pattern = PatternFaceTypes.C8;
//                    }
//                    else if (result.Sides == 2)
//                    {
//                        result.Pattern = PatternFaceTypes.C9;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternFaceTypes.C10;
//                    }
//                }
//            }

//            // Stickers

//            return result;
//        }

//        public PatternAdjacentResultModel GetAdjacentCompleteness(StickerColorTypes colorToCheck,
//                                            /* 
//                                                                              */StickerColorTypes n,
//                                /*                                  
//                                                      */StickerColorTypes nw, StickerColorTypes ne,
//               /* 
//                    */StickerColorTypes wm, StickerColorTypes w, StickerColorTypes e, StickerColorTypes em,
//                                /*                                 
//                                                      */StickerColorTypes sw, StickerColorTypes se,
//                                            /*                                        
//                                                                              */StickerColorTypes s
//            )
//        {

//            var result = new PatternAdjacentResultModel();
//            if (n == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (nw == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (ne == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (wm == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Middles += 1;
//            }
//            if (w == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (e == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Sides += 1;
//            }
//            if (em == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Middles += 1;
//            }
//            if (sw == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (se == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }
//            if (s == colorToCheck)
//            {
//                result.Stickers += 1;
//                result.Corners += 1;
//            }


//            if (result.Stickers == 0)
//            {
//                result.Pattern = PatternAdjacentTypes.None;
//            }
//            else if (result.Stickers == 1)
//            {
//                if (result.Sides == 1)
//                {
//                    if (w == colorToCheck)
//                    {
//                        result.Pattern = PatternAdjacentTypes.A3;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//                else if (result.Corners == 1)
//                {
//                    if (n == colorToCheck)
//                    {
//                        result.Pattern = PatternAdjacentTypes.A1;
//                    }
//                    else if (nw == colorToCheck)
//                    {
//                        result.Pattern = PatternAdjacentTypes.A2;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//                else
//                {
//                    if (wm == colorToCheck)
//                    {
//                        result.Pattern = PatternAdjacentTypes.A4;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//            }
//            else if (result.Stickers == 2)
//            {
//                if (result.Corners > 1)
//                {
//                    if (n == colorToCheck)
//                    {
//                        if (s == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B4;
//                        }
//                        else if (sw == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B3;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else if (nw == colorToCheck)
//                    {
//                        if (sw == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B9;
//                        }
//                        else if (se == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B10;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//                else if (result.Sides == 1 && result.Corners == 1)
//                {
//                    if (w == colorToCheck)
//                    {
//                        if (n == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B2;
//                        }
//                        else if (nw == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B6;
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else if (nw == colorToCheck && e == colorToCheck)
//                    {
//                        result.Pattern = PatternAdjacentTypes.B7;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//                else if (result.Sides == 1 && result.Middles == 1)
//                {
//                    if (n == sw)
//                    {
//                        result.Pattern = PatternAdjacentTypes.B11;
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.B12;
//                    }
//                }
//                else
//                {
//                    if (w == colorToCheck)
//                    {
//                        if (n == colorToCheck)
//                        {
//                            result.Pattern = PatternAdjacentTypes.B1;
//                        }
//                        else if (nw == colorToCheck)
//                        {
//                            if (wm == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.B5;
//                            }
//                            else if (em == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.B8;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//            }
//            else if (result.Stickers == 3)
//            {
//                if (result.Middles > 0)
//                {
//                    if (wm == colorToCheck)
//                    {
//                        if (n == colorToCheck)
//                        {
//                            if (w == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C1;
//                            }
//                            else if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C2;
//                            }
//                            else if (s == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C3;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else if (nw == colorToCheck)
//                        {
//                            if (w == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C6;
//                            }
//                            else if (e == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C7;
//                            }
//                            else if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.C8;
//                            }
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//                else
//                {

//                    if (n == colorToCheck)
//                    {
//                        if (w == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {

//                                result.Pattern = PatternAdjacentTypes.C4;
//                            }
//                            else if (s == colorToCheck)
//                            {

//                                result.Pattern = PatternAdjacentTypes.C5;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else if (nw == colorToCheck)
//                    {
//                        if (w == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {

//                                result.Pattern = PatternAdjacentTypes.C9;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else
//                        {
//                            result.Pattern = PatternAdjacentTypes.None;
//                        }
//                    }
//                    else
//                    {
//                        result.Pattern = PatternAdjacentTypes.None;
//                    }
//                }
//            }
//            else
//            {
//                if (wm == colorToCheck)
//                {
//                    if (n == colorToCheck)
//                    {
//                        if (w == colorToCheck)
//                        {
//                            if (s == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D1;
//                            }
//                            else if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D3;
//                            }
//                            else if (se == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D4;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else if (e == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D5;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                    }
//                    else if (nw == colorToCheck)
//                    {
//                        if (w == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D6;
//                            }
//                            else if (se == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D7;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else if (e == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D7;
//                            }
//                            else if (se == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D7;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                    }
//                }
//                else if (em == colorToCheck)
//                {
//                    if (nw == colorToCheck)
//                    {
//                        if (e == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D7;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                        else if (w == colorToCheck)
//                        {
//                            if (sw == colorToCheck)
//                            {
//                                result.Pattern = PatternAdjacentTypes.D7;
//                            }
//                            else
//                            {
//                                result.Pattern = PatternAdjacentTypes.None;
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    result.Pattern = PatternAdjacentTypes.None;
//                }

//            }
//            // Stickers

//            return result;
//        }

//        public PatternAdjacentFaceResultModel GetWhiteCompleteness(CubeModel cube)
//        {
//            var result = new PatternAdjacentFaceResultModel();
//            result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.White,
//                cube.NorthWest.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType,
//                cube.BackNorth.StickerNorth.StickerColorType,  cube.North.StickerNorth.StickerColorType,cube.FrontNorthEast.StickerNorth.StickerColorType,
//                cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthWest.StickerNorth.StickerColorType, cube.FrontNorthWest.StickerNorth.StickerColorType
//            );

//            if (result.PatternFaceResult.Pattern == PatternFaceTypes.None) { }

//            result.PatternAdjacentResult = this.GetAdjacentCompleteness(StickerColorTypes.White,
//                cube.BackNorthEast.StickerBack.StickerColorType,
//                cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
//                cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType, 
//                cube.FrontNorthEast.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
//                cube.FrontNorthEast.StickerFront.StickerColorType
//            );

//            return result;
//        }

//        //public PatternAdjacentFaceResultModel GetYellowCompleteness(CubeModel cube)
//        //{
//        //    var result = new PatternAdjacentFaceResultModel();
//        //    result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.Yellow,
//        //        cube.SouthEast.StickerSouth.StickerColorType,
//        //        cube.SouthWest.StickerSouth.StickerColorType,
//        //        cube.FrontSouth.StickerSouth.StickerColorType,
//        //        cube.BackSouth.StickerSouth.StickerColorType,
//        //        cube.South.StickerSouth.StickerColorType,
//        //        cube.FrontSouthEast.StickerSouth.StickerColorType,
//        //        cube.FrontSouthWest.StickerSouth.StickerColorType,
//        //        cube.BackSouthEast.StickerSouth.StickerColorType,
//        //        cube.BackSouthWest.StickerSouth.StickerColorType
//        //    );

//        //     result.PatternAdjacentResult = this.GetAdjacentCompleteness(StickerColorTypes.Yellow,
//        //        cube.BackSouthWest.StickerBack.StickerColorType,
//        //        cube.BackSouthWest.StickerSouth.StickerColorType,
//        //        cube.BackSouthWest.StickerWest.StickerColorType,
//        //        cube.South.StickerSouth.StickerColorType,
//        //        cube.SouthWest.StickerSouth.StickerColorType,
//        //        cube.SouthWest.StickerWest.StickerColorType,
//        //        cube.West.StickerWest.StickerColorType,
//        //        cube.FrontSouthWest.StickerSouth.StickerColorType,
//        //        cube.FrontSouthWest.StickerWest.StickerColorType,
//        //        cube.FrontSouthWest.StickerFront.StickerColorType
//        //    );


//        //    return result;
//        //}

//        //public PatternAdjacentFaceResultModel GetRedCompleteness(CubeModel cube)
//        //{
//        //    var result = new PatternAdjacentFaceResultModel();
//        //    result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.Red,
//        //        cube.NorthWest.StickerWest.StickerColorType,
//        //        cube.SouthWest.StickerWest.StickerColorType,
//        //        cube.FrontWest.StickerWest.StickerColorType,
//        //        cube.BackWest.StickerWest.StickerColorType,
//        //        cube.West.StickerWest.StickerColorType,
//        //        cube.FrontSouthWest.StickerWest.StickerColorType,
//        //        cube.FrontNorthWest.StickerWest.StickerColorType,
//        //        cube.BackSouthWest.StickerWest.StickerColorType,
//        //        cube.BackNorthWest.StickerWest.StickerColorType
//        //    );

//        //    result.PatternAdjacentResult = this.GetAdjacentCompleteness(StickerColorTypes.Red,
//        //      cube.BackNorthEast.StickerNorth.StickerColorType,
//        //      cube.BackNorthEast.StickerEast.StickerColorType,
//        //      cube.BackNorthEast.StickerBack.StickerColorType,
//        //      cube.Back.StickerBack.StickerColorType,
//        //      cube.BackEast.StickerEast.StickerColorType,
//        //      cube.BackEast.StickerBack.StickerColorType,
//        //      cube.Back.StickerBack.StickerColorType,
//        //      cube.BackSouthEast.StickerEast.StickerColorType,
//        //      cube.BackSouthEast.StickerBack.StickerColorType,
//        //      cube.BackSouthEast.StickerSouth.StickerColorType
//        //  );

//        //    return result;
//        //}

//        //public PatternAdjacentFaceResultModel GetOrangeCompleteness(CubeModel cube)
//        //{
//        //    var result = new PatternAdjacentFaceResultModel();
//        //    result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.Orange,
//        //        cube.NorthEast.StickerEast.StickerColorType,
//        //        cube.SouthEast.StickerEast.StickerColorType,
//        //        cube.FrontEast.StickerEast.StickerColorType,
//        //        cube.BackEast.StickerEast.StickerColorType,
//        //        cube.East.StickerEast.StickerColorType,
//        //        cube.FrontNorthEast.StickerEast.StickerColorType,
//        //        cube.FrontSouthEast.StickerEast.StickerColorType,
//        //        cube.BackNorthEast.StickerEast.StickerColorType,
//        //        cube.BackSouthEast.StickerEast.StickerColorType
//        //    );

//        //    result.PatternAdjacentResult = this.GetAdjacentCompleteness(StickerColorTypes.Orange,
//        //      cube.FrontSouthEast.StickerSouth.StickerColorType,
//        //      cube.FrontSouthEast.StickerEast.StickerColorType,
//        //      cube.FrontSouthEast.StickerFront.StickerColorType,
//        //      cube.East.StickerEast.StickerColorType,
//        //      cube.FrontEast.StickerEast.StickerColorType,
//        //      cube.FrontEast.StickerFront.StickerColorType,
//        //      cube.Front.StickerFront.StickerColorType,
//        //      cube.FrontSouthEast.StickerEast.StickerColorType,
//        //      cube.FrontSouthEast.StickerFront.StickerColorType,
//        //      cube.FrontSouthEast.StickerSouth.StickerColorType
//        //  );

//        //    return result;
//        //}


//        //public PatternAdjacentFaceResultModel GetBlueCompleteness(CubeModel cube)
//        //{
//        //    var result = new PatternAdjacentFaceResultModel();
//        //    result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.Blue,
//        //        cube.FrontNorth.StickerFront.StickerColorType,
//        //        cube.FrontSouth.StickerFront.StickerColorType,
//        //        cube.FrontWest.StickerFront.StickerColorType,
//        //        cube.FrontEast.StickerFront.StickerColorType,
//        //        cube.Front.StickerFront.StickerColorType,
//        //        cube.FrontNorthEast.StickerFront.StickerColorType,
//        //        cube.FrontSouthEast.StickerFront.StickerColorType,
//        //        cube.FrontSouthWest.StickerFront.StickerColorType,
//        //        cube.FrontNorthWest.StickerFront.StickerColorType
//        //    );

//        //    return result;
//        //}

//        //public PatternAdjacentFaceResultModel GetGreenCompleteness(CubeModel cube)
//        //{
//        //    var result = new PatternAdjacentFaceResultModel();
//        //    result.PatternFaceResult = this.GetFaceCompleteness(StickerColorTypes.Green,
//        //        cube.BackNorth.StickerBack.StickerColorType,
//        //        cube.BackSouth.StickerBack.StickerColorType,
//        //        cube.BackWest.StickerBack.StickerColorType,
//        //        cube.BackEast.StickerBack.StickerColorType,
//        //        cube.Back.StickerBack.StickerColorType,
//        //        cube.BackNorthEast.StickerBack.StickerColorType,
//        //        cube.BackSouthEast.StickerBack.StickerColorType,
//        //        cube.BackSouthWest.StickerBack.StickerColorType,
//        //        cube.BackNorthWest.StickerBack.StickerColorType
//        //    );

//        //    return result;
//        //}



//        public KeyValuePair<StickerColorTypes, Int32> GetHighestCompleteness(Dictionary<StickerColorTypes, Int32> side)
//        {
//            Int32 max = 0;

//            var result = default(KeyValuePair<StickerColorTypes, Int32>);
//            foreach (KeyValuePair<StickerColorTypes, Int32> kvp in side)
//            {
//                if (kvp.Value > max)
//                {
//                    result = kvp;
//                }
//            }

//            return result;
//        }

//        //public KeyValuePair<StickerColorTypes, Int32> GetHighestCompleteness(Dictionary<StickerColorTypes, Int32> side)
//        //{
//        //    Int32 max = 0;

//        //    var result = default(KeyValuePair<StickerColorTypes, Int32>);
//        //    foreach (KeyValuePair<StickerColorTypes, Int32> kvp in side)
//        //    {
//        //        if (kvp.Value > max)
//        //        {
//        //            result = kvp;
//        //        }
//        //    }

//        //    return result;
//        //}

//        //public void GetSideCompleteness(CubeModel cube)
//        //{
//        //    var sideColorTotals = new Dictionary<StickerColorTypes, PatternAdjacentFaceResultModel>();

//        //    sideColorTotals[StickerColorTypes.White] = this.GetCompleteness(cube, StickerColorTypes.White);
//        //    sideColorTotals[StickerColorTypes.Yellow] = this.GetCompleteness(cube, StickerColorTypes.Yellow);

//        //    sideColorTotals[StickerColorTypes.Blue] = this.GetCompleteness(cube, StickerColorTypes.Blue);
//        //    sideColorTotals[StickerColorTypes.Green] = this.GetCompleteness(cube, StickerColorTypes.Green);

//        //    sideColorTotals[StickerColorTypes.Red] = this.GetCompleteness(cube, StickerColorTypes.Red);
//        //    sideColorTotals[StickerColorTypes.Orange] = this.GetCompleteness(cube, StickerColorTypes.Orange);

//        //}
//        //public PatternAdjacentStickerTypes PatternAdjacentStickerType(StickerColorTypes stickerColorA, StickerColorTypes stickerColorB)
//        //{
//        //    if (stickerColorA == stickerColorB)
//        //    {
//        //        return PatternAdjacentStickerTypes.Match;
//        //    }
//        //    else if ((stickerColorA == StickerColorTypes.White && stickerColorB == StickerColorTypes.Yellow)
//        //       || (stickerColorA == StickerColorTypes.Yellow && stickerColorB == StickerColorTypes.White)
//        //       || (stickerColorA == StickerColorTypes.Red && stickerColorB == StickerColorTypes.Orange)
//        //       || (stickerColorA == StickerColorTypes.Orange && stickerColorB == StickerColorTypes.Red)
//        //       || (stickerColorA == StickerColorTypes.Blue && stickerColorB == StickerColorTypes.Green)
//        //       || (stickerColorA == StickerColorTypes.Green && stickerColorB == StickerColorTypes.Blue))
//        //    {
//        //        return PatternAdjacentStickerTypes.Opposite;
//        //    }
//        //    else
//        //    {
//        //        return PatternAdjacentStickerTypes.Adjacent;
//        //    }

//        //}



//    //    public String GetRawPattern(CubePatternModel cubePattern)
//    //    {
//    //        String rawPattern = $@"
//    //                {cubePattern.NorthEast.StickerNorth }
//    //                {cubePattern.NorthWest.StickerNorth }
//    //                {cubePattern.FrontNorth.StickerNorth }
//    //                {cubePattern.BackNorth.StickerNorth }

//    //                {cubePattern.FrontNorthEast.StickerNorth }
//    //                {cubePattern.BackNorthEast.StickerNorth }
//    //                {cubePattern.BackNorthWest.StickerNorth }
//    //                {cubePattern.FrontNorthWest.StickerNorth }

//    //                {cubePattern.SouthEast.StickerSouth }
//    //                {cubePattern.SouthWest.StickerSouth }
//    //                {cubePattern.FrontSouth.StickerSouth }
//    //                {cubePattern.BackSouth.StickerSouth }

//    //                {cubePattern.FrontSouthEast.StickerSouth }
//    //                {cubePattern.FrontSouthWest.StickerSouth }
//    //                {cubePattern.BackSouthEast.StickerSouth }
//    //                {cubePattern.BackSouthWest.StickerSouth }

//    //                {cubePattern.NorthWest.StickerWest }
//    //                {cubePattern.SouthWest.StickerWest }
//    //                {cubePattern.FrontWest.StickerWest }
//    //                {cubePattern.BackWest.StickerWest }

//    //                {cubePattern.FrontSouthWest.StickerWest }
//    //                {cubePattern.FrontNorthWest.StickerWest }
//    //                {cubePattern.BackSouthWest.StickerWest }
//    //                {cubePattern.BackNorthWest.StickerWest }

//    //                {cubePattern.NorthEast.StickerEast }
//    //                {cubePattern.SouthEast.StickerEast }
//    //                {cubePattern.FrontEast.StickerEast }
//    //                {cubePattern.BackEast.StickerEast }

//    //                {cubePattern.FrontNorthEast.StickerEast }
//    //                {cubePattern.FrontSouthEast.StickerEast }
//    //                {cubePattern.BackNorthEast.StickerEast }
//    //                {cubePattern.BackSouthEast.StickerEast }

//    //                {cubePattern.FrontNorth.StickerFront }
//    //                {cubePattern.FrontSouth.StickerFront }
//    //                {cubePattern.FrontWest.StickerFront }
//    //                {cubePattern.FrontEast.StickerFront }

//    //                {cubePattern.FrontNorthEast.StickerFront }
//    //                {cubePattern.FrontSouthEast.StickerFront }
//    //                {cubePattern.FrontSouthWest.StickerFront }
//    //                {cubePattern.FrontNorthWest.StickerFront }

//    //                {cubePattern.BackNorth.StickerBack }
//    //                {cubePattern.BackSouth.StickerBack }
//    //                {cubePattern.BackWest.StickerBack }
//    //                {cubePattern.BackEast.StickerBack }

//    //                {cubePattern.BackNorthEast.StickerBack }
//    //                {cubePattern.BackSouthEast.StickerBack }
//    //                {cubePattern.BackSouthWest.StickerBack }
//    //                {cubePattern.BackNorthWest.StickerBack }
//    //            ";

//    //        return new CubePatternModel(
//    //           stickers[0], stickers[1], stickers[2],
//    //           stickers[3], stickers[4], stickers[5],
//    //           stickers[6], stickers[7], stickers[8],

//    //            stickers[9], stickers[10], stickers[11],
//    //            stickers[12], stickers[13], stickers[14],
//    //            stickers[15], stickers[16], stickers[17],

//    //            stickers[18], stickers[19], stickers[20],
//    //            stickers[21], stickers[22], stickers[23],
//    //            stickers[24], stickers[25], stickers[26],

//    //            stickers[27], stickers[28], stickers[29],
//    //            stickers[30], stickers[31], stickers[32],
//    //            stickers[33], stickers[34], stickers[35],

//    //            stickers[36], stickers[37], stickers[38],
//    //            stickers[39], stickers[40], stickers[41],
//    //            stickers[42], stickers[43], stickers[44],

//    //            stickers[45], stickers[46], stickers[47],
//    //            stickers[48], stickers[49], stickers[50],
//    //            stickers[51], stickers[52], stickers[53]);

//    //    }
//    //}

//    //    private CubePatternModel GetCompleteness(CubeModel cube)
//    //    {
            

//    //        return new CubePatternModel(
//    //             cube.
//    //            );

//    //    }

//        //public StickerColorTypes GetMostCompleteSide(CubeModel cube)
//        //{

//        //    foreach (String side in this.Sides)
//        //    {


//        //    }


//        //    if (cube.NorthEast.StickerNorth.StickerColorType  == StickerColorTypes.)
//        //    cube.NorthWest.StickerNorth =
//        //    cube.FrontNorth.StickerNorth =
//        //    cube.BackNorth.StickerNorth =

//        //    cube.FrontNorthEast.StickerNorth =
//        //    cube.BackNorthEast.StickerNorth =
//        //    cube.BackNorthWest.StickerNorth =
//        //    cube.FrontNorthWest.StickerNorth =


//        //    cube.SouthEast.StickerSouth =
//        //    cube.SouthWest.StickerSouth =
//        //    cube.FrontSouth.StickerSouth =
//        //    cube.BackSouth.StickerSouth =


//        //    cube.FrontSouthEast.StickerSouth =
//        //    cube.FrontSouthWest.StickerSouth =
//        //    cube.BackSouthEast.StickerSouth =
//        //    cube.BackSouthWest.StickerSouth =

//        //    cube.NorthWest.StickerWest =
//        //    cube.SouthWest.StickerWest =
//        //    cube.FrontWest.StickerWest =
//        //    cube.BackWest.StickerWest =

//        //    cube.FrontSouthWest.StickerWest =
//        //    cube.FrontNorthWest.StickerWest =
//        //    cube.BackSouthWest.StickerWest =
//        //    cube.BackNorthWest.StickerWest =


//        //    cube.NorthEast.StickerEast =
//        //    cube.SouthEast.StickerEast =
//        //    cube.FrontEast.StickerEast =
//        //    cube.BackEast.StickerEast =

//        //    cube.FrontNorthEast.StickerEast =
//        //    cube.FrontSouthEast.StickerEast =
//        //    cube.BackNorthEast.StickerEast =
//        //    cube.BackSouthEast.StickerEast =


//        //    cube.FrontNorth.StickerFront =
//        //    cube.FrontSouth.StickerFront =
//        //    cube.FrontWest.StickerFront =
//        //    cube.FrontEast.StickerFront =

//        //    cube.FrontNorthEast.StickerFront =
//        //    cube.FrontSouthEast.StickerFront =
//        //    cube.FrontSouthWest.StickerFront =
//        //    cube.FrontNorthWest.StickerFront =


//        //    cube.BackNorth.StickerBack =
//        //    cube.BackSouth.StickerBack =
//        //    cube.BackWest.StickerBack =
//        //    cube.BackEast.StickerBack =


//        //    cube.BackNorthEast.StickerBack =
//        //    cube.BackSouthEast.StickerBack =
//        //    cube.BackSouthWest.StickerBack =
//        //    cube.BackNorthWest.StickerBack =
//        //}

//        //public void GetPattern(CubeModel cube)
//        //{

//        //    StickerColorTypes mostCompleteSide;


//        //    var stickers = new List<PaternStickerTypes>(54);

//        //    return new CubePatternModel(
//        //        stickers[0], stickers[1], stickers[2],
//        //        stickers[3], stickers[4], stickers[5],
//        //        stickers[6], stickers[7], stickers[8],

//        //        stickers[9], stickers[10], stickers[11],
//        //        stickers[12], stickers[13], stickers[14],
//        //        stickers[15], stickers[16], stickers[17],

//        //        stickers[18], stickers[19], stickers[20],
//        //        stickers[21], stickers[22], stickers[23],
//        //        stickers[24], stickers[25], stickers[26],

//        //        stickers[27], stickers[28], stickers[29],
//        //        stickers[30], stickers[31], stickers[32],
//        //        stickers[33], stickers[34], stickers[35],

//        //        stickers[36], stickers[37], stickers[38],
//        //        stickers[39], stickers[40], stickers[41],
//        //        stickers[42], stickers[43], stickers[44],

//        //        stickers[45], stickers[46], stickers[47],
//        //        stickers[48], stickers[49], stickers[50],
//        //        stickers[51], stickers[52], stickers[53]);

//        //}

//        //public String SavePattern(CubePatternModel cubePattern)
//        //{
//        //    String result = " " +
//        //    cubePattern.North52 + " " +
//        //    cubePattern.North60 + " " +
//        //    cubePattern.North7 + " " +
//        //    cubePattern.North15 + " " +
//        //    cubePattern.North0 + " " +
//        //    cubePattern.North22 + " " +
//        //    cubePattern.North30 + " " +
//        //    cubePattern.North37 + " " +
//        //    cubePattern.North45 + " " +

//        //    cubePattern.South52 + " " +
//        //    cubePattern.South60 + " " +
//        //    cubePattern.South7 + " " +
//        //    cubePattern.South15 + " " +
//        //    cubePattern.South0 + " " +
//        //    cubePattern.South22 + " " +
//        //    cubePattern.South30 + " " +
//        //    cubePattern.South37 + " " +
//        //    cubePattern.South45 + " " +

//        //    cubePattern.East52 + " " +
//        //    cubePattern.East60 + " " +
//        //    cubePattern.East7 + " " +
//        //    cubePattern.East15 + " " +
//        //    cubePattern.East0 + " " +
//        //    cubePattern.East22 + " " +
//        //    cubePattern.East30 + " " +
//        //    cubePattern.East37 + " " +
//        //    cubePattern.East45 + " " +

//        //    cubePattern.West52 + " " +
//        //    cubePattern.West60 + " " +
//        //    cubePattern.West7 + " " +
//        //    cubePattern.West15 + " " +
//        //    cubePattern.West0 + " " +
//        //    cubePattern.West22 + " " +
//        //    cubePattern.West30 + " " +
//        //    cubePattern.West37 + " " +
//        //    cubePattern.West45 + " " +

//        //    cubePattern.Front52 + " " +
//        //    cubePattern.Front60 + " " +
//        //    cubePattern.Front7 + " " +
//        //    cubePattern.Front15 + " " +
//        //    cubePattern.Front0 + " " +
//        //    cubePattern.Front22 + " " +
//        //    cubePattern.Front30 + " " +
//        //    cubePattern.Front37 + " " +
//        //    cubePattern.Front45 + " " +

//        //    cubePattern.Back52 + " " +
//        //    cubePattern.Back60 + " " +
//        //    cubePattern.Back7 + " " +
//        //    cubePattern.Back15 + " " +
//        //    cubePattern.Back0 + " " +
//        //    cubePattern.Back22 + " " +
//        //    cubePattern.Back30 + " " +
//        //    cubePattern.Back37 + " " +
//        //    cubePattern.Back45;

//        //    return result;
//        //}
//    }
//}



////var sideColorTotals = new Dictionary<StickerColorTypes, Dictionary<StickerColorTypes, PatternModel>>();

////sideColorTotals.Add(StickerColorTypes.Blue, this.GetFrontCompleteness(cube));
////sideColorTotals.Add(StickerColorTypes.Green, this.GetBackCompleteness(cube));
////sideColorTotals.Add(StickerColorTypes.Orange, this.GetEastCompleteness(cube));
////sideColorTotals.Add(StickerColorTypes.Red, this.GetWestCompleteness(cube));
////sideColorTotals.Add(StickerColorTypes.White, this.GetNorthCompleteness(cube));
////sideColorTotals.Add(StickerColorTypes.Yellow, this.GetSouthCompleteness(cube));


////KeyValuePair<StickerColorTypes, Int32> kvpFront = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Blue]);
////KeyValuePair<StickerColorTypes, Int32> kvpGreen = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Green]);
////KeyValuePair<StickerColorTypes, Int32> kvpOrange = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Orange]);
////KeyValuePair<StickerColorTypes, Int32> kvpRed = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Red]);
////KeyValuePair<StickerColorTypes, Int32> kvpWhite = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.White]);
////KeyValuePair<StickerColorTypes, Int32> kvpYellow = this.GetHighestCompleteness(sideColorTotals[StickerColorTypes.Yellow]);


////KeyValuePair<StickerColorTypes, Int32> kvpBlue = sideColorTotals[StickerColorTypes.Blue].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
////KeyValuePair<StickerColorTypes, Int32> kvpGreen = sideColorTotals[StickerColorTypes.Green].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
////KeyValuePair<StickerColorTypes, Int32> kvpOrange = sideColorTotals[StickerColorTypes.Orange].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
////KeyValuePair<StickerColorTypes, Int32> kvpRed = sideColorTotals[StickerColorTypes.Red].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
////KeyValuePair<StickerColorTypes, Int32> kvpWhite = sideColorTotals[StickerColorTypes.White].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);
////KeyValuePair<StickerColorTypes, Int32> kvpYellow = sideColorTotals[StickerColorTypes.Yellow].Aggregate((x1, y1) => x1.Value > y1.Value ? x1 : y1);