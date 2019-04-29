using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Logic;
using RC.Model;

namespace RC
{
    class Program
    {
        public static CubeModel Cube;
        public static Dictionary<String, (Int32, Int32)> UniqueCubePatternHits;
        public static CubeLogic Logic = new CubeLogic();
        public static CubeFacePatternLogic FacePatternLogic = new CubeFacePatternLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();

        //public static CubePatternLogic PatternLogic = new CubePatternLogic();
        //public static List<String> Combinations;
        //public static List<String> Patterns;
        //public static List<String> FacePatterns;
        //public static List<String> CubePatterns;
        //public static List<String> UniqueFacePatterns;

        public static Int32 Count = 0;

        static void Main(string[] args)
        {

           
            CubeLogic logic = new CubeLogic();
            if (Cube == default(CubeModel))
            {
                Cube = logic.Create(XyzCubeTypes.BlueOrangeWhite);
                Console.WriteLine(Cube.ToString());
                Load();

                //Logic.SetCubeState(Cube, Combinations.Last());

            }

            //PatternLogic.GetSideCompleteness(Cube);

            //OutputAllCubeVariations();
            //foreach (CubeModel cube in Cubes)
            //{
            //foreach (var completeness in PatternLogic.GetSideCompleteness(Cube))
            //{
            //    Console.Write("\n");
            //    Console.Write(completeness.Key);
            //    Console.Write("\nFace:" + completeness.Value.PatternFaceResult.Pattern);
            //    Console.Write("\nCorner:" + completeness.Value.PatternAdjacentResult.Pattern);
            //    Console.Write("\n");
            //}
            // }
            var command = Console.ReadLine().ToUpper();

            if (command == "PRINT")
            {
                //foreach (CubeModel cube in Cubes)
                //{
                Console.WriteLine(PatternLogic.GetCubePattern(Cube));
                //}
            }

            //else if (command == "LOAD")
            //{
            //    Logic.SetCubeState(Cubes, "BNW:Blue|BN:White|BNE:White|NW:Blue|N:White|NE:Blue|FNW:Blue|FN:Yellow|FNE:White,FSW:Yellow|FS:Orange|FSE:Green|SW:Green|S:Yellow|SE:Green|BSW:Yellow|BS:Red|BSE:Green,FNW:Red|FN:Orange|FNE:Orange|FW:Yellow|F:Blue|FE:White|FSW:Orange|FS:Green|FSE:Red,BNW:Red|BN:Orange|BNE:Orange|BW:Red|B:Green|BE:Orange|BSW:Orange|BS:Green|BSE:Red,BNW:Yellow|NW:Yellow|FNW:White|BW:Blue|W:Red|FW:Red|BSW:Green|SW:Yellow|FSW:Blue,FNE:Green|NE:White|BNE:Blue|FE:Red|E:Orange|BE:Blue|FSE:Yellow|SE:White|BSE:White");
            //}
            else if (command == "SCRAMBLE")
            {
                logic.Scramble(Cube, 500);
            }
            //else if (command == "SAVEALL")
            //{
            //    RunTest();
            //}
            else if (command.Length == 9 * 6)
            {
                logic.SetDetailedCubeState(Cube, PatternLogic.GetCubePatternDetail(command));
            }
            else if (command == "TEST")
            {
                RunTest();
            }
            else if (command == "GO")
            {
                GenerateStatistics();
            }
            else
            {
                logic.RunMoves(Cube, command);
            }

            Main(null);
        }

        public static void Load()
        {

            if (!File.Exists("UniqueCubePatternHits.txt"))
            {
                File.Create("UniqueCubePatternHits.txt");
                Thread.Sleep(1000);
            }

            UniqueCubePatternHits = new Dictionary<String, (Int32, Int32)>();
            String[] uniqueCubePatternHitsRaw = File.ReadAllLines("UniqueCubePatternHits.txt");
            if (uniqueCubePatternHitsRaw.Length > 0)
            {

                foreach (var uniqueCubePatternHitRaw in uniqueCubePatternHitsRaw)
                {
                    String[] uniqueCubePatternHitRawArgs = uniqueCubePatternHitRaw.Split(' ');
                    String key = uniqueCubePatternHitRawArgs[1];
                    Int32 value1 = Int32.Parse(uniqueCubePatternHitRawArgs[0]);
                    Int32 value2 = 0;
                    if (uniqueCubePatternHitRawArgs.Length > 2)
                    {
                        value2 = Int32.Parse(uniqueCubePatternHitRawArgs[2]);
                    }
                    UniqueCubePatternHits.Add(key, (value1, value2));
                }

            }


            //if (!File.Exists("Combinations.txt"))
            //{
            //    File.Create("Combinations.txt");
            //    File.Create("Patterns.txt");
            //    File.Create("CubePatterns.txt");
            //    File.Create("UniqueCubePatterns.txt");
            //    File.Create("UniqueCubePatternDetails.txt");
            //    File.Create("UniqueCubePatternHits.txt");
            //    File.Create("FacePatterns.txt");
            //    File.Create("UniqueFacePatterns.txt");
            //    File.Create("UniqueFacePatternDetails.txt");
            //    Thread.Sleep(100);
            //}

            //try
            //{
            //    Combinations = new List<String>(File.ReadAllLines("Combinations.txt"));
            //    //Combinations.Capacity = Int32.MaxValue / 2;
            //}
            //catch (Exception ex)
            //{
            //    Combinations = new List<String>(Int32.MaxValue / 2);
            //}


            //try
            //{
            //    Patterns = new List<String>(File.ReadAllLines("Patterns.txt"));
            //    //Patterns.Capacity = Int32.MaxValue / 2;
            //}
            //catch (Exception ex)
            //{
            //    Patterns = new List<String>(Int32.MaxValue / 2);
            //}

            //try
            //{
            //    CubePatterns = new List<String>(File.ReadAllLines("CubePatterns.txt"));
            //    //Patterns.Capacity = Int32.MaxValue / 2;
            //}
            //catch (Exception ex)
            //{
            //    CubePatterns = new List<String>(Int32.MaxValue / 2);
            //}


            //Patterns.Capacity = Int32.MaxValue / 2;


            //try
            //{
            //    FacePatterns = new List<String>(File.ReadAllLines("FacePatterns.txt"));
            //    //Patterns.Capacity = Int32.MaxValue / 2;
            //}
            //catch (Exception ex)
            //{
            //    FacePatterns = new List<String>(Int32.MaxValue / 2);
            //}

            //try
            //{
            //    UniqueFacePatterns = new List<String>(File.ReadAllLines("UniqueFacePatterns.txt"));
            //    //Patterns.Capacity = Int32.MaxValue / 2;
            //}
            //catch (Exception ex)
            //{
            //    UniqueFacePatterns = new List<String>(Int32.MaxValue / 2);
            //}



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



        public static String Scamble(CubeModel cube)
        {
            CubeModel result = Logic.CloneCube(cube);

            Logic.Scramble(result, 10);

            return PatternLogic.GetCubePattern(result);
        }
        

        public static void UpdateOrAddToStuff(String pattern, Int32 variationCount)
        {
            if (UniqueCubePatternHits.ContainsKey(pattern))
            {
                var item = UniqueCubePatternHits[pattern];
                UniqueCubePatternHits[pattern] = (item.Item1 + 1, item.Item2);
                Console.WriteLine(UniqueCubePatternHits.Count().ToString().PadLeft(5, '0') + " " + UniqueCubePatternHits[pattern]);
            }
            else
            {
                UniqueCubePatternHits.Add(pattern,(1, variationCount));
                Console.WriteLine(UniqueCubePatternHits.Count());
            }
        }

        public static void UpdateStuff(IList<(String, Int32)> patterns, String pattern)
        {
            Console.WriteLine($"{pattern} GetAllCubePatterns");
            String[] cubePatternsVariations = PatternLogic.GetAllCubePatterns(pattern);
            Console.WriteLine($"{pattern}  {cubePatternsVariations.Count()} Variations");
            lock (patterns)
            {
                String match = UniqueCubePatternHits.Keys.FirstOrDefault(x1 => cubePatternsVariations.Contains(x1));
                if (String.IsNullOrWhiteSpace(match))
                {
                    patterns.Add((pattern, cubePatternsVariations.Length));

                    Console.WriteLine($"{pattern} ADDED");
                }
                else
                {
                    patterns.Add((match, cubePatternsVariations.Length));

                    Console.WriteLine($"{match} UPDATED {pattern}");
                }
            }
        }

        public static void RunTest()
        {
            foreach(var item in UniqueCubePatternHits)
            {
                var validPatterns = 0;
                String[] patterns = PatternLogic.GetAllCubePatterns(item.Key);
                foreach (var pattern in patterns)
                {
                    try
                    {
                        CubeModel cube = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
                        String cubePatternDetail = PatternLogic.GetCubePatternDetail(pattern);
                        Logic.SetDetailedCubeState(cube, cubePatternDetail);
                        validPatterns += 1;
                    }
                    catch (Exception ex) {

                    }
                    
                    Console.WriteLine($"{pattern}");
                }
                Console.WriteLine($"{item.Key} {validPatterns} of {patterns.Count() } are Valid {item.Key}\n");
                Thread.Sleep(200);
            }
        }

        public static void GenerateStatistics()
        {

            //OutputAllCubeVariations();
            {
                var results = new List<(String, Int32)>();

                UpdateStuff(results, PatternLogic.GetCubePattern(Cube));
                {
                    var cubesPatterns = new List<String>();
                    for (var i = 0; i < 1000; i++)
                    {
                        cubesPatterns.Add(Scamble(Cube));
                    }

                    Parallel.ForEach(cubesPatterns, (pattern) =>
                    {
                        try
                        {
                          UpdateStuff(results, pattern);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.Write($"\n\t{results.Count()}\n");
                    });
                    cubesPatterns = null;
                    
                }
                foreach (var result in results)
                {
                    UpdateOrAddToStuff(result.Item1, result.Item2);
                }
                results = null;
            }

            Logic.Scramble(Cube, 20);

            {
                List<String> list = UniqueCubePatternHits.Select(x => x.Value.Item1.ToString().PadLeft(5, '0') + " " + x.Key + " " + x.Value.Item2).ToList();
                using (StreamWriter writer = new StreamWriter("UniqueCubePatternHits.txt", false))
                {
                    foreach (var uniqueCubePatternHit in list.OrderByDescending(x => x, StringComparer.Ordinal))
                    {
                        writer.WriteLine(uniqueCubePatternHit);
                    }
                }
                list = null;
            }

            //foreach (CubeModel cube in Cubes)
            //{

            //String state = Logic.GetCubeState(cube);
            //if (!Combinations.Contains(state))
            //{
            //    Combinations.Add(state);
            //    if (Combinations.Count % 1000 == 0)
            //    {
            //        File.AppendAllLines("Combinations.txt", Combinations.Skip(Combinations.Count - 1000).Take(1000));
            //        Console.WriteLine("Combinations:" + Combinations.Count);
            //        Thread.Sleep(100);
            //    }
            //}

            //String pattern = Logic.GetCubePattern(cube);
            //if (!Patterns.Contains(pattern))
            //{
            //    Patterns.Add(pattern);
            //    if (Patterns.Count % 1000 == 0)
            //    {
            //        File.AppendAllLines("Patterns.txt", Patterns.Skip(Patterns.Count - 1000).Take(1000));
            //        Console.WriteLine("Patterns:" + Patterns.Count);
            //        Thread.Sleep(100);
            //    }
            //}


            //if (!CubePatterns.Contains(cubePattern))
            //{
            //    CubePatterns.Add(cubePattern);
            //    if (CubePatterns.Count % 100 == 0)
            //    {
            //        File.AppendAllLines("CubePatterns.txt", CubePatterns.Skip(CubePatterns.Count - 100).Take(100));
            //        Console.WriteLine("CubePatterns:" + CubePatterns.Count);
            //        Thread.Sleep(10);
            //    }
            //}




            //String[] facePatterns = logic.GetCubeFacePatterns(Cube);

            //foreach (string facePattern in facePatterns)
            //{
            //    if (!FacePatterns.Contains(facePattern))
            //    {
            //        FacePatterns.Add(facePattern);
            //        if (FacePatterns.Count % 100 == 0)
            //        {
            //            File.AppendAllLines("FacePatterns.txt", FacePatterns.Skip(FacePatterns.Count - 100).Take(100));
            //            Console.WriteLine("FacePatterns:" + FacePatterns.Count);
            //            Thread.Sleep(10);
            //        }
            //    }
            //    if (facePattern.ToCharArray()[4] == 'A')
            //    {
            //        String[] facePatternsVariations = logic.GetAllFacePatterns(facePattern);
            //        String[] facePatternsVariationsFound = UniqueFacePatterns.Where(x => facePatternsVariations.Contains(x)).ToArray();
            //        if (facePatternsVariationsFound.Length == 0)
            //        {
            //            UniqueFacePatterns.Add(facePattern);

            //            File.AppendAllText("UniqueFacePatterns.txt", "\n" + facePattern);
            //            File.AppendAllText("UniqueFacePatternDetails.txt", "\n" + $"{UniqueFacePatterns.Count} {facePatternsVariations.Count()} " + String.Join(",", facePatternsVariations));

            //            Console.WriteLine("UniqueFacePatterns:" + UniqueFacePatterns.Count);
            //            Thread.Sleep(10);
            //        }
            //        else
            //        {

            //        }
            //    }
            //}
            //}


            //try
            //{
                GenerateStatistics();
            //}
            //catch
            //{
            //    Console.WriteLine("ERROR");
            //    GenerateStatistics();
            //}
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
        public static void OutputAllCubeVariations()
        {
            //foreach (CubeModel cube in Cubes)
            //{
            Console.Write("\n\n************************************************\n\n");

            var count = 1;
            String[] cubePatternsVariations = PatternLogic.GetAllCubePatterns(PatternLogic.GetCubePattern(Cube));
            foreach (String cubePatternsVariation in cubePatternsVariations)
            {
                //try
                //{
                    CubeModel cube = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
                    String cubePatternDetail = PatternLogic.GetCubePatternDetail(cubePatternsVariation);
                    Logic.SetDetailedCubeState(cube, cubePatternDetail);
                    OutputCube(cube);
                    count++;
                //}
                //catch (Exception ex)
                //{
                //    //FIX:
                //    Console.Write($"\n        ERROR INVALID PATTERN: { cubePatternsVariation } \n");
                //}
            }

            Console.Write("\n\n********************* " + count + " **************************\n\n");
            //}
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
