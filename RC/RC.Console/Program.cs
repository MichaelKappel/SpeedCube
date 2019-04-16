using System;
using System.Linq;
using System.Collections.Generic;
using RC.Enumerations;
using RC.Logic;
using RC.Model;
using RC.Model.Slots;
using System.Threading;
using System.IO;

namespace RC
{
    class Program
    {
        public static CubeModel Cube;
        public static CubeLogic Logic = new CubeLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static List<String> Combinations;
        public static List<String> Patterns;

        static void Main(string[] args)
        {
            if (Cube == default(CubeModel))
            {
                Cube = Logic.Create();
                if (Load())
                {
                    Logic.SetCubeState(Cube, Combinations.Last());
                }
            }

            PatternLogic.GetSideCompleteness(Cube);

            OutputCube();

            var command = Console.ReadLine().ToUpper();

            if (command == "PRINT")
            {
                Console.WriteLine(Logic.GetCubeState(Cube));
            }
            else if (command == "LOAD")
            {
                Logic.SetCubeState(Cube, "BNW:Blue|BN:White|BNE:White|NW:Blue|N:White|NE:Blue|FNW:Blue|FN:Yellow|FNE:White,FSW:Yellow|FS:Orange|FSE:Green|SW:Green|S:Yellow|SE:Green|BSW:Yellow|BS:Red|BSE:Green,FNW:Red|FN:Orange|FNE:Orange|FW:Yellow|F:Blue|FE:White|FSW:Orange|FS:Green|FSE:Red,BNW:Red|BN:Orange|BNE:Orange|BW:Red|B:Green|BE:Orange|BSW:Orange|BS:Green|BSE:Red,BNW:Yellow|NW:Yellow|FNW:White|BW:Blue|W:Red|FW:Red|BSW:Green|SW:Yellow|FSW:Blue,FNE:Green|NE:White|BNE:Blue|FE:Red|E:Orange|BE:Blue|FSE:Yellow|SE:White|BSE:White");
            }
            else if (command == "SCRAMBLE")
            {
                Logic.Scramble(Cube, 500);
            }
            else if (command == "SAVEALL")
            {
                RunTest();
            }
            else if (command == "SAVEPATTERN")
            {
                RunTest();
            }
            else
            {
                Logic.RunMoves(Cube, command);
            }

            Main(null);
        }
        
        public static Boolean Load()
        {
            try
            {
                Combinations = new List<String>(File.ReadAllLines("Combination.txt"));
                Combinations.Capacity = Int32.MaxValue / 2;
                return true;
            }
            catch
            {
                Combinations = new List<String>(Int32.MaxValue / 2);
                return false;
            }
        }

        public static void RunTest()
        {

            Logic.Scramble(Cube, 1);
            String combination = Logic.GetCubeState(Cube);
            if (!Combinations.Contains(combination))
            {
                Combinations.Add(combination);
                if (Combinations.Count % 1000 == 0) {
                    File.AppendAllLines("Combination.txt", Combinations.Skip(Combinations.Count - 1000).Take(1000));
                    Console.WriteLine(Combinations.Count);
                    Thread.Sleep(100);
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

        public static void OutputCube()
        {

            Console.Write("\n\nNorth\n");

            OutputSticker("[BNW] ", Cube.BackNorthWest.StickerNorth);
            OutputSticker("[BN]  ", Cube.BackNorth.StickerNorth);
            OutputSticker("[BNE] ", Cube.BackNorthEast.StickerNorth);

            Console.Write("\n");

            OutputSticker("[NW]  ", Cube.NorthWest.StickerNorth);
            OutputSticker("[N]   ", Cube.North.StickerNorth);
            OutputSticker("[NE]  ", Cube.NorthEast.StickerNorth);

            Console.Write("\n");

            OutputSticker("[FNW] ", Cube.FrontNorthWest.StickerNorth);
            OutputSticker("[FN]  ", Cube.FrontNorth.StickerNorth);
            OutputSticker("[FNE] ", Cube.FrontNorthEast.StickerNorth);


            Console.Write("\n\nWest\n");

            OutputSticker("[BNW] ", Cube.BackNorthWest.StickerWest);
            OutputSticker("[NW]  ", Cube.NorthWest.StickerWest);
            OutputSticker("[FNW] ", Cube.FrontNorthWest.StickerWest);

            Console.Write("\n");

            OutputSticker("[BW]  ", Cube.BackWest.StickerWest);
            OutputSticker("[W]   ", Cube.West.StickerWest);
            OutputSticker("[FW]  ", Cube.FrontWest.StickerWest);

            Console.Write("\n");

            OutputSticker("[BSW] ", Cube.BackSouthWest.StickerWest);
            OutputSticker("[SW]  ", Cube.SouthWest.StickerWest);
            OutputSticker("[FSW] ", Cube.FrontSouthWest.StickerWest);


            Console.Write("\n\nFront\n");

            OutputSticker("[FNW] ", Cube.FrontNorthWest.StickerFront);
            OutputSticker("[FN]  ", Cube.FrontNorth.StickerFront);
            OutputSticker("[FNE] ", Cube.FrontNorthEast.StickerFront);

            Console.Write("\n");

            OutputSticker("[FW]  ", Cube.FrontWest.StickerFront);
            OutputSticker("[F]   ", Cube.Front.StickerFront);
            OutputSticker("[FE]  ", Cube.FrontEast.StickerFront);

            Console.Write("\n");

            OutputSticker("[FSW] ", Cube.FrontSouthWest.StickerFront);
            OutputSticker("[FS]  ", Cube.FrontSouth.StickerFront);
            OutputSticker("[FSE] ", Cube.FrontSouthEast.StickerFront);


            Console.Write("\n\nEast\n");

            OutputSticker("[FNE] ", Cube.FrontNorthEast.StickerEast);
            OutputSticker("[NE]  ", Cube.NorthEast.StickerEast);
            OutputSticker("[BNE] ", Cube.BackNorthEast.StickerEast);

            Console.Write("\n");

            OutputSticker("[FE]  ", Cube.FrontEast.StickerEast);
            OutputSticker("[E]   ", Cube.East.StickerEast);
            OutputSticker("[BE]  ", Cube.BackEast.StickerEast);

            Console.Write("\n");

            OutputSticker("[FSE] ", Cube.FrontSouthEast.StickerEast);
            OutputSticker("[SE]  ", Cube.SouthEast.StickerEast);
            OutputSticker("[BSE] ", Cube.BackSouthEast.StickerEast);


            Console.Write("\n\nSouth\n");

            OutputSticker("[FSW] ", Cube.FrontSouthWest.StickerSouth);
            OutputSticker("[FS]  ", Cube.FrontSouth.StickerSouth);
            OutputSticker("[FSE] ", Cube.FrontSouthEast.StickerSouth);

            Console.Write("\n");

            OutputSticker("[SW]  ", Cube.SouthWest.StickerSouth);
            OutputSticker("[S]   ", Cube.South.StickerSouth);
            OutputSticker("[SE]  ", Cube.SouthEast.StickerSouth);

            Console.Write("\n");

            OutputSticker("[BSW] ", Cube.BackSouthWest.StickerSouth);
            OutputSticker("[BS]  ", Cube.BackSouth.StickerSouth);
            OutputSticker("[BSE] ", Cube.BackSouthEast.StickerSouth);


            Console.Write("\n\nBack\n");

            OutputSticker("[BNW] ", Cube.BackNorthWest.StickerBack);
            OutputSticker("[BN]  ", Cube.BackNorth.StickerBack);
            OutputSticker("[BNE] ", Cube.BackNorthEast.StickerBack);

            Console.Write("\n");

            OutputSticker("[BW]  ", Cube.BackWest.StickerBack);
            OutputSticker("[B]   ", Cube.Back.StickerBack);
            OutputSticker("[BE]  ", Cube.BackEast.StickerBack);

            Console.Write("\n");

            OutputSticker("[BSW] ", Cube.BackSouthWest.StickerBack);
            OutputSticker("[BS]  ", Cube.BackSouth.StickerBack);
            OutputSticker("[BSE] ", Cube.BackSouthEast.StickerBack);

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
                    return ConsoleColor.Red;
                case StickerColorTypes.Red:
                    return ConsoleColor.DarkRed;
                case StickerColorTypes.White:
                    return ConsoleColor.White;
                case StickerColorTypes.Yellow:
                    return ConsoleColor.DarkYellow;
            }

            return ConsoleColor.Gray;
        }
    }
}
