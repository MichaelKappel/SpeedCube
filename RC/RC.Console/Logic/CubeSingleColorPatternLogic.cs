using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;

namespace RC.Logic
{
    public class CubeSingleColorPatternLogic : LogicBase
    {
        /// <summary>
        /// 
        ///                          [B  0] [B  1] [B  2]
        ///                          [BNW ] [ BN ] [ BNE]

        ///                          [B  3] [B  4] [B  5]
        ///                          [NW  ] [  N ] [  NE]

        ///                          [B  6] [B  7] [B  8]
        ///                          [FNW ] [ FN ] [ FNE]


        ///  [a 36] [a 37] [a 38]    [C 18] [C 19] [C 20]       [A 45] [A 46] [A 47]    [c 27] [c 28] [c 29]
        ///  [BNW ] [ NW ] [ FNW]    [FNW ] [ FN ] [ FNE]       [FNE ] [ NE ] [ BNE]    [BNW ] [ BN ] [ BNE]

        ///  [a 39] [a 40] [a 41]    [C 21] [C 22] [C 23]       [A 48] [A 49] [A 50]    [c 30] [c 31] [c 32]
        ///  [BW  ] [  W ] [  FW]    [FW  ] [  F ] [  FE]       [FE  ] [  E ] [  BE]    [BW  ] [  B ] [  BE]

        ///  [a 42] [a 43] [a 44]    [C 24] [C 25] [C 26]       [A 51] [A 52] [A 53]    [c 33] [c 34] [c 35]
        ///  [BSW ] [ SW ] [ FSW]    [FSW ] [ FS ] [ FSE]       [FSE ] [ SE ] [ BSE]    [BSW ] [ BS ] [ BSE]


        ///                          [b  9] [b 10] [b 11]
        ///                          [FSW ] [ FS ] [ FSE]

        ///                          [b 12] [b 13] [b 14]
        ///                          [SW  ] [  S ] [  SE]

        ///                          [b 15] [b 16] [b 17]
        ///                          [BSW ] [ BS ] [ BSE]

        /// </summary>
        public CubeSingleColorPatternLogic()
        {
           int? number1 = null;
           if (number1 == null)
           {

            }

            int number2 = default;
            if (number2 == default)
            {

            }

            Guid number3 = default;
            if (number3 == default)
            {

            }

            Guid? number4 = default;
            if (number4 == default)
            {

            }
        }

        public String GetPatternFaceResult(CubeModel cube, StickerColorTypes color)
        {

        }
    }
}
