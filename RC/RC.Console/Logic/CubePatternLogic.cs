using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;
using RC.Model.Patterns;
using RC.Model.Slots;
using RC.Model.Stickers;

namespace RC.Logic
{
    public class CubePatternLogic
    {
        public const String SideX = "A";
        public const String SideXn = "a";
        public const String SideY = "B";
        public const String SideYn = "b";
        public const String SideZ = "C";
        public const String SideZn = "c";

        public String[] Sides = new string[] { SideX, SideXn, SideY, SideYn, SideX, SideXn };

        public CubePatternLogic()
        {

        }

        public Dictionary<StickerColorTypes, PatternResultModel> GetCompletenessDictionary()
        {
            var result = new Dictionary<StickerColorTypes, PatternResultModel>(6);

            result.Add(StickerColorTypes.Blue, new PatternResultModel());
            result.Add(StickerColorTypes.Green, new PatternResultModel());
            result.Add(StickerColorTypes.Orange, new PatternResultModel());
            result.Add(StickerColorTypes.Red, new PatternResultModel());
            result.Add(StickerColorTypes.White, new PatternResultModel());
            result.Add(StickerColorTypes.Yellow, new PatternResultModel());

            return result;
        }

        //public PatternNorthFaceResultModel GetFaceCompleteness(PieceNorthModel pieceMiddle, StickerColorTypes colorToCheck)
        //{
        //    StickerColorTypes f00 = pieceMiddle.Stickers.Single().StickerColorType;

        //    StickerColorTypes f52;
        //    StickerColorTypes f60;
        //    StickerColorTypes f07;
        //    StickerColorTypes f15;
        //    StickerColorTypes f22;
        //    StickerColorTypes f30;
        //    StickerColorTypes f37;
        //    StickerColorTypes f45;

        //    var slotSideCount = new Dictionary<SlotSideModelBase, Int32>();

        //    foreach (SlotSideModelBase slotSide in pieceMiddle.AdjacentSideSlots)
        //    {
        //        slotSide.AdjacentCornerSlots.Where(x => x.AdjacentSideSlots.)

        //        foreach (SlotCornerModelBase slotCorner in slotSide.AdjacentCornerSlots)
        //        {
        //            slotCorner.GetStickers();

        //            foreach (SlotSideModelBase slotCornerSide in slotCorner.AdjacentSideSlots)
        //            {
        //                slotCornerSide.GetStickers();

        //            }
        //        }
        //    }
        //}

        public PatternFaceResultModel GetFaceCompleteness(StickerColorTypes colorToCheck,
            StickerColorTypes t52, StickerColorTypes t60, StickerColorTypes t07,
            StickerColorTypes t15, StickerColorTypes t00, StickerColorTypes t22,
            StickerColorTypes t30, StickerColorTypes t37, StickerColorTypes t45)
        {
            var result = new PatternFaceResultModel();
            if (t52 == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (t60 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (t07 == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (t15 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (t00 == colorToCheck)
            {
                result.Stickers += 1;
                result.Middles += 1;
            }
            if (t22 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (t30 == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (t37 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (t45 == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }


            if (result.Stickers == 0)
            {
                result.Pattern = PatternFaceTypes.None;
            }
            else if (result.Stickers == 1)
            {
                if (result.Corners == 1)
                {
                    result.Pattern = PatternFaceTypes.A1;
                }
                else if (result.Sides == 1)
                {
                    result.Pattern = PatternFaceTypes.A2;
                }
                else
                {
                    result.Pattern = PatternFaceTypes.A3;

                }
            }
            else if (result.Stickers == 2)
            {
                if (result.Middles > 0)
                {
                    if (result.Corners == 1)
                    {
                        result.Pattern = PatternFaceTypes.B1;
                    }
                    else
                    {
                        result.Pattern = PatternFaceTypes.B2;
                    }
                }
                else if (result.Sides == 2)
                {
                    if (
                           (t60 == colorToCheck && (t45 == colorToCheck || t15 == colorToCheck))
                        || (t15 == colorToCheck && (t60 == colorToCheck || t30 == colorToCheck))
                        || (t30 == colorToCheck && (t15 == colorToCheck || t45 == colorToCheck))
                        || (t45 == colorToCheck && (t30 == colorToCheck || t60 == colorToCheck))
                      )
                    {
                        result.Pattern = PatternFaceTypes.B3;
                    }
                    else
                    {
                        result.Pattern = PatternFaceTypes.B4;
                    }
                }
                else
                {
                    if (
                             (t07 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
                          || (t22 == colorToCheck && (t07 == colorToCheck || t37 == colorToCheck))
                          || (t37 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
                          || (t52 == colorToCheck && (t37 == colorToCheck || t07 == colorToCheck))
                        )
                    {
                        result.Pattern = PatternFaceTypes.B5;
                    }
                    else
                    {
                        result.Pattern = PatternFaceTypes.B6;
                    }
                }
            }
            else if (result.Stickers == 3)
            {
                if (result.Middles > 0)
                {
                    if (result.Sides == 2)
                    {
                        if (
                               (t60 == colorToCheck && (t45 == colorToCheck || t15 == colorToCheck))
                            || (t15 == colorToCheck && (t60 == colorToCheck || t30 == colorToCheck))
                            || (t30 == colorToCheck && (t15 == colorToCheck || t45 == colorToCheck))
                            || (t45 == colorToCheck && (t30 == colorToCheck || t60 == colorToCheck))
                          )
                        {
                            result.Pattern = PatternFaceTypes.C1;
                        }
                        else
                        {
                            result.Pattern = PatternFaceTypes.C2;
                        }
                    }
                    else if (result.Corners == 2)
                    {
                        if (
                                 (t07 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
                              || (t22 == colorToCheck && (t07 == colorToCheck || t37 == colorToCheck))
                              || (t37 == colorToCheck && (t22 == colorToCheck || t52 == colorToCheck))
                              || (t52 == colorToCheck && (t37 == colorToCheck || t07 == colorToCheck))
                            )
                        {
                            result.Pattern = PatternFaceTypes.C3;
                        }
                        else
                        {
                            result.Pattern = PatternFaceTypes.C4;
                        }
                    }
                    else
                    {
                        if (
                                (t07 == colorToCheck && (t15 == colorToCheck || t60 == colorToCheck))
                             || (t22 == colorToCheck && (t15 == colorToCheck || t30 == colorToCheck))
                             || (t37 == colorToCheck && (t30 == colorToCheck || t45 == colorToCheck))
                             || (t52 == colorToCheck && (t45 == colorToCheck || t60 == colorToCheck))
                           )
                        {
                            result.Pattern = PatternFaceTypes.C5;
                        }
                        else
                        {
                            result.Pattern = PatternFaceTypes.C6;
                        }
                    }
                }
                else
                {
                    if (result.Sides == 3)
                    {
                        result.Pattern = PatternFaceTypes.C7;
                    }
                    else if (result.Corners == 3)
                    {
                        result.Pattern = PatternFaceTypes.C8;
                    }
                    else if (result.Sides == 2)
                    {
                        result.Pattern = PatternFaceTypes.C9;
                    }
                    else
                    {
                        result.Pattern = PatternFaceTypes.C10;
                    }
                }
            }


            return result;
        }

        public PatternAdjacentResultModel GetAdjacentCompleteness(StickerColorTypes colorToCheck,
                                                                                                                                                                                    /* 
                                                                                                                                                                                                                      */StickerColorTypes n,
                                                                                                                        /*                                  
                                                                                                                                              */StickerColorTypes nw, StickerColorTypes ne,
                                   /* 
                                        */StickerColorTypes wm, StickerColorTypes w, StickerColorTypes e, StickerColorTypes em,
                                                                                                                        /*                                 
                                                                                                                                              */StickerColorTypes sw, StickerColorTypes se,
                                                                                                                                                                                    /*                                        
                                                                                                                                                                                                                      */StickerColorTypes s
            )
        {

            var result = new PatternAdjacentResultModel();
            if (n == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (nw == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (ne == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (wm == colorToCheck)
            {
                result.Stickers += 1;
                result.Middles += 1;
            }
            if (w == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (e == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (em == colorToCheck)
            {
                result.Stickers += 1;
                result.Middles += 1;
            }
            if (sw == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (se == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (s == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }


            if (result.Stickers == 0)
            {
                result.Pattern = PatternAdjacentTypes.None;
            }
            else if (result.Stickers == 1)
            {
                if (result.Sides == 1)
                {
                    if (w == colorToCheck)
                    {
                        result.Pattern = PatternAdjacentTypes.A3;
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
                else if (result.Corners == 1)
                {
                    if (n == colorToCheck)
                    {
                        result.Pattern = PatternAdjacentTypes.A1;
                    }
                    else if (nw == colorToCheck)
                    {
                        result.Pattern = PatternAdjacentTypes.A2;
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
                else
                {
                    if (wm == colorToCheck)
                    {
                        result.Pattern = PatternAdjacentTypes.A4;
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
            }
            else if (result.Stickers == 2)
            {
                if (result.Corners > 1)
                {
                    if (n == colorToCheck)
                    {
                        if (s == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B4;
                        }
                        else if (sw == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B3;
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else if (nw == colorToCheck)
                    {
                        if (sw == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B9;
                        }
                        else if (se == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B10;
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
                else if (result.Sides == 1 && result.Corners == 1)
                {
                    if (w == colorToCheck)
                    {
                        if (n == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B2;
                        }
                        else if (nw == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B6;
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else if (nw == colorToCheck && e == colorToCheck)
                    {
                        result.Pattern = PatternAdjacentTypes.B7;
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
                else if (result.Sides == 1 && result.Middles == 1)
                {
                    if (n == sw)
                    {
                        result.Pattern = PatternAdjacentTypes.B11;
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.B12;
                    }
                }
                else
                {
                    if (w == colorToCheck)
                    {
                        if (n == colorToCheck)
                        {
                            result.Pattern = PatternAdjacentTypes.B1;
                        }
                        else if (nw == colorToCheck)
                        {
                            if (wm == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.B5;
                            }
                            else if (em == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.B8;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
            }
            else if (result.Stickers == 3)
            {
                if (result.Middles > 0)
                {
                    if (wm == colorToCheck)
                    {
                        if (n == colorToCheck)
                        {
                            if (w == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C1;
                            }
                            else if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C2;
                            }
                            else if (s == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C3;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else if (nw == colorToCheck)
                        {
                            if (w == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C6;
                            }
                            else if (e == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C7;
                            }
                            else if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.C8;
                            }
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
                else
                {

                    if (n == colorToCheck)
                    {
                        if (w == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {

                                result.Pattern = PatternAdjacentTypes.C4;
                            }
                            else if (s == colorToCheck)
                            {

                                result.Pattern = PatternAdjacentTypes.C5;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else if (nw == colorToCheck)
                    {
                        if (w == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {

                                result.Pattern = PatternAdjacentTypes.C9;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else
                        {
                            result.Pattern = PatternAdjacentTypes.None;
                        }
                    }
                    else
                    {
                        result.Pattern = PatternAdjacentTypes.None;
                    }
                }
            }
            else
            {
                if (wm == colorToCheck)
                {
                    if (n == colorToCheck)
                    {
                        if (w == colorToCheck)
                        {
                            if (s == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D1;
                            }
                            else if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D3;
                            }
                            else if (se == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D4;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else if (e == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D5;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                    }
                    else if (nw == colorToCheck)
                    {
                        if (w == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D6;
                            }
                            else if (se == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D7;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else if (e == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D7;
                            }
                            else if (se == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D7;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                    }
                }
                else if (em == colorToCheck)
                {
                    if (nw == colorToCheck)
                    {
                        if (e == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D7;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                        else if (w == colorToCheck)
                        {
                            if (sw == colorToCheck)
                            {
                                result.Pattern = PatternAdjacentTypes.D7;
                            }
                            else
                            {
                                result.Pattern = PatternAdjacentTypes.None;
                            }
                        }
                    }
                }
                else
                {
                    result.Pattern = PatternAdjacentTypes.None;
                }

            }

            return result;
        }

        public PatternAdjacentFaceResultModel GetCompleteness(CubeModel cube, StickerColorTypes color)
        {
            var result = new PatternAdjacentFaceResultModel();
            result.PatternFaceResult = this.GetFaceCompleteness(color,
                cube.NorthWest.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType,
                cube.BackNorth.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerNorth.StickerColorType,
                cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthWest.StickerNorth.StickerColorType, cube.FrontNorthWest.StickerNorth.StickerColorType
            );

            if (result.PatternFaceResult.Pattern == PatternFaceTypes.None) { }

            result.PatternAdjacentResult = this.GetAdjacentCompleteness(color,
                cube.BackNorthEast.StickerBack.StickerColorType,
                cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                cube.FrontNorthEast.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
                cube.FrontNorthEast.StickerFront.StickerColorType
            );

            return result;
        }

        public Dictionary<StickerColorTypes, PatternAdjacentFaceResultModel> GetSideCompleteness(CubeModel cube)
        {
            var sideColorTotals = new Dictionary<StickerColorTypes, PatternAdjacentFaceResultModel>();

            sideColorTotals[StickerColorTypes.White] = this.GetCompleteness(cube, StickerColorTypes.White);
            sideColorTotals[StickerColorTypes.Yellow] = this.GetCompleteness(cube, StickerColorTypes.Yellow);

            sideColorTotals[StickerColorTypes.Blue] = this.GetCompleteness(cube, StickerColorTypes.Blue);
            sideColorTotals[StickerColorTypes.Green] = this.GetCompleteness(cube, StickerColorTypes.Green);

            sideColorTotals[StickerColorTypes.Red] = this.GetCompleteness(cube, StickerColorTypes.Red);
            sideColorTotals[StickerColorTypes.Orange] = this.GetCompleteness(cube, StickerColorTypes.Orange);

            return sideColorTotals;
        }

        public PatternAdjacentStickerTypes PatternAdjacentStickerType(StickerColorTypes stickerColorA, StickerColorTypes stickerColorB)
        {
            if (stickerColorA == stickerColorB)
            {
                return PatternAdjacentStickerTypes.Match;
            }
            else if ((stickerColorA == StickerColorTypes.White && stickerColorB == StickerColorTypes.Yellow)
               || (stickerColorA == StickerColorTypes.Yellow && stickerColorB == StickerColorTypes.White)
               || (stickerColorA == StickerColorTypes.Red && stickerColorB == StickerColorTypes.Orange)
               || (stickerColorA == StickerColorTypes.Orange && stickerColorB == StickerColorTypes.Red)
               || (stickerColorA == StickerColorTypes.Blue && stickerColorB == StickerColorTypes.Green)
               || (stickerColorA == StickerColorTypes.Green && stickerColorB == StickerColorTypes.Blue))
            {
                return PatternAdjacentStickerTypes.Opposite;
            }
            else
            {
                return PatternAdjacentStickerTypes.Adjacent;
            }

        }
    }
}