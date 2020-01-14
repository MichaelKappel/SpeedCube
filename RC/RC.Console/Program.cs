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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using SqlServerTypes;

namespace RC
{
    class Program
    {

        public static Dictionary<String, Int32> FacePatternDictionary = new Dictionary<string, int>();
        public static String[] FacePatternArray = new String[1679617];

        public static Int32 PatternTypeId = 1;
        public static CubeLogic Logic = new CubeLogic();
        public static CubeFacePatternLogic FacePatternLogic = new CubeFacePatternLogic();
        public static CubePatternLogic PatternLogic = new CubePatternLogic();
        public static PatternRecognitionLogic PatternRecognition = new PatternRecognitionLogic();
        public static OrangeWhiteBlueLogic ExperimentalLogic = new OrangeWhiteBlueLogic();


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
        public static String  FromDatabase(PatternModel cSharpFormat)
        {
            String result = String.Empty;

            result += FacePatternArray[cSharpFormat.AFacePatternId].Insert(4, "A");
            result += FacePatternArray[cSharpFormat.BFacePatternId].Insert(4, "B");
            result += FacePatternArray[cSharpFormat.CFacePatternId].Insert(4, "C");
            result += FacePatternArray[cSharpFormat.XFacePatternId].Insert(4, "X");
            result += FacePatternArray[cSharpFormat.YFacePatternId].Insert(4, "Y");
            result += FacePatternArray[cSharpFormat.ZFacePatternId].Insert(4, "Z");

            return result;
        }

        public static PatternModel ToDatabase(String cSharpFormat)
        {
            if (cSharpFormat.Substring(4,1) != "A")
            {
                throw new Exception("Invalid Pattern");
            }
            else if(cSharpFormat.Substring(13, 1) != "B")
            {
                throw new Exception("Invalid Pattern");
            }
            else if (cSharpFormat.Substring(22, 1) != "C")
            {
                throw new Exception("Invalid Pattern");
            }
            else if (cSharpFormat.Substring(31, 1) != "X")
            {
                throw new Exception("Invalid Pattern");
            }
            else if (cSharpFormat.Substring(40, 1) != "Y")
            {
                throw new Exception("Invalid Pattern");
            }
            else if (cSharpFormat.Substring(49, 1) != "Z")
            {
                throw new Exception("Invalid Pattern");
            }

            var result = new PatternModel(
                FacePatternDictionary[cSharpFormat.Substring(0, 4) + cSharpFormat.Substring(5, 4)]
                , FacePatternDictionary[cSharpFormat.Substring(9, 4) + cSharpFormat.Substring(14, 4)]
                , FacePatternDictionary[cSharpFormat.Substring(18, 4) + cSharpFormat.Substring(23, 4)]
                , FacePatternDictionary[cSharpFormat.Substring(27, 4) + cSharpFormat.Substring(32, 4)]
                , FacePatternDictionary[cSharpFormat.Substring(36, 4) + cSharpFormat.Substring(41, 4)]
                , FacePatternDictionary[cSharpFormat.Substring(45, 4) + cSharpFormat.Substring(50, 4)]
                );

            return result;
        }

        public class PatternModel
        {
            public PatternModel(Int32 aFacePatternId, Int32 bFacePatternId, Int32 cFacePatternId, Int32 xFacePatternId, Int32 yFacePatternId, Int32 zFacePatternId)
            {
                this.AFacePatternId = aFacePatternId;
                this.BFacePatternId = bFacePatternId;
                this.CFacePatternId = cFacePatternId;
                this.XFacePatternId = xFacePatternId;
                this.YFacePatternId = yFacePatternId;
                this.ZFacePatternId = zFacePatternId;
            }

            public Int32 AFacePatternId {get; set;}
            public Int32 BFacePatternId {get; set;}
            public Int32 CFacePatternId {get; set;}
            public Int32 XFacePatternId {get; set;}
            public Int32 YFacePatternId {get; set;}
            public Int32 ZFacePatternId { get; set; }
        }
        public class DatabasePatternModel: PatternModel
        {
            public DatabasePatternModel(Int32 patternId, Int32 aFacePatternId, Int32 bFacePatternId, Int32 cFacePatternId, Int32 xFacePatternId, Int32 yFacePatternId, Int32 zFacePatternId)
                :base(aFacePatternId, bFacePatternId, cFacePatternId, xFacePatternId, yFacePatternId, zFacePatternId)
            {
                this.PatternId = patternId;
            }
            public Int32 PatternId { get; set; }
        }

        public class PatternHierarchyModel
        {
            public PatternHierarchyModel(SqlHierarchyId patternHierarchyHid, Int16 herarchyLevel,   String relationship, String primaryPattern,  Int32 primaryPatternId, String connectedPattern, Int32 connectedPatternId)
            {
                this.PatternHierarchyHid = patternHierarchyHid;
                this.HerarchyLevel = herarchyLevel;
                this.Relationship = relationship;
                this.PrimaryPattern = primaryPattern;
                this.PrimaryPatternId = primaryPatternId;
                this.ConnectedPattern = connectedPattern;
                this.ConnectedPatternId = connectedPatternId;
            }

            public SqlHierarchyId PatternHierarchyHid { get; protected set; }   
            public Int16 HerarchyLevel { get; protected set; }                  
            public String Relationship { get; protected set; }                  
            public String ConnectedPattern { get; protected set; }              
            public String PrimaryPattern { get; protected set; }                
            public Int32 PrimaryPatternId { get; protected set; }               
            public Int32 ConnectedPatternId { get; protected set; }             
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
                String commandName = "RBK.[wsp_SolutionGet]";
                using (SqlCommand cmd = new SqlCommand(commandName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;

                    {
                        PatternModel unsolvedNormalizedDatabase = ToDatabase(unsolvedNormalized);
                        cmd.Parameters.Add(new SqlParameter("@UnsolvedPattern", SqlDbType.VarChar, 59)
                        {
                            Value = unsolvedNormalizedDatabase
                        });

                        PatternModel solvedNormalizedDatabase = ToDatabase(solvedNormalized);
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
                                //String lessSolvedPattern = FromDatabase(reader.GetString(lessSolvedPatternOrdinal));
                                //String moreSolvedPatternContent = FromDatabase(reader.GetString(moreSolvedPatternOrdinal));

                                //results.Add(new SolutionMoveModel(step, lessSolvedPattern, moreSolvedPatternContent, relationships));
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
                var patternRelationStepDetails = new List<PatternHierarchyModel>();
                patternRelationStepDetails.Add(
                                          new PatternHierarchyModel(
                                               SqlHierarchyId.Parse(new System.Data.SqlTypes.SqlString("/1/")),
                                                (Int16)2,
                                                String.Empty,
                                                String.Empty,
                                                0,
                                                FromDatabase(new PatternModel(1, 335924, 671847, 1007770, 1343693, 1679616)),
                                                1));

                DoStep(patternRelationStepDetails.ToArray());

                return;
            }

            Int32 stepSize = 5000;
            while (true)
            {
                GC.Collect();
                var patternRelationStepDetails = new List<PatternHierarchyModel>();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                {
                    connection.Open();
                    String commandName = "[RBK].[wsp_PatternRelationHierarchiesRemainingDetailsGet]";
                    using (SqlCommand cmd = new SqlCommand(commandName, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@HierarchyLevel", SqlDbType.Int)
                        {
                            Value = iStep
                        });

                        cmd.Parameters.Add(new SqlParameter("@MaxRecords", SqlDbType.Int)
                        {
                            Value = stepSize
                        });

                        Console.WriteLine($@"Started  EXEC {commandName} @HierarchyLevel={iStep}, @MaxRecords={stepSize}");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Int32 patternHierarchyHidOrdinal = reader.GetOrdinal("PatternHierarchyHid");
                                Int32 herarchyLevelOrdinal = reader.GetOrdinal("HierarchyLevel");
                                Int32 relationshipOrdinal = reader.GetOrdinal("Relationship");
                                Int32 primaryPatternIdOrdinal = reader.GetOrdinal("PrimaryPatternId");
                                Int32 connectedPatternIdOrdinal = reader.GetOrdinal("ConnectedPatternId");
                                Int32 primaryAFacePatternIdOrdinal = reader.GetOrdinal("PrimaryAFacePatternId");
                                Int32 primaryBFacePatternIdOrdinal = reader.GetOrdinal("PrimaryBFacePatternId");
                                Int32 primaryCFacePatternIdOrdinal = reader.GetOrdinal("PrimaryCFacePatternId");
                                Int32 primaryXFacePatternIdOrdinal = reader.GetOrdinal("PrimaryXFacePatternId");
                                Int32 primaryYFacePatternIdOrdinal = reader.GetOrdinal("PrimaryYFacePatternId");
                                Int32 primaryZFacePatternIdOrdinal = reader.GetOrdinal("PrimaryZFacePatternId");
                                Int32 connectedAFacePatternIdOrdinal = reader.GetOrdinal("ConnectedAFacePatternId");
                                Int32 connectedBFacePatternIdOrdinal = reader.GetOrdinal("ConnectedBFacePatternId");
                                Int32 connectedCFacePatternIdOrdinal = reader.GetOrdinal("ConnectedCFacePatternId");
                                Int32 connectedXFacePatternIdOrdinal = reader.GetOrdinal("ConnectedXFacePatternId");
                                Int32 connectedYFacePatternIdOrdinal = reader.GetOrdinal("ConnectedYFacePatternId");
                                Int32 connectedZFacePatternIdOrdinal = reader.GetOrdinal("ConnectedZFacePatternId");


                                while (reader.Read())
                                {
                                    patternRelationStepDetails.Add(
                                        new PatternHierarchyModel(
                                             (SqlHierarchyId)reader.GetSqlValue(patternHierarchyHidOrdinal),
                                              reader.GetInt16(herarchyLevelOrdinal),
                                              reader.GetString(relationshipOrdinal),
                                              FromDatabase(new PatternModel(
                                                reader.GetInt32(primaryAFacePatternIdOrdinal),
                                                reader.GetInt32(primaryBFacePatternIdOrdinal),
                                                reader.GetInt32(primaryCFacePatternIdOrdinal),
                                                reader.GetInt32(primaryXFacePatternIdOrdinal),
                                                reader.GetInt32(primaryYFacePatternIdOrdinal),
                                                reader.GetInt32(primaryZFacePatternIdOrdinal)
                                                )),
                                                reader.GetInt32(primaryPatternIdOrdinal),
                                              FromDatabase(new PatternModel(
                                                reader.GetInt32(connectedAFacePatternIdOrdinal),
                                                reader.GetInt32(connectedBFacePatternIdOrdinal),
                                                reader.GetInt32(connectedCFacePatternIdOrdinal),
                                                reader.GetInt32(connectedXFacePatternIdOrdinal),
                                                reader.GetInt32(connectedYFacePatternIdOrdinal),
                                                reader.GetInt32(connectedZFacePatternIdOrdinal)
                                                )),
                                                reader.GetInt32(connectedPatternIdOrdinal)
                                              ));
                                }
                            }
                        }

                        Console.WriteLine($@"Result: {patternRelationStepDetails.Count}");

                    }
                    connection.Close();
                }
                if (patternRelationStepDetails.Count() > 0)
                {
                    DoStep(patternRelationStepDetails.ToArray());
                }
                else
                {
                    break;
                }

            }
        }

        public static void LoadFaces()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
            {
                connection.Open();
                String commandName = "[RBK].[wsp_FacePatternsGet]";
                using (SqlCommand cmd = new SqlCommand(commandName, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;


                    Console.WriteLine($@"Started  EXEC {commandName} ");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                FacePatternDictionary.Add(reader.GetString(1), reader.GetInt32(0));
                                FacePatternArray[reader.GetInt32(0)] = reader.GetString(1);
                            }
                        }
                    }

                    Console.WriteLine($@"Result: {FacePatternDictionary.Count}");

                }
                connection.Close();
            }
        }

        static void DoStep(PatternHierarchyModel[] nextStepPrimaries)
        {

            var nextSteps = new List<NextStepInfo>();

            for (Int32 isd = 0; isd < nextStepPrimaries.Count(); isd++)
            {
                Console.WriteLine("\tStep {0} {1} of {2}", nextStepPrimaries[0].HerarchyLevel, isd + 1, nextStepPrimaries.Count());

                CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);
                Logic.SetCubeState(cubeStartingPoint, nextStepPrimaries[isd].ConnectedPattern);
                String normalizedPattern = PatternLogic.GetCubePattern(cubeStartingPoint);

                Parallel.For(1, 28, (Int32 iMove) =>
                // for (var iMove = 1; iMove < 28; iMove++)
                {

                    CubeModel cubeClone = Logic.CloneCube(cubeStartingPoint);
                        MoveTypes moveType = (MoveTypes)iMove;
                        Logic.RunMove(cubeClone, moveType);

                        //Debug.Write("moveType:" + moveType);

                        String cubeCloneRaw = PatternLogic.GetCubePattern(cubeClone);
                        String cubeClonedNormalized = PatternLogic.GetFirstPatternAlphabetically(cubeCloneRaw);

                        String relationship = Logic.Convert(moveType);
                        String reverseRelationship = Logic.Convert(Logic.Reverse(moveType));

                        lock (nextSteps)
                        {
                            var nextStep = nextSteps.FirstOrDefault(x => x.PrimaryPatternId == nextStepPrimaries[isd].ConnectedPatternId && x.ConnectedPattern == cubeClonedNormalized);
                            if (nextStep == default)
                            {
                                SqlHierarchyId patternHierarchyHid = SqlHierarchyId.Parse($"{nextStepPrimaries[isd].PatternHierarchyHid}{iMove}/");
                                nextSteps.Add(new NextStepInfo(
                                    patternHierarchyHid,
                                    nextStepPrimaries[isd].ConnectedPatternId,
                                    '|' + relationship + '|',
                                    '|' + reverseRelationship + '|',
                                    cubeClonedNormalized));
                            }
                            else
                            {
                                nextStep.Relationship += relationship + '|';
                                nextStep.ReverseRelationship = '|' + reverseRelationship + nextStep.ReverseRelationship;
                            }
                        }
                        //Console.WriteLine("\t\tMove {0}", iMove);
                    }
                );
            }

            SaveStep(nextSteps);
        }
        public static void SaveStep(List<NextStepInfo> nextSteps)
        {
            try
            {

                var nextStepsInDatabaseFormat = new DataTable();
                nextStepsInDatabaseFormat.Columns.Add("PatternHierarchyHid");
                nextStepsInDatabaseFormat.Columns.Add("ParentPatternId");
                nextStepsInDatabaseFormat.Columns.Add("Relationship");
                nextStepsInDatabaseFormat.Columns.Add("ReverseRelationship");
                nextStepsInDatabaseFormat.Columns.Add("AFacePatternId");
                nextStepsInDatabaseFormat.Columns.Add("BFacePatternId");
                nextStepsInDatabaseFormat.Columns.Add("CFacePatternId");
                nextStepsInDatabaseFormat.Columns.Add("XFacePatternId");
                nextStepsInDatabaseFormat.Columns.Add("YFacePatternId");
                nextStepsInDatabaseFormat.Columns.Add("ZFacePatternId");

                foreach (var nextStep in nextSteps)
                {
                    DataRow row = nextStepsInDatabaseFormat.NewRow();
                    PatternModel connectedPattern = ToDatabase(nextStep.ConnectedPattern);

                    row["PatternHierarchyHid"] = nextStep.PatternHierarchyHid;
                    row["ParentPatternId"] = nextStep.PrimaryPatternId;
                    row["Relationship"] = nextStep.Relationship;
                    row["ReverseRelationship"] = nextStep.ReverseRelationship;
                    row["AFacePatternId"] = connectedPattern.AFacePatternId;
                    row["BFacePatternId"] = connectedPattern.BFacePatternId;
                    row["CFacePatternId"] = connectedPattern.CFacePatternId;
                    row["XFacePatternId"] = connectedPattern.XFacePatternId;
                    row["YFacePatternId"] = connectedPattern.YFacePatternId;
                    row["ZFacePatternId"] = connectedPattern.ZFacePatternId;

                    nextStepsInDatabaseFormat.Rows.Add(row);
                }

                if (nextStepsInDatabaseFormat.Rows.Count > 0)
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Whatever"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlCommand cmd = new SqlCommand("[RBK].[wsp_PatternRelationHierarchiesUpsert]", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;

                            cmd.Parameters.Add(new SqlParameter("@PatternTypeId", SqlDbType.Int)
                            {
                                Value = PatternTypeId
                            });

                            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                            {
                                TypeName = "[RBK].[PatternRelationHierarchyType]",
                                Value = nextStepsInDatabaseFormat
                            });

                            cmd.ExecuteNonQuery();
                        }
                        connection.Close();
                    }
                }
            }
            catch 
            {
                SaveStep(nextSteps);
            }
        }


        public class NextStepInfo
        {
            public NextStepInfo(SqlHierarchyId patternHierarchyHid, Int32 primaryPatternId, String relationship, String reverseRelationship, String connectedPattern)
            {
                this.PatternHierarchyHid = patternHierarchyHid;
                this.PrimaryPatternId = primaryPatternId;
                this.Relationship = relationship;
                this.ReverseRelationship = reverseRelationship;
                this.ConnectedPattern = connectedPattern;
            }

            public Int32 PrimaryPatternId { get; set; }
            public SqlHierarchyId PatternHierarchyHid { get; set; }
            public String Relationship { get; set; }
            public String ReverseRelationship { get; set; }
            public String ConnectedPattern { get; set; }
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

            CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);

            String sqlSelectCommand = "[RBK].[wsp_PatternsWithoutAdjacentRecognitionGet]";
            String sqlUpdateCommand = "[RBK].[wsp_PatternRecognitionAdjacentInsert]";
            Int32 pageSize = 100000;

           IList<DatabasePatternModel> patterns = FindPatternsWithoutPatternTypes(sqlSelectCommand, pageSize);

            Console.WriteLine($@"Started  EXEC {sqlUpdateCommand}  Rows:{patterns.Count}");

            var patternTypes = new DataTable();
            patternTypes.Columns.Add("PatternId");
            patternTypes.Columns.Add("PatternTypeId");
            patternTypes.Columns.Add("Color");

            Int32 count = 0;
            foreach (DatabasePatternModel pattern in patterns)
            {

                Logic.SetCubeState(cubeStartingPoint, FromDatabase(pattern));

                (StickerColorTypes Color, PatternAdjacentTypes PatternAdjacentType)[] typesForpattern = PatternRecognition.GetCubeAdjacentPatterns(cubeStartingPoint);
                foreach (var item in typesForpattern)
                {
                    DataRow row = patternTypes.NewRow();
                    row["PatternId"] = pattern.PatternId;
                    row["PatternTypeId"] = (Int32)item.PatternAdjacentType;
                    row["Color"] = Logic.GetStickerAbbreviation(item.Color);

                    patternTypes.Rows.Add(row);
                }

                if (count % 1000 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine($@" {count} of {pageSize}");
                }

                count++;
            }

            UpdatePatternRecognition(sqlUpdateCommand, patternTypes);
        }

        static void FindFacePatternTypes()
        {
            CubeModel cubeStartingPoint = Logic.Create(XyzCubeTypes.OrangeWhiteBlue);

            String sqlSelectCommand = "[RBK].[wsp_PatternsWithoutFaceRecognitionGet]";
            String sqlUpdateCommand = "[RBK].[wsp_PatternRecognitionFaceInsert]";
            Int32 pageSize = 100000;

            IList<DatabasePatternModel> patterns = FindPatternsWithoutPatternTypes(sqlSelectCommand, pageSize);

            Console.WriteLine($@"Started  EXEC {sqlUpdateCommand}  Rows:{patterns.Count}");

            var patternTypes = new DataTable();
            patternTypes.Columns.Add("PatternId");
            patternTypes.Columns.Add("PatternTypeId");
            patternTypes.Columns.Add("Color");

            Int32 count = 0;
            foreach (DatabasePatternModel pattern in patterns)
            {
                Logic.SetCubeState(cubeStartingPoint, FromDatabase(pattern));

                (StickerColorTypes Color, PatternFaceTypes PatternFaceType)[] typesForpattern = PatternRecognition.GetCubeFacePatterns(cubeStartingPoint);
                foreach (var item in typesForpattern)
                {
                    DataRow row = patternTypes.NewRow();
                    row["PatternId"] = pattern.PatternId;
                    row["PatternTypeId"] = (Int32)item.PatternFaceType;
                    row["Color"] = Logic.GetStickerAbbreviation(item.Color);

                    patternTypes.Rows.Add(row);
                }

                if (count % 1000 == 0)
                {
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.WriteLine($@" {count} of {pageSize}");
                }

                count++;
            }

            UpdatePatternRecognition(sqlUpdateCommand, patternTypes);
        }

        static void UpdatePatternRecognition(string sqlUpdateCommand, DataTable patternTypes)
        {

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
                            TypeName = "RBK.[PatternRecognitionStateType]",
                            Value = patternTypes
                        });

                        cmdUpdate.ExecuteNonQuery();
                    }

                    mergeConnection.Close();

                }
                catch (Exception ex)
                {

                    Console.WriteLine($@"ERROR  EXEC {sqlUpdateCommand}  {ex.Message} ");
                }
                finally
                {
                    mergeConnection.Close();
                }
            }

            Console.WriteLine($@"Completed  EXEC {sqlUpdateCommand}  Rows:{patternTypes.Rows.Count}");
        }

       static IList<DatabasePatternModel> FindPatternsWithoutPatternTypes(String sqlSelectCommand, Int32 pageSize)
       {
           var patterns = new List<DatabasePatternModel>();

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


                       using (SqlDataReader reader = cmd.ExecuteReader())
                       {
                           if (reader.HasRows)
                           {
                                Int32 patternIdOrdinal = reader.GetOrdinal("PatternId");
                                Int32 aFacePatternIdOrdinal = reader.GetOrdinal("AFacePatternId");
                                Int32 bFacePatternIdOrdinal = reader.GetOrdinal("BFacePatternId");
                                Int32 cFacePatternIdOrdinal = reader.GetOrdinal("CFacePatternId");
                                Int32 xFacePatternIdOrdinal = reader.GetOrdinal("XFacePatternId");
                                Int32 yFacePatternIdOrdinal = reader.GetOrdinal("YFacePatternId");
                                Int32 zFacePatternIdOrdinal = reader.GetOrdinal("ZFacePatternId");

                                while (reader.Read())
                                {
                                    patterns.Add(
                                        new DatabasePatternModel(
                                                reader.GetInt32(patternIdOrdinal),
                                                reader.GetInt32(aFacePatternIdOrdinal),
                                                reader.GetInt32(bFacePatternIdOrdinal),
                                                reader.GetInt32(cFacePatternIdOrdinal),
                                                reader.GetInt32(xFacePatternIdOrdinal),
                                                reader.GetInt32(yFacePatternIdOrdinal),
                                                reader.GetInt32(zFacePatternIdOrdinal)
                                                )
                                              );
                                }
                           }
                       }

                       Console.WriteLine($@"Completed EXEC {sqlSelectCommand} Result: {patterns.Count}");
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
           }
           return patterns;
       }

        static void Main(string[] args)
        {
            Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);

            var command = Console.ReadLine();
   
            if (command.ToUpper() == "GO")
            {
                LoadFaces();

                for (var i = 1; i < 100000; i++)
                {

                    //FindFacePatternTypes();
                    //FindAdjacentPatternTypes();
                    //
                    //GC.Collect();

                    DoSteps(i);
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

                    Cube = ExperimentalLogic.Create(Logic.GetXyzCubeType(Cube), sides.ToArray());
                }
                else if (command.Length == 54)
                {
                    Cube = ExperimentalLogic.Create(Logic.GetXyzCubeType(Cube), Regex.Split(command, "(.{9})").Where(x => !String.IsNullOrWhiteSpace(x)).ToArray());
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
