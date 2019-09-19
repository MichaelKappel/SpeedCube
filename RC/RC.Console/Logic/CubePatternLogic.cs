using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class CubePatternLogic: PatternLogicBase
    {


        public const String SideX = "A";
        public const String SideXn = "a";
        public const String SideY = "B";
        public const String SideYn = "b";
        public const String SideZ = "C";
        public const String SideZn = "c";


        public String[] Sides = new string[] { SideX, SideXn, SideY, SideYn, SideX, SideXn };

        /// <summary>
        /// 
        /// 
        ///                          [B  0] [B  1] [B  2]
        ///                          [BNW ] [ BN ] [ BNE]
        ///
        ///                          [B  3] [B  4] [B  5]
        ///                          [NW  ] [  N ] [  NE]
        ///
        ///                          [B  6] [B  7] [B  8]
        ///                          [FNW ] [ FN ] [ FNE]
        ///
        ///
        ///  [a 36] [a 37] [a 38]    [C 18] [C 19] [C 20]       [A 45] [A 46] [A 47]    [c 27] [c 28] [c 29]
        ///  [BNW ] [ NW ] [ FNW]    [FNW ] [ FN ] [ FNE]       [FNE ] [ NE ] [ BNE]    [BNW ] [ BN ] [ BNE]
        ///
        ///  [a 39] [a 40] [a 41]    [C 21] [C 22] [C 23]       [A 48] [A 49] [A 50]    [c 30] [c 31] [c 32]
        ///  [BW  ] [  W ] [  FW]    [FW  ] [  F ] [  FE]       [FE  ] [  E ] [  BE]    [BW  ] [  B ] [  BE]
        ///
        ///  [a 42] [a 43] [a 44]    [C 24] [C 25] [C 26]       [A 51] [A 52] [A 53]    [c 33] [c 34] [c 35]
        ///  [BSW ] [ SW ] [ FSW]    [FSW ] [ FS ] [ FSE]       [FSE ] [ SE ] [ BSE]    [BSW ] [ BS ] [ BSE]
        ///
        ///
        ///                          [b  9] [b 10] [b 11]
        ///                          [FSW ] [ FS ] [ FSE]
        ///
        ///                          [b 12] [b 13] [b 14]
        ///                          [SW  ] [  S ] [  SE]
        ///
        ///                          [b 15] [b 16] [b 17]
        ///                          [BSW ] [ BS ] [ BSE]
        ///                          
        ///
        //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
        //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
        //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
        //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
        //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
        //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW
        ///
        /// </summary>
        public CubePatternLogic()
        {

        }


        public String[] GetAllCubePatterns(String original)
        {
            var resultWithDups = new List<String>() { original };

            String[] shiftedPatterns = this.ShiftSwitchAndMirrorCubePatterns(original);
            foreach (var shiftedPattern in shiftedPatterns)
            {
                String[] rotatedPatterns = this.RotateCubePatterns(shiftedPattern);
                foreach (var rotatedPattern in rotatedPatterns)
                {
                    resultWithDups.Add(rotatedPattern);
                    resultWithDups.Add(this.ReversePattern(rotatedPattern));
                }
            }

            var normalizeRresultWithDups = new List<String>();
            foreach (var resultUnnormalized in resultWithDups.Distinct())
            {
                normalizeRresultWithDups.Add(this.Normalize(resultUnnormalized));
            }

            String[] results = normalizeRresultWithDups.Distinct().ToArray();

            //String[] results = resultWithDups.Distinct().ToArray();
            return results;
        }

        public String[] RotateCubePatterns(String original)
        {
            //Debug.WriteLine("RotateCubePatterns");

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

            return results.Distinct().ToArray();
        }

        public String[] ShiftSwitchAndMirrorCubePatterns(String original)
        {
            //Debug.WriteLine("ShiftSwitchAndMirrorCubePatterns");

            var resultWithDups = new List<String>();

            foreach (var shiftedPattern in ShiftPatternComprehensive(original))
            {
                foreach (var switchedOutPattern in this.SwitchOutPatternComprehensive(shiftedPattern))
                {
                    resultWithDups.Add(switchedOutPattern);

                    String btf = this.GetCubePatternMirrorNorthBackToFront(switchedOutPattern);
                    String wte = this.GetCubePatternMirrorNorthWestToEast(switchedOutPattern);
                    String ttb = this.GetCubePatternMirrorNorthTopToBottom(switchedOutPattern);

                    resultWithDups.Add(btf);
                    resultWithDups.Add(wte);
                    resultWithDups.Add(ttb);

                    String btfbtf = this.GetCubePatternMirrorNorthBackToFront(btf);
                    String btfwte = this.GetCubePatternMirrorNorthWestToEast(btf);
                    String btfttb = this.GetCubePatternMirrorNorthTopToBottom(btf);

                    String wtebtf = this.GetCubePatternMirrorNorthBackToFront(wte);
                    String wtewte = this.GetCubePatternMirrorNorthWestToEast(wte);
                    String wtettb = this.GetCubePatternMirrorNorthTopToBottom(wte);

                    String ttbbtf = this.GetCubePatternMirrorNorthBackToFront(ttb);
                    String ttbwte = this.GetCubePatternMirrorNorthWestToEast(ttb);
                    String ttbttb = this.GetCubePatternMirrorNorthTopToBottom(ttb);


                    resultWithDups.Add(btfbtf);
                    resultWithDups.Add(btfwte);
                    resultWithDups.Add(btfttb);

                    resultWithDups.Add(wtebtf);
                    resultWithDups.Add(wtewte);
                    resultWithDups.Add(wtettb);

                    resultWithDups.Add(ttbbtf);
                    resultWithDups.Add(ttbwte);
                    resultWithDups.Add(ttbttb);


                    String btfbtfbtf = this.GetCubePatternMirrorNorthBackToFront(btfbtf);
                    String btfbtfwte = this.GetCubePatternMirrorNorthWestToEast(btfbtf);
                    String btfbtfttb = this.GetCubePatternMirrorNorthTopToBottom(btfbtf);

                    String btfwtebtf = this.GetCubePatternMirrorNorthBackToFront(btfwte);
                    String btfwtewte = this.GetCubePatternMirrorNorthWestToEast(btfwte);
                    String btfwtettb = this.GetCubePatternMirrorNorthTopToBottom(btfwte);

                    String btfttbbtf = this.GetCubePatternMirrorNorthBackToFront(btfttb);
                    String btfttbwte = this.GetCubePatternMirrorNorthWestToEast(btfttb);
                    String btfttbttb = this.GetCubePatternMirrorNorthTopToBottom(btfttb);


                    String wtebtfbtf = this.GetCubePatternMirrorNorthBackToFront(wtebtf);
                    String wtebtfwte = this.GetCubePatternMirrorNorthWestToEast(wtebtf);
                    String wtebtfttb = this.GetCubePatternMirrorNorthTopToBottom(wtebtf);

                    String wtewtebtf = this.GetCubePatternMirrorNorthBackToFront(wtewte);
                    String wtewtewte = this.GetCubePatternMirrorNorthWestToEast(wtewte);
                    String wtewtettb = this.GetCubePatternMirrorNorthTopToBottom(wtewte);

                    String wtettbbtf = this.GetCubePatternMirrorNorthBackToFront(wtettb);
                    String wtettbwte = this.GetCubePatternMirrorNorthWestToEast(wtettb);
                    String wtettbttb = this.GetCubePatternMirrorNorthTopToBottom(wtettb);


                    String ttbbtfbtf = this.GetCubePatternMirrorNorthBackToFront(ttbbtf);
                    String ttbbtfwte = this.GetCubePatternMirrorNorthWestToEast(ttbbtf);
                    String ttbbtfttb = this.GetCubePatternMirrorNorthTopToBottom(ttbbtf);

                    String ttbwtebtf = this.GetCubePatternMirrorNorthBackToFront(ttbwte);
                    String ttbwtewte = this.GetCubePatternMirrorNorthWestToEast(ttbwte);
                    String ttbwtettb = this.GetCubePatternMirrorNorthTopToBottom(ttbwte);

                    String ttbttbbtf = this.GetCubePatternMirrorNorthBackToFront(ttbttb);
                    String ttbttbwte = this.GetCubePatternMirrorNorthWestToEast(ttbttb);
                    String ttbttbttb = this.GetCubePatternMirrorNorthTopToBottom(ttbttb);


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



                }
            }

            String[] results = resultWithDups.Distinct().ToArray();
            return results;
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
                this.ValidateCube(result);
                results.Add(result);
            }

            return results.Distinct().ToArray();
        }

        public String[] ShiftPatternComprehensive(String original)
        {
            var results = new List<String>() { original };

            String codedOriginal = original
                .Replace("A", "A1").Replace("B", "B1").Replace("C", "C1")
                .Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            results.Add(codedOriginal.Replace("A1", "B").Replace("B1", "C").Replace("C1", "a").Replace("a1", "b").Replace("b1", "c").Replace("c1", "A"));
            results.Add(codedOriginal.Replace("A1", "C").Replace("B1", "a").Replace("C1", "b").Replace("a1", "c").Replace("b1", "A").Replace("c1", "B"));
            results.Add(codedOriginal.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c").Replace("a1", "A").Replace("b1", "B").Replace("c1", "C"));
            results.Add(codedOriginal.Replace("A1", "b").Replace("B1", "c").Replace("C1", "A").Replace("a1", "B").Replace("b1", "C").Replace("c1", "a"));
            results.Add(codedOriginal.Replace("A1", "c").Replace("B1", "A").Replace("C1", "B").Replace("a1", "C").Replace("b1", "a").Replace("c1", "b"));

            foreach (var result in results)
            {
                this.ValidateCube(result);
            }

            return results.Distinct().ToArray();
        }


        public String ReversePattern(String original)
        {
            var result = original;
            result = result.Replace("A", "A1").Replace("B", "B1").Replace("C", "C1");
            result = result.Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            result = result.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c");
            result = result.Replace("a1", "A").Replace("b1", "B").Replace("c1", "C");

            this.ValidateCube(result);

            return result;
        }

        
        public String GetCubePatternMirrorNorthWestToEast(String original)
        {
            //Debug.WriteLine("GetCubePatternNorthBackToFront");

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";
            north += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            north += $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";

            var south = $"{originalStickers[11]}{originalStickers[10]}{originalStickers[9]}";
            south += $"{originalStickers[14]}{originalStickers[13]}{originalStickers[12]}";
            south += $"{originalStickers[17]}{originalStickers[16]}{originalStickers[15]}";

            var front = $"{originalStickers[20]}{originalStickers[19]}{originalStickers[18]}";
            front += $"{originalStickers[23]}{originalStickers[22]}{originalStickers[21]}";
            front += $"{originalStickers[26]}{originalStickers[25]}{originalStickers[24]}";

            var back = $"{originalStickers[29]}{originalStickers[28]}{originalStickers[27]}";
            back += $"{originalStickers[32]}{originalStickers[31]}{originalStickers[30]}";
            back += $"{originalStickers[35]}{originalStickers[34]}{originalStickers[33]}";

            var west = $"{originalStickers[47]}{originalStickers[46]}{originalStickers[45]}";
            west += $"{originalStickers[50]}{originalStickers[49]}{originalStickers[48]}";
            west += $"{originalStickers[53]}{originalStickers[52]}{originalStickers[51]}";

            var east = $"{originalStickers[38]}{originalStickers[37]}{originalStickers[36]}";
            east += $"{originalStickers[41]}{originalStickers[40]}{originalStickers[39]}";
            east += $"{originalStickers[44]}{originalStickers[43]}{originalStickers[42]}";

            var result = $"{north}{south}{front}{back}{west}{east}";

            this.ValidateCube(result);

            return result;
        }


        public String GetCubePatternMirrorNorthBackToFront(String original)
        {
            //Debug.WriteLine("GetCubePatternNorthBackToFront");

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            north += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            north += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var south = $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";
            south += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            south += $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";

            var front = $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";
            front += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            front += $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";

            var back = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            back += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            back += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var west = $"{originalStickers[38]}{originalStickers[37]}{originalStickers[36]}";
            west += $"{originalStickers[41]}{originalStickers[40]}{originalStickers[39]}";
            west += $"{originalStickers[44]}{originalStickers[43]}{originalStickers[42]}";

            var east = $"{originalStickers[47]}{originalStickers[46]}{originalStickers[45]}";
            east += $"{originalStickers[50]}{originalStickers[49]}{originalStickers[48]}";
            east += $"{originalStickers[53]}{originalStickers[52]}{originalStickers[51]}";


            var result = $"{north}{south}{front}{back}{west}{east}";

            this.ValidateCube(result);

            return result;
        }


        public String GetCubePatternMirrorNorthTopToBottom(String original)
        {
            //Debug.WriteLine("GetCubePatternMirrorNorthTopToBottom");

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";
            north += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            north += $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";

            var south = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            south += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            south += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var front = $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";
            front += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            front += $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";

            var back = $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";
            back += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            back += $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";

            var west = $"{originalStickers[42]}{originalStickers[43]}{originalStickers[44]}";
            west += $"{originalStickers[39]}{originalStickers[40]}{originalStickers[41]}";
            west += $"{originalStickers[36]}{originalStickers[37]}{originalStickers[38]}";

            var east = $"{originalStickers[51]}{originalStickers[52]}{originalStickers[53]}";
            east += $"{originalStickers[48]}{originalStickers[49]}{originalStickers[50]}";
            east += $"{originalStickers[45]}{originalStickers[46]}{originalStickers[47]}";


            var result = $"{north}{south}{front}{back}{west}{east}";

            this.ValidateCube(result);

            return result;
        }

        public String Normalize( String pattern)
        {
            String resultRaw = pattern.Replace(pattern[49].ToString(), "X").Replace(pattern[40].ToString(), "x")
                 .Replace(pattern[4].ToString(), "Y").Replace(pattern[13].ToString(), "y")
                 .Replace(pattern[22].ToString(), "Z").Replace(pattern[31].ToString(), "z");

            String result = resultRaw.Replace("X", "A").Replace("x", "a")
                         .Replace("Y", "B").Replace("y", "b")
                         .Replace("Z", "C").Replace("z", "c");

            //if (result[49] != 'A'
            //    || result[40] != 'a'
            //    || result[4] != 'B'
            //    || result[13] != 'b'
            //    || result[22] != 'C'
            //    || result[31] != 'c')
            //{
            //    throw new Exception("Normalize FAILED");
            //}

            return result;
        }


        public String RotateCubePatternNorthClockwise(String original)
        {
            //Debug.WriteLine("RotateCubePatternNorthClockwise");

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[6]}{originalStickers[3]}{originalStickers[0]}";
            north += $"{originalStickers[7]}{originalStickers[4]}{originalStickers[1]}";
            north += $"{originalStickers[8]}{originalStickers[5]}{originalStickers[2]}";

            var south = $"{originalStickers[11]}{originalStickers[14]}{originalStickers[17]}";
            south += $"{originalStickers[10]}{originalStickers[13]}{originalStickers[16]}";
            south += $"{originalStickers[9]}{originalStickers[12]}{originalStickers[15]}";

            var front = $"{originalStickers[45]}{originalStickers[46]}{originalStickers[47]}";
            front += $"{originalStickers[48]}{originalStickers[49]}{originalStickers[50]}";
            front += $"{originalStickers[51]}{originalStickers[52]}{originalStickers[53]}";

            var back = $"{originalStickers[38]}{originalStickers[37]}{originalStickers[36]}";
            back += $"{originalStickers[41]}{originalStickers[40]}{originalStickers[39]}";
            back += $"{originalStickers[44]}{originalStickers[43]}{originalStickers[42]}";

            var west = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            west += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            west += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var east = $"{originalStickers[29]}{originalStickers[28]}{originalStickers[27]}";
            east += $"{originalStickers[32]}{originalStickers[31]}{originalStickers[30]}";
            east += $"{originalStickers[35]}{originalStickers[34]}{originalStickers[33]}";

            var resultRaw = $"{north}{south}{front}{back}{west}{east}";

            String result = this.Normalize(original);

            this.ValidateCube(result);

            return result;
        }
        public String RotateCubePatternEastClockwise(String original)
        {
            //Debug.WriteLine("RotateCubePatternWestClockwise");

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            north += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            north += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var south = $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";
            south += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            south += $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";

            var front = $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";
            front += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            front += $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";

            var back = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            back += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            back += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var west = $"{originalStickers[38]}{originalStickers[41]}{originalStickers[44]}";
            west += $"{originalStickers[37]}{originalStickers[40]}{originalStickers[43]}";
            west += $"{originalStickers[36]}{originalStickers[39]}{originalStickers[42]}";

            var east = $"{originalStickers[51]}{originalStickers[48]}{originalStickers[45]}";
            east += $"{originalStickers[52]}{originalStickers[49]}{originalStickers[46]}";
            east += $"{originalStickers[53]}{originalStickers[50]}{originalStickers[47]}";


            var result = $"{north}{south}{front}{back}{west}{east}";

            this.ValidateCube(result);

            return result;
        }
        public String RotateCubePatternFrontClockwise(String original)
        {
            //Debug.WriteLine("RotateCubePatternFrontClockwise");

            var originalStickers = original.ToCharArray();

           var north = $"{originalStickers[42]}{originalStickers[39]}{originalStickers[36]}";
            north += $"{originalStickers[43]}{originalStickers[40]}{originalStickers[37]}";
            north += $"{originalStickers[44]}{originalStickers[41]}{originalStickers[38]}";

            var south = $"{originalStickers[51]}{originalStickers[48]}{originalStickers[45]}";
            south += $"{originalStickers[52]}{originalStickers[49]}{originalStickers[46]}";
            south += $"{originalStickers[53]}{originalStickers[50]}{originalStickers[47]}";

            var front = $"{originalStickers[24]}{originalStickers[21]}{originalStickers[18]}";
            front += $"{originalStickers[25]}{originalStickers[22]}{originalStickers[19]}";
            front += $"{originalStickers[26]}{originalStickers[23]}{originalStickers[20]}";

            var back = $"{originalStickers[33]}{originalStickers[30]}{originalStickers[27]}";
            back += $"{originalStickers[34]}{originalStickers[31]}{originalStickers[28]}";
            back += $"{originalStickers[35]}{originalStickers[32]}{originalStickers[29]}";

            var west = $"{originalStickers[15]}{originalStickers[12]}{originalStickers[9]}";
            west += $"{originalStickers[16]}{originalStickers[13]}{originalStickers[10]}";
            west += $"{originalStickers[17]}{originalStickers[14]}{originalStickers[11]}";

            var east = $"{originalStickers[6]}{originalStickers[3]}{originalStickers[0]}";
            east += $"{originalStickers[7]}{originalStickers[4]}{originalStickers[1]}";
            east += $"{originalStickers[8]}{originalStickers[5]}{originalStickers[2]}";


            var result = $"{north}{south}{front}{back}{west}{east}";

            this.ValidateCube(result);

            return result;
        }

        #region Validating


        public void ValidateCube(String pattern)
        {
            this.ValidateStickerCount(pattern);
            this.ValidateMiddleStickers(pattern);
            this.ValidateAdjacentStickers(pattern);
        }

        public Boolean IsCubeValid(String pattern)
        {
            if (!this.IsStickerCountValid(pattern)
                ||this.AreMiddleStickersValid(pattern)
                && this.AreAdjacentStickersValid(pattern))
            {
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
                    || pattern.ToArray().Count(x => x == 'a') != 9
                    || pattern.ToArray().Count(x => x == 'b') != 9
                    || pattern.ToArray().Count(x => x == 'c') != 9)
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
            String[] upperPattern = pattern.ToCharArray().Select(x => x.ToString().ToUpper()).ToArray();
            if (upperPattern[49] != upperPattern[40])
            {
                return false;
            }
            else if (upperPattern[4] != upperPattern[13])
            {
                return false;
            }
            else if (upperPattern[22] != upperPattern[31])
            {
                return false;
            }

            return true;
        }
        public void ValidateAdjacentStickers(String pattern)
        {
            if (!this.AreAdjacentStickersValid(pattern))
            {
                throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");
            }
        }

        public Boolean AreAdjacentStickersValid(String pattern)
        {
            String[] upperPattern = pattern.ToCharArray().Select(x => x.ToString().ToUpper()).ToArray();
            if (upperPattern[0] == upperPattern[27])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[1] == upperPattern[28])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[2] == upperPattern[29])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }


            if (upperPattern[2] == upperPattern[47])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[5] == upperPattern[46])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[8] == upperPattern[45])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }


            if (upperPattern[6] == upperPattern[18])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[7] == upperPattern[19])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[8] == upperPattern[20])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }


            if (upperPattern[0] == upperPattern[36])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[3] == upperPattern[37])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[6] == upperPattern[38])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }


            if (upperPattern[20] == upperPattern[45])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[23] == upperPattern[48])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[26] == upperPattern[51])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[24] == upperPattern[9])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[25] == upperPattern[10])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[26] == upperPattern[11])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[18] == upperPattern[38])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[21] == upperPattern[41])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[24] == upperPattern[44])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[47] == upperPattern[29])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[50] == upperPattern[32])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[53] == upperPattern[35])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[51] == upperPattern[11])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[52] == upperPattern[14])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[53] == upperPattern[17])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }


            if (upperPattern[27] == upperPattern[36])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[30] == upperPattern[39])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[33] == upperPattern[42])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[33] == upperPattern[15])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[34] == upperPattern[16])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[35] == upperPattern[17])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            if (upperPattern[42] == upperPattern[15])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[43] == upperPattern[12])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }
            else if (upperPattern[44] == upperPattern[9])
            {
               throw new Exception($"ValidateCube ValidateAdjacentStickers FAILED");  return false;
            }

            return true;
        }

        #endregion

    }
}