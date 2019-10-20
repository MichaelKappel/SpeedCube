using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;
using RC.Common.Model;
using RC.Common.Model.Patterns;
using RC.Common.Model.Slots;
using RC.Common.Model.Stickers;

namespace RC.Logic
{
    public class CubePatternLogic : PatternLogicBase
    {


        public const String SideX = "A";
        public const String SideXn = "X";
        public const String SideY = "B";
        public const String SideYn = "Y";
        public const String SideZ = "C";
        public const String SideZn = "Z";


        public String[] Sides = new string[] { SideX, SideXn, SideY, SideYn, SideX, SideXn };

        /// <summary>
        /// 
        ///                          [B  9] [B 10] [B 11]
        ///                          [BNW ] [ BN ] [ BNE]
        ///
        ///                          [B 12] [B 13] [B 14]
        ///                          [NW  ] [  N ] [  NE]
        ///
        ///                          [B 15] [B 16] [B 17]
        ///                          [FNW ] [ FN ] [ FNE]
        ///
        ///
        ///  [X 27] [X 28] [X 29]    [C 18] [C 19] [C 20]       [A  0] [A  1] [A  2]    [Z 45] [Z 46] [Z 47]
        ///  [BNW ] [ NW ] [ FNW]    [FNW ] [ FN ] [ FNE]       [FNE ] [ NE ] [ BNE]    [BNE ] [ BN ] [ BNW]
        ///
        ///  [X 30] [X 31] [X 32]    [C 21] [C 22] [C 23]       [A  3] [A  4] [A  5]    [Z 48] [Z 49] [Z 50]
        ///  [BW  ] [  W ] [  FW]    [FW  ] [  F ] [  FE]       [FE  ] [  E ] [  BE]    [BE  ] [  B ] [  BW]
        ///
        ///  [X 33] [X 34] [X 35]    [C 24] [C 25] [C 26]       [A  6] [A  7] [A  8]    [Z 51] [Z 52] [Z 53]
        ///  [BSW ] [ SW ] [ FSW]    [FSW ] [ FS ] [ FSE]       [FSE ] [ SE ] [ BSE]    [BSE ] [ BS ] [ BSW]
        ///
        ///
        ///                          [Y 36] [Y 37] [Y 38]
        ///                          [FSW ] [ FS ] [ FSE]
        ///
        ///                          [Y 39] [Y 40] [Y 41]
        ///                          [SW  ] [  S ] [  SE]
        ///
        ///                          [Y 42] [Y 43] [Y 44]
        ///                          [BSW ] [ BS ] [ BSE]
        ///
        //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW
        //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
        //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
        //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
        //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
        //  BNE, BE, BNW, BE, B, BW, BSE, BS, BSW
        ///
        /// </summary>
        /// 
        public void ValidateAdjacentStickersAreValid(String pattern)
        {
            Char[] patternChars = pattern.ToCharArray();

            if (patternChars[(Int32)PositionTypes.ENE] == patternChars[(Int32)PositionTypes.NNE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.EFE] == patternChars[(Int32)PositionTypes.FFE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.NBN] == patternChars[(Int32)PositionTypes.BBN])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.ESE] == patternChars[(Int32)PositionTypes.SSE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.FFS] == patternChars[(Int32)PositionTypes.SFS])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.BBS] == patternChars[(Int32)PositionTypes.SBS])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.WBW] == patternChars[(Int32)PositionTypes.BBW])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.FFN] == patternChars[(Int32)PositionTypes.NFN])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.FFNE] == patternChars[(Int32)PositionTypes.NFNE]
                || patternChars[(Int32)PositionTypes.NFNE] == patternChars[(Int32)PositionTypes.EFNE]
                || patternChars[(Int32)PositionTypes.EFNE] == patternChars[(Int32)PositionTypes.FFNE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.FFNW] == patternChars[(Int32)PositionTypes.NFNW]
                || patternChars[(Int32)PositionTypes.NFNW] == patternChars[(Int32)PositionTypes.WFNW]
                || patternChars[(Int32)PositionTypes.WFNW] == patternChars[(Int32)PositionTypes.FFNW])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.EFSE] == patternChars[(Int32)PositionTypes.FFSE]
                || patternChars[(Int32)PositionTypes.FFSE] == patternChars[(Int32)PositionTypes.SFSE]
                || patternChars[(Int32)PositionTypes.SFSE] == patternChars[(Int32)PositionTypes.EFSE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.FFSW] == patternChars[(Int32)PositionTypes.SFSW]
                || patternChars[(Int32)PositionTypes.SFSW] == patternChars[(Int32)PositionTypes.WFSW]
                || patternChars[(Int32)PositionTypes.WFSW] == patternChars[(Int32)PositionTypes.FFSW])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.BBNW] == patternChars[(Int32)PositionTypes.NBNW]
                || patternChars[(Int32)PositionTypes.NBNW] == patternChars[(Int32)PositionTypes.WBNW]
                || patternChars[(Int32)PositionTypes.WBNW] == patternChars[(Int32)PositionTypes.BBNW])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.BBNE] == patternChars[(Int32)PositionTypes.NBNE]
                || patternChars[(Int32)PositionTypes.NBNE] == patternChars[(Int32)PositionTypes.EBNE]
                || patternChars[(Int32)PositionTypes.EBNE] == patternChars[(Int32)PositionTypes.BBNE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            else if (patternChars[(Int32)PositionTypes.BBSE] == patternChars[(Int32)PositionTypes.SBSE]
                || patternChars[(Int32)PositionTypes.SBSE] == patternChars[(Int32)PositionTypes.EBSE]
                || patternChars[(Int32)PositionTypes.EBSE] == patternChars[(Int32)PositionTypes.BBSE])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
            if (patternChars[(Int32)PositionTypes.BBSW] == patternChars[(Int32)PositionTypes.SBSW]
                || patternChars[(Int32)PositionTypes.SBSW] == patternChars[(Int32)PositionTypes.WBSW]
                || patternChars[(Int32)PositionTypes.WBSW] == patternChars[(Int32)PositionTypes.BBSW])
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
        }
        public CubePatternLogic()
        {

        }

        public String GetFirstPatternAlphabetically(String original)
        {
            return this.GetAllPatterns(original).OrderBy(x => x).First();
        }

        public String[] GetAllPatterns(String original)
        {
            var results = new List<String>() { original };

            foreach (String mirroredPattern in this.MirrorCubePatterns(original).Distinct()) 
            {
                results.Add(mirroredPattern);
                results.AddRange(this.RotateCubePatterns(mirroredPattern).Distinct());
            }

            return results.ToArray();
        }

        public String[] RotateCubePatterns(String original)
        {
            String n = this.RotateCubePatternNorthClockwise(original);
            String f = this.RotateCubePatternFrontClockwise(original);
            String e = this.RotateCubePatternEastClockwise(original);

            String nn = this.RotateCubePatternNorthClockwise(n);
            String nf = this.RotateCubePatternFrontClockwise(n);
            String ne = this.RotateCubePatternEastClockwise(n);

            String fn = this.RotateCubePatternNorthClockwise(f);
            String ff = this.RotateCubePatternFrontClockwise(f);
            String fe = this.RotateCubePatternEastClockwise(f);

            String en = this.RotateCubePatternNorthClockwise(e);
            String ef = this.RotateCubePatternFrontClockwise(e);
            String ee = this.RotateCubePatternEastClockwise(e);

            String nnn = this.RotateCubePatternNorthClockwise(nn);
            String nnf = this.RotateCubePatternFrontClockwise(nn);
            String nne = this.RotateCubePatternEastClockwise(nn);

            String nfn = this.RotateCubePatternNorthClockwise(nf);
            String nff = this.RotateCubePatternFrontClockwise(nf);
            String nfe = this.RotateCubePatternEastClockwise(nf);

            String nen = this.RotateCubePatternNorthClockwise(ne);
            String nef = this.RotateCubePatternFrontClockwise(ne);
            String nee = this.RotateCubePatternEastClockwise(ne);

            String fnn = this.RotateCubePatternNorthClockwise(fn);
            String fnf = this.RotateCubePatternFrontClockwise(fn);
            String fne = this.RotateCubePatternEastClockwise(fn);

            String ffn = this.RotateCubePatternNorthClockwise(ff);
            String fff = this.RotateCubePatternFrontClockwise(ff);
            String ffe = this.RotateCubePatternEastClockwise(ff);

            String fen = this.RotateCubePatternNorthClockwise(fe);
            String fef = this.RotateCubePatternFrontClockwise(fe);
            String fee = this.RotateCubePatternEastClockwise(fe);

            var results = new String[] {
                original,
                n,f,e,
                nn ,nf ,ne ,fn ,ff ,fe ,en ,ef ,ee,
                nnn,nnf,nne,nfn,nff,nfe,nen,nef,nee,fnn,fnf,fne,ffn,fff,ffe,ffn,fff,ffe,fen,fef,fee
            };

            return results;
        }

        public String[] MirrorCubePatterns(String original)
        {
            this.ValidateCube(original);

            var resultWithDups = new List<String>();

            resultWithDups.Add(original);

            String btf = this.GetCubePatternMirrorBackToFront(original);
            String wte = this.GetCubePatternMirrorWestToEast(original);
            String ttb = this.GetCubePatternMirrorTopToBottom(original);

            resultWithDups.Add(btf);
            resultWithDups.Add(wte);
            resultWithDups.Add(ttb);

            String btfbtf = this.GetCubePatternMirrorBackToFront(btf);
            String btfwte = this.GetCubePatternMirrorWestToEast(btf);
            String btfttb = this.GetCubePatternMirrorTopToBottom(btf);

            String wtebtf = this.GetCubePatternMirrorBackToFront(wte);
            String wtewte = this.GetCubePatternMirrorWestToEast(wte);
            String wtettb = this.GetCubePatternMirrorTopToBottom(wte);

            String ttbbtf = this.GetCubePatternMirrorBackToFront(ttb);
            String ttbwte = this.GetCubePatternMirrorWestToEast(ttb);
            String ttbttb = this.GetCubePatternMirrorTopToBottom(ttb);


            resultWithDups.Add(btfbtf);
            resultWithDups.Add(btfwte);
            resultWithDups.Add(btfttb);

            resultWithDups.Add(wtebtf);
            resultWithDups.Add(wtewte);
            resultWithDups.Add(wtettb);

            resultWithDups.Add(ttbbtf);
            resultWithDups.Add(ttbwte);
            resultWithDups.Add(ttbttb);


            String btfbtfbtf = this.GetCubePatternMirrorBackToFront(btfbtf);
            String btfbtfwte = this.GetCubePatternMirrorWestToEast(btfbtf);
            String btfbtfttb = this.GetCubePatternMirrorTopToBottom(btfbtf);

            String btfwtebtf = this.GetCubePatternMirrorBackToFront(btfwte);
            String btfwtewte = this.GetCubePatternMirrorWestToEast(btfwte);
            String btfwtettb = this.GetCubePatternMirrorTopToBottom(btfwte);

            String btfttbbtf = this.GetCubePatternMirrorBackToFront(btfttb);
            String btfttbwte = this.GetCubePatternMirrorWestToEast(btfttb);
            String btfttbttb = this.GetCubePatternMirrorTopToBottom(btfttb);


            String wtebtfbtf = this.GetCubePatternMirrorBackToFront(wtebtf);
            String wtebtfwte = this.GetCubePatternMirrorWestToEast(wtebtf);
            String wtebtfttb = this.GetCubePatternMirrorTopToBottom(wtebtf);

            String wtewtebtf = this.GetCubePatternMirrorBackToFront(wtewte);
            String wtewtewte = this.GetCubePatternMirrorWestToEast(wtewte);
            String wtewtettb = this.GetCubePatternMirrorTopToBottom(wtewte);

            String wtettbbtf = this.GetCubePatternMirrorBackToFront(wtettb);
            String wtettbwte = this.GetCubePatternMirrorWestToEast(wtettb);
            String wtettbttb = this.GetCubePatternMirrorTopToBottom(wtettb);


            String ttbbtfbtf = this.GetCubePatternMirrorBackToFront(ttbbtf);
            String ttbbtfwte = this.GetCubePatternMirrorWestToEast(ttbbtf);
            String ttbbtfttb = this.GetCubePatternMirrorTopToBottom(ttbbtf);

            String ttbwtebtf = this.GetCubePatternMirrorBackToFront(ttbwte);
            String ttbwtewte = this.GetCubePatternMirrorWestToEast(ttbwte);
            String ttbwtettb = this.GetCubePatternMirrorTopToBottom(ttbwte);

            String ttbttbbtf = this.GetCubePatternMirrorBackToFront(ttbttb);
            String ttbttbwte = this.GetCubePatternMirrorWestToEast(ttbttb);
            String ttbttbttb = this.GetCubePatternMirrorTopToBottom(ttbttb);


            resultWithDups.Add(btfbtfbtf);
            resultWithDups.Add(btfbtfwte);
            resultWithDups.Add(btfbtfttb);

            resultWithDups.Add(btfwtebtf);
            resultWithDups.Add(btfwtewte);
            resultWithDups.Add(btfwtettb);

            resultWithDups.Add(btfttbbtf);
            resultWithDups.Add(btfttbwte);
            resultWithDups.Add(btfttbttb);

            resultWithDups.Add(wtebtfbtf);
            resultWithDups.Add(wtebtfwte);
            resultWithDups.Add(wtebtfttb);

            resultWithDups.Add(wtewtebtf);
            resultWithDups.Add(wtewtewte);
            resultWithDups.Add(wtewtettb);

            resultWithDups.Add(wtettbbtf);
            resultWithDups.Add(wtettbwte);
            resultWithDups.Add(wtettbttb);

            resultWithDups.Add(ttbbtfbtf);
            resultWithDups.Add(ttbbtfwte);
            resultWithDups.Add(ttbbtfttb);

            resultWithDups.Add(ttbwtebtf);
            resultWithDups.Add(ttbwtewte);
            resultWithDups.Add(ttbwtettb);

            resultWithDups.Add(ttbttbbtf);
            resultWithDups.Add(ttbttbwte);
            resultWithDups.Add(ttbttbttb);

            String[] results = resultWithDups.Distinct().ToArray();
            return results;
        }

        //public String[] SwitchOutPatternComprehensive(String original)
        //{
        //    var results = new List<String>() { original };

        //    String codedOriginal = original
        //        .Replace("A", "D").Replace("B", "E").Replace("C", "F")
        //        .Replace("X", "U").Replace("Y", "V").Replace("Z", "W");

        //    var resultsRaw = new List<String>();

        //    resultsRaw.Add(codedOriginal.Replace("D", "B").Replace("U", "Y").Replace("E", "A").Replace("V", "X"));
        //    resultsRaw.Add(codedOriginal.Replace("D", "C").Replace("U", "Z").Replace("F", "A").Replace("W", "X"));

        //    resultsRaw.Add(codedOriginal.Replace("E", "C").Replace("V", "Z").Replace("F", "B").Replace("W", "Y"));
        //    resultsRaw.Add(codedOriginal.Replace("E", "A").Replace("V", "X").Replace("D", "B").Replace("U", "Y"));

        //    resultsRaw.Add(codedOriginal.Replace("F", "A").Replace("W", "X").Replace("D", "C").Replace("U", "Z"));
        //    resultsRaw.Add(codedOriginal.Replace("F", "B").Replace("W", "Y").Replace("E", "C").Replace("V", "Z"));

        //    foreach (var resultRaw in resultsRaw)
        //    {
        //        var result = resultRaw.Replace("D", "A").Replace("E", "B").Replace("F", "C").Replace("U", "X").Replace("V", "Y").Replace("W", "Z");
        //        this.ValidateCube(result);
        //        results.Add(result);
        //    }

        //    return results.Distinct().ToArray();
        //}

        //public String[] ShiftPatternComprehensive(String original)
        //{
        //    var results = new List<String>() { original };

        //    String codedOriginal = original
        //        .Replace("A", "D").Replace("B", "E").Replace("C", "F")
        //        .Replace("X", "U").Replace("Y", "V").Replace("Z", "W");

        //    results.Add(codedOriginal.Replace("D", "B").Replace("E", "C").Replace("F", "X").Replace("U", "Y").Replace("V", "Z").Replace("W", "A"));
        //    results.Add(codedOriginal.Replace("D", "C").Replace("E", "X").Replace("F", "Y").Replace("U", "Z").Replace("V", "A").Replace("W", "B"));
        //    results.Add(codedOriginal.Replace("D", "X").Replace("E", "Y").Replace("F", "Z").Replace("U", "A").Replace("V", "B").Replace("W", "C"));
        //    results.Add(codedOriginal.Replace("D", "Y").Replace("E", "Z").Replace("F", "A").Replace("U", "B").Replace("V", "C").Replace("W", "X"));
        //    results.Add(codedOriginal.Replace("D", "Z").Replace("E", "A").Replace("F", "B").Replace("U", "C").Replace("V", "X").Replace("W", "Y"));

        //    foreach (var result in results)
        //    {
        //        this.ValidateCube(result);
        //    }

        //    return results.Distinct().ToArray();
        //}


        //public String ReversePattern(String original)
        //{
        //    var result = original;
        //    result = result.Replace("A", "D").Replace("B", "E").Replace("C", "F");
        //    result = result.Replace("X", "U").Replace("Y", "V").Replace("Z", "W");

        //    result = result.Replace("D", "X").Replace("E", "Y").Replace("F", "Z");
        //    result = result.Replace("U", "A").Replace("V", "B").Replace("W", "C");

        //    this.ValidateCube(result);

        //    return result;
        //}


        public String GetCubePatternMirrorWestToEast(String original)
        {
            var originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.WFNW]}{originalStickers[(Int32)PositionTypes.WNW]}{originalStickers[(Int32)PositionTypes.WBNW]}";
            east += $"{originalStickers[(Int32)PositionTypes.WFW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WBW]}";
            east += $"{originalStickers[(Int32)PositionTypes.WFSW]}{originalStickers[(Int32)PositionTypes.WSW]}{originalStickers[(Int32)PositionTypes.WBSW]}";

            String north = $"{originalStickers[(Int32)PositionTypes.NBNE]}{originalStickers[(Int32)PositionTypes.NBN]}{originalStickers[(Int32)PositionTypes.NBNW]}";
            north += $"{originalStickers[(Int32)PositionTypes.NNE]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NNW]}";
            north += $"{originalStickers[(Int32)PositionTypes.NFNE]}{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NFNW]}";

            String front = $"{originalStickers[(Int32)PositionTypes.FFNE]}{originalStickers[(Int32)PositionTypes.FFN]}{originalStickers[(Int32)PositionTypes.FFNW]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFE]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFW]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFSE]}{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FFSW]}";

            String west = $"{originalStickers[(Int32)PositionTypes.EBNE]}{originalStickers[(Int32)PositionTypes.ENE]}{originalStickers[(Int32)PositionTypes.EFNE]}";
            west += $"{originalStickers[(Int32)PositionTypes.EBE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.EFE]}";
            west += $"{originalStickers[(Int32)PositionTypes.EBSE]}{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EFSE]}";

            String south = $"{originalStickers[(Int32)PositionTypes.SFSE]}{originalStickers[(Int32)PositionTypes.SFS]}{originalStickers[(Int32)PositionTypes.SFSW]}";
            south += $"{originalStickers[(Int32)PositionTypes.SSE]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SSW]}";
            south += $"{originalStickers[(Int32)PositionTypes.SBSE]}{originalStickers[(Int32)PositionTypes.SBS]}{originalStickers[(Int32)PositionTypes.SBSW]}";

            String back = $"{originalStickers[(Int32)PositionTypes.BBNW]}{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BBNE]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBW]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBE]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBSW]}{originalStickers[(Int32)PositionTypes.BBS]}{originalStickers[(Int32)PositionTypes.BBSE]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  X->D->A
            //  B->E->B
            //  C->F->C
            //  A->U->X
            //  Y->V->Y
            //  Z->W->Z

            String resultRaw = notNormalized
                .Replace("X", "D")
                .Replace("B", "E")
                .Replace("C", "F")
                .Replace("A", "U")
                .Replace("Y", "V")
                .Replace("Z", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");

            this.ValidateCube(result);

            return result;
        }


        public String GetCubePatternMirrorBackToFront(String original)
        {
            Char[] originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.EBNE]}{originalStickers[(Int32)PositionTypes.ENE]}{originalStickers[(Int32)PositionTypes.EFNE]}";
            east += $"{originalStickers[(Int32)PositionTypes.EBE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.EFE]}";
            east += $"{originalStickers[(Int32)PositionTypes.EBSE]}{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EFSE]}";

            String north = $"{originalStickers[(Int32)PositionTypes.NFNW]}{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NFNE]}";
            north += $"{originalStickers[(Int32)PositionTypes.NNW]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NNE]}";
            north += $"{originalStickers[(Int32)PositionTypes.NBNW]}{originalStickers[(Int32)PositionTypes.NBN]}{originalStickers[(Int32)PositionTypes.NBNE]}";

            String front = $"{originalStickers[(Int32)PositionTypes.BBNW]}{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BBNE]}";
            front += $"{originalStickers[(Int32)PositionTypes.BBW]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBE]}";
            front += $"{originalStickers[(Int32)PositionTypes.BBSW]}{originalStickers[(Int32)PositionTypes.BBS]}{originalStickers[(Int32)PositionTypes.BBSE]}";

            String west = $"{originalStickers[(Int32)PositionTypes.WFNW]}{originalStickers[(Int32)PositionTypes.WNW]}{originalStickers[(Int32)PositionTypes.WBNW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WFW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WBW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WFSW]}{originalStickers[(Int32)PositionTypes.WSW]}{originalStickers[(Int32)PositionTypes.WBSW]}";

            String south = $"{originalStickers[(Int32)PositionTypes.SBSW]}{originalStickers[(Int32)PositionTypes.SBS]}{originalStickers[(Int32)PositionTypes.SBSE]}";
            south += $"{originalStickers[(Int32)PositionTypes.SSW]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SSE]}";
            south += $"{originalStickers[(Int32)PositionTypes.SFSW]}{originalStickers[(Int32)PositionTypes.SFS]}{originalStickers[(Int32)PositionTypes.SFSE]}";

            String back = $"{originalStickers[(Int32)PositionTypes.FFNE]}{originalStickers[(Int32)PositionTypes.FFN]}{originalStickers[(Int32)PositionTypes.FFNW]}";
            back += $"{originalStickers[(Int32)PositionTypes.FFE]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFW]}";
            back += $"{originalStickers[(Int32)PositionTypes.FFSE]}{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FFSW]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  A->D->A
            //  B->E->B
            //  Z->F->C
            //  X->U->X
            //  Y->V->Y
            //  C->W->Z

            String resultRaw = notNormalized
                .Replace("A", "D")
                .Replace("B", "E")
                .Replace("Z", "F")
                .Replace("X", "U")
                .Replace("Y", "V")
                .Replace("C", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");

            this.ValidateCube(result);

            return result;
        }


        public String GetCubePatternMirrorTopToBottom(String original)
        {
            Char[] originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.EFSE]}{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EBSE]}";
            east += $"{originalStickers[(Int32)PositionTypes.EFE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.EBE]}";
            east += $"{originalStickers[(Int32)PositionTypes.EFNE]}{originalStickers[(Int32)PositionTypes.ENE]}{originalStickers[(Int32)PositionTypes.EBNE]}";

            String north = $"{originalStickers[(Int32)PositionTypes.SBSW]}{originalStickers[(Int32)PositionTypes.SBS]}{originalStickers[(Int32)PositionTypes.SBSE]}";
            north += $"{originalStickers[(Int32)PositionTypes.SSW]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SSE]}";
            north += $"{originalStickers[(Int32)PositionTypes.SFSW]}{originalStickers[(Int32)PositionTypes.SFS]}{originalStickers[(Int32)PositionTypes.SFSE]}";

            String front = $"{originalStickers[(Int32)PositionTypes.FFSW]}{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FFSE]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFW]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFE]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFNW]}{originalStickers[(Int32)PositionTypes.FFN]}{originalStickers[(Int32)PositionTypes.FFNE]}";

            String west = $"{originalStickers[(Int32)PositionTypes.WBSW]}{originalStickers[(Int32)PositionTypes.WSW]}{originalStickers[(Int32)PositionTypes.WFSW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WBW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WFW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WBNW]}{originalStickers[(Int32)PositionTypes.WNW]}{originalStickers[(Int32)PositionTypes.WFNW]}";

            String south = $"{originalStickers[(Int32)PositionTypes.NFNW]}{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NFNE]}";
            south += $"{originalStickers[(Int32)PositionTypes.NNW]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NNE]}";
            south += $"{originalStickers[(Int32)PositionTypes.NBNW]}{originalStickers[(Int32)PositionTypes.NBN]}{originalStickers[(Int32)PositionTypes.NBNE]}";

            String back = $"{originalStickers[(Int32)PositionTypes.BBSE]}{originalStickers[(Int32)PositionTypes.BBS]}{originalStickers[(Int32)PositionTypes.BBSW]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBE]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBW]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBNE]}{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BBNW]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  A->D->A
            //  Y->E->B
            //  C->F->C
            //  X->U->X
            //  B->V->Y
            //  X->W->Z

            String resultRaw = notNormalized
                .Replace("A", "D")
                .Replace("Y", "E")
                .Replace("C", "F")
                .Replace("X", "U")
                .Replace("B", "V")
                .Replace("X", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");

            this.ValidateCube(result);

            return result;
        }

        public String RotateCubePatternNorthClockwise(String original)
        {
            Char[] originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.BBNE]}{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BBNW]}";
            east += $"{originalStickers[(Int32)PositionTypes.BBE]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBW]}";
            east += $"{originalStickers[(Int32)PositionTypes.BBSE]}{originalStickers[(Int32)PositionTypes.BBS]}{originalStickers[(Int32)PositionTypes.BBSW]}";

            String north = $"{originalStickers[(Int32)PositionTypes.NFNW]}{originalStickers[(Int32)PositionTypes.NNW]}{originalStickers[(Int32)PositionTypes.NBNW]}";
            north += $"{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NBN]}";
            north += $"{originalStickers[(Int32)PositionTypes.NFNE]}{originalStickers[(Int32)PositionTypes.NNE]}{originalStickers[(Int32)PositionTypes.NBNE]}";

            String front = $"{originalStickers[(Int32)PositionTypes.EFNE]}{originalStickers[(Int32)PositionTypes.ENE]}{originalStickers[(Int32)PositionTypes.EBNE]}";
            front += $"{originalStickers[(Int32)PositionTypes.EFE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.EBE]}";
            front += $"{originalStickers[(Int32)PositionTypes.EFSE]}{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EBSE]}";

            String west = $"{originalStickers[(Int32)PositionTypes.FFNW]}{originalStickers[(Int32)PositionTypes.FFN]}{originalStickers[(Int32)PositionTypes.FFNE]}";
            west += $"{originalStickers[(Int32)PositionTypes.FFW]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFE]}";
            west += $"{originalStickers[(Int32)PositionTypes.FFSW]}{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FFSE]}";

            String south = $"{originalStickers[(Int32)PositionTypes.SFSE]}{originalStickers[(Int32)PositionTypes.SSE]}{originalStickers[(Int32)PositionTypes.SBSE]}";
            south += $"{originalStickers[(Int32)PositionTypes.SFS]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SBS]}";
            south += $"{originalStickers[(Int32)PositionTypes.SFSW]}{originalStickers[(Int32)PositionTypes.SSW]}{originalStickers[(Int32)PositionTypes.SBSW]}";

            String back = $"{originalStickers[(Int32)PositionTypes.WBNW]}{originalStickers[(Int32)PositionTypes.WNW]}{originalStickers[(Int32)PositionTypes.WFNW]}";
            back += $"{originalStickers[(Int32)PositionTypes.WBW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WFW]}";
            back += $"{originalStickers[(Int32)PositionTypes.WBSW]}{originalStickers[(Int32)PositionTypes.WSW]}{originalStickers[(Int32)PositionTypes.WFSW]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  Z->D->A
            //  B->E->B
            //  A->F->C
            //  C->U->X
            //  Y->V->Y
            //  X->W->Z

            String resultRaw = notNormalized
               .Replace("Z", "D")
               .Replace("B", "E")
               .Replace("A", "F")
               .Replace("C", "U")
               .Replace("Y", "V")
               .Replace("X", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");

            this.ValidateCube(result);

            return result;
        }
        public String RotateCubePatternEastClockwise(String original)
        {
            Char[] originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.EFSE]}{originalStickers[(Int32)PositionTypes.EFE]}{originalStickers[(Int32)PositionTypes.EFNE]}";
            east += $"{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.ENE]}";
            east += $"{originalStickers[(Int32)PositionTypes.EBSE]}{originalStickers[(Int32)PositionTypes.EBE]}{originalStickers[(Int32)PositionTypes.EBNE]}";

            String north = $"{originalStickers[(Int32)PositionTypes.FFNW]}{originalStickers[(Int32)PositionTypes.FFN]}{originalStickers[(Int32)PositionTypes.FFNE]}";
            north += $"{originalStickers[(Int32)PositionTypes.FFW]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFE]}";
            north += $"{originalStickers[(Int32)PositionTypes.FFSW]}{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FFSE]}";

            String front = $"{originalStickers[(Int32)PositionTypes.SFSW]}{originalStickers[(Int32)PositionTypes.SFS]}{originalStickers[(Int32)PositionTypes.SFSE]}";
            front += $"{originalStickers[(Int32)PositionTypes.SSW]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SSE]}";
            front += $"{originalStickers[(Int32)PositionTypes.SBSW]}{originalStickers[(Int32)PositionTypes.SBS]}{originalStickers[(Int32)PositionTypes.SBSE]}";

            String west = $"{originalStickers[(Int32)PositionTypes.WFNW]}{originalStickers[(Int32)PositionTypes.WFW]}{originalStickers[(Int32)PositionTypes.WFSW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WNW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WSW]}";
            west += $"{originalStickers[(Int32)PositionTypes.WBNW]}{originalStickers[(Int32)PositionTypes.WBW]}{originalStickers[(Int32)PositionTypes.WBSW]}";

            String south = $"{originalStickers[(Int32)PositionTypes.BBSW]}{originalStickers[(Int32)PositionTypes.BBS]}{originalStickers[(Int32)PositionTypes.BBSE]}";
            south += $"{originalStickers[(Int32)PositionTypes.BBW]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBE]}";
            south += $"{originalStickers[(Int32)PositionTypes.BBNW]}{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BBNE]}";

            String back = $"{originalStickers[(Int32)PositionTypes.NFNE]}{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NFNW]}";
            back += $"{originalStickers[(Int32)PositionTypes.NNE]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NNW]}";
            back += $"{originalStickers[(Int32)PositionTypes.NBNE]}{originalStickers[(Int32)PositionTypes.NBN]}{originalStickers[(Int32)PositionTypes.NBNW]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  A->D->A
            //  C->E->B
            //  Y->F->C
            //  X->U->X
            //  Z->V->Y
            //  B->W->Z

            String resultRaw = notNormalized
               .Replace("A", "D")
               .Replace("C", "E")
               .Replace("Y", "F")
               .Replace("X", "U")
               .Replace("Z", "V")
               .Replace("B", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");

            this.ValidateCube(result);

            return result;
        }

        public String RotateCubePatternFrontClockwise(String original)
        {
            Char[] originalStickers = original.ToCharArray();

            String east = $"{originalStickers[(Int32)PositionTypes.NFNW]}{originalStickers[(Int32)PositionTypes.NNW]}{originalStickers[(Int32)PositionTypes.NBNW]}";
            east += $"{originalStickers[(Int32)PositionTypes.NFN]}{originalStickers[(Int32)PositionTypes.NN]}{originalStickers[(Int32)PositionTypes.NBN]}";
            east += $"{originalStickers[(Int32)PositionTypes.NFNE]}{originalStickers[(Int32)PositionTypes.NNE]}{originalStickers[(Int32)PositionTypes.NBNE]}";

            String north = $"{originalStickers[(Int32)PositionTypes.WBSW]}{originalStickers[(Int32)PositionTypes.WBW]}{originalStickers[(Int32)PositionTypes.WBNW]}";
            north += $"{originalStickers[(Int32)PositionTypes.WSW]}{originalStickers[(Int32)PositionTypes.WW]}{originalStickers[(Int32)PositionTypes.WNW]}";
            north += $"{originalStickers[(Int32)PositionTypes.WFSW]}{originalStickers[(Int32)PositionTypes.WFW]}{originalStickers[(Int32)PositionTypes.WFNW]}";

            String front = $"{originalStickers[(Int32)PositionTypes.FFSW]}{originalStickers[(Int32)PositionTypes.FFW]}{originalStickers[(Int32)PositionTypes.FFNW]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFS]}{originalStickers[(Int32)PositionTypes.FF]}{originalStickers[(Int32)PositionTypes.FFN]}";
            front += $"{originalStickers[(Int32)PositionTypes.FFSE]}{originalStickers[(Int32)PositionTypes.FFE]}{originalStickers[(Int32)PositionTypes.FFNE]}";

            String west = $"{originalStickers[(Int32)PositionTypes.SBSW]}{originalStickers[(Int32)PositionTypes.SSW]}{originalStickers[(Int32)PositionTypes.SFSW]}";
            west += $"{originalStickers[(Int32)PositionTypes.SBS]}{originalStickers[(Int32)PositionTypes.SS]}{originalStickers[(Int32)PositionTypes.SFS]}";
            west += $"{originalStickers[(Int32)PositionTypes.SBSE]}{originalStickers[(Int32)PositionTypes.SSE]}{originalStickers[(Int32)PositionTypes.SFSE]}";

            String south = $"{originalStickers[(Int32)PositionTypes.EFSE]}{originalStickers[(Int32)PositionTypes.EFE]}{originalStickers[(Int32)PositionTypes.EFNE]}";
            south += $"{originalStickers[(Int32)PositionTypes.ESE]}{originalStickers[(Int32)PositionTypes.EE]}{originalStickers[(Int32)PositionTypes.ENE]}";
            south += $"{originalStickers[(Int32)PositionTypes.EBSE]}{originalStickers[(Int32)PositionTypes.EBE]}{originalStickers[(Int32)PositionTypes.EBNE]}";

            String back = $"{originalStickers[(Int32)PositionTypes.BBNW]}{originalStickers[(Int32)PositionTypes.BBW]}{originalStickers[(Int32)PositionTypes.BBSW]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBN]}{originalStickers[(Int32)PositionTypes.BB]}{originalStickers[(Int32)PositionTypes.BBS]}";
            back += $"{originalStickers[(Int32)PositionTypes.BBNE]}{originalStickers[(Int32)PositionTypes.BBE]}{originalStickers[(Int32)PositionTypes.BBSE]}";

            String notNormalized = $"{east}{north}{front}{west}{south}{back}";

            //  B->D->A
            //  X->E->B
            //  C->F->C
            //  Y->U->X
            //  A->V->Y
            //  Z->W->Z

            String resultRaw = notNormalized
               .Replace("B", "D")
               .Replace("X", "E")
               .Replace("C", "F")
               .Replace("Y", "U")
               .Replace("A", "V")
               .Replace("Z", "W");

            String result = resultRaw
                .Replace("D", "A")
                .Replace("E", "B")
                .Replace("F", "C")
                .Replace("U", "X")
                .Replace("V", "Y")
                .Replace("W", "Z");



            this.ValidateCube(result);

            return result;
        }

        #region Validating


        public void ValidateCube(String pattern)
        {
            //Debug.Write(this.Visualize(pattern));

            this.ValidateStickerCount(pattern);
            this.ValidateMiddleStickers(pattern);
            this.ValidateAdjacentStickersAreValid(pattern);
        }

        public Boolean IsCubeValid(String pattern)
        {
            if (!this.IsStickerCountValid(pattern)
                || this.AreMiddleStickersValid(pattern))
            {
                this.ValidateAdjacentStickersAreValid(pattern);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ValidateStickerCount(String pattern)
        {
            if (!this.IsStickerCountValid(pattern))
            {
                throw new Exception($"ValidateCube IsCubeValid {pattern} FAILED");
            }
        }

        public Boolean IsStickerCountValid(String pattern)
        {
            if (pattern.ToArray().Count(x => x == 'A') != 9
                    || pattern.ToArray().Count(x => x == 'B') != 9
                    || pattern.ToArray().Count(x => x == 'C') != 9
                    || pattern.ToArray().Count(x => x == 'X') != 9
                    || pattern.ToArray().Count(x => x == 'Y') != 9
                    || pattern.ToArray().Count(x => x == 'Z') != 9)
            {
                return false;
            }

            return true;
        }

        public void ValidateMiddleStickers(String pattern)
        {
            if (!this.AreMiddleStickersValid(pattern))
            {
                throw new Exception($"ValidateCube ValidateMiddleStickers FAILED");
            }
        }

        public Boolean AreMiddleStickersValid(String pattern)
        {
            String[] upperPattern = pattern.ToCharArray().Select(x => x.ToString().Replace('X', 'A').Replace('Y', 'B').Replace('Z', 'C')).ToArray();

            if (upperPattern[4] != upperPattern[31])
            {
                return false;
            }
            else if (upperPattern[13] != upperPattern[40])
            {
                return false;
            }
            else if (upperPattern[22] != upperPattern[49])
            {
                return false;
            }

            return true;
        }


        #endregion

    }
}