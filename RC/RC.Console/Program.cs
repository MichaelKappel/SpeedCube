using System;
using System.Linq;
using System.Collections.Generic;
using RC.Enumerations;
using RC.Model;
using RC.Model.Slots;
using RC.Model.Stickers;
using System.Threading;
using System.IO;
using RC.Logic;

namespace RC
{
    class Program
    {
        public static CubeModel[] Cubes;
        public static CubeLogic Logic = new CubeLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static List<String> Combinations;
        public static List<String> Patterns;

        static void Main(string[] args)
        {
            if (Cubes == default(CubeModel[]))
            {
                Cubes = Logic.CreateAllVariations();
                Load();

                    //Logic.SetCubeState(Cube, Combinations.Last());
                
            }

            //PatternLogic.GetSideCompleteness(Cube);

            OutputCubes();
            foreach (CubeModel cube in Cubes)
            {
                foreach (var completeness in PatternLogic.GetSideCompleteness(cube))
                {
                    Console.Write("\n");
                    Console.Write(completeness.Key);
                    Console.Write("\nFace:" + completeness.Value.PatternFaceResult.Pattern);
                    Console.Write("\nCorner:" + completeness.Value.PatternAdjacentResult.Pattern);
                    Console.Write("\n");
                }
            }
            var command = Console.ReadLine().ToUpper();

            if (command == "PRINT")
            {
                foreach (CubeModel cube in Cubes)
                {
                    Console.WriteLine(Logic.GetCubePattern(cube));
                }
            }

            //else if (command == "LOAD")
            //{
            //    Logic.SetCubeState(Cubes, "BNW:Blue|BN:White|BNE:White|NW:Blue|N:White|NE:Blue|FNW:Blue|FN:Yellow|FNE:White,FSW:Yellow|FS:Orange|FSE:Green|SW:Green|S:Yellow|SE:Green|BSW:Yellow|BS:Red|BSE:Green,FNW:Red|FN:Orange|FNE:Orange|FW:Yellow|F:Blue|FE:White|FSW:Orange|FS:Green|FSE:Red,BNW:Red|BN:Orange|BNE:Orange|BW:Red|B:Green|BE:Orange|BSW:Orange|BS:Green|BSE:Red,BNW:Yellow|NW:Yellow|FNW:White|BW:Blue|W:Red|FW:Red|BSW:Green|SW:Yellow|FSW:Blue,FNE:Green|NE:White|BNE:Blue|FE:Red|E:Orange|BE:Blue|FSE:Yellow|SE:White|BSE:White");
            //}
            else if (command == "SCRAMBLE")
            {
                Logic.Scramble(Cubes, 500);
            }
            //else if (command == "SAVEALL")
            //{
            //    RunTest();
            //}
            else if (command == "SAVEPATTERN")
            {
                RunTest();
            }
            else
            {
                Logic.RunMoves(Cubes, command);
            }

            Main(null);
        }

        public static void Load()
        {
            try
            {
                Combinations = new List<String>(File.ReadAllLines("Combinations.txt"));
                //Combinations.Capacity = Int32.MaxValue / 2;
            }
            catch (Exception ex)
            {
                Combinations = new List<String>(Int32.MaxValue / 2);
            }


            try
            {
                Patterns = new List<String>(File.ReadAllLines("Patterns.txt"));
                //Patterns.Capacity = Int32.MaxValue / 2;
            }
            catch (Exception ex)
            {
                Patterns = new List<String>(Int32.MaxValue / 2);
            }
        }

        //public static void RunTest()
        //{

        //    Logic.Scramble(Cube, 1);
        //    String combination = Logic.GetCubeState(Cube);
        //    if (!Combinations.Contains(combination))
        //    {
        //        Combinations.Add(combination);
        //        if (Combinations.Count % 1000 == 0)
        //        {
        //            File.AppendAllLines("Combination.txt", Combinations.Skip(Combinations.Count - 1000).Take(1000));
        //            Console.WriteLine(Combinations.Count);
        //            Thread.Sleep(100);
        //        }
        //    }

        //    try
        //    {
        //        RunTest();
        //    }
        //    catch
        //    {
        //        Console.WriteLine("ERROR");
        //        RunTest();
        //    }
        //}

        public static void RunTest()
        {
            Logic.Scramble(Cubes, 1);
            foreach (CubeModel cube in Cubes)
            {
                String state = Logic.GetCubeState(cube);
                if (!Combinations.Contains(state))
                {
                    Combinations.Add(state);
                    if (Combinations.Count % 1000 == 0)
                    {
                        File.AppendAllLines("Combinations.txt", Combinations.Skip(Combinations.Count - 1000).Take(1000));
                        Console.WriteLine(Combinations.Count);
                        Thread.Sleep(100);
                    }
                }

                String pattern = Logic.GetCubePattern(cube);
                if (!Patterns.Contains(pattern))
                {
                    Patterns.Add(pattern);
                    if (Patterns.Count % 1000 == 0)
                    {
                        File.AppendAllLines("Patterns.txt", Patterns.Skip(Patterns.Count - 1000).Take(1000));
                        Console.WriteLine(Patterns.Count);
                        Thread.Sleep(100);
                    }
                }
            }

            try
            {
                RunTest();
            }
            catch
            {
                Console.WriteLine("ERROR");
                RunTest();
            }
        }


        public static void FindPatterns()
        {

            //Logic.Scramble(Cube, 1);
            //String pattern = PatternLogic.GetPattern(Cube);
            //if (!Combinations.Contains(combination))
            //{
            //    Combinations.Add(combination);
            //    if (Combinations.Count % 1000 == 0)
            //    {
            //        File.AppendAllLines("Combination.txt", Combinations.Skip(Combinations.Count - 1000).Take(1000));
            //        Console.WriteLine(Combinations.Count);
            //        Thread.Sleep(100);
            //    }
            //}

            //try
            //{
            //    RunTest();
            //}
            //catch
            //{
            //    Console.WriteLine("ERROR");
            //    RunTest();
            //}
        }
        public static void OutputCubes()
        {
            foreach (CubeModel cube in Cubes)
            {
                Console.Write("\n\n************************************************\n\n");
                OutputCube(cube);
            }
        }

        public static void OutputCube(CubeModel cube)
        {

            Console.Write("\n\nNorth\n");

            OutputSticker("[BNW] ", cube.BackNorthWest.StickerNorth);
            OutputSticker("[BN]  ", cube.BackNorth.StickerNorth);
            OutputSticker("[BNE] ", cube.BackNorthEast.StickerNorth);

            Console.Write("\n");

            OutputSticker("[NW]  ", cube.NorthWest.StickerNorth);
            OutputSticker("[N]   ", cube.North.StickerNorth);
            OutputSticker("[NE]  ", cube.NorthEast.StickerNorth);

            Console.Write("\n");

            OutputSticker("[FNW] ", cube.FrontNorthWest.StickerNorth);
            OutputSticker("[FN]  ", cube.FrontNorth.StickerNorth);
            OutputSticker("[FNE] ", cube.FrontNorthEast.StickerNorth);


            Console.Write("\n\nWest\n");

            OutputSticker("[BNW] ", cube.BackNorthWest.StickerWest);
            OutputSticker("[NW]  ", cube.NorthWest.StickerWest);
            OutputSticker("[FNW] ", cube.FrontNorthWest.StickerWest);

            Console.Write("\n");

            OutputSticker("[BW]  ", cube.BackWest.StickerWest);
            OutputSticker("[W]   ", cube.West.StickerWest);
            OutputSticker("[FW]  ", cube.FrontWest.StickerWest);

            Console.Write("\n");

            OutputSticker("[BSW] ", cube.BackSouthWest.StickerWest);
            OutputSticker("[SW]  ", cube.SouthWest.StickerWest);
            OutputSticker("[FSW] ", cube.FrontSouthWest.StickerWest);


            Console.Write("\n\nFront\n");

            OutputSticker("[FNW] ", cube.FrontNorthWest.StickerFront);
            OutputSticker("[FN]  ", cube.FrontNorth.StickerFront);
            OutputSticker("[FNE] ", cube.FrontNorthEast.StickerFront);

            Console.Write("\n");

            OutputSticker("[FW]  ", cube.FrontWest.StickerFront);
            OutputSticker("[F]   ", cube.Front.StickerFront);
            OutputSticker("[FE]  ", cube.FrontEast.StickerFront);

            Console.Write("\n");

            OutputSticker("[FSW] ", cube.FrontSouthWest.StickerFront);
            OutputSticker("[FS]  ", cube.FrontSouth.StickerFront);
            OutputSticker("[FSE] ", cube.FrontSouthEast.StickerFront);


            Console.Write("\n\nEast\n");

            OutputSticker("[FNE] ", cube.FrontNorthEast.StickerEast);
            OutputSticker("[NE]  ", cube.NorthEast.StickerEast);
            OutputSticker("[BNE] ", cube.BackNorthEast.StickerEast);

            Console.Write("\n");

            OutputSticker("[FE]  ", cube.FrontEast.StickerEast);
            OutputSticker("[E]   ", cube.East.StickerEast);
            OutputSticker("[BE]  ", cube.BackEast.StickerEast);

            Console.Write("\n");

            OutputSticker("[FSE] ", cube.FrontSouthEast.StickerEast);
            OutputSticker("[SE]  ", cube.SouthEast.StickerEast);
            OutputSticker("[BSE] ", cube.BackSouthEast.StickerEast);


            Console.Write("\n\nSouth\n");

            OutputSticker("[FSW] ", cube.FrontSouthWest.StickerSouth);
            OutputSticker("[FS]  ", cube.FrontSouth.StickerSouth);
            OutputSticker("[FSE] ", cube.FrontSouthEast.StickerSouth);

            Console.Write("\n");

            OutputSticker("[SW]  ", cube.SouthWest.StickerSouth);
            OutputSticker("[S]   ", cube.South.StickerSouth);
            OutputSticker("[SE]  ", cube.SouthEast.StickerSouth);

            Console.Write("\n");

            OutputSticker("[BSW] ", cube.BackSouthWest.StickerSouth);
            OutputSticker("[BS]  ", cube.BackSouth.StickerSouth);
            OutputSticker("[BSE] ", cube.BackSouthEast.StickerSouth);


            Console.Write("\n\nBack\n");

            OutputSticker("[BNW] ", cube.BackNorthWest.StickerBack);
            OutputSticker("[BN]  ", cube.BackNorth.StickerBack);
            OutputSticker("[BNE] ", cube.BackNorthEast.StickerBack);

            Console.Write("\n");

            OutputSticker("[BW]  ", cube.BackWest.StickerBack);
            OutputSticker("[B]   ", cube.Back.StickerBack);
            OutputSticker("[BE]  ", cube.BackEast.StickerBack);

            Console.Write("\n");

            OutputSticker("[BSW] ", cube.BackSouthWest.StickerBack);
            OutputSticker("[BS]  ", cube.BackSouth.StickerBack);
            OutputSticker("[BSE] ", cube.BackSouthEast.StickerBack);

            Console.Write("\n");



        }

        public static void OutputSticker(String label, StickerModelBase sticker)
        {
            Console.ForegroundColor = GetColor(sticker.StickerColorType);
            Console.Write(label);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static ConsoleColor GetColor(StickerColorTypes sticker)
        {
            switch (sticker)
            {
                case StickerColorTypes.Blue:
                    return ConsoleColor.Blue;
                case StickerColorTypes.Green:
                    return ConsoleColor.Green;
                case StickerColorTypes.Orange:
                    return ConsoleColor.DarkYellow;
                case StickerColorTypes.Red:
                    return ConsoleColor.DarkRed;
                case StickerColorTypes.White:
                    return ConsoleColor.White;
                case StickerColorTypes.Yellow:
                    return ConsoleColor.Yellow;
            }

            return ConsoleColor.Gray;
        }
    }
}
