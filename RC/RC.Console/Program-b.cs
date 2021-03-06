﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RC
{
    class Program
    {
        //public static CubeModel Cube;
        public static CubeLogic Logic = new CubeLogic();
        public static CubeFacePatternLogic FacePatternLogic = new CubeFacePatternLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static PatternRecognitionLogic PatternRecognition = new PatternRecognitionLogic();

        //public static Int32 RecordStep(Int32 parentPatternStepId, Int32 lastStepPatternId,  String nextPattern, MoveTypes moveType, Int32 iStep)
        //{
        //    using (Whatever WhateverThing = new Whatever())
        //    {
        //        String patternOfNextStepRaw = PatternLogic.ToDatabase(nextPattern);
        //        Pattern patternOfNextStep = WhateverThing.Patterns.FirstOrDefault(x => x.PatternContent == patternOfNextStepRaw);
        //        if (patternOfNextStep == default(Pattern))
        //        {
        //            try
        //            {
        //                patternOfNextStep = new Pattern()
        //                {
        //                    PatternContent = patternOfNextStepRaw
        //                };
        //                patternOfNextStep = WhateverThing.Patterns.Add(patternOfNextStep);
        //                WhateverThing.SaveChanges();
        //            }
        //            catch (Exception)
        //            {

        //            }
        //        }

        //        PatternRelation patternRelation = WhateverThing.PatternRelations.FirstOrDefault(x => x.PatternId == lastStepPatternId && x.ConnectedPatternId == patternOfNextStep.PatternId);
        //        if (patternRelation == default(PatternRelation))
        //        {
        //            try
        //            {
        //                patternRelation = new PatternRelation()
        //                {
        //                    PatternId = lastStepPatternId,
        //                    ConnectedPatternId = patternOfNextStep.PatternId,
        //                    Relationship = Logic.Convert(moveType)
        //                };
        //                WhateverThing.PatternRelations.Add(patternRelation);
        //                WhateverThing.SaveChanges();
        //            }
        //            catch (Exception)
        //            {

        //            }
        //        }


        //        if (!patternRelation.Relationship.Contains("2"))
        //        {
        //            PatternRelation patternRelationReversed = WhateverThing.PatternRelations.FirstOrDefault(x => x.PatternId == patternOfNextStep.PatternId && x.ConnectedPatternId == lastStepPatternId);
        //            if (patternRelationReversed == default(PatternRelation))
        //            {
        //                try { 
        //                    patternRelationReversed = new PatternRelation()
        //                    {
        //                        PatternId = patternOfNextStep.PatternId,
        //                        ConnectedPatternId = lastStepPatternId,
        //                        Relationship = Logic.Convert(Logic.Reverse(moveType))
        //                    };
        //                    WhateverThing.PatternRelations.Add(patternRelationReversed);
        //                    WhateverThing.SaveChanges();
        //                }
        //                catch (Exception)
        //                {

        //                }
        //            }
        //        }

        //        PatternStep patternStep = WhateverThing.PatternSteps.FirstOrDefault(x => x.PatternRelationId == patternRelation.PatternRelationId && x.PatternTypeId == 1);
        //        if (patternStep == default(PatternStep))
        //        {
        //            try
        //            {
        //                patternStep = new PatternStep()
        //                {
        //                    PatternTypeId = 1,
        //                    PatternRelationId = patternRelation.PatternRelationId,
        //                    Step = iStep
        //                };

        //                if (parentPatternStepId > 0)
        //                {
        //                    patternStep.ParentPatternStepId = parentPatternStepId;
        //                }

        //                patternStep = WhateverThing.PatternSteps.Add(patternStep);
        //                WhateverThing.SaveChanges();
        //                Console.WriteLine("Added {0} {1} {2} ", iStep, patternStep.PatternStepId, moveType);
        //            }
        //            catch
        //            {

        //            }
        //        }
        //        else if (patternStep.Step < iStep)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Exists {0} {1} {2} ", iStep, patternStep.PatternStepId, moveType);
        //        }

        //        return patternStep.PatternStepId;
        //    }
        //}

        //static void Steps(Int32 iStep)
        //{
        //    if (iStep == 1)
        //    {
        //        CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);
        //        //Step(iStep, 1, cubeStartingPoint);
        //    }
        //    else
        //    {
        //        vw_PatternRelationStepDetails[] patternRelationStepDetails;
        //        using (Whatever WhateverThing = new Whatever())
        //        {
        //            patternRelationStepDetails = WhateverThing.vw_PatternRelationStepDetails.Where(x => x.Step == iStep - 1).ToArray();

        //        }

        //        for (var i = 0; i < patternRelationStepDetails.Count(); i++)
        //        {
        //            CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);
        //            Logic.SetCubeState(cubeStartingPoint, PatternLogic.FromDatabase(patternRelationStepDetails[i].ConnectedPattern));
        //            Step(iStep, patternRelationStepDetails[i].ConnectedPatternId, cubeStartingPoint);
        //        }
        //    }
        //}

        static void DoSteps(Int32 iStep)
        {
            if (iStep == 1)
            {
                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);
                DoStep(iStep, new[] { (1, 0, PatternLogic.GetCubePattern(cubeStartingPoint)) });
            }
            else
            {
                Int32 stepSize = 200;
                while (true)
                {
                    var patternRelationStepDetails = new List<(Int32 PrimaryPatternId, Int32 ParentPatternStepId, String Pattern)>();
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                    {
                        connection.Open();
                        String commandName = "dbo.[wsp_PatternRelationStepRemainingDetailsGet]";
                        using (SqlCommand cmd = new SqlCommand(commandName, connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;

                            cmd.Parameters.Add(new SqlParameter("@Step", SqlDbType.Int)
                            {
                                Value = iStep
                            });

                            cmd.Parameters.Add(new SqlParameter("@MaxRecords", SqlDbType.Int)
                            {
                                Value = stepSize
                            });

                            Debug.WriteLine($@"Started  EXEC {commandName} @Step={iStep}, @MaxRecords={stepSize}");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Int32 primaryPatternId = reader.GetInt32(5);
                                        Int32 parentPatternStepId = reader.GetInt32(9);
                                        String pattern = reader.GetString(8);

                                        patternRelationStepDetails.Add((primaryPatternId, parentPatternStepId, pattern));
                                    }
                                }
                            }

                            Debug.WriteLine($@"Result: {patternRelationStepDetails.Count}");

                        }
                        connection.Close();
                    }
                    if (patternRelationStepDetails.Count() > 0)
                    {
                        DoStep(iStep, patternRelationStepDetails.ToArray());
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public class NextStepInfo {
            public NextStepInfo(Int32 parentPatternId, Int32 parentPatternStepId, String relationship, String reverseRelationship, String connectedPattern)
            {
                this.ParentPatternId = parentPatternId;
                this.ParentPatternStepId = parentPatternStepId;
                this.Relationship = relationship;
                this.ReverseRelationship = reverseRelationship;
                this.ConnectedPattern = connectedPattern;
            }

            public Int32 ParentPatternId { get; set; }
            public Int32 ParentPatternStepId { get; set; }
            public String Relationship { get; set; }
            public String ReverseRelationship { get; set; }
            public String ConnectedPattern { get; set; }
        }

        static void DoStep(Int32 step, (Int32 PrimaryPatternId, Int32 ParentPatternStepId, String Pattern)[] nextStepPrimaries)
        {

            var nextSteps = new List<NextStepInfo>();
            var reverseSteps = new List<NextStepInfo>();

            for (var isd = 0; isd < nextStepPrimaries.Count(); isd++)
            {
                Console.WriteLine("\tStep {0} {1} of {2}", step, isd + 1, nextStepPrimaries.Count());

                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);
                Logic.SetCubeState(cubeStartingPoint, PatternLogic.FromDatabase(nextStepPrimaries[isd].Pattern));
                String normalizedPattern = PatternLogic.GetCubePattern(cubeStartingPoint);

                Parallel.For(1, 28, (Int32 iMove) => 
                {
                    CubeModel cubeClone = Logic.CloneCube(cubeStartingPoint);
                    MoveTypes moveType = (MoveTypes)iMove;
                    Logic.RunMove(cubeClone, moveType);

                    String cubeCloneRaw = PatternLogic.GetCubePattern(cubeClone);
                    String cubeClonedNormalized = PatternLogic.GetAllCubePatterns(cubeCloneRaw).OrderBy(x => x).First();

                    Int32 parentPatternId = nextStepPrimaries[isd].PrimaryPatternId;
                    Int32 parentPatternStepId = nextStepPrimaries[isd].ParentPatternStepId;
                    String connectedPattern = Logic.ToDatabase(cubeClonedNormalized);
                    String relationship = Logic.Convert(moveType);
                    String reverseRelationship = Logic.Convert(Logic.Reverse(moveType));

                    lock (nextSteps)
                    {
                        var nextStep = nextSteps.FirstOrDefault(x => x.ParentPatternId == parentPatternId && x.ConnectedPattern == connectedPattern);
                        if (nextStep == default)
                        {
                            nextSteps.Add(new NextStepInfo(parentPatternId, 
                                parentPatternStepId,
                                '|' + relationship + '|', 
                                '|' + reverseRelationship + '|',
                                connectedPattern));
                        }
                        else
                        {
                            nextStep.Relationship += relationship + '|';
                            nextStep.ReverseRelationship =  reverseRelationship + '|';
                        }
                    }
                    Console.WriteLine("\t\tMove {0}", iMove);
                });
            }

            var nextStepsInDatabaseFormat = new DataTable();
            nextStepsInDatabaseFormat.Columns.Add("ParentPatternId");
            nextStepsInDatabaseFormat.Columns.Add("ParentPatternStepId");
            nextStepsInDatabaseFormat.Columns.Add("Relationship");
            nextStepsInDatabaseFormat.Columns.Add("ReverseRelationship");
            nextStepsInDatabaseFormat.Columns.Add("ConnectedPattern");

            foreach (var nextStep in nextSteps)
            {
                DataRow row = nextStepsInDatabaseFormat.NewRow();

                row["ParentPatternId"] = nextStep.ParentPatternId;
                row["ParentPatternStepId"] = nextStep.ParentPatternStepId;
                row["Relationship"] = nextStep.Relationship;
                row["ReverseRelationship"] = nextStep.ReverseRelationship;
                row["ConnectedPattern"] = nextStep.ConnectedPattern;
                

                nextStepsInDatabaseFormat.Rows.Add(row);
            }

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.[PatternRelationStepUpsert]", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    cmd.Parameters.Add(new SqlParameter("@PatternTypeId", SqlDbType.Int)
                    {
                        Value = 1
                    });

                    cmd.Parameters.Add(new SqlParameter("@Step", SqlDbType.Int)
                    {
                        Value = step
                    });

                    cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                    {
                        TypeName = "dbo.[PrimaryPatternIdRelationToConnectedPatternType]",
                        Value = nextStepsInDatabaseFormat
                    });

                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //static void Step(Int32 iStep, Int32 parentPatternStepId, CubeModel cubeStartingPoint)
        //{
        //    XyzCubeTypes xyzCubeType = PatternLogic.GetXyzCubeType(cubeStartingPoint);

        //    Int32 startingPointPatternId;
        //    String cubeStartingPointNormalizedInDatabaseFormat = PatternLogic.ToDatabase(PatternLogic.GetCubePattern(cubeStartingPoint));

        //    using (Whatever WhateverThing = new Whatever())
        //    {
        //        Pattern startingPointScramblePattern = WhateverThing.Patterns.FirstOrDefault(x => x.PatternContent == cubeStartingPointNormalizedInDatabaseFormat);
        //        if (startingPointScramblePattern == default(Pattern))
        //        {
        //            try
        //            {
        //                startingPointScramblePattern = new Pattern()
        //                {
        //                    PatternContent = cubeStartingPointNormalizedInDatabaseFormat
        //                };
        //                startingPointScramblePattern = WhateverThing.Patterns.Add(startingPointScramblePattern);
        //                WhateverThing.SaveChanges();
        //            }
        //            catch
        //            {

        //            }
        //        }

        //        startingPointPatternId = startingPointScramblePattern.PatternId;

        //        try
        //        {
        //            AdjacentPatternRecognitionState adjacentPatternRecognitionState = WhateverThing.AdjacentPatternRecognitionStates.FirstOrDefault(x => x.PatternId == startingPointPatternId);
        //            if (adjacentPatternRecognitionState == default(AdjacentPatternRecognitionState))
        //            {
        //                (StickerColorTypes Color, PatternAdjacentTypes Pattern)[] adjacentPatterns = PatternRecognition.GetCubeAdjacentPatterns(cubeStartingPoint);

        //                IEnumerable<AdjacentPatternRecognitionState> adjacentPatternRecognitionStates = adjacentPatterns.Select(x => new AdjacentPatternRecognitionState()
        //                {
        //                    PatternAdjacentTypeId = (Int32)x.Pattern,
        //                    PatternId = startingPointPatternId,
        //                    Color = PatternLogic.ToDatabase(PatternLogic.GetStickerAbbreviation(xyzCubeType, x.Color))
        //                });
        //                WhateverThing.AdjacentPatternRecognitionStates.AddRange(adjacentPatternRecognitionStates);
        //                WhateverThing.SaveChanges();
        //            }

        //            FacePatternRecognitionState facePatternRecognitionState = WhateverThing.FacePatternRecognitionStates.FirstOrDefault(x => x.PatternId == startingPointPatternId);
        //            if (facePatternRecognitionState == default(FacePatternRecognitionState))
        //            {
        //                (StickerColorTypes Color, PatternFaceTypes Pattern)[] facePatterns = PatternRecognition.GetCubeFacePatterns(cubeStartingPoint);

        //                IEnumerable<FacePatternRecognitionState> facePatternRecognitionStates = facePatterns.Select(x => new FacePatternRecognitionState()
        //                {
        //                    PatternFaceTypeId = (Int32)x.Pattern,
        //                    PatternId = startingPointPatternId,
        //                    Color = PatternLogic.ToDatabase(PatternLogic.GetStickerAbbreviation(xyzCubeType, x.Color))

        //                });
        //                WhateverThing.FacePatternRecognitionStates.AddRange(facePatternRecognitionStates);
        //                WhateverThing.SaveChanges();
        //            }
        //        }
        //        catch
        //        {
        //            Console.WriteLine("Duplicate Pattern for {0}", startingPointPatternId);
        //        }


        //        Boolean isCanceled = false;
        //        Parallel.For(1, 28, (Int32 iReverse) =>
        //        {
        //            Int32 iMove = 28 - iReverse;
        //            if (!isCanceled)
        //            {
        //                CubeModel cubeClone = Logic.CloneCube(cubeStartingPoint);
        //                MoveTypes moveType = (MoveTypes)iMove;
        //                Logic.RunMove(cubeClone, moveType);

        //                String cubeCloneRaw = PatternLogic.GetCubePattern(cubeClone);
        //                String cubeClonetNormalized = PatternLogic.GetAllCubePatterns(cubeCloneRaw).OrderBy(x => x).First();

        //                if (!isCanceled)
        //                {
        //                    Int32 recordStepId = RecordStep(parentPatternStepId, startingPointPatternId, cubeClonetNormalized, moveType, iStep);
        //                    if (recordStepId == 0)
        //                    {
        //                        Console.WriteLine("Branch Ended {0} {1} ", iStep, parentPatternStepId);
        //                        isCanceled = true;
        //                    }
        //                }
        //            }
        //        });
        //    }
        //}


        //static void Check()
        //{
        //    Int32 countBadRecords = 0;
        //    Int32 countGoodRecords = 0;
        //    using (Whatever whateverThing = new Whatever())
        //    {
        //        Parallel.ForEach(whateverThing.wvw_PatternRelationDetails.OrderByDescending((x)=>x.PatternRelationId), (wvw_PatternRelationDetails patternRelationDetail) =>
        //        {
        //            CubeModel testCube = Logic.Create(XyzCubeTypes.BlueOrangeWhite);
        //            Logic.SetCubeState(testCube, Logic.FromDatabase(patternRelationDetail.PrimaryPattern));
        //            Logic.RunMove(testCube, Logic.Convert(patternRelationDetail.Relationship));

        //            String patternOfStepRaw = PatternLogic.ToDatabase(PatternLogic.GetCubePattern(testCube));

        //            if (patternOfStepRaw != patternRelationDetail.ConnectedPattern)
        //            {
        //                countBadRecords++;
        //            }
        //            else
        //            {
        //                countGoodRecords++;
        //            }

        //            Console.WriteLine("G: {0} B: {1} ID:{2}", countGoodRecords, countBadRecords, patternRelationDetail.PatternRelationId);
        //        });
        //    }

        //    if (countBadRecords > 0)
        //    {
        //        throw new Exception(String.Format("{0} Bad Records", countBadRecords));
        //    }
        //}

        static void Main(string[] args)
        {

            //var command = Console.ReadLine();
            //Check();
            //if (command.ToUpper() == "GO")
            //{

            for (var i = 1; i < 9; i++)
            {
                DoSteps(i);
            }

            //}
            //else if (command.ToUpper() == "GO")
            //{
            //FromAndTo();
            // }

            Console.WriteLine("Done");
            Console.ReadLine();

            //Console.WriteLine(patternRow.PatternId);

            //Console.ReadLine();

            //CubeLogic logic = new CubeLogic();
            //if (Cube == default(CubeModel))
            //{
            //    Cube = logic.Create(XyzCubeTypes.BlueOrangeWhite);
            //    Console.WriteLine(Cube.ToString());
            //    Load();

            //    //Logic.SetCubeState(Cube, Combinations.Last());

            //}

            //OutputCube(Cube);
            //foreach(var pattern in FindPatternsBasic(Cube))
            //{
            //    Console.WriteLine(pattern);
            //}

            //var command = Console.ReadLine();

            //if (command.ToUpper() == "PRINT")
            //{
            //    Console.WriteLine(PatternLogic.GetCubePattern(Cube));
            //}
            //else if (command.ToUpper() == "SCRAMBLE")
            //{
            //    logic.Scramble(Cube, 500);
            //}
            //else if (command.Length == 9 * 6)
            //{
            //    Logic.SetCubeState(Cube, command.Trim());
            //}
            //else if (command.ToUpper() == "TEST")
            //{
            //    RunTest();
            //}
            //else if (command.ToUpper() == "GO")
            //{
            //    GeneratePatternTypeStatistics();
            //    //GenerateStatistics();
            //}
            //else if (command.Trim().Length > 100)
            //{
            //    logic.SetDetailedCubeState(Cube, PatternLogic.GetCubePatternDetail(command));
            //}
            //else
            //{
            //    logic.RunMoves(Cube, command.ToUpper());
            //}


            Main(null);
        }

        // public static void Load()
        // {

        //     if (!File.Exists("UniqueCubePatterns.txt"))
        //     {
        //         using (var fs = File.Create("UniqueCubePatterns.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     if (!File.Exists("UniqueFacePatterns.txt"))
        //     {
        //         using (var fs = File.Create("UniqueFacePatterns.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     if (!File.Exists("UniqueAdjacentPatternTypes.txt"))
        //     {
        //         using (var fs = File.Create("UniqueAdjacentPatternTypes.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     if (!File.Exists("UniqueFacePatternTypes.txt"))
        //     {
        //         using (var fs = File.Create("UniqueFacePatternTypes.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     if (!File.Exists("UniqueAdjacentPatternTypes2.txt"))
        //     {
        //         using (var fs = File.Create("UniqueAdjacentPatternTypes2.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     if (!File.Exists("UniqueFacePatternTypes2.txt"))
        //     {
        //         using (var fs = File.Create("UniqueFacePatternTypes2.txt"))
        //         {
        //             Thread.Sleep(1000);
        //         }
        //     }

        //     UniqueCubePatterns = new CubePatternSegments();

        //     String[] uniqueCubePatternHitsRaw = File.ReadAllLines("UniqueCubePatterns.txt");
        //     if (uniqueCubePatternHitsRaw.Length > 0)
        //     {

        //         foreach (var uniqueCubePatternHitRaw in uniqueCubePatternHitsRaw)
        //         {
        //             String[] uniqueCubePatternHitRawArgs = uniqueCubePatternHitRaw.Split(' ');
        //             String key = uniqueCubePatternHitRawArgs[1];
        //             Int32 value1 = Int32.Parse(uniqueCubePatternHitRawArgs[0]);
        //             Int32 value2 = Int32.Parse(uniqueCubePatternHitRawArgs[2]);
        //             UniqueCubePatterns.GetOrAdd(key, (value2, value1));
        //         }

        //     }

        //     UniqueFacePatterns = new Dictionary<String, (Int32, Int32)>();
        //     String[] uniqueFacePatternsRaw = File.ReadAllLines("UniqueFacePatterns.txt");
        //     if (uniqueFacePatternsRaw.Length > 0)
        //     {

        //         foreach (var uniqueFacePatternRaw in uniqueFacePatternsRaw)
        //         {
        //             String[] uniqueFacePatternRawArgs = uniqueFacePatternRaw.Split(' ');
        //             String key = uniqueFacePatternRawArgs[1];
        //             Int32 value1 = Int32.Parse(uniqueFacePatternRawArgs[0]);
        //             Int32 value2 = Int32.Parse(uniqueFacePatternRawArgs[2]);
        //             UniqueFacePatterns.Add(key, (value2, value1));
        //         }

        //     }

        //     UniqueAdjacentPatternTypes = new Dictionary<PatternAdjacentTypes, Int32>();
        //     String[] uniqueAdjacentPatternTypesRaw = File.ReadAllLines("UniqueAdjacentPatternTypes.txt");
        //     if (uniqueAdjacentPatternTypesRaw.Length > 0)
        //     {
        //         foreach (var uniqueAdjacentPatternTypeRaw in uniqueAdjacentPatternTypesRaw)
        //         {
        //             String[] uniqueAdjacentPatternTypeRawArgs = uniqueAdjacentPatternTypeRaw.Split(' ');
        //             PatternAdjacentTypes key = (PatternAdjacentTypes)Enum.Parse(typeof(PatternAdjacentTypes), uniqueAdjacentPatternTypeRawArgs[1]);
        //             Int32 value = Int32.Parse(uniqueAdjacentPatternTypeRawArgs[0]);
        //             UniqueAdjacentPatternTypes.Add(key, value);
        //         }
        //     }

        //     UniqueFacePatternTypes = new Dictionary<PatternFaceTypes, Int32>();
        //     String[] uniqueFacePatternTypesRaw = File.ReadAllLines("UniqueFacePatternTypes.txt");
        //     if (uniqueFacePatternTypesRaw.Length > 0)
        //     {
        //         foreach (var uniqueFacePatternTypeRaw in uniqueFacePatternTypesRaw)
        //         {
        //             String[] uniqueFacePatternTypeRawArgs = uniqueFacePatternTypeRaw.Split(' ');
        //             PatternFaceTypes key = (PatternFaceTypes)Enum.Parse(typeof(PatternFaceTypes), uniqueFacePatternTypeRawArgs[1]);
        //             Int32 value = Int32.Parse(uniqueFacePatternTypeRawArgs[0]);
        //             UniqueFacePatternTypes.Add(key, value);
        //         }
        //     }
        // }

        // public static String Scamble(CubeModel cube)
        // {
        //     CubeModel result = Logic.CloneCube(cube);

        //     Logic.Scramble(result, 10);

        //     return PatternLogic.GetCubePattern(result);
        // }


        // public static void UpdateOrAddCubeStatistics(String pattern, Int32 variationCount, Int32 occurrences)
        // {
        //     lock (UniqueCubePatterns)
        //     {

        //         var result  = UniqueCubePatterns.GetOrAdd(pattern, (variationCount, 1));
        //         Console.WriteLine($"{result.Occurrences.ToString().PadLeft(5, '0')} {pattern} {result.Variations} ");
        //     }
        // }

        // public static void UpdateOrAddFaceStatistics(String pattern, Int32 variationCount, Int32 occurrences)
        // {
        //     lock (UniqueFacePatterns)
        //     {
        //         if (UniqueFacePatterns.ContainsKey(pattern))
        //         {
        //             var item = UniqueFacePatterns[pattern];
        //             UniqueFacePatterns[pattern] = (item.Item1, item.Item2 + occurrences);
        //         }
        //         else
        //         {
        //             UniqueFacePatterns.Add(pattern, (variationCount, 1));
        //         }
        //         Console.WriteLine($"{UniqueFacePatterns[pattern].Item2.ToString().PadLeft(5, '0')} {pattern} {UniqueFacePatterns[pattern].Item1} ");
        //     }
        //}

        // public static void UpdateCubeCount(Dictionary<String, (Int32, Int32)> cubePatterns, String pattern)
        // {
        //     Console.WriteLine($"{pattern} UpdateFaceCount");
        //     String[] cubePatternsVariations = PatternLogic.GetAllCubePatterns(pattern);
        //     Console.WriteLine($"{pattern}  {cubePatternsVariations.Count()} Variations");
        //     lock (cubePatterns)
        //     {
        //         String localMatch = cubePatterns.Keys.FirstOrDefault(x1 => cubePatternsVariations.Contains(x1));
        //         if (String.IsNullOrWhiteSpace(localMatch))
        //         {
        //             (String Pattern, Int32 Variations, Int32 Occurrences) mainMatch = UniqueCubePatterns.FirstOrDefault(x1 => cubePatternsVariations.Contains(x1.Pattern));
        //             if (mainMatch == default)
        //             {
        //                 cubePatterns.Add(pattern, (cubePatternsVariations.Count(), 1));
        //                 Console.WriteLine($"{pattern} ADDED");
        //             }
        //             else
        //             {
        //                 cubePatterns.Add(mainMatch.Pattern, (cubePatternsVariations.Count(), 1));
        //                 Console.WriteLine($"{mainMatch} ADDED");
        //             }
        //         }
        //         else
        //         {
        //             if (cubePatterns.ContainsKey(pattern))
        //             {
        //                 var existingRecord = cubePatterns[pattern];
        //                 cubePatterns[pattern] = (cubePatternsVariations.Count(), existingRecord.Item2 + 1);

        //                 Console.WriteLine($"{pattern} UPDATED");
        //             }
        //             else
        //             {
        //                 var existingRecord = cubePatterns[localMatch];
        //                 cubePatterns[localMatch] = (cubePatternsVariations.Count(), existingRecord.Item2 + 1);

        //                 Console.WriteLine($"{localMatch} UPDATED");
        //             }
        //         }
        //     }
        // }

        // public static void UpdateFaceCount(Dictionary<String, (Int32, Int32)> resultfacePatterns, String cubePattern)
        // {
        //     Console.WriteLine($"{cubePattern} UpdateFaceCount");

        //     String[] facePatterns = FacePatternLogic.GetCubeFacePatterns(cubePattern);

        //     for (var i2 = 0; i2 < facePatterns.Count(); i2++)
        //     {
        //         String facePattern = FacePatternLogic.Normalize(facePatterns[i2]);

        //         String[] facePatternVariations = FacePatternLogic.GetAllFacePatterns(facePattern);
        //         lock (resultfacePatterns)
        //         {
        //             String localMatch = resultfacePatterns.Keys.FirstOrDefault(x1 => facePatternVariations.Contains(x1));

        //             if (String.IsNullOrWhiteSpace(localMatch))
        //             {
        //                 String mainMatch = UniqueFacePatterns.Keys.FirstOrDefault(x1 => facePatternVariations.Contains(x1));
        //                 if (String.IsNullOrWhiteSpace(mainMatch))
        //                 {
        //                     resultfacePatterns.Add(facePattern, (facePatternVariations.Count(), 1));
        //                     Console.WriteLine($"{facePattern} ADDED");
        //                 }
        //                 else
        //                 {
        //                     resultfacePatterns.Add(mainMatch, (facePatternVariations.Count(), 1));
        //                     Console.WriteLine($"{mainMatch} ADDED");
        //                 }
        //             }
        //             else
        //             {
        //                 if (resultfacePatterns.ContainsKey(facePattern))
        //                 {
        //                     var existingRecord = resultfacePatterns[facePattern];
        //                     resultfacePatterns[facePattern] = (existingRecord.Item1, existingRecord.Item2 + 1);

        //                     Console.WriteLine($"{facePattern} UPDATED");
        //                 }
        //                 else
        //                 {
        //                     var existingRecord = resultfacePatterns[localMatch];
        //                     resultfacePatterns[localMatch] = (existingRecord.Item1, existingRecord.Item2 + 1);

        //                     Console.WriteLine($"{localMatch} UPDATED");
        //                 }
        //             }
        //         }
        //     }
        // }

        // public static void UpdatePatternTypeCount(Dictionary<PatternFaceTypes, Int32> resultFacePatterns, Dictionary<PatternAdjacentTypes, Int32> resultAdjacentPatterns, CubeModel cube)
        // {
        //     Console.WriteLine($"UpdateFacePatternCount");

        //     Dictionary<StickerColorTypes, PatternStatisticModel> patternsFound = PatternRecognition.GetSideCompleteness(cube);

        //     var colorTypes = new StickerColorTypes[]
        //     {
        //         StickerColorTypes.Blue,
        //         StickerColorTypes.Green,
        //         StickerColorTypes.Orange,
        //         StickerColorTypes.Red,
        //         StickerColorTypes.White,
        //         StickerColorTypes.Yellow
        //     };
        //     for (var i = 0; i < colorTypes.Length; i++)
        //     {
        //         for (var i2 = 0; i2 < patternsFound[colorTypes[i]].PatternFaceResults.Count(); i2++)
        //         {
        //             PatternFaceTypes currentPattern = patternsFound[colorTypes[i]].PatternFaceResults[i2].Pattern;
        //             lock (resultFacePatterns)
        //             {
        //                 if (resultFacePatterns.ContainsKey(patternsFound[colorTypes[i]].PatternFaceResults[i2].Pattern))
        //                 {
        //                     resultFacePatterns[currentPattern] += 1;
        //                 }
        //                 else
        //                 {
        //                     resultFacePatterns.Add(currentPattern, 1);
        //                 }
        //             }
        //         }

        //         for (var i2 = 0; i2 < patternsFound[colorTypes[i]].PatternAdjacentResults.Count(); i2++)
        //         {
        //             PatternAdjacentTypes currentPattern = patternsFound[colorTypes[i]].PatternAdjacentResults[i2].Pattern;
        //             lock (resultAdjacentPatterns)
        //             {
        //                 if (resultAdjacentPatterns.ContainsKey(currentPattern))
        //                 {
        //                     resultAdjacentPatterns[currentPattern] += 1;
        //                 }
        //                 else
        //                 {
        //                     resultAdjacentPatterns.Add(currentPattern, 1);
        //                 }
        //             }
        //         }
        //     }
        // }

        // public static void UpdateFacePatternStatistics(PatternFaceTypes pattern, Int32 occurrences)
        // {
        //     lock (UniqueFacePatternTypes)
        //     {
        //         if (UniqueFacePatternTypes.ContainsKey(pattern))
        //         {
        //             var item = UniqueFacePatternTypes[pattern];
        //             UniqueFacePatternTypes[pattern] = occurrences + item;
        //         }
        //         else
        //         {
        //             UniqueFacePatternTypes.Add(pattern, occurrences);
        //         }
        //         Console.WriteLine($"{UniqueFacePatternTypes[pattern].ToString().PadLeft(5, '0')} {pattern}");
        //     }
        // }

        // public static void UpdateAdjacentPatternStatistics(PatternAdjacentTypes pattern, Int32 occurrences)
        // {
        //     lock (UniqueAdjacentPatternTypes)
        //     {
        //         if (UniqueAdjacentPatternTypes.ContainsKey(pattern))
        //         {
        //             var item = UniqueAdjacentPatternTypes[pattern];
        //             UniqueAdjacentPatternTypes[pattern] = occurrences + item;
        //         }
        //         else
        //         {
        //             UniqueAdjacentPatternTypes.Add(pattern, occurrences);
        //         }
        //         Console.WriteLine($"{UniqueAdjacentPatternTypes[pattern].ToString().PadLeft(5, '0')} {pattern}");
        //     }
        // }

        // public static void RunTest()
        // {
        //     foreach (var item in UniqueCubePatterns)
        //     {
        //         var validPatterns = 0;
        //         String[] patterns = PatternLogic.GetAllCubePatterns(item.Pattern);
        //         foreach (var pattern in patterns)
        //         {
        //             try
        //             {
        //                 CubeModel cube = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
        //                 String cubePatternDetail = PatternLogic.GetCubePatternDetail(pattern);
        //                 Logic.SetDetailedCubeState(cube, cubePatternDetail);
        //                 validPatterns += 1;
        //             }
        //             catch (Exception ex)
        //             {
        //                 Console.WriteLine($"{pattern} {ex.Message}");
        //             }

        //             Console.WriteLine($"{pattern}");
        //         }
        //         Console.WriteLine($"{item} {validPatterns} of {patterns.Count() } are Valid {item}\n");
        //         Thread.Sleep(200);
        //     }
        // }

        // public static String[] FindPatternsBasic(CubeModel cube)
        // {
        //     var result = new List<String>();

        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Blue));
        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Green));
        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Orange));
        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Red));
        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.White));
        //     result.Add(DocumentPatternsStringBasic(cube, StickerColorTypes.Yellow));

        //     return result.ToArray();
        // }

        // public static String DocumentPatternsStringBasic(CubeModel cube, StickerColorTypes stickerColorType)
        // {
        //     String result = $"C:{stickerColorType}|F[";

        //     PatternStatisticModel patternStatistic = PatternRecognition.GetCompleteness(cube, stickerColorType);
        //     foreach (var patternFaceResult in patternStatistic.PatternFaceResults)
        //     {
        //         if (patternFaceResult.Pattern != PatternFaceTypes.None)
        //         {
        //             result += $"{patternFaceResult.MiddleColorType}:{patternFaceResult.Pattern},";
        //         }
        //     }

        //     result += "]|A:[";

        //     foreach (var patternAdjacentResult in patternStatistic.PatternAdjacentResults)
        //     {
        //         if (patternAdjacentResult.Pattern != PatternAdjacentTypes.None)
        //         {
        //             result += $"{patternAdjacentResult.MiddleColorTypeWest}{patternAdjacentResult.MiddleColorTypeEast}:{patternAdjacentResult.Pattern},";
        //         }
        //     }

        //     result += "]";

        //     return result.Replace(",]","]");
        // }


        // public static String[] FindPatterns(CubeModel cube)
        // {
        //     var result = new List<String>();

        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.Blue));
        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.Green));
        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.Orange));
        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.Red));
        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.White));
        //     result.Add(DocumentPatternsString(cube, StickerColorTypes.Yellow));

        //     return result.ToArray();
        // }

        // public static String DocumentPatternsString(CubeModel cube, StickerColorTypes stickerColorType)
        // {
        //     String result = $"C:{stickerColorType}|";

        //     PatternStatisticModel patternStatistic = PatternRecognition.GetCompleteness(cube, stickerColorType);
        //     foreach (var patternFaceResult in patternStatistic.PatternFaceResults)
        //     {
        //         if (patternFaceResult.Pattern != PatternFaceTypes.None)
        //         {
        //             result += $"[FM:{patternFaceResult.Middles}|" +
        //             $"FS:{patternFaceResult.Sides}|" +
        //             $"FC:{patternFaceResult.Corners}|" +
        //             $"FP:{patternFaceResult.Pattern }]";
        //         }
        //     }

        //     foreach (var patternAdjacentResult in patternStatistic.PatternAdjacentResults)
        //     {
        //         if (patternAdjacentResult.Pattern != PatternAdjacentTypes.None)
        //         {
        //             result += $"[AM:{patternAdjacentResult.Middles}|" +
        //             $"AS:{patternAdjacentResult.Sides}|" +
        //             $"AC:{patternAdjacentResult.Corners}|" +
        //             $"AP:{patternAdjacentResult.Pattern }]";
        //         }
        //     }

        //     return result;
        // }

        // public static void GeneratePatternTypeStatistics()
        // {
        //     Console.WriteLine("\n\n**************** START GeneratePatternTypeStatistics ****************\n\n");
        //     {
        //         var resultFacePatterns = new Dictionary<PatternFaceTypes, Int32>();
        //         var resultAdjacentPatterns = new Dictionary<PatternAdjacentTypes, Int32>();

        //         UpdatePatternTypeCount(resultFacePatterns, resultAdjacentPatterns, Cube);

        //         for (var i = 0; i < 400; i++)
        //         {
        //             UpdatePatternTypeCount(resultFacePatterns, resultAdjacentPatterns, Cube);
        //             Logic.Scramble(Cube, 4);
        //         }

        //         foreach (var result in resultFacePatterns)
        //         {
        //             UpdateFacePatternStatistics(result.Key, result.Value);
        //         }

        //         foreach (var result in resultAdjacentPatterns)
        //         {
        //             UpdateAdjacentPatternStatistics(result.Key, result.Value);
        //         }

        //         {
        //             List<String> facePatterns = UniqueFacePatternTypes.Select(x => x.Value.ToString().PadLeft(10, '0') + " " + x.Key).ToList();
        //             using (StreamWriter writer = new StreamWriter("UniqueFacePatternTypes.txt", false))
        //             {
        //                 foreach (var uniqueCubePatternHit in facePatterns.OrderByDescending(x => x, StringComparer.Ordinal))
        //                 {
        //                     writer.WriteLine(uniqueCubePatternHit);
        //                 }
        //             }
        //             facePatterns = null;
        //         }

        //         {
        //             List<String> adjacentPatterns = UniqueAdjacentPatternTypes.Select(x => x.Value.ToString().PadLeft(10, '0') + " " + x.Key).ToList();
        //             using (StreamWriter writer = new StreamWriter("UniqueAdjacentPatternTypes.txt", false))
        //             {
        //                 foreach (var uniqueCubePatternHit in adjacentPatterns.OrderByDescending(x => x, StringComparer.Ordinal))
        //                 {
        //                     writer.WriteLine(uniqueCubePatternHit);
        //                 }
        //             }
        //             adjacentPatterns = null;
        //         }

        //         {

        //             List<String> facePatterns2 = UniqueFacePatternTypes.Select(x => x.Key + " " + x.Value.ToString().PadLeft(10, '0')).ToList();
        //             using (StreamWriter writer = new StreamWriter("UniqueFacePatternTypes2.txt", false))
        //             {
        //                 foreach (var uniqueCubePatternHit in facePatterns2.OrderBy(x => x, StringComparer.Ordinal))
        //                 {
        //                     writer.WriteLine(uniqueCubePatternHit);
        //                 }
        //             }
        //             facePatterns2 = null;
        //         }

        //         {
        //             List<String> adjacentPatterns2 = UniqueAdjacentPatternTypes.Select(x => x.Key + " " + x.Value.ToString().PadLeft(10, '0')).ToList();
        //             using (StreamWriter writer = new StreamWriter("UniqueAdjacentPatternTypes2.txt", false))
        //             {
        //                 foreach (var uniqueCubePatternHit in adjacentPatterns2.OrderBy(x => x, StringComparer.Ordinal))
        //                 {
        //                     writer.WriteLine(uniqueCubePatternHit);
        //                 }
        //             }
        //             adjacentPatterns2 = null;
        //         }

        //         Console.WriteLine("\n\n**************** DONE GeneratePatternTypeStatistics ****************\n\n");
        //     }
        //     GeneratePatternTypeStatistics();
        // }

        // public static void GenerateStatistics()
        // {
        //     Console.WriteLine("\n\n**************** START ****************\n\n");
        //     {
        //         var cubeResults = new Dictionary<String, (Int32, Int32)>();
        //         var faceResults = new Dictionary<String, (Int32, Int32)>();


        //         String initalPattern = PatternLogic.GetCubePattern(Cube);

        //         UpdateCubeCount(cubeResults, initalPattern);
        //         UpdateFaceCount(faceResults, initalPattern);
        //         {
        //             var cubesPatterns = new List<String>();
        //             for (var i = 0; i < 100; i++)
        //             {
        //                 cubesPatterns.Add(Scamble(Cube));
        //             }
        //             Parallel.ForEach(cubesPatterns, (pattern) =>
        //             {
        //                 //try
        //                 //{

        //                     UpdateCubeCount(cubeResults, pattern);
        //                     UpdateFaceCount(faceResults, pattern);
        //                 //}
        //                 //catch (Exception e)
        //                 //{
        //                 //    Console.WriteLine(e.Message);
        //                 //}

        //                 Console.Write($"\n\t{cubeResults.Count()}\n");
        //             });
        //             cubesPatterns = null;

        //         }
        //         foreach (var result in cubeResults)
        //         {
        //             UpdateOrAddCubeStatistics(result.Key, result.Value.Item1, result.Value.Item2);
        //         }
        //         foreach (var result in faceResults)
        //         {
        //             UpdateOrAddFaceStatistics(result.Key, result.Value.Item1, result.Value.Item2);
        //         }

        //         cubeResults = null;
        //         faceResults = null;
        //     }

        //     Console.WriteLine("\n************************************************");
        //     Console.WriteLine("*********         Scrambling       *************");
        //     Console.WriteLine("************************************************\n");

        //     Logic.Scramble(Cube, 20);

        //     {
        //         List<String> list = UniqueCubePatterns.Select(x => x.Occurrences.ToString().PadLeft(5, '0') + " " + x.Pattern + " " + x.Variations).ToList();
        //         using (StreamWriter writer = new StreamWriter("UniqueCubePatterns.txt", false))
        //         {
        //             foreach (var uniqueCubePatternHit in list.OrderByDescending(x => x, StringComparer.Ordinal))
        //             {
        //                 writer.WriteLine(uniqueCubePatternHit);
        //             }
        //         }
        //         list = null;
        //     }

        //     {
        //         List<String> list = UniqueFacePatterns.Select(x => x.Value.Item2.ToString().PadLeft(5, '0') + " " + x.Key + " " + x.Value.Item1).ToList();
        //         using (StreamWriter writer = new StreamWriter("UniqueFacePatterns.txt", false))
        //         {
        //             foreach (var uniqueCubePatternHit in list.OrderByDescending(x => x, StringComparer.Ordinal))
        //             {
        //                 writer.WriteLine(uniqueCubePatternHit);
        //             }
        //         }
        //         list = null;
        //     }

        //     Console.WriteLine("\n\n**************** DONE ****************\n\n");
        //     GenerateStatistics();
        // }

        // public static void OutputAllCubeVariations()
        // {
        //     //foreach (CubeModel cube in Cubes)
        //     //{
        //     Console.Write("\n\n************************************************\n\n");

        //     var count = 1;
        //     String[] cubePatternsVariations = PatternLogic.GetAllCubePatterns(PatternLogic.GetCubePattern(Cube));
        //     foreach (String cubePatternsVariation in cubePatternsVariations)
        //     {
        //         //try
        //         //{
        //         CubeModel cube = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
        //         String cubePatternDetail = PatternLogic.GetCubePatternDetail(cubePatternsVariation);
        //         Logic.SetDetailedCubeState(cube, cubePatternDetail);
        //         OutputCube(cube);
        //         count++;
        //         //}
        //         //catch (Exception ex)
        //         //{
        //         //    //FIX:
        //         //    Console.Write($"\n        ERROR INVALID PATTERN: { cubePatternsVariation } \n");
        //         //}
        //     }

        //     Console.Write("\n\n********************* " + count + " **************************\n\n");
        //     //}
        // }

        // public static void OutputCube(CubeModel cube)
        // {

        //     Console.Write("\n\nNorth\n");

        //     OutputSticker("[BNW] ", cube.BackNorthWest.StickerNorth);
        //     OutputSticker("[BN]  ", cube.BackNorth.StickerNorth);
        //     OutputSticker("[BNE] ", cube.BackNorthEast.StickerNorth);

        //     Console.Write("\n");

        //     OutputSticker("[NW]  ", cube.NorthWest.StickerNorth);
        //     OutputSticker("[N]   ", cube.North.StickerNorth);
        //     OutputSticker("[NE]  ", cube.NorthEast.StickerNorth);

        //     Console.Write("\n");

        //     OutputSticker("[FNW] ", cube.FrontNorthWest.StickerNorth);
        //     OutputSticker("[FN]  ", cube.FrontNorth.StickerNorth);
        //     OutputSticker("[FNE] ", cube.FrontNorthEast.StickerNorth);


        //     Console.Write("\n\nWest\n");

        //     OutputSticker("[BNW] ", cube.BackNorthWest.StickerWest);
        //     OutputSticker("[NW]  ", cube.NorthWest.StickerWest);
        //     OutputSticker("[FNW] ", cube.FrontNorthWest.StickerWest);

        //     Console.Write("\n");

        //     OutputSticker("[BW]  ", cube.BackWest.StickerWest);
        //     OutputSticker("[W]   ", cube.West.StickerWest);
        //     OutputSticker("[FW]  ", cube.FrontWest.StickerWest);

        //     Console.Write("\n");

        //     OutputSticker("[BSW] ", cube.BackSouthWest.StickerWest);
        //     OutputSticker("[SW]  ", cube.SouthWest.StickerWest);
        //     OutputSticker("[FSW] ", cube.FrontSouthWest.StickerWest);


        //     Console.Write("\n\nFront\n");

        //     OutputSticker("[FNW] ", cube.FrontNorthWest.StickerFront);
        //     OutputSticker("[FN]  ", cube.FrontNorth.StickerFront);
        //     OutputSticker("[FNE] ", cube.FrontNorthEast.StickerFront);

        //     Console.Write("\n");

        //     OutputSticker("[FW]  ", cube.FrontWest.StickerFront);
        //     OutputSticker("[F]   ", cube.Front.StickerFront);
        //     OutputSticker("[FE]  ", cube.FrontEast.StickerFront);

        //     Console.Write("\n");

        //     OutputSticker("[FSW] ", cube.FrontSouthWest.StickerFront);
        //     OutputSticker("[FS]  ", cube.FrontSouth.StickerFront);
        //     OutputSticker("[FSE] ", cube.FrontSouthEast.StickerFront);


        //     Console.Write("\n\nEast\n");

        //     OutputSticker("[FNE] ", cube.FrontNorthEast.StickerEast);
        //     OutputSticker("[NE]  ", cube.NorthEast.StickerEast);
        //     OutputSticker("[BNE] ", cube.BackNorthEast.StickerEast);

        //     Console.Write("\n");

        //     OutputSticker("[FE]  ", cube.FrontEast.StickerEast);
        //     OutputSticker("[E]   ", cube.East.StickerEast);
        //     OutputSticker("[BE]  ", cube.BackEast.StickerEast);

        //     Console.Write("\n");

        //     OutputSticker("[FSE] ", cube.FrontSouthEast.StickerEast);
        //     OutputSticker("[SE]  ", cube.SouthEast.StickerEast);
        //     OutputSticker("[BSE] ", cube.BackSouthEast.StickerEast);


        //     Console.Write("\n\nSouth\n");

        //     OutputSticker("[FSW] ", cube.FrontSouthWest.StickerSouth);
        //     OutputSticker("[FS]  ", cube.FrontSouth.StickerSouth);
        //     OutputSticker("[FSE] ", cube.FrontSouthEast.StickerSouth);

        //     Console.Write("\n");

        //     OutputSticker("[SW]  ", cube.SouthWest.StickerSouth);
        //     OutputSticker("[S]   ", cube.South.StickerSouth);
        //     OutputSticker("[SE]  ", cube.SouthEast.StickerSouth);

        //     Console.Write("\n");

        //     OutputSticker("[BSW] ", cube.BackSouthWest.StickerSouth);
        //     OutputSticker("[BS]  ", cube.BackSouth.StickerSouth);
        //     OutputSticker("[BSE] ", cube.BackSouthEast.StickerSouth);


        //     Console.Write("\n\nBack\n");

        //     OutputSticker("[BNW] ", cube.BackNorthWest.StickerBack);
        //     OutputSticker("[BN]  ", cube.BackNorth.StickerBack);
        //     OutputSticker("[BNE] ", cube.BackNorthEast.StickerBack);

        //     Console.Write("\n");

        //     OutputSticker("[BW]  ", cube.BackWest.StickerBack);
        //     OutputSticker("[B]   ", cube.Back.StickerBack);
        //     OutputSticker("[BE]  ", cube.BackEast.StickerBack);

        //     Console.Write("\n");

        //     OutputSticker("[BSW] ", cube.BackSouthWest.StickerBack);
        //     OutputSticker("[BS]  ", cube.BackSouth.StickerBack);
        //     OutputSticker("[BSE] ", cube.BackSouthEast.StickerBack);

        //     Console.Write("\n");



        // }

        // public static void OutputSticker(String label, StickerModelBase sticker)
        // {
        //     Console.ForegroundColor = GetColor(sticker.StickerColorType);
        //     Console.Write(label);
        //     Console.ForegroundColor = ConsoleColor.Gray;
        // }

        // public static ConsoleColor GetColor(StickerColorTypes sticker)
        // {
        //     switch (sticker)
        //     {
        //         case StickerColorTypes.Blue:
        //             return ConsoleColor.Blue;
        //         case StickerColorTypes.Green:
        //             return ConsoleColor.Green;
        //         case StickerColorTypes.Orange:
        //             return ConsoleColor.DarkYellow;
        //         case StickerColorTypes.Red:
        //             return ConsoleColor.DarkRed;
        //         case StickerColorTypes.White:
        //             return ConsoleColor.White;
        //         case StickerColorTypes.Yellow:
        //             return ConsoleColor.Yellow;
        //     }

        //     return ConsoleColor.Gray;
        // }
    }
}
