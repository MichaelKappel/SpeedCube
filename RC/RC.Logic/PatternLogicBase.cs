using RC.Common.Enumerations;
using RC.Common.Model;
using RC.Common.Model.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Logic
{
    public abstract class PatternLogicBase: LogicBase
    {

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


        public String Visualize(String pattern)
        {

            var s = pattern.ToCharArray();


            String result = $@" 
                                   [9:{s[9]}|10:{s[10]}|ll:{s[11]}]
                                   [12:{s[12]}|13:{s[13]}|14:{s[14]}]
                                   [15:{s[15]}|16:{s[16]}|17:{s[17]}]  
    
[27:{s[27]}|28:{s[28]}|29:{s[29]}] [18:{s[18]}|19:{s[19]}|20:{s[20]}] [0:{s[0]}|1:{s[1]}|2:{s[2]}] [45:{s[45]}|46:{s[46]}|47:{s[47]}]    
[30:{s[30]}|31:{s[31]}|32:{s[32]}] [21:{s[21]}|22:{s[22]}|23:{s[23]}] [3:{s[3]}|4:{s[4]}|5:{s[5]}] [48:{s[48]}|49:{s[49]}|50:{s[50]}]    
[33:{s[33]}|34:{s[34]}|35:{s[35]}] [24:{s[24]}|25:{s[25]}|26:{s[26]}] [6:{s[6]}|7:{s[7]}|8:{s[8]}] [51:{s[51]}|52:{s[52]}|53:{s[53]}]    
            
                                   [36:{s[36]}|37:{s[37]}|38:{s[38]}]  
                                   [39:{s[39]}|40:{s[40]}|41:{s[41]}]  
                                   [42:{s[42]}|43:{s[43]}|44:{s[44]}]     
                    
";

            return result;

        }

        public String GetCubePattern(CubeModel cube)
        {
            XyzCubeTypes xyzCubeType = GetXyzCubeType(cube);

            String east = $"{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.NorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.East.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.SouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthEast.StickerEast.StickerColorType)}";
            String north = $"{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.NorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.North.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.NorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthEast.StickerNorth.StickerColorType)}";
            String front = $"{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.Front.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthEast.StickerFront.StickerColorType)}";
            String west = $"{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.NorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.West.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.SouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthWest.StickerWest.StickerColorType)}";
            String south = $"{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.FrontSouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.SouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.South.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.SouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthEast.StickerSouth.StickerColorType)}";
            String back = $"{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackNorth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackNorthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.Back.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(xyzCubeType, cube.BackSouthWest.StickerBack.StickerColorType)}";

            return $"{east}{north}{front}{west}{south}{back}";
        }
    }
}
