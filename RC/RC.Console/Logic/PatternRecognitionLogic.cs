using RC.Enumerations;
using RC.Model;
using RC.Model.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.Logic
{
    public class PatternRecognitionLogic
    {
        //public Dictionary<StickerColorTypes, PatternResultModel> GetCompletenessDictionary()
        //{
        //    var result = new Dictionary<StickerColorTypes, PatternResultModel>(6);

        //    result.Add(StickerColorTypes.Blue, new PatternResultModel());
        //    result.Add(StickerColorTypes.Green, new PatternResultModel());
        //    result.Add(StickerColorTypes.Orange, new PatternResultModel());
        //    result.Add(StickerColorTypes.Red, new PatternResultModel());
        //    result.Add(StickerColorTypes.White, new PatternResultModel());
        //    result.Add(StickerColorTypes.Yellow, new PatternResultModel());

        //    return result;
        //}

        #region public methods
        public PatternFaceResultModel[] GetPatternFaceResult(StickerColorTypes colorToCheck,
            StickerColorTypes t52, StickerColorTypes t60, StickerColorTypes t07,
            StickerColorTypes t45, StickerColorTypes t00, StickerColorTypes t15,
            StickerColorTypes t37, StickerColorTypes t30, StickerColorTypes t22, Int32 tryCount = 0,
            List<PatternFaceResultModel> resultList = default)
        {

            //Debug.Write($@" testing face pattern
            //                {colorToCheck},
            //                {t52}, {t60}, {t07},
            //                {t45}, {t00}, {t15},
            //                {t37}, {t30}, {t22},
            //                {tryCount}");

            if (resultList == default)
            {
                resultList = new List<PatternFaceResultModel>();
            }

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


            if (!resultList.Any(x => x.Pattern == PatternFaceTypes.None) && result.Stickers == 0)
            {
                result.Pattern = PatternFaceTypes.None;
            }
            else if (result.Stickers == 1)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.A01) && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.A01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.A02) && result.Corners == 1)
                {
                    result.Pattern = PatternFaceTypes.A02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.A03) && result.Sides == 1)
                {
                    result.Pattern = PatternFaceTypes.A03;
                }
            }
            else if (result.Stickers == 2)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B01) && t52 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B02) && t60 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B03) && t60 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B04) && t60 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B05) && t52 == colorToCheck && t07 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B06) && t52 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B07) && t52 == colorToCheck && t60 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.B08) && t52 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.B08;
                }
            }
            else if (result.Stickers == 3)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C01) && t60 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C02) && t60 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C03) && t52 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C04) && t52 == colorToCheck && t00 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C05) && t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C06) && t52 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C07) && t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C08) && t52 == colorToCheck && t07 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C09) && t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C10) && t60 == colorToCheck && t07 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C11) && t52 == colorToCheck && t60 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C12) && t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C13) && t52 == colorToCheck && t07 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C13;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C14) && t52 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C14;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C15) && t52 == colorToCheck && t60 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C15;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.C16) && t52 == colorToCheck && t60 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.C16;
                }
            }
            else if (result.Stickers == 4)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D01) && t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D02) && t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D03) && t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D04) && t52 == colorToCheck && t60 == colorToCheck && t07 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D05) && t52 == colorToCheck && t60 == colorToCheck && t45 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D06) && t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D07) && t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D08) && t52 == colorToCheck && t60 == colorToCheck && t37 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D09) && t52 == colorToCheck && t60 == colorToCheck && t30 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D10) && t52 == colorToCheck && t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D11) && t52 == colorToCheck && t07 == colorToCheck && t22 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D12) && t60 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck && t45 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D13) && t60 == colorToCheck && t45 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D13;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D14) && t52 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D14;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D16) && t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D16;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D17) && t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D17;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D18) && t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t37 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D18;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D19) && t52 == colorToCheck && t15 == colorToCheck && t37 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D19;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D20) && t52 == colorToCheck && t60 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D20;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D21) && t52 == colorToCheck && t60 == colorToCheck && t15 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D21;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D22) && t52 == colorToCheck && t07 == colorToCheck && t00 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D22;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D23) && t52 == colorToCheck && t00 == colorToCheck && t15 == colorToCheck && t30 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D23;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.D15) && t52 == colorToCheck && t60 == colorToCheck && t45 == colorToCheck && t22 == colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.D15;
                }
            }
            else if (result.Stickers == 5)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E01) && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E02) && t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E03) && t07 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E04) && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E05) && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E06) && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E08) && t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E09) && t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E10) && t07 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E11) && t07 != colorToCheck && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E14) && t60 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck && t45 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E14;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E15) && t52 != colorToCheck && t07 != colorToCheck && t22 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E15;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E16) && t07 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E16;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E17) && t00 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E17;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E18) && t60 != colorToCheck && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E18;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E19) && t52 != colorToCheck && t00 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E19;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E21) && t07 != colorToCheck && t45 != colorToCheck && t00 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E21;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E22) && t07 != colorToCheck && t45 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E22;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E12) && t07 != colorToCheck && t45 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E13) && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E13;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E23) && t07 != colorToCheck && t45 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E23;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E20) && t60 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E20;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.E07) && t07 != colorToCheck && t45 != colorToCheck && t00 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.E07;
                }

            }
            else if (result.Stickers == 6)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F01) && t37 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F02) && t15 != colorToCheck && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F03) && t15 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F04) && t15 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F05) && t00 != colorToCheck && t37 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F06) && t00 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F07) && t00 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F08) && t45 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F10) && t45 != colorToCheck && t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F12) && t45 != colorToCheck && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F13) && t00 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F13;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F14) && t07 != colorToCheck && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F14;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F15) && t07 != colorToCheck && t45 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F15;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F16) && t07 != colorToCheck && t45 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F16;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F11) && t07 != colorToCheck && t00 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.F09) && t07 != colorToCheck && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.F09;
                }
            }
            else if (result.Stickers == 7)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G01) && t30 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G02) && t37 != colorToCheck && t22 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G03) && t45 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G04) && t15 != colorToCheck && t30 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G05) && t15 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G06) && t00 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G07) && t00 != colorToCheck && t15 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.G08) && t07 != colorToCheck && t37 != colorToCheck)
                {
                    result.Pattern = PatternFaceTypes.G08;
                }
            }
            else if (result.Stickers == 8)
            {
                if (!resultList.Any(x => x.Pattern == PatternFaceTypes.H01) && result.Corners == 3)
                {
                    result.Pattern = PatternFaceTypes.H01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.H02) && result.Sides == 3)
                {
                    result.Pattern = PatternFaceTypes.H02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.H03) && result.Middles == 0)
                {
                    result.Pattern = PatternFaceTypes.H03;
                }
            }
            else if (!resultList.Any(x => x.Pattern == PatternFaceTypes.I01) && result.Stickers == 9)
            {
                result.Pattern = PatternFaceTypes.I01;
            }

            tryCount += 1;

            if (result.Pattern != PatternFaceTypes.Unknown)
            {
                resultList.Add(result);
            }

            if (tryCount <= 20 || (result.Pattern == PatternFaceTypes.Unknown && !resultList.Any()))
            {
                if (tryCount == 5 || tryCount == 15)
                {
                    //Mirror: Top To Bottom
                    return this.GetPatternFaceResult(colorToCheck,
                             t37, t30, t22,
                             t45, t00, t15,
                             t52, t60, t07, tryCount, resultList);
                }
                else if (tryCount == 10)
                {
                    //Mirror: Right To Left
                    return this.GetPatternFaceResult(colorToCheck,
                            t07, t60, t52,
                            t15, t00, t45,
                            t22, t30, t37, tryCount, resultList);
                }
                else if (tryCount <= 20)
                {
                    //Rotate Clockwise
                    return this.GetPatternFaceResult(colorToCheck,
                            t37, t45, t52,
                            t30, t00, t60,
                            t22, t15, t07, tryCount, resultList);
                }
                else
                {
                    throw new Exception($@" face pattern not found
                            {colorToCheck},
                            {t52}, {t60}, {t07},
                            {t45}, {t00}, {t15},
                            {t37}, {t30}, {t22},
                            {tryCount}");
                }
            }
            else
            {
                return resultList.ToArray();
            }
        }

        public PatternAdjacentResultModel[] GetPatternAdjacentResult(StickerColorTypes colorToCheck,
            /*                                  */StickerColorTypes n,
            /*                      */StickerColorTypes nw, StickerColorTypes ne,
            /* */StickerColorTypes wm, StickerColorTypes w, StickerColorTypes e, StickerColorTypes em,
            /*                      */StickerColorTypes sw, StickerColorTypes se,
            /*                                   */StickerColorTypes s
            , Int32 tryCount = 0, List<PatternAdjacentResultModel> resultList = default)
        {
            //Debug.Write($@"adjacent pattern not found
            //                {colorToCheck},
            //                        {n},
            //                        {nw}, {ne},
            //                        {wm}, {w}, {e}, {em},
            //                        {sw}, {se},
            //                        {s},
            //                { tryCount}

            if (resultList == default)
            {
                resultList = new List<PatternAdjacentResultModel>();
            }

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


            if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.None) && result.Stickers == 0)
            {
                result.Pattern = PatternAdjacentTypes.None;
            }
            else if (result.Stickers == 1)
            {
                if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.A01) && n == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.A02) && nw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.A03) && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.A04) && wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.A04;
                }
            }
            else if (result.Stickers == 2)
            {
                if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B01) && n == colorToCheck && wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B02) && n == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B03) && n == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B04) && n == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B05) && nw == colorToCheck && wm == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B06) && nw == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B07) && nw == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B08) && nw == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B09) && nw == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B10) && nw == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B11) && wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.B12) && wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.B12;
                }
            }
            else if (result.Stickers == 3)
            {
                if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C01) && n == colorToCheck && wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C02) && n == colorToCheck && wm == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C03) && n == colorToCheck && wm == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C04) && n == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C05) && n == colorToCheck && w == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C06) && nw == colorToCheck && wm == colorToCheck && w == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C07) && nw == colorToCheck && wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C08) && nw == colorToCheck && wm == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C09) && nw == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C10) && nw == colorToCheck && e == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C10;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C11) && nw == colorToCheck && w == colorToCheck && em == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C12) && nw == colorToCheck && e == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C13) && nw == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C13;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C14) && nw == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C14;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C15) && nw == colorToCheck && e == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C15;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C16) && n == colorToCheck && wm == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C16;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C17) && n == colorToCheck && wm == colorToCheck && e == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C17;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.C18) && n == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.C18;
                }
            }
            else
            {
                if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D01) && n == colorToCheck && wm == colorToCheck && w == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D01;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D02) && n == colorToCheck && wm == colorToCheck && e == colorToCheck && s == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D02;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D03) && n == colorToCheck && wm == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D03;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D04) && n == colorToCheck && wm == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D04;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D05) && n == colorToCheck && wm == colorToCheck && e == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D05;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D06) && nw == colorToCheck && wm == colorToCheck && w == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D06;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D07) && nw == colorToCheck && e == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D07;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D08) && nw == colorToCheck && w == colorToCheck && em == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D08;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D09) && nw == colorToCheck && wm == colorToCheck && w == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D09;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D11) && nw == colorToCheck && wm == colorToCheck && e == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D11;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D12) && nw == colorToCheck && w == colorToCheck && em == colorToCheck && se == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D12;
                }
                else if (!resultList.Any(x => x.Pattern == PatternAdjacentTypes.D10) && n == colorToCheck && wm == colorToCheck && e == colorToCheck && sw == colorToCheck)
                {
                    result.Pattern = PatternAdjacentTypes.D10;
                }
            }

            tryCount += 1;

            if (result.Pattern != PatternAdjacentTypes.Unknown)
            {
                resultList.Add(result);
            }

            if (tryCount < 5 || (result.Pattern == PatternAdjacentTypes.Unknown && !resultList.Any()))
            {
                if (tryCount == 1 || tryCount == 3)
                {
                    //Mirror: Top To Bottom
                    return this.GetPatternAdjacentResult(colorToCheck,
                                    s,
                                    sw, se,
                                    wm, w, e, em,
                                    nw, ne,
                                    n,
                                    tryCount, resultList);
                }
                else if (tryCount == 2 || tryCount == 4)
                {
                    //Mirror: Right To Left
                    return this.GetPatternAdjacentResult(colorToCheck,
                                    n,
                                    ne, nw,
                                    em, e, w, wm,
                                    se, sw,
                                    s,
                                    tryCount, resultList);
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
                return resultList.ToArray();
            }
        }

        public PatternFaceWithAdjacentsModel[] GetCubePatternModel(CubeModel cube, StickerColorTypes color)
        {
            var results = new List<PatternFaceWithAdjacentsModel>();

            PatternStatisticModel patternStatistic = this.GetPatternStatisticModel(cube, color);

            IEnumerable<PatternAdjacentBitModel> adjacentModels = patternStatistic.PatternAdjacentResults.Select(x => this.Convert(x.Pattern));

            for (var i = 0; i < 6; i++)
            {
                PatternFaceBitModel faceForI = this.Convert(patternStatistic.PatternFaceResults[i].Pattern);

                IEnumerable<PatternAdjacentBitModel> modelsForI = adjacentModels.Where(x => this.IsAdjacentPattern(faceForI, x));

                PatternFaceWithAdjacentsModel result = this.GetFaceLayer(faceForI, modelsForI);

                if (result != default)
                {
                    results.Add(result);
                }
            }

            return results.ToArray();
        }

        public Dictionary<StickerColorTypes, PatternStatisticModel> GetSideCompleteness(CubeModel cube)
        {
            var sideColorTotals = new Dictionary<StickerColorTypes, PatternStatisticModel>();

            sideColorTotals[StickerColorTypes.White] = this.GetPatternStatisticModel(cube, StickerColorTypes.White);
            sideColorTotals[StickerColorTypes.Yellow] = this.GetPatternStatisticModel(cube, StickerColorTypes.Yellow);

            sideColorTotals[StickerColorTypes.Blue] = this.GetPatternStatisticModel(cube, StickerColorTypes.Blue);
            sideColorTotals[StickerColorTypes.Green] = this.GetPatternStatisticModel(cube, StickerColorTypes.Green);

            sideColorTotals[StickerColorTypes.Red] = this.GetPatternStatisticModel(cube, StickerColorTypes.Red);
            sideColorTotals[StickerColorTypes.Orange] = this.GetPatternStatisticModel(cube, StickerColorTypes.Orange);

            return sideColorTotals;
        }

        public PatternStatisticModel GetPatternStatisticModel(CubeModel cube, StickerColorTypes color)
        {
            var result = new PatternStatisticModel();
            {
                /// [BNW ] [ BN ] [ BNE]
                /// [NW  ] [  N ] [  NE]
                /// [FNW ] [ FN ] [ FNE]
                PatternFaceResultModel[] northResults = this.GetPatternFaceResult(color,
                    cube.BackNorthWest.StickerNorth.StickerColorType, cube.BackNorth.StickerNorth.StickerColorType, cube.BackNorthEast.StickerNorth.StickerColorType,
                    cube.NorthWest.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType,
                    cube.FrontNorthWest.StickerNorth.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerNorth.StickerColorType
                );
                PatternFaceResultModel north = northResults.Single();

                // [FSW ] [ FS ] [ FSE]
                // [SW  ] [  S ] [  SE]
                // [BSW ] [ BS ] [ BSE]
                PatternFaceResultModel[] southResults = this.GetPatternFaceResult(color,
                    cube.FrontSouthWest.StickerSouth.StickerColorType, cube.FrontSouth.StickerSouth.StickerColorType, cube.FrontSouthEast.StickerSouth.StickerColorType,
                    cube.SouthWest.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType, cube.SouthEast.StickerSouth.StickerColorType,
                    cube.BackSouthWest.StickerSouth.StickerColorType, cube.BackSouth.StickerSouth.StickerColorType, cube.BackSouthEast.StickerSouth.StickerColorType
                );

                PatternFaceResultModel south = southResults.Single();

                //  [BNW ] [ NW ] [ FNW]   
                //  [BW  ] [  W ] [  FW]   
                //  [BSW ] [ SW ] [ FSW]   
                PatternFaceResultModel[] westResults = this.GetPatternFaceResult(color,
                    cube.BackNorthWest.StickerWest.StickerColorType, cube.NorthWest.StickerWest.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                    cube.BackWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType, cube.FrontWest.StickerWest.StickerColorType,
                    cube.BackSouthWest.StickerWest.StickerColorType, cube.SouthWest.StickerWest.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType
                );

                PatternFaceResultModel west = westResults.Single();

                //  [FNE ] [ NE ] [ BNE]    
                //  [FE  ] [  E ] [  BE]    
                //  [FSE ] [ SE ] [ BSE]  
                PatternFaceResultModel[] eastResults = this.GetPatternFaceResult(color,
                       cube.FrontNorthEast.StickerEast.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                       cube.FrontEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType, cube.BackEast.StickerEast.StickerColorType,
                       cube.FrontSouthEast.StickerEast.StickerColorType, cube.SouthEast.StickerEast.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType
                   );

                PatternFaceResultModel east = eastResults.Single();

                //  [FNW ] [ FN ] [ FNE]       
                //  [FW  ] [  F ] [  FE]       
                //  [FSW ] [ FS ] [ FSE]     
                PatternFaceResultModel[] frontResults = this.GetPatternFaceResult(color,
                       cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorth.StickerFront.StickerColorType, cube.FrontNorthEast.StickerFront.StickerColorType,
                       cube.FrontWest.StickerFront.StickerColorType, cube.Front.StickerFront.StickerColorType, cube.FrontEast.StickerFront.StickerColorType,
                       cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouth.StickerFront.StickerColorType, cube.FrontSouthEast.StickerFront.StickerColorType
                   );

                PatternFaceResultModel front = frontResults.Single();

                //  [BNW ] [ BN ] [ BNE]
                //  [BW  ] [  B ] [  BE]
                //  [BSW ] [ BS ] [ BSE]
                PatternFaceResultModel[] backResults = this.GetPatternFaceResult(color,
                       cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorth.StickerBack.StickerColorType, cube.BackNorthEast.StickerBack.StickerColorType,
                       cube.BackWest.StickerBack.StickerColorType, cube.Back.StickerBack.StickerColorType, cube.BackEast.StickerBack.StickerColorType,
                       cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouth.StickerBack.StickerColorType, cube.BackSouthEast.StickerBack.StickerColorType
                   );

                PatternFaceResultModel back = backResults.Single();

                result.PatternFaceResults = new List<PatternFaceResultModel>() { north, south, east, west, front, back };
            }
            {
                //            [ FNE]
                //         [ FNE] [FNE ]  
                //  [  F ] [  FE] [FE  ] [  E ] 
                //         [ FSE] [FSE ] 
                //            [ FSE]
                PatternAdjacentResultModel[] feResults = this.GetPatternAdjacentResult(color,
                    cube.FrontNorthEast.StickerNorth.StickerColorType,
                    cube.FrontNorthEast.StickerFront.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
                    cube.Front.StickerFront.StickerColorType, cube.FrontEast.StickerFront.StickerColorType, cube.FrontEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                    cube.FrontSouthEast.StickerFront.StickerColorType, cube.FrontSouthEast.StickerEast.StickerColorType,
                    cube.FrontSouthEast.StickerSouth.StickerColorType
                );

                PatternAdjacentResultModel fe = feResults.Single();

                //            [ FNW]
                //         [ FNW] [FNW ]  
                //  [  F ] [  FW] [FW  ] [  W ] 
                //         [ FSW] [FSW ] 
                //            [ FSW]
                PatternAdjacentResultModel[] fwResults = this.GetPatternAdjacentResult(color,
                    cube.FrontNorthWest.StickerNorth.StickerColorType,
                    cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                    cube.Front.StickerFront.StickerColorType, cube.FrontWest.StickerFront.StickerColorType, cube.FrontWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                    cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType,
                    cube.FrontSouthWest.StickerSouth.StickerColorType
                );

                PatternAdjacentResultModel fw = fwResults.Single();


                //            [ FNW]
                //         [ FNW] [FNW ]  
                //  [  F ] [  FN] [FN  ] [  N ] 
                //         [ FNE] [FNE ] 
                //            [ FNE]
                PatternAdjacentResultModel[] fnResults = this.GetPatternAdjacentResult(color,
                    cube.FrontNorthWest.StickerWest.StickerColorType,
                    cube.FrontNorthWest.StickerFront.StickerColorType, cube.FrontNorthWest.StickerNorth.StickerColorType,
                    cube.Front.StickerFront.StickerColorType, cube.FrontNorth.StickerFront.StickerColorType, cube.FrontNorth.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType,
                    cube.FrontNorthEast.StickerFront.StickerColorType, cube.FrontNorthEast.StickerNorth.StickerColorType,
                    cube.FrontNorthEast.StickerEast.StickerColorType
                );

                PatternAdjacentResultModel fn = fnResults.Single();

                //            [ FSE]
                //         [ FSE] [FSE ]  
                //  [  F ] [  FS] [FS  ] [  S ] 
                //         [ FSW] [FSW ] 
                //            [ FSW]
                PatternAdjacentResultModel[] fsResults = this.GetPatternAdjacentResult(color,
                    cube.FrontSouthEast.StickerEast.StickerColorType,
                    cube.FrontSouthEast.StickerFront.StickerColorType, cube.FrontSouthEast.StickerSouth.StickerColorType,
                    cube.Front.StickerFront.StickerColorType, cube.FrontSouth.StickerFront.StickerColorType, cube.FrontSouth.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType,
                    cube.FrontSouthWest.StickerFront.StickerColorType, cube.FrontSouthWest.StickerSouth.StickerColorType,
                    cube.FrontSouthWest.StickerWest.StickerColorType
                );

                PatternAdjacentResultModel fs = fsResults.Single();

                //            [ BNE]
                //         [ BNE] [BNE ]  
                //  [  N ] [  NE] [NE  ] [  E ] 
                //         [ FNE] [FNE ] 
                //            [ FNE]
                PatternAdjacentResultModel[] neResults = this.GetPatternAdjacentResult(color,
                    cube.BackNorthEast.StickerBack.StickerColorType,
                    cube.BackNorthEast.StickerNorth.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                    cube.North.StickerNorth.StickerColorType, cube.NorthEast.StickerNorth.StickerColorType, cube.NorthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                    cube.FrontNorthEast.StickerNorth.StickerColorType, cube.FrontNorthEast.StickerEast.StickerColorType,
                    cube.FrontNorthEast.StickerFront.StickerColorType
                );

                PatternAdjacentResultModel ne = neResults.Single();

                //            [ FNW]
                //         [ FNW] [FNW ]  
                //  [  N ] [  NW] [NW  ] [  W ] 
                //         [ BNW] [BNW ] 
                //            [ BNW]
                PatternAdjacentResultModel[] nwResults = this.GetPatternAdjacentResult(color,
                    cube.FrontNorthWest.StickerFront.StickerColorType,
                    cube.FrontNorthWest.StickerNorth.StickerColorType, cube.FrontNorthWest.StickerWest.StickerColorType,
                    cube.North.StickerNorth.StickerColorType, cube.NorthWest.StickerNorth.StickerColorType, cube.NorthWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                    cube.BackNorthWest.StickerNorth.StickerColorType, cube.BackNorthWest.StickerWest.StickerColorType,
                    cube.BackNorthWest.StickerBack.StickerColorType
                );

                PatternAdjacentResultModel nw = nwResults.Single();

                //            [ FSE]
                //         [ FSE] [FSE ]  
                //  [  S ] [  SW] [SW  ] [  E ] 
                //         [ BSE] [BSE ] 
                //            [ BSE]
                PatternAdjacentResultModel[] seResults = this.GetPatternAdjacentResult(color,
                    cube.FrontSouthEast.StickerFront.StickerColorType,
                    cube.FrontSouthEast.StickerSouth.StickerColorType, cube.FrontSouthEast.StickerEast.StickerColorType,
                    cube.South.StickerSouth.StickerColorType, cube.SouthEast.StickerSouth.StickerColorType, cube.SouthEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                    cube.BackSouthEast.StickerSouth.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType,
                    cube.BackSouthEast.StickerBack.StickerColorType
                );

                PatternAdjacentResultModel se = seResults.Single();

                //            [ BSW]
                //         [ BSW] [BSW ]  
                //  [  S ] [  SW] [SW  ] [  W ] 
                //         [ FSW] [FSW ] 
                //            [ FSW]
                PatternAdjacentResultModel[] swResults = this.GetPatternAdjacentResult(color,
                    cube.BackSouthWest.StickerBack.StickerColorType,
                    cube.BackSouthWest.StickerSouth.StickerColorType, cube.BackSouthWest.StickerWest.StickerColorType,
                    cube.South.StickerSouth.StickerColorType, cube.SouthWest.StickerSouth.StickerColorType, cube.SouthWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                    cube.FrontSouthWest.StickerSouth.StickerColorType, cube.FrontSouthWest.StickerWest.StickerColorType,
                    cube.FrontSouthWest.StickerFront.StickerColorType
                );

                PatternAdjacentResultModel sw = swResults.Single();

                //            [ BNE]
                //         [ BNE] [BNE ]  
                //  [  B ] [  BE] [BE  ] [  E ] 
                //         [ BSE] [BSE ] 
                //            [ BSE]
                PatternAdjacentResultModel[] beResults = this.GetPatternAdjacentResult(color,
                    cube.BackNorthEast.StickerNorth.StickerColorType,
                    cube.BackNorthEast.StickerBack.StickerColorType, cube.BackNorthEast.StickerEast.StickerColorType,
                    cube.Back.StickerBack.StickerColorType, cube.BackEast.StickerBack.StickerColorType, cube.BackEast.StickerEast.StickerColorType, cube.East.StickerEast.StickerColorType,
                    cube.BackSouthEast.StickerBack.StickerColorType, cube.BackSouthEast.StickerEast.StickerColorType,
                    cube.BackSouthEast.StickerSouth.StickerColorType
                );

                PatternAdjacentResultModel be = beResults.Single();

                //            [ BNW]
                //         [ BNW] [BNW ]  
                //  [  B ] [  BW] [BW  ] [  W ] 
                //         [ BSW] [BSW ] 
                //            [ BSW]
                PatternAdjacentResultModel[] bwResults = this.GetPatternAdjacentResult(color,
                    cube.BackNorthWest.StickerNorth.StickerColorType,
                    cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorthWest.StickerWest.StickerColorType,
                    cube.Back.StickerBack.StickerColorType, cube.BackWest.StickerBack.StickerColorType, cube.BackWest.StickerWest.StickerColorType, cube.West.StickerWest.StickerColorType,
                    cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouthWest.StickerWest.StickerColorType,
                    cube.BackSouthWest.StickerSouth.StickerColorType
                );

                PatternAdjacentResultModel bw = bwResults.Single();

                //            [ BSE]
                //         [ BSE] [BSE ]  
                //  [  B ] [  BS] [BS  ] [  S ] 
                //         [ BSW] [BSW ] 
                //            [ BSW]
                PatternAdjacentResultModel[] bsResults = this.GetPatternAdjacentResult(color,
                    cube.BackSouthEast.StickerEast.StickerColorType,
                    cube.BackSouthEast.StickerBack.StickerColorType, cube.BackSouthEast.StickerSouth.StickerColorType,
                    cube.Back.StickerBack.StickerColorType, cube.BackSouth.StickerBack.StickerColorType, cube.BackSouth.StickerSouth.StickerColorType, cube.South.StickerSouth.StickerColorType,
                    cube.BackSouthWest.StickerBack.StickerColorType, cube.BackSouthWest.StickerSouth.StickerColorType,
                    cube.BackSouthWest.StickerWest.StickerColorType
                );

                PatternAdjacentResultModel bs = bsResults.Single();

                //            [ BNE]
                //         [ BNE] [BNE ]  
                //  [  B ] [  BN] [BN  ] [  N ] 
                //         [ BNW] [BNW ] 
                //            [ BNW]
                PatternAdjacentResultModel[] bnResults = this.GetPatternAdjacentResult(color,
                    cube.BackNorthEast.StickerEast.StickerColorType,
                    cube.BackNorthEast.StickerBack.StickerColorType, cube.BackNorthEast.StickerNorth.StickerColorType,
                    cube.Back.StickerBack.StickerColorType, cube.BackNorth.StickerBack.StickerColorType, cube.BackNorth.StickerNorth.StickerColorType, cube.North.StickerNorth.StickerColorType,
                    cube.BackNorthWest.StickerBack.StickerColorType, cube.BackNorthWest.StickerNorth.StickerColorType,
                    cube.BackNorthWest.StickerWest.StickerColorType
                );

                PatternAdjacentResultModel bn = bnResults.Single();


                result.PatternAdjacentResults = new List<PatternAdjacentResultModel>() { fn, fe, fs, fw, ne, se, sw, nw, bn, be, bs, bw };
            }
            return result;
        }

        #endregion

        #region protected methods

        protected Boolean IsAdjacentPattern(PatternFaceBitModel facePatternBits, PatternAdjacentBitModel patternAdjacentTypeBits)
        {
            return (patternAdjacentTypeBits.WM && facePatternBits.T00) || (patternAdjacentTypeBits.EM && facePatternBits.T00);
        }

        protected PatternFaceWithAdjacentsModel GetFaceLayer(PatternFaceBitModel patternFaceBitModel, IEnumerable<PatternAdjacentBitModel> patternAdjacentModels)
        {
            var result = new PatternFaceWithAdjacentsModel();

            foreach (var patternAdjacentBitModel in patternAdjacentModels)
            {
                if (patternFaceBitModel.T00 == patternAdjacentBitModel.EM)
                {
                    foreach (RotationTypes rotationType in (RotationTypes[])Enum.GetValues(typeof(RotationTypes)))
                    {
                        if (patternAdjacentBitModel.NE == patternFaceBitModel.T07
                            && patternAdjacentBitModel.E == patternFaceBitModel.T15
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T22)
                        {
                            result.East = new PatternAdjacentModel(PatternAdjacentFlipTypes.None, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T22
                            && patternAdjacentBitModel.E == patternFaceBitModel.T30
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T37)
                        {
                            result.South = new PatternAdjacentModel(PatternAdjacentFlipTypes.None, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T37
                            && patternAdjacentBitModel.E == patternFaceBitModel.T45
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T52)
                        {
                            result.West = new PatternAdjacentModel(PatternAdjacentFlipTypes.None, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T52
                            && patternAdjacentBitModel.E == patternFaceBitModel.T60
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T07)
                        {
                            result.North = new PatternAdjacentModel(PatternAdjacentFlipTypes.None, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T07
                            && patternAdjacentBitModel.E == patternFaceBitModel.T15
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T22)
                        {
                            result.East = new PatternAdjacentModel(PatternAdjacentFlipTypes.Vertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T22
                            && patternAdjacentBitModel.E == patternFaceBitModel.T30
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T37)
                        {
                            result.South = new PatternAdjacentModel(PatternAdjacentFlipTypes.Vertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T37
                            && patternAdjacentBitModel.E == patternFaceBitModel.T45
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T52)
                        {
                            result.West = new PatternAdjacentModel(PatternAdjacentFlipTypes.Vertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NE == patternFaceBitModel.T52
                            && patternAdjacentBitModel.E == patternFaceBitModel.T60
                            && patternAdjacentBitModel.SE == patternFaceBitModel.T07)
                        {
                            result.North = new PatternAdjacentModel(PatternAdjacentFlipTypes.Vertical, patternAdjacentBitModel);
                        }
                    }
                }
                else if (patternFaceBitModel.T00 == patternAdjacentBitModel.NW)
                {
                    foreach (RotationTypes rotationType in (RotationTypes[])Enum.GetValues(typeof(RotationTypes)))
                    {
                        if (patternAdjacentBitModel.NW == patternFaceBitModel.T07
                            && patternAdjacentBitModel.W == patternFaceBitModel.T15
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T22)
                        {
                            result.East = new PatternAdjacentModel(PatternAdjacentFlipTypes.Horizontal, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T22
                            && patternAdjacentBitModel.W == patternFaceBitModel.T30
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T37)
                        {
                            result.South = new PatternAdjacentModel(PatternAdjacentFlipTypes.None, patternAdjacentBitModel);
                            result.South.PatternAdjacentFlipType = PatternAdjacentFlipTypes.Horizontal;
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T37
                            && patternAdjacentBitModel.W == patternFaceBitModel.T45
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T52)
                        {
                            result.West = new PatternAdjacentModel(PatternAdjacentFlipTypes.Horizontal, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T52
                            && patternAdjacentBitModel.W == patternFaceBitModel.T60
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T07)
                        {
                            result.North = new PatternAdjacentModel(PatternAdjacentFlipTypes.Horizontal, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T07
                            && patternAdjacentBitModel.W == patternFaceBitModel.T15
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T22)
                        {
                            result.East = new PatternAdjacentModel(PatternAdjacentFlipTypes.HorizontalAndVertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T22
                            && patternAdjacentBitModel.W == patternFaceBitModel.T30
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T37)
                        {
                            result.South = new PatternAdjacentModel(PatternAdjacentFlipTypes.HorizontalAndVertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T37
                            && patternAdjacentBitModel.W == patternFaceBitModel.T45
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T52)
                        {
                            result.West = new PatternAdjacentModel(PatternAdjacentFlipTypes.HorizontalAndVertical, patternAdjacentBitModel);
                        }
                        else if (patternAdjacentBitModel.NW == patternFaceBitModel.T52
                            && patternAdjacentBitModel.W == patternFaceBitModel.T60
                            && patternAdjacentBitModel.SW == patternFaceBitModel.T07)
                        {
                            result.North = new PatternAdjacentModel(PatternAdjacentFlipTypes.HorizontalAndVertical, patternAdjacentBitModel);
                        }
                    }
                }
            }

            //if (result.North..PatternAdjacentType == PatternAdjacentTypes.)
            //{

            //}

            return result;
        }

        protected PatternAdjacentStickerTypes PatternAdjacentStickerType(StickerColorTypes stickerColorA, StickerColorTypes stickerColorB)
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

        protected PatternFaceBitModel Convert(PatternFaceTypes patternFaceType)
        {


            /// <summary>
            /// | X X X |
            /// | X X X |
            /// | X X X |
            /// </summary>
            if (patternFaceType == PatternFaceTypes.None) { return new PatternFaceBitModel(PatternFaceTypes.None, false, false, false, false, false, false, false, false, false); }

            /// <summary>
            /// | X X X |
            /// | X O X |
            /// | X X X |
            /// </summary>
            else if (patternFaceType == PatternFaceTypes.A01) { return new PatternFaceBitModel(PatternFaceTypes.A01, false, false, false, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.A02) { return new PatternFaceBitModel(PatternFaceTypes.A02, true, false, false, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.A03) { return new PatternFaceBitModel(PatternFaceTypes.A03, false, true, false, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B01) { return new PatternFaceBitModel(PatternFaceTypes.B01, true, false, false, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B02) { return new PatternFaceBitModel(PatternFaceTypes.B02, false, true, false, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B03) { return new PatternFaceBitModel(PatternFaceTypes.B03, false, true, false, false, false, true, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B04) { return new PatternFaceBitModel(PatternFaceTypes.B04, false, true, false, false, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B05) { return new PatternFaceBitModel(PatternFaceTypes.B05, true, false, true, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X X X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B06) { return new PatternFaceBitModel(PatternFaceTypes.B06, true, false, false, false, false, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B07) { return new PatternFaceBitModel(PatternFaceTypes.B07, true, true, false, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X X O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.B08) { return new PatternFaceBitModel(PatternFaceTypes.B08, true, false, false, false, false, true, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X O O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C01) { return new PatternFaceBitModel(PatternFaceTypes.C01, false, true, false, false, true, true, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C02) { return new PatternFaceBitModel(PatternFaceTypes.C02, false, true, false, false, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C03) { return new PatternFaceBitModel(PatternFaceTypes.C03, true, false, true, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C04) { return new PatternFaceBitModel(PatternFaceTypes.C04, true, false, false, false, true, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C05) { return new PatternFaceBitModel(PatternFaceTypes.C05, true, true, false, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X O O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C06) { return new PatternFaceBitModel(PatternFaceTypes.C06, true, false, false, false, true, true, false, false, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C07) { return new PatternFaceBitModel(PatternFaceTypes.C07, false, true, false, false, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X X X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C08) { return new PatternFaceBitModel(PatternFaceTypes.C08, true, false, true, false, false, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C09) { return new PatternFaceBitModel(PatternFaceTypes.C09, true, true, false, false, false, true, false, false, false); }

            /// <summary>                                                                      
            /// | X O O |                                                                      
            /// | X X O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C10) { return new PatternFaceBitModel(PatternFaceTypes.C10, false, true, true, false, false, true, false, false, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C11) { return new PatternFaceBitModel(PatternFaceTypes.C11, true, true, false, false, false, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C12) { return new PatternFaceBitModel(PatternFaceTypes.C12, true, true, true, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C13) { return new PatternFaceBitModel(PatternFaceTypes.C13, true, false, true, false, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C14) { return new PatternFaceBitModel(PatternFaceTypes.C14, true, false, false, false, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C15) { return new PatternFaceBitModel(PatternFaceTypes.C15, true, true, false, false, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.C16) { return new PatternFaceBitModel(PatternFaceTypes.C16, true, true, false, false, false, false, true, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D01) { return new PatternFaceBitModel(PatternFaceTypes.D01, true, true, true, true, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D02) { return new PatternFaceBitModel(PatternFaceTypes.D02, true, true, true, false, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D03) { return new PatternFaceBitModel(PatternFaceTypes.D03, true, true, true, false, false, false, true, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D04) { return new PatternFaceBitModel(PatternFaceTypes.D04, true, true, true, false, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D05) { return new PatternFaceBitModel(PatternFaceTypes.D05, true, true, false, true, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D06) { return new PatternFaceBitModel(PatternFaceTypes.D06, true, true, false, false, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D07) { return new PatternFaceBitModel(PatternFaceTypes.D07, true, true, false, false, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | O O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D08) { return new PatternFaceBitModel(PatternFaceTypes.D08, true, true, false, false, false, false, true, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D09) { return new PatternFaceBitModel(PatternFaceTypes.D09, true, true, false, false, false, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D10) { return new PatternFaceBitModel(PatternFaceTypes.D10, true, true, false, true, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X X X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D11) { return new PatternFaceBitModel(PatternFaceTypes.D11, true, false, true, false, false, false, true, false, true); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D12) { return new PatternFaceBitModel(PatternFaceTypes.D12, false, true, false, true, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D13) { return new PatternFaceBitModel(PatternFaceTypes.D13, false, true, false, true, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D14) { return new PatternFaceBitModel(PatternFaceTypes.D14, true, false, true, false, true, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O X X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D15) { return new PatternFaceBitModel(PatternFaceTypes.D15, true, true, false, true, false, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D16) { return new PatternFaceBitModel(PatternFaceTypes.D16, true, true, false, false, false, true, true, false, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D17) { return new PatternFaceBitModel(PatternFaceTypes.D17, true, true, false, false, true, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D18) { return new PatternFaceBitModel(PatternFaceTypes.D18, true, true, false, false, true, false, true, false, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X X O |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D19) { return new PatternFaceBitModel(PatternFaceTypes.D19, true, false, false, false, false, true, true, false, true); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X X O |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D20) { return new PatternFaceBitModel(PatternFaceTypes.D20, true, false, true, false, false, true, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D21) { return new PatternFaceBitModel(PatternFaceTypes.D21, true, true, false, false, false, true, false, false, true); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D22) { return new PatternFaceBitModel(PatternFaceTypes.D22, true, false, true, false, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X X |                                                                      
            /// | X O O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.D23) { return new PatternFaceBitModel(PatternFaceTypes.D23, false, false, false, false, false, false, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E01) { return new PatternFaceBitModel(PatternFaceTypes.E01, true, true, true, true, true, false, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E02) { return new PatternFaceBitModel(PatternFaceTypes.E02, true, true, true, true, false, false, true, false, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E03) { return new PatternFaceBitModel(PatternFaceTypes.E03, true, true, false, true, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E04) { return new PatternFaceBitModel(PatternFaceTypes.E04, true, true, true, true, false, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E05) { return new PatternFaceBitModel(PatternFaceTypes.E05, true, true, true, true, false, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E06) { return new PatternFaceBitModel(PatternFaceTypes.E06, true, true, true, false, true, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | O O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E07) { return new PatternFaceBitModel(PatternFaceTypes.E07, true, true, false, false, false, true, true, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E08) { return new PatternFaceBitModel(PatternFaceTypes.E08, true, true, true, false, false, false, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E09) { return new PatternFaceBitModel(PatternFaceTypes.E09, true, true, true, false, false, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O X X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E10) { return new PatternFaceBitModel(PatternFaceTypes.E10, true, true, false, true, false, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E11) { return new PatternFaceBitModel(PatternFaceTypes.E11, true, true, false, false, true, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E12) { return new PatternFaceBitModel(PatternFaceTypes.E12, true, true, false, false, true, true, true, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E13) { return new PatternFaceBitModel(PatternFaceTypes.E13, true, true, true, false, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E14) { return new PatternFaceBitModel(PatternFaceTypes.E14, true, false, true, false, true, false, true, false, true); }

            /// <summary>                                                                      
            /// | X O X |                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E15) { return new PatternFaceBitModel(PatternFaceTypes.E15, false, true, false, true, true, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E16) { return new PatternFaceBitModel(PatternFaceTypes.E16, true, true, false, true, true, true, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E17) { return new PatternFaceBitModel(PatternFaceTypes.E17, true, true, true, true, false, true, false, false, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E18) { return new PatternFaceBitModel(PatternFaceTypes.E18, true, false, true, false, true, false, false, true, true); }

            /// <summary>                                                                      
            /// | X O O |                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E19) { return new PatternFaceBitModel(PatternFaceTypes.E19, false, true, true, true, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | O X O |                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E20) { return new PatternFaceBitModel(PatternFaceTypes.E20, true, false, true, true, true, true, false, false, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// | O X O |                                                                      
            /// </summarytrue                                                                  
            else if (patternFaceType == PatternFaceTypes.E21) { return new PatternFaceBitModel(PatternFaceTypes.E21, true, true, false, false, false, true, true, false, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E22) { return new PatternFaceBitModel(PatternFaceTypes.E22, true, true, false, false, true, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.E23) { return new PatternFaceBitModel(PatternFaceTypes.E23, true, true, false, false, true, true, false, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F01) { return new PatternFaceBitModel(PatternFaceTypes.F01, true, true, true, true, true, true, false, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F02) { return new PatternFaceBitModel(PatternFaceTypes.F02, true, true, true, true, true, false, true, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F03) { return new PatternFaceBitModel(PatternFaceTypes.F03, true, true, true, true, true, false, false, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F04) { return new PatternFaceBitModel(PatternFaceTypes.F04, true, true, true, true, true, false, false, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// | X X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F05) { return new PatternFaceBitModel(PatternFaceTypes.F05, true, true, true, true, false, true, false, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F06) { return new PatternFaceBitModel(PatternFaceTypes.F06, true, true, true, true, false, false, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F07) { return new PatternFaceBitModel(PatternFaceTypes.F07, true, true, true, true, false, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F08) { return new PatternFaceBitModel(PatternFaceTypes.F08, true, true, true, false, true, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F09) { return new PatternFaceBitModel(PatternFaceTypes.F09, true, true, false, true, true, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X X X |                                                                      
            /// | O O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F10) { return new PatternFaceBitModel(PatternFaceTypes.F10, true, true, true, false, false, false, true, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O X O |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F11) { return new PatternFaceBitModel(PatternFaceTypes.F11, true, true, false, true, false, true, false, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F12) { return new PatternFaceBitModel(PatternFaceTypes.F12, true, true, true, false, true, false, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F13) { return new PatternFaceBitModel(PatternFaceTypes.F13, true, true, true, true, false, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F14) { return new PatternFaceBitModel(PatternFaceTypes.F14, true, true, false, true, true, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// | O O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F15) { return new PatternFaceBitModel(PatternFaceTypes.F15, true, true, false, false, true, true, true, true, false); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.F16) { return new PatternFaceBitModel(PatternFaceTypes.F16, true, true, false, false, true, true, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G01) { return new PatternFaceBitModel(PatternFaceTypes.G01, true, true, true, true, true, true, true, false, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G02) { return new PatternFaceBitModel(PatternFaceTypes.G02, true, true, true, true, true, true, false, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | X O X |                                                                      
            /// | O O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G03) { return new PatternFaceBitModel(PatternFaceTypes.G03, true, true, true, false, true, false, true, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G04) { return new PatternFaceBitModel(PatternFaceTypes.G04, true, true, true, true, true, false, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G05) { return new PatternFaceBitModel(PatternFaceTypes.G05, true, true, true, true, true, false, false, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G06) { return new PatternFaceBitModel(PatternFaceTypes.G06, true, true, true, true, false, true, false, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X X |                                                                      
            /// | O O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G07) { return new PatternFaceBitModel(PatternFaceTypes.G07, true, true, true, true, false, false, true, true, true); }

            /// <summary>                                                                      
            /// | O O X |                                                                      
            /// | O O O |                                                                      
            /// | X O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.G08) { return new PatternFaceBitModel(PatternFaceTypes.G08, true, true, false, true, true, true, false, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | O O X |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.H01) { return new PatternFaceBitModel(PatternFaceTypes.H01, true, true, true, true, true, true, true, true, false); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.H02) { return new PatternFaceBitModel(PatternFaceTypes.H02, true, true, true, true, true, true, true, false, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O X O |                                                                      
            /// | O O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.H03) { return new PatternFaceBitModel(PatternFaceTypes.H03, true, true, true, true, false, true, true, true, true); }

            /// <summary>                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// | O O O |                                                                      
            /// </summary>                                                                     
            else if (patternFaceType == PatternFaceTypes.I01) { return new PatternFaceBitModel(PatternFaceTypes.I01, true, true, true, true, true, true, true, true, true); }

            /// <summary>
            /// | ? ? ? |
            /// | ? ? ? |
            /// | ? ? ? |
            /// </summary>
            else { throw new Exception("Convert PatternFaceTypes Failed"); }
        }

        protected PatternAdjacentBitModel Convert(PatternAdjacentTypes patternAdjacentType)
        {



            ///  <summary>
            /// [ - - X - - ]
            /// [ - X | X - ]
            /// [ X X | X X ]
            /// [ - X | X - ]
            /// [ - - X - - ]
            ///  </summary>
            if (patternAdjacentType == PatternAdjacentTypes.None) { return new PatternAdjacentBitModel(PatternAdjacentTypes.None, false, false, false, false, false, false, false, false, false, false); }

            ///  <summary>
            /// [ - - O - - ]
            /// [ - X | X - ]
            /// [ X X | X X ]
            /// [ - X | X - ]
            /// [ - - X - - ]
            ///  </summary>
            else if (patternAdjacentType == PatternAdjacentTypes.A01) { return new PatternAdjacentBitModel(PatternAdjacentTypes.A01, true, false, false, false, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.A02) { return new PatternAdjacentBitModel(PatternAdjacentTypes.A02, false, true, false, false, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.A03) { return new PatternAdjacentBitModel(PatternAdjacentTypes.A03, false, false, false, false, true, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.A04) { return new PatternAdjacentBitModel(PatternAdjacentTypes.A04, false, false, false, true, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B01) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B01, true, false, false, true, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B02) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B02, true, false, false, false, true, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X X | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B03) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B03, true, false, false, false, false, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - O - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B04) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B04, true, false, false, false, false, false, false, false, false, true); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B05) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B05, false, true, false, true, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B06) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B06, false, true, false, false, true, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | O X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B07) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B07, false, true, false, false, false, true, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X O ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B08) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B08, false, true, false, false, false, false, true, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B09) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B09, false, true, false, false, false, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B10) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B10, true, true, false, false, false, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B11) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B11, false, false, false, true, true, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.B12) { return new PatternAdjacentBitModel(PatternAdjacentTypes.B12, false, false, false, true, false, true, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C01) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C01, true, false, false, true, true, false, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C02) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C02, true, false, false, true, false, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - O - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C03) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C03, true, false, false, true, false, false, false, false, false, true); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C04) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C04, true, false, false, false, true, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - O - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C05) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C05, true, false, false, false, true, false, false, false, false, true); }


            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C06) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C06, false, true, false, true, true, false, false, false, false, false); }


            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C07) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C07, false, true, false, true, false, true, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C08) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C08, false, true, false, true, false, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C09) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C09, false, true, false, false, true, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | O O ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C10) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C10, false, true, false, false, false, true, true, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X O | X O ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C11) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C11, false, true, false, false, true, false, true, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | O X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C12) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C12, false, true, false, false, false, true, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X O ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C13) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C13, false, true, false, false, false, false, true, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | X O ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C14) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C14, false, true, false, false, false, false, true, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | O X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C15) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C15, false, true, false, false, false, true, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | X X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C16) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C16, true, false, false, true, false, false, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C17) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C17, true, false, false, true, false, true, false, false, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ X O | X X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.C18) { return new PatternAdjacentBitModel(PatternAdjacentTypes.C18, true, false, false, false, true, false, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - O - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D01) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D01, true, false, false, true, true, false, false, false, false, true); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ - - O - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D02) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D02, true, false, false, true, false, true, false, false, false, true); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D03) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D03, true, false, false, true, true, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D04) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D04, true, false, false, true, true, false, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D05) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D05, true, false, false, true, false, true, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D06) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D06, false, true, false, true, true, false, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X X | O O ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D07) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D07, false, true, false, false, false, true, true, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X O | X O ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D08) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D08, false, true, false, false, true, false, true, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O O | X X ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D09) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D09, false, true, false, true, true, false, false, false, true, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - X | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D10) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D10, true, false, false, true, false, true, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - X - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ O X | O X ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D11) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D11, false, true, false, true, false, true, false, true, false, false); }

            ///  <summary>                                                                                
            /// [ - - O - - ]                                                                             
            /// [ - O | X - ]                                                                             
            /// [ X O | X O ]                                                                             
            /// [ - X | O - ]                                                                             
            /// [ - - X - - ]                                                                             
            ///  </summary>                                                                               
            else if (patternAdjacentType == PatternAdjacentTypes.D12) { return new PatternAdjacentBitModel(PatternAdjacentTypes.D12, true, true, false, false, true, false, true, false, true, false); }

            ///  <summary>
            /// [ - - ? - - ]
            /// [ - ? | ? - ]
            /// [ ? ? | ? ? ]
            /// [ - ? | ? - ]
            /// [ - - ? - - ]
            ///  </summary>
            else { throw new Exception("Convert PatternAdjacentTypes Failed"); }
        }
        
        #endregion
    }
}
