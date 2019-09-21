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

        static void DoPatterns()
        {
            String sqlCommand = "[dbo].[wsp_PatternsGet]";
            Int32 pageSize = 100;


            Parallel.For(1, 238900, (Int32 pageNumber) =>
            {
                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.BlueOrangeWhite);

                var patterns = new List<(Int32 PatternId, String PatternContent)>(pageSize);

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)
                        {
                            Value = pageSize
                        });

                        cmd.Parameters.Add(new SqlParameter("@PageNumber", SqlDbType.Int)
                        {
                            Value = pageNumber
                        });

                        Debug.WriteLine($@"Started  EXEC {sqlCommand} @PageSize={pageSize}, @PageNumber={pageNumber}");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Int32 patternId = reader.GetInt32(0);
                                    String pattern = PatternLogic.FromDatabase(reader.GetString(1));

                                    patterns.Add((patternId, pattern));
                                }
                            }
                        }
                        Debug.WriteLine($@"Result: {patterns.Count}");
                    }

                    connection.Close();

                    var adjacentPatternTypes = new DataTable();
                    adjacentPatternTypes.Columns.Add("PatternId");
                    adjacentPatternTypes.Columns.Add("PatternTypeId");
                    adjacentPatternTypes.Columns.Add("Color");

                    var facePatternTypes = new DataTable();
                    facePatternTypes.Columns.Add("PatternId");
                    facePatternTypes.Columns.Add("PatternTypeId");
                    facePatternTypes.Columns.Add("Color");

                    foreach (var pattern in patterns) {

                        Logic.SetCubeState(cubeStartingPoint, pattern.PatternContent);

                        (StickerColorTypes Color, PatternAdjacentTypes PatternAdjacentType)[] adjacentPatterns = PatternRecognition.GetCubeAdjacentPatterns(cubeStartingPoint);
                        foreach(var item in adjacentPatterns)
                        {
                            DataRow row = adjacentPatternTypes.NewRow();
                            row["PatternId"] = pattern.PatternId;
                            row["PatternTypeId"] = (Int32)item.PatternAdjacentType;
                            row["Color"] = Logic.GetStickerAbbreviation(item.Color);

                            adjacentPatternTypes.Rows.Add(row);
                        }

                        (StickerColorTypes Color, PatternFaceTypes PatternFaceType)[] facePatterns = PatternRecognition.GetCubeFacePatterns(cubeStartingPoint);
                        foreach (var item in facePatterns)
                        {
                            DataRow row = facePatternTypes.NewRow();
                            row["PatternId"] = pattern.PatternId;
                            row["PatternTypeId"] = (Int32)item.PatternFaceType;
                            row["Color"] = Logic.GetStickerAbbreviation(item.Color);

                            facePatternTypes.Rows.Add(row);
                        }
                    }


                    connection.Open();
                    using (SqlCommand cmdUpsert = new SqlCommand("[dbo].[wsp_PatternRecognitionAdjacentUpsert]", connection))
                    {
                        cmdUpsert.CommandType = CommandType.StoredProcedure;
                        cmdUpsert.CommandTimeout = 0;

                        cmdUpsert.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                        {
                            TypeName = "dbo.[PatternRecognitionStateType]",
                            Value = adjacentPatternTypes
                        });

                        cmdUpsert.ExecuteNonQuery();
                    }

                    using (SqlCommand cmdUpsert = new SqlCommand("[dbo].[wsp_PatternRecognitionFaceUpsert]", connection))
                    {
                        cmdUpsert.CommandType = CommandType.StoredProcedure;
                        cmdUpsert.CommandTimeout = 0;

                        cmdUpsert.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                        {
                            TypeName = "dbo.[PatternRecognitionStateType]",
                            Value = facePatternTypes
                        });

                        cmdUpsert.ExecuteNonQuery();
                    }


                    connection.Close();
                }

            });
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

            DoPatterns();

            Console.WriteLine("Done");
            Console.ReadLine();

            Main(null);
        }

    
    }
}
