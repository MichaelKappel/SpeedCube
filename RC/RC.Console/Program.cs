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
            CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);

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

            //var command = Console.ReadLine();
            //Check();
            //if (command.ToUpper() == "GO")
            //{

            //for (var i = 1; i < 9; i++)
            //{
            //    DoSteps(i);
            //}


            for (var i = 0; i < 100000; i++)
            {
                FindFacePatternTypes();
                FindAdjacentPatternTypes();

                GC.Collect();
            }

            Console.WriteLine("Done");
            Console.ReadLine();

            Main(null);
        }


    }
}
