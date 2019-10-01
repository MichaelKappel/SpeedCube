using RC.Common.Enumerations;
using RC.Common.Model;
using RC.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace RC
{
    class Program
    {
        public static CubeLogic Logic = new CubeLogic();
        public static CubeFacePatternLogic FacePatternLogic = new CubeFacePatternLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static PatternRecognitionLogic PatternRecognition = new PatternRecognitionLogic();


        public static CubeModel Cube = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);

        [DebuggerDisplay("{MoveOrder} {PatternFrom} {PatternTo}", Name = "{MoveOptions}")]
        public class SolutionMoveModel
        {
            public SolutionMoveModel(Int32 moveOrder, String lessSolvedPattern, String moreSolvedPattern, MoveTypes[] moveOptions)
            {
                this.MoveOrder = moveOrder;
                this.LessSolvedPattern = lessSolvedPattern;
                this.MoreSolvedPattern = moreSolvedPattern;
                this.MoveOptions = moveOptions;
            }

            public Int32 MoveOrder
            {
                get;
                set;
            }

            public String LessSolvedPattern
            {
                get;
                set;
            }

            public String MoreSolvedPattern
            {
                get;
                set;
            }


            public MoveTypes[] MoveOptions
            {
                get;
                set;
            }
        }

        public static MoveTypes[] GetRelationships(String rawRelationships) {
            var result = new  List<MoveTypes>();
            
            if (rawRelationships.Contains("|"))
            {
                String[] relationshipFromDbs =  rawRelationships.Split('|');
                foreach (var relationshipFromDb in relationshipFromDbs)
                {
                    if (!String.IsNullOrEmpty(relationshipFromDb))
                    {
                        result.Add(Logic.Convert(relationshipFromDb));
                    }
                }
            }

            return result.ToArray();
        }

        public static SolutionMoveModel[] FindSolution(CubeModel unsolved, CubeModel solved)
        {
            String unsolvedNormalized = PatternLogic.GetFirstPatternAlphabetically(PatternLogic.GetCubePattern(unsolved));
            String solvedNormalized = PatternLogic.GetFirstPatternAlphabetically(PatternLogic.GetCubePattern(solved));


            var results = new List<SolutionMoveModel>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
            {
                connection.Open();
                String commandName = "dbo.[wsp_SolutionGet]";
                using (SqlCommand cmd = new SqlCommand(commandName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    {
                        String unsolvedNormalizedDatabase = Logic.ToDatabase(unsolvedNormalized);
                        cmd.Parameters.Add(new SqlParameter("@UnsolvedPattern", SqlDbType.VarChar, 59)
                        {
                            Value = unsolvedNormalizedDatabase
                        });

                        String solvedNormalizedDatabase = Logic.ToDatabase(solvedNormalized);
                        cmd.Parameters.Add(new SqlParameter("@SolvedPattern", SqlDbType.VarChar, 59)
                        {
                            Value = solvedNormalizedDatabase
                        });

                        Console.WriteLine($@"Started  EXEC {commandName} @UnsolvedPattern='{unsolvedNormalizedDatabase}', @SolvedPattern='{solvedNormalizedDatabase}'");
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            Int32 stepOrdinal = reader.GetOrdinal("Step");
                            Int32 relationshipOrdinal = reader.GetOrdinal("Relationship");
                            Int32 lessSolvedPatternOrdinal = reader.GetOrdinal("ConnectedPattern");
                            Int32 moreSolvedPatternOrdinal = reader.GetOrdinal("PrimaryPattern");

                            while (reader.Read())
                            {
                                Int32 step = reader.GetInt32(stepOrdinal);
                                MoveTypes[] relationships = GetRelationships(reader.GetString(relationshipOrdinal));
                                String lessSolvedPattern = Logic.FromDatabase(reader.GetString(lessSolvedPatternOrdinal));
                                String moreSolvedPatternContent = Logic.FromDatabase(reader.GetString(moreSolvedPatternOrdinal));

                                results.Add(new SolutionMoveModel(step, lessSolvedPattern, moreSolvedPatternContent, relationships));
                            }
                        }
                    }
                }
                connection.Close();
            }

            Console.WriteLine($@"Result: {results.Count}");


            return results.ToArray();
        }


        static void DoSteps(Int32 iStep)
        {
            if (iStep == 1)
            {
                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
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

                            Console.WriteLine($@"Started  EXEC {commandName} @Step={iStep}, @MaxRecords={stepSize}");

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

                            Console.WriteLine($@"Result: {patternRelationStepDetails.Count}");

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

        public class NextStepInfo
        {
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

                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
                Logic.SetCubeState(cubeStartingPoint, PatternLogic.FromDatabase(nextStepPrimaries[isd].Pattern));
                String normalizedPattern = PatternLogic.GetCubePattern(cubeStartingPoint);

                Parallel.For(1, 28, (Int32 iMove) =>
                {
                    CubeModel cubeClone = Logic.CloneCube(cubeStartingPoint);
                    MoveTypes moveType = (MoveTypes)iMove;
                    Logic.RunMove(cubeClone, moveType);

                    String cubeCloneRaw = PatternLogic.GetCubePattern(cubeClone);
                    String cubeClonedNormalized = PatternLogic.GetFirstPatternAlphabetically(cubeCloneRaw);

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
                            nextStep.ReverseRelationship = reverseRelationship + '|';
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

            if (nextStepsInDatabaseFormat.Rows.Count > 0)
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("[dbo].[wsp_PatternRelationStepUpsert]", connection))
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
        }

        private static RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

        static Int32 RandomInteger(Int32 min, Int32 max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                Rand.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) *
                (scale / (double)uint.MaxValue));
        }

        static void FindAdjacentPatternTypes()
        {
            String sqlSelectCommand = "[dbo].[wsp_PatternsWithoutAdjacentRecognitionGet]";
            String sqlUpdateCommand = "[dbo].[wsp_PatternRecognitionAdjacentInsert]";
            Int32 pageSize = 1000000;

            FindPatternTypes(sqlSelectCommand, sqlUpdateCommand, pageSize);
        }

        static void FindFacePatternTypes()
        {
            String sqlSelectCommand = "[dbo].[wsp_PatternsWithoutFaceRecognitionGet]";
            String sqlUpdateCommand = "[dbo].[wsp_PatternRecognitionFaceInsert]";
            Int32 pageSize = 200000;

            FindPatternTypes(sqlSelectCommand, sqlUpdateCommand, pageSize);
        }

        static void FindPatternTypes(String sqlSelectCommand, String sqlUpdateCommand, Int32 pageSize)
        {
            CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);

            var patternTypes = new DataTable();
            patternTypes.Columns.Add("PatternId");
            patternTypes.Columns.Add("PatternTypeId");
            patternTypes.Columns.Add("Color");

            using (SqlConnection queryConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
            {
                try
                {
                    queryConnection.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlSelectCommand, queryConnection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)
                        {
                            Value = pageSize
                        });

                        Console.WriteLine($@"Started  EXEC {sqlSelectCommand} @PageSize={pageSize}");

                        Int32 count = 0;
                        int top = Console.CursorTop;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {

                                    Logic.SetCubeState(cubeStartingPoint, PatternLogic.FromDatabase(reader.GetString(1)));

                                    (StickerColorTypes Color, PatternFaceTypes PatternFaceType)[] typesForpattern = PatternRecognition.GetCubeFacePatterns(cubeStartingPoint);
                                    foreach (var item in typesForpattern)
                                    {
                                        DataRow row = patternTypes.NewRow();
                                        row["PatternId"] = reader.GetInt32(0);
                                        row["PatternTypeId"] = (Int32)item.PatternFaceType;
                                        row["Color"] = Logic.GetStickerAbbreviation(item.Color);

                                        patternTypes.Rows.Add(row);
                                    }

                                    if (count % 1000 == 0)
                                    {
                                        Console.SetCursorPosition(0, top);
                                        Console.WriteLine($@" {count} of {pageSize}");
                                    }

                                    count++;
                                }
                            }
                        }

                        Console.WriteLine($@"Completed EXEC {sqlSelectCommand} Result: {patternTypes.Rows.Count}");
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine($@"Query ERROR EXEC {sqlSelectCommand} @PageSize={pageSize} {ex.Message} ");
                }
                finally
                {
                    queryConnection.Close();
                }

                Console.WriteLine($@"Started  EXEC {sqlUpdateCommand}  Rows:{patternTypes.Rows.Count}");

                using (SqlConnection mergeConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                {
                    try
                    {
                        mergeConnection.Open();

                        using (SqlCommand cmdUpdate = new SqlCommand(sqlUpdateCommand, mergeConnection))
                        {
                            cmdUpdate.CommandType = CommandType.StoredProcedure;
                            cmdUpdate.CommandTimeout = 0;

                            cmdUpdate.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                            {
                                TypeName = "dbo.[PatternRecognitionStateType]",
                                Value = patternTypes
                            });

                            cmdUpdate.ExecuteNonQuery();
                        }

                        mergeConnection.Close();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($@"ERROR  EXEC {sqlUpdateCommand} @PageSize={pageSize} {ex.Message} ");
                    }
                    finally
                    {
                        mergeConnection.Close();
                    }
                }

                Console.WriteLine($@"Completed  EXEC {sqlUpdateCommand}  Rows:{patternTypes.Rows.Count}");
            }
        }

        static void Main(string[] args)
        {

            var command = Console.ReadLine();
   
            if (command.ToUpper() == "GO")
            {

                for (var i = 1; i <= 9; i++)
                {
                    DoSteps(i);
                }


                for (var i = 0; i < 100000; i++)
                {
                    FindFacePatternTypes();
                    FindAdjacentPatternTypes();

                    GC.Collect();
                }
            }
            else
            {

                if (command.Length == 9)
                {
                    var sides = new List<String>();

                    String sidePattern = " [1] [2] [3] \n [4] [5] [6] \n [7] [8] [9]";
                    String side = command.ToUpper();

                    while (!String.IsNullOrEmpty(side))
                    {
                        sides.Add(side);
                        Console.WriteLine(sidePattern);
                        side = Console.ReadLine().ToUpper();
                    }

                    Logic.SetCubeState(Cube, sides.ToArray());
                }
                else if (command.Length == 54)
                {
                    Logic.SetCubeState(Cube, Logic.FromDatabase(command));
                }


                OutputCube(Cube);

                Console.WriteLine(PatternLogic.GetCubePattern(Cube));

                SolutionMoveModel[] moves = FindSolution(Cube, Logic.Create(Logic.GetXyzCubeType(Cube)));
                if (moves.Count() > 0)
                {
                    foreach (var move in moves)
                    {
                        Console.WriteLine("{0} => {1} {2}", move.LessSolvedPattern, move.MoreSolvedPattern, String.Join(" or ", move.MoveOptions));
                    }
                }
                else
                {
                    Console.WriteLine("Unknown Pattern");
                }

                //Logic.Scramble(Cube, 1);
                
                //SolutionMoveModel[] moves = FindSolution(Cube, Logic.Create(Logic.GetXyzCubeType(Cube)));

                //foreach (var move in moves) 
                //{
                //    Console.WriteLine(move.MoveOptions);
                //}

                //Console.WriteLine(PatternLogic.GetCubePattern(Cube));

                //Logic.Scramble(Cube, 1);

                //SolutionMoveModel[] moves2 = FindSolution(Cube, Logic.Create(Logic.GetXyzCubeType(Cube)));

                //foreach (var move in moves2)
                //{
                //    Console.WriteLine(move.MoveOptions);
                //}
            }

            Console.WriteLine("Done");
            Console.ReadLine();

            Main(null);
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
                    return ConsoleColor.Magenta;
                case StickerColorTypes.Red:
                    return ConsoleColor.Red;
                case StickerColorTypes.White:
                    return ConsoleColor.White;
                case StickerColorTypes.Yellow:
                    return ConsoleColor.Yellow;
            }

            return ConsoleColor.Gray;
        }
    }
}
