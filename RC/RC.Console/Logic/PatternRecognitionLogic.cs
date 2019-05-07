using RC.Enumerations;
using RC.Model;
using RC.Model.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Logic
{
    public class PatternRecognitionLogic
    {
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
            StickerColorTypes t45, StickerColorTypes t00, StickerColorTypes t15,
            StickerColorTypes t37, StickerColorTypes t30, StickerColorTypes t22, Int32 tryCount = 0)
        {
            var result = new PatternFaceResultModel();
            result.MiddleColorType = t00;
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
                result.Corners += 1;
            }
            if (t30 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }
            if (t37 == colorToCheck)
            {
                result.Stickers += 1;
                result.Corners += 1;
            }
            if (t45 == colorToCheck)
            {
                result.Stickers += 1;
                result.Sides += 1;
            }


            if (result.Stickers == 0)
            {
                result.Pattern = PatternFaceTypes.None;
            }
            else if (result.Stickers == 1)
            {
                if (t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.A1;
                }
                else if (result.Corners == 1)
                {
                    result.Pattern = PatternFaceTypes.A2;
                }
                else if (result.Sides == 1)
                {
                    result.Pattern = PatternFaceTypes.A3;
                }
            }
            else if (result.Stickers == 2)
            {
                if (t52 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B1;
                }
                else if (t60 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B2;
                }
                else if (t60 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B3;
                }
                else if (t60 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B4;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B5;
                }
                else if (t52 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B6;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B7;
                }
                else if (t52 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B8;
                }
            }
            else if (result.Stickers == 3)
            {
                if (t60 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck )
                {
                    result.Pattern = PatternFaceTypes.C1;
                }
                else if (t60 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C2;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C3;
                }
                else if (t52 == colorToCheck && t00 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C4;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C5;
                }
                else if (t52 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C6;
                }
                else if (t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C7;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C8;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C9;
                }
                else if (t60 == colorToCheck && t07 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C10;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C11;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C12;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C13;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C14;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C15;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C16;
                }
                else if (t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C17;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C18;
                }
                else if (t52 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C19;
                }
                else if (t52 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C20;
                }
                else if (t52 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C21;
                }
            }
            else if (result.Stickers == 4)
            {
                if (t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D1;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D2;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D3;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D4;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t45 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D5;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D6;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D7;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t37 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D8;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t30 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D9;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D10;
                }
                else if (t52 == colorToCheck && t07 == colorToCheck && t22 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D11;
                }
                else if (t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck && t45 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D12;
                }
                else if (t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D13;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t30 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D14;
                }
                else if (t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D15;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D16;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D17;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D18;
                }
                else if (t52 == colorToCheck && t15 == colorToCheck && t37 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D19;
                }
                else if (t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D20;
                }

            }
            else if (result.Stickers == 5)
            {
                if (t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E1;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E2;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E3;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E4;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E5;
                }
                else if (t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E6;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E7;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E8;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E9;
                }
                else if (t07 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E10;
                }
                else if (t07 != colorToCheck && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E11;
                }
                else if (t07 != colorToCheck && t45 != colorToCheck && t00 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E12;
                }
                else if (t07 != colorToCheck && t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E13;
                }
                else if (t60 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck && t45 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E14;
                }
                else if (t52 != colorToCheck && t07 != colorToCheck && t22 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E15;
                }
                else if (t07 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E16;
                }
                else if (t00 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E17;
                }
                else if (t60 != colorToCheck && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E18;
                }
                else if (t45 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E19;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E20;
                }
            }
            else if (result.Stickers == 6)
            {
                if (t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F1;
                }
                else if (t15 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F2;
                }
                else if (t15 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F3;
                }
                else if (t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F4;
                }
                else if (t00 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F5;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F6;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F7;
                }
                else if (t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F8;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F9;
                }
                else if (t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F10;
                }
                else if (t07 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F11;
                }
            }
            else if (result.Stickers == 7)
            {
                if (t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G1;
                }
                else if (t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G2;
                }
                else if (t52 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G3;
                }
                else if (t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G4;
                }
                else if (t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G5;
                }
                else if (t00 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G6;
                }
                else if (t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G7;
                }
                else if (t45 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G8;
                }
            }
            else if (result.Stickers == 8)
            {
                if (result.Corners == 3)
                {
                    result.Pattern = PatternFaceTypes.H1;
                }
                else if (result.Sides == 3)
                {
                    result.Pattern = PatternFaceTypes.H2;
                }
                else if (result.Middles == 0)
                {
                    result.Pattern = PatternFaceTypes.H3;
                }
            }
            else if (result.Stickers == 9)
            {
                result.Pattern = PatternFaceTypes.I1;
            }
            tryCount += 1;
            if (result.Pattern == PatternFaceTypes.Unknown)
            {
                if (tryCount == 5 || tryCount == 15)
                {
                    //Mirror: Top To Bottom
                    return this.GetFaceCompleteness(colorToCheck,
                             t37, t30, t22,
                             t45, t00, t15,
                             t52, t60, t07, tryCount);
                }
                else if (tryCount == 10)
                {
                    //Mirror: Right To Left
                    return this.GetFaceCompleteness(colorToCheck,
                            t07, t60, t52,
                            t15, t00, t45,
                            t22, t30, t37, tryCount);
                }
                else if (tryCount <= 20)
                {
                    //Rotate Clockwise
                    return this.GetFaceCompleteness(colorToCheck,
                            t37, t45, t52,
                            t30, t00, t60,
                            t22, t15, t07, tryCount);
                }
                else
                {
                    throw new Exception($@" face pattern not found
                            {colorToCheck},
                            {t52}, {t60}, {t22},
                            {t45}, {t00}, {t15},
                            {t37}, {t30}, {t22},
                            {tryCount}");
                }
            }
            else
            {
                return result;
            }
        }

        public PatternAdjacentResultModel GetAdjacentCompleteness(StickerColorTypes colorToCheck,
            /*                                  */StickerColorTypes n,
            /*                      */StickerColorTypes nw, StickerColorTypes ne,
            /* */StickerColorTypes wm, StickerColorTypes w, StickerColorTypes e, StickerColorTypes em,
            /*                      */StickerColorTypes sw, StickerColorTypes se,
            /*                                   */StickerColorTypes s
            ,Int32 tryCount = 0)
        {

            var result = new PatternAdjacentResultModel();

            result.MiddleColorTypeWest = wm;
            result.MiddleColorTypeEast = em;

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
                if (n == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A1;
                }
                else if (nw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A2;
                }
                else if (w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A3;
                }
                else if (wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A4;
                }
            }
            else if (result.Stickers == 2)
            {
                if (n == colorToCheck && wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B1;
                }
                else if (n == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B2;
                }
                else if (n == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B3;
                }
                else if (n == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B4;
                }
                else if (nw == colorToCheck && wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B5;
                }
                else if (nw == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B6;
                }
                else if (nw == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B7;
                }
                else if (nw == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B8;
                }
                else if (nw == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B9;
                }
                else if (nw == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B10;
                }
                else if (wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B11;
                }
                else if (wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B12;
                }
            }
            else if (result.Stickers == 3)
            {
                if (n == colorToCheck && wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C1;
                }
                else if (n == colorToCheck && wm == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C2;
                }
                else if (n == colorToCheck && wm == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C3;
                }
                else if (n == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C4;
                }
                else if (n == colorToCheck && w == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C5;
                }
                else if (nw == colorToCheck && wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C6;
                }
                else if (nw == colorToCheck && wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C7;
                }
                else if (nw == colorToCheck && wm == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C8;
                }
                else if (nw == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C9;
                }
                else if (nw == colorToCheck && e == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C10;
                }
                else if (nw == colorToCheck && w == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C11;
                }
                else if (nw == colorToCheck && e == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C12;
                }
                else if (nw == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C13;
                }
                else if (nw == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C14;
                }
                else if (nw == colorToCheck && e == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C15;
                }
                else if (n == colorToCheck && wm == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C16;
                }
                else if (n == colorToCheck && wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C17;
                }
                else if (n == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C18;
                }
                else if (n == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C19;
                }
            }
            else
            {
                if (n == colorToCheck && wm == colorToCheck && w == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D1;
                }
                else if (n == colorToCheck && wm == colorToCheck && e == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D2;
                }
                else if (n == colorToCheck && wm == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D3;
                }
                else if (n == colorToCheck && wm == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D4;
                }
                else if (n == colorToCheck && wm == colorToCheck && e == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D5;
                }
                else if (nw == colorToCheck && wm == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D6;
                }
                else if (nw == colorToCheck && e == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D7;
                }
                else if (nw == colorToCheck && w == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D8;
                }
                else if (nw == colorToCheck && wm == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D9;
                }
                else if (nw == colorToCheck && e == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D10;
                }
                else if (n == colorToCheck && nw == colorToCheck && e == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D11;
                }
                else if (n == colorToCheck && nw == colorToCheck && e == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D12;
                }
                else if (n == colorToCheck && nw == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D13;
                }
                else if (nw == colorToCheck && wm == colorToCheck && e == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D14;
                }
                else if (n == colorToCheck && w == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D15;
                }
                else if (nw == colorToCheck && w == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D16;
                }
            }

            tryCount += 1;
            if (result.Pattern == PatternAdjacentTypes.Unknown)
            {
                if (tryCount == 1 || tryCount == 3)
                {
                    //Mirror: Top To Bottom
                    return this.GetAdjacentCompleteness(colorToCheck,
                                    s,
                                    sw, se,
                                    wm, w, e, em,
                                    nw, ne,
                                    n,
                                    tryCount);
                }
                else if (tryCount == 2 || tryCount == 4)
                {
                    //Mirror: Right To Left
                    return this.GetAdjacentCompleteness(colorToCheck,
                                    n,
                                    ne, nw,
                                    em, e, w, wm,
                                    se, sw,
                                    s,
                                    tryCount);
                }
                else 
                {
                    throw new Exception($@"adjacent pattern not found
                            {colorToCheck},
                                    {n},
                                    {nw}, {ne},
                                    {wm}, {w}, {e}, {em},
                                    {sw}, {se},
                                    {s},
                            { tryCount}
                    ");
                }                               
         
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// 
        /// 

        ///
        /// </summary>
        /// <param name="cube"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public PatternStatisticModel GetCompleteness(CubeModel cube, StickerColorTypes color)
        {
            var result = new PatternStatisticModel();

            /// [BNW ] [ BN ] [ BNE]
            /// [NW  ] [  N ] [  NE]
            /// [FNW ] [ FN ] [ FNE]
            PatternFaceResultModel north =  this.GetFaceCompleteness(color,
                cube.BackNorthWest.StickerNorth.StickerColorType, cube.BackNorth.StickerNorth.StickerColorType, cube.BackNorthEast.StickerNorth.StickerColorType,
                cube.NorthWest.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType,
                cube.FrontNorthWest.StickerNorth.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerNorth.StickerColorType
            );

            // [FSW ] [ FS ] [ FSE]
            // [SW  ] [  S ] [  SE]
            // [BSW ] [ BS ] [ BSE]
            PatternFaceResultModel south = this.GetFaceCompleteness(color,
                cube.FrontSouthWest.StickerSouth.StickerColorType, cube.FrontSouth.StickerSouth.StickerColorType, cube.FrontSouthEast.StickerSouth.StickerColorType,
                cube.SouthWest.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType, cube.SouthEast.StickerSouth.StickerColorType,
                cube.BackSouthWest.StickerSouth.StickerColorType, cube.BackSouth.StickerSouth.StickerColorType, cube.BackSouthEast.StickerSouth.StickerColorType
            );

            //  [BNW ] [ NW ] [ FNW]   
            //  [BW  ] [  W ] [  FW]   
            //  [BSW ] [ SW ] [ FSW]   
            PatternFaceResultModel west = this.GetFaceCompleteness(color,
                cube.BackNorthWest.StickerWest.StickerColorType, cube.NorthWest.StickerWest.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                cube.BackWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType, cube.FrontWest.StickerWest.StickerColorType,
                cube.BackSouthWest.StickerWest.StickerColorType, cube.SouthWest.StickerWest.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType
            );

            //  [FNE ] [ NE ] [ BNE]    
            //  [FE  ] [  E ] [  BE]    
            //  [FSE ] [ SE ] [ BSE]  
            PatternFaceResultModel east = this.GetFaceCompleteness(color,
                   cube.FrontNorthEast.StickerEast.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                   cube.FrontEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType, cube.BackEast.StickerEast.StickerColorType,
                   cube.FrontSouthEast.StickerEast.StickerColorType, cube.SouthEast.StickerEast.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType
               );

            //  [FNW ] [ FN ] [ FNE]       
            //  [FW  ] [  F ] [  FE]       
            //  [FSW ] [ FS ] [ FSE]     
            PatternFaceResultModel front = this.GetFaceCompleteness(color,
                   cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorth.StickerFront.StickerColorType, cube.FrontNorthEast.StickerFront.StickerColorType,
                   cube.FrontWest.StickerFront.StickerColorType, cube.Front.StickerFront.StickerColorType, cube.FrontEast.StickerFront.StickerColorType,
                   cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouth.StickerFront.StickerColorType, cube.FrontSouthEast.StickerFront.StickerColorType
               );

            //  [BNW ] [ BN ] [ BNE]
            //  [BW  ] [  B ] [  BE]
            //  [BSW ] [ BS ] [ BSE]
            PatternFaceResultModel back = this.GetFaceCompleteness(color,
                   cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorth.StickerBack.StickerColorType, cube.BackNorthEast.StickerBack.StickerColorType,
                   cube.BackWest.StickerBack.StickerColorType, cube.Back.StickerBack.StickerColorType, cube.BackEast.StickerBack.StickerColorType,
                   cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouth.StickerBack.StickerColorType, cube.BackSouthEast.StickerBack.StickerColorType
               );

            result.PatternFaceResults = new List<PatternFaceResultModel>() { north, south, east, west, front, back };

            //            [ FNE]
            //         [ FNE] [FNE ]  
            //  [  F ] [  FE] [FE  ] [  E ] 
            //         [ FSE] [FSE ] 
            //            [ FSE]
            PatternAdjacentResultModel fe = this.GetAdjacentCompleteness(color,
                cube.FrontNorthEast.StickerNorth.StickerColorType,
                cube.FrontNorthEast.StickerFront.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
                cube.Front.StickerFront.StickerColorType, cube.FrontEast.StickerFront.StickerColorType, cube.FrontEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                cube.FrontSouthEast.StickerFront.StickerColorType, cube.FrontSouthEast.StickerEast.StickerColorType,
                cube.FrontSouthEast.StickerSouth.StickerColorType
            );

            //            [ FNW]
            //         [ FNW] [FNW ]  
            //  [  F ] [  FW] [FW  ] [  W ] 
            //         [ FSW] [FSW ] 
            //            [ FSW]
            PatternAdjacentResultModel fw = this.GetAdjacentCompleteness(color,
                cube.FrontNorthWest.StickerNorth.StickerColorType,
                cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                cube.Front.StickerFront.StickerColorType, cube.FrontWest.StickerFront.StickerColorType, cube.FrontWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType,
                cube.FrontSouthWest.StickerSouth.StickerColorType
            );


            //            [ FNW]
            //         [ FNW] [FNW ]  
            //  [  F ] [  FN] [FN  ] [  N ] 
            //         [ FNE] [FNE ] 
            //            [ FNE]
            PatternAdjacentResultModel fn = this.GetAdjacentCompleteness(color,
                cube.FrontNorthWest.StickerWest.StickerColorType,
                cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorthWest.StickerNorth.StickerColorType,
                cube.Front.StickerFront.StickerColorType, cube.FrontNorth.StickerFront.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType,
                cube.FrontNorthEast.StickerFront.StickerColorType, cube.FrontNorthEast.StickerNorth.StickerColorType,
                cube.FrontNorthEast.StickerEast.StickerColorType
            );

            //            [ FSE]
            //         [ FSE] [FSE ]  
            //  [  F ] [  FS] [FS  ] [  S ] 
            //         [ FSW] [FSW ] 
            //            [ FSW]
            PatternAdjacentResultModel fs = this.GetAdjacentCompleteness(color,
                cube.FrontSouthEast.StickerEast.StickerColorType,
                cube.FrontSouthEast.StickerFront.StickerColorType, cube.FrontSouthEast.StickerSouth.StickerColorType,
                cube.Front.StickerFront.StickerColorType, cube.FrontSouth.StickerFront.StickerColorType, cube.FrontSouth.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType,
                cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouthWest.StickerSouth.StickerColorType,
                cube.FrontSouthWest.StickerWest.StickerColorType
            );

            //            [ BNE]
            //         [ BNE] [BNE ]  
            //  [  N ] [  NE] [NE  ] [  E ] 
            //         [ FNE] [FNE ] 
            //            [ FNE]
            PatternAdjacentResultModel ne = this.GetAdjacentCompleteness(color,
                cube.BackNorthEast.StickerBack.StickerColorType,
                cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                cube.FrontNorthEast.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
                cube.FrontNorthEast.StickerFront.StickerColorType
            );

            //            [ FNW]
            //         [ FNW] [FNW ]  
            //  [  N ] [  NW] [NW  ] [  W ] 
            //         [ BNW] [BNW ] 
            //            [ BNW]
            PatternAdjacentResultModel nw = this.GetAdjacentCompleteness(color,
                cube.FrontNorthWest.StickerFront.StickerColorType,
                cube.FrontNorthWest.StickerNorth.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                cube.North.StickerNorth.StickerColorType, cube.NorthWest.StickerNorth.StickerColorType, cube.NorthWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                cube.BackNorthWest.StickerNorth.StickerColorType, cube.BackNorthWest.StickerWest.StickerColorType,
                cube.BackNorthWest.StickerBack.StickerColorType
            );

            //            [ FSE]
            //         [ FSE] [FSE ]  
            //  [  S ] [  SW] [SW  ] [  E ] 
            //         [ BSE] [BSE ] 
            //            [ BSE]
            PatternAdjacentResultModel se = this.GetAdjacentCompleteness(color,
                cube.FrontSouthEast.StickerFront.StickerColorType,
                cube.FrontSouthEast.StickerSouth.StickerColorType, cube.FrontSouthEast.StickerEast.StickerColorType,
                cube.South.StickerSouth.StickerColorType, cube.SouthEast.StickerSouth.StickerColorType, cube.SouthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerSouth.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerBack.StickerColorType
            );

            //            [ BSW]
            //         [ BSW] [BSW ]  
            //  [  S ] [  SW] [SW  ] [  W ] 
            //         [ FSW] [FSW ] 
            //            [ FSW]
            PatternAdjacentResultModel sw = this.GetAdjacentCompleteness(color,
                cube.BackSouthWest.StickerBack.StickerColorType,
                cube.BackSouthWest.StickerSouth.StickerColorType, cube.BackSouthWest.StickerWest.StickerColorType,
                cube.South.StickerSouth.StickerColorType, cube.SouthWest.StickerSouth.StickerColorType, cube.SouthWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                cube.FrontSouthWest.StickerSouth.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType,
                cube.FrontSouthWest.StickerFront.StickerColorType
            );


            //            [ BNE]
            //         [ BNE] [BNE ]  
            //  [  B ] [  BE] [BE  ] [  E ] 
            //         [ BSE] [BSE ] 
            //            [ BSE]
            PatternAdjacentResultModel be = this.GetAdjacentCompleteness(color,
                cube.BackNorthEast.StickerNorth.StickerColorType,
                cube.BackNorthEast.StickerBack.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                cube.Back.StickerBack.StickerColorType, cube.BackEast.StickerBack.StickerColorType, cube.BackEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerBack.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerSouth.StickerColorType
            );

            //            [ BNW]
            //         [ BNW] [BNW ]  
            //  [  B ] [  BW] [BW  ] [  W ] 
            //         [ BSW] [BSW ] 
            //            [ BSW]
            PatternAdjacentResultModel bw = this.GetAdjacentCompleteness(color,
                cube.BackNorthWest.StickerNorth.StickerColorType,
                cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorthWest.StickerWest.StickerColorType,
                cube.Back.StickerBack.StickerColorType, cube.BackWest.StickerBack.StickerColorType, cube.BackWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouthWest.StickerWest.StickerColorType,
                cube.BackSouthWest.StickerSouth.StickerColorType
            );

            //            [ BSE]
            //         [ BSE] [BSE ]  
            //  [  B ] [  BS] [BS  ] [  S ] 
            //         [ BSW] [BSW ] 
            //            [ BSW]
            PatternAdjacentResultModel bs = this.GetAdjacentCompleteness(color,
                cube.BackSouthEast.StickerEast.StickerColorType,
                cube.BackSouthEast.StickerBack.StickerColorType, cube.BackSouthEast.StickerSouth.StickerColorType,
                cube.Back.StickerBack.StickerColorType, cube.BackSouth.StickerBack.StickerColorType, cube.BackSouth.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType,
                cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouthWest.StickerSouth.StickerColorType,
                cube.BackSouthWest.StickerWest.StickerColorType
            );

            //            [ BNE]
            //         [ BNE] [BNE ]  
            //  [  B ] [  BN] [BN  ] [  N ] 
            //         [ BNW] [BNW ] 
            //            [ BNW]
            PatternAdjacentResultModel bn = this.GetAdjacentCompleteness(color,
                cube.BackNorthEast.StickerEast.StickerColorType,
                cube.BackNorthEast.StickerBack.StickerColorType, cube.BackNorthEast.StickerNorth.StickerColorType,
                cube.Back.StickerBack.StickerColorType, cube.BackNorth.StickerBack.StickerColorType, cube.BackNorth.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType,
                cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorthWest.StickerNorth.StickerColorType,
                cube.BackNorthWest.StickerWest.StickerColorType
            );


            result.PatternAdjacentResults = new List<PatternAdjacentResultModel>() { fn, fe, fs, fw, ne, se, sw, nw, bn, be, bs, bw };

            return result;
        }

        public Dictionary<StickerColorTypes, PatternStatisticModel> GetSideCompleteness(CubeModel cube)
        {
            var sideColorTotals = new Dictionary<StickerColorTypes, PatternStatisticModel>();

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
