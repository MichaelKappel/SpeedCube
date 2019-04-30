using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Logic;
using RC.Model;
using RC.Model.Patterns;

namespace RC
{
    class Program
    {
        public static CubeModel Cube;
        public static CubeLogic Logic = new CubeLogic();
        public static CubeFacePatternLogic FacePatternLogic = new CubeFacePatternLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static PatternRecognitionLogic PatternRecognition = new PatternRecognitionLogic();

        public static Dictionary<String, (Int32, Int32)> UniqueFacePatterns;
        public static Dictionary<String, (Int32, Int32)> UniqueCubePatterns;

        //public static CubePatternLogic PatternLogic = new CubePatternLogic();
        //public static List<String> Combinations;
        //public static List<String> Patterns;
        //public static List<String> FacePatterns;
        //public static List<String> CubePatterns;

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

            OutputCube(Cube);
            foreach(var pattern in FindPatternsBasic(Cube))
            {
                Console.WriteLine(pattern);
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

            if (!File.Exists("UniqueCubePatterns.txt"))
            {
                using (var fs = File.Create("UniqueCubePatterns.txt"))
                {
                    Thread.Sleep(1000);
                }
            }

            if (!File.Exists("UniqueFacePatterns.txt"))
            {
                using (var fs = File.Create("UniqueFacePatterns.txt"))
                {
                    Thread.Sleep(1000);
                }
            }

            UniqueCubePatterns = new Dictionary<String, (Int32, Int32)>();
            String[] uniqueCubePatternHitsRaw = File.ReadAllLines("UniqueCubePatterns.txt");
            if (uniqueCubePatternHitsRaw.Length > 0)
            {

                foreach (var uniqueCubePatternHitRaw in uniqueCubePatternHitsRaw)
                {
                    String[] uniqueCubePatternHitRawArgs = uniqueCubePatternHitRaw.Split(' ');
                    String key = uniqueCubePatternHitRawArgs[1];
                    Int32 value1 = Int32.Parse(uniqueCubePatternHitRawArgs[0]);
                    Int32 value2 = Int32.Parse(uniqueCubePatternHitRawArgs[2]);
                    UniqueCubePatterns.Add(key, (value2, value1));
                }

            }

            UniqueFacePatterns = new Dictionary<String, (Int32, Int32)>();
            String[] uniqueFacePatternsRaw = File.ReadAllLines("UniqueFacePatterns.txt");
            if (uniqueFacePatternsRaw.Length > 0)
            {

                foreach (var uniqueFacePatternRaw in uniqueFacePatternsRaw)
                {
                    String[] uniqueFacePatternRawArgs = uniqueFacePatternRaw.Split(' ');
                    String key = uniqueFacePatternRawArgs[1];
                    Int32 value1 = Int32.Parse(uniqueFacePatternRawArgs[0]);
                    Int32 value2 = Int32.Parse(uniqueFacePatternRawArgs[2]);
                    UniqueFacePatterns.Add(key, (value2, value1));
                }

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



        public static String Scamble(CubeModel cube)
        {
            CubeModel result = Logic.CloneCube(cube);

            Logic.Scramble(result, 10);

            return PatternLogic.GetCubePattern(result);
        }


        public static void UpdateOrAddCubeStatistics(String pattern, Int32 variationCount, Int32 occurrences)
        {
            lock (UniqueCubePatterns)
            {
                if (UniqueCubePatterns.ContainsKey(pattern))
                {
                    var item = UniqueCubePatterns[pattern];
                    UniqueCubePatterns[pattern] = (item.Item1, item.Item2 + occurrences);
                }
                else
                {
                    UniqueCubePatterns.Add(pattern, (variationCount, 1));
                }
                Console.WriteLine($"{UniqueCubePatterns[pattern].Item2.ToString().PadLeft(5, '0')} {pattern} {UniqueCubePatterns[pattern].Item1} ");
            }
        }

        public static void UpdateOrAddFaceStatistics(String pattern, Int32 variationCount, Int32 occurrences)
        {
            lock (UniqueFacePatterns)
            {
                if (UniqueFacePatterns.ContainsKey(pattern))
                {
                    var item = UniqueFacePatterns[pattern];
                    UniqueFacePatterns[pattern] = (item.Item1, item.Item2 + occurrences);
                }
                else
                {
                    UniqueFacePatterns.Add(pattern, (variationCount, 1));
                }
                Console.WriteLine($"{UniqueFacePatterns[pattern].Item2.ToString().PadLeft(5, '0')} {pattern} {UniqueFacePatterns[pattern].Item1} ");
            }
            }

        public static void UpdateCubeCount(Dictionary<String, (Int32, Int32)> cubePatterns, String pattern)
        {
            Console.WriteLine($"{pattern} UpdateFaceCount");
            String[] cubePatternsVariations = PatternLogic.GetAllCubePatterns(pattern);
            Console.WriteLine($"{pattern}  {cubePatternsVariations.Count()} Variations");
            lock (cubePatterns)
            {
                String localMatch = cubePatterns.Keys.FirstOrDefault(x1 => cubePatternsVariations.Contains(x1));
                if (String.IsNullOrWhiteSpace(localMatch))
                {
                    String mainMatch = UniqueCubePatterns.Keys.FirstOrDefault(x1 => cubePatternsVariations.Contains(x1));
                    if (String.IsNullOrWhiteSpace(mainMatch))
                    {
                        cubePatterns.Add(pattern, (cubePatternsVariations.Count(), 1));
                        Console.WriteLine($"{pattern} ADDED");
                    }
                    else
                    {
                        cubePatterns.Add(mainMatch, (cubePatternsVariations.Count(), 1));
                        Console.WriteLine($"{mainMatch} ADDED");
                    }
                }
                else
                {
                    if (cubePatterns.ContainsKey(pattern))
                    {
                        var existingRecord = cubePatterns[pattern];
                        cubePatterns[pattern] = (existingRecord.Item2, existingRecord.Item2 + 1);

                        Console.WriteLine($"{pattern} UPDATED");
                    }
                    else
                    {
                        var existingRecord = cubePatterns[localMatch];
                        cubePatterns[localMatch] = (existingRecord.Item2, existingRecord.Item2 + 1);

                        Console.WriteLine($"{localMatch} UPDATED");
                    }
                }
            }
        }

        public static void UpdateFaceCount(Dictionary<String, (Int32, Int32)> resultfacePatterns, String cubePattern)
        {
            Console.WriteLine($"{cubePattern} UpdateFaceCount");

            String[] facePatterns = FacePatternLogic.GetCubeFacePatterns(cubePattern);

            for (var i2 = 0; i2 < facePatterns.Count(); i2++)
            {
                String facePattern = facePatterns[i2];

                String[] facePatternVariations = FacePatternLogic.GetAllFacePatterns(facePattern);
                lock (resultfacePatterns)
                {
                    String localMatch = resultfacePatterns.Keys.FirstOrDefault(x1 => facePatternVariations.Contains(x1));

                    if (String.IsNullOrWhiteSpace(localMatch))
                    {
                        String mainMatch = UniqueFacePatterns.Keys.FirstOrDefault(x1 => facePatternVariations.Contains(x1));
                        if (String.IsNullOrWhiteSpace(mainMatch))
                        {
                            resultfacePatterns.Add(facePattern, (facePatternVariations.Count(), 1));
                            Console.WriteLine($"{facePattern} ADDED");
                        }
                        else
                        {
                            resultfacePatterns.Add(mainMatch, (facePatternVariations.Count(), 1));
                            Console.WriteLine($"{mainMatch} ADDED");
                        }
                    }
                    else
                    {
                        if (resultfacePatterns.ContainsKey(facePattern))
                        {
                            var existingRecord = resultfacePatterns[facePattern];
                            resultfacePatterns[facePattern] = (existingRecord.Item2, existingRecord.Item2 + 1);

                            Console.WriteLine($"{facePattern} UPDATED");
                        }
                        else
                        {
                            var existingRecord = resultfacePatterns[localMatch];
                            resultfacePatterns[localMatch] = (existingRecord.Item2, existingRecord.Item2 + 1);

                            Console.WriteLine($"{localMatch} UPDATED");
                        }
                    }
                }
            }
        }


        public static void RunTest()
        {
            foreach (var item in UniqueCubePatterns)
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
                    catch (Exception ex)
                    {

                    }

                    Console.WriteLine($"{pattern}");
                }
                Console.WriteLine($"{item.Key} {validPatterns} of {patterns.Count() } are Valid {item.Key}\n");
                Thread.Sleep(200);
            }
        }

        public static String[] FindPatternsBasic(CubeModel cube)
        {
            var result = new List<String>();

            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Blue));
            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Green));
            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Orange));
            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Red));
            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.White));
            result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Yellow));

            return result.ToArray();
        }

        public static String DocumentPatternsStringBasic(CubeModel cube, StickerColorTypes stickerColorType)
        {
            String result = $"C:{stickerColorType}|F:";

            PatternStatisticModel patternStatistic = PatternRecognition.GetCompleteness(cube, stickerColorType);
            foreach (var patternFaceResult in patternStatistic.PatternFaceResults)
            {
                if (patternFaceResult.Pattern != PatternFaceTypes.None)
                {
                    result += $"{patternFaceResult.Pattern} ";
                }
            }

            result += "|A:";

            foreach (var patternAdjacentResult in patternStatistic.PatternAdjacentResults)
            {
                if (patternAdjacentResult.Pattern != PatternAdjacentTypes.None)
                {
                    result += $"{patternAdjacentResult.Pattern} ";
                }
            }

            return result;
        }

        public static String[] FindPatterns(CubeModel cube)
        {
            var result = new List<String>();
            
            result.Add(DocumentPatternsString(cube, StickerColorTypes.Blue));
            result.Add(DocumentPatternsString(cube, StickerColorTypes.Green));
            result.Add(DocumentPatternsString(cube, StickerColorTypes.Orange));
            result.Add(DocumentPatternsString(cube, StickerColorTypes.Red));
            result.Add(DocumentPatternsString(cube, StickerColorTypes.White));
            result.Add(DocumentPatternsString(cube, StickerColorTypes.Yellow));

            return result.ToArray();
        }

        public static String DocumentPatternsString(CubeModel cube, StickerColorTypes stickerColorType)
        {
            String result = $"C:{stickerColorType}|";

            PatternStatisticModel patternStatistic = PatternRecognition.GetCompleteness(cube, stickerColorType);
            foreach (var patternFaceResult in patternStatistic.PatternFaceResults)
            {
                if (patternFaceResult.Pattern != PatternFaceTypes.None)
                {
                    result += $"[FM:{patternFaceResult.Middles}|" +
                    $"FS:{patternFaceResult.Sides}|" +
                    $"FC:{patternFaceResult.Corners}|" +
                    $"FP:{patternFaceResult.Pattern }]";
                }
            }

            foreach (var patternAdjacentResult in patternStatistic.PatternAdjacentResults)
            {
                if (patternAdjacentResult.Pattern != PatternAdjacentTypes.None)
                {
                    result += $"[AM:{patternAdjacentResult.Middles}|" +
                    $"AS:{patternAdjacentResult.Sides}|" +
                    $"AC:{patternAdjacentResult.Corners}|" +
                    $"AP:{patternAdjacentResult.Pattern }]";
                }
            }

            return result;
        }

        public static void GenerateStatistics()
        {
            Console.WriteLine("\n\n**************** START ****************\n\n");
            {
                foreach (var item in FindPatterns(Cube))
                {
                    Console.WriteLine(item);
                }

                Thread.Sleep(2000);
            }
            {
                var cubeResults = new Dictionary<String, (Int32, Int32)>();
                var faceResults = new Dictionary<String, (Int32, Int32)>();
                String initalPattern = PatternLogic.GetCubePattern(Cube);
                UpdateCubeCount(cubeResults, initalPattern);
                UpdateFaceCount(faceResults, initalPattern);
                {
                    var cubesPatterns = new List<String>();
                    for (var i = 0; i < 100; i++)
                    {
                        cubesPatterns.Add(Scamble(Cube));
                    }

                    Parallel.ForEach(cubesPatterns, (pattern) =>
                    {
                        //try
                        //{
                            UpdateCubeCount(cubeResults, pattern);
                            UpdateFaceCount(faceResults, pattern);
                        //}
                        //catch (Exception e)
                        //{
                        //    Console.WriteLine(e.Message);
                        //}

                        Console.Write($"\n\t{cubeResults.Count()}\n");
                    });
                    cubesPatterns = null;

                }
                foreach (var result in cubeResults)
                {
                    UpdateOrAddCubeStatistics(result.Key, result.Value.Item1, result.Value.Item2);
                }
                foreach (var result in faceResults)
                {
                    UpdateOrAddFaceStatistics(result.Key, result.Value.Item1, result.Value.Item2);
                }
                cubeResults = null;
                faceResults = null;
            }

            Console.WriteLine("\n************************************************");
            Console.WriteLine("*********         Scrambling       *************");
            Console.WriteLine("************************************************\n");

            Logic.Scramble(Cube, 20);

            {
                List<String> list = UniqueCubePatterns.Select(x => x.Value.Item2.ToString().PadLeft(5, '0') + " " + x.Key + " " + x.Value.Item1).ToList();
                using (StreamWriter writer = new StreamWriter("UniqueCubePatterns.txt", false))
                {
                    foreach (var uniqueCubePatternHit in list.OrderByDescending(x => x, StringComparer.Ordinal))
                    {
                        writer.WriteLine(uniqueCubePatternHit);
                    }
                }
                list = null;
            }

            {
                List<String> list = UniqueFacePatterns.Select(x => x.Value.Item2.ToString().PadLeft(5, '0') + " " + x.Key + " " + x.Value.Item1).ToList();
                using (StreamWriter writer = new StreamWriter("UniqueFacePatterns.txt", false))
                {
                    foreach (var uniqueCubePatternHit in list.OrderByDescending(x => x, StringComparer.Ordinal))
                    {
                        writer.WriteLine(uniqueCubePatternHit);
                    }
                }
                list = null;
            }

            Console.WriteLine("\n\n**************** DONE ****************\n\n");
            GenerateStatistics();
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
