using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models
{
    public class CubePatternSegments : IEnumerable<(String Pattern, Int32 Variations, Int32 Occurrences)>
    {
        internal Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>>> CubePatterns;

        public CubePatternSegments()
        {
            this.CubePatterns = new  Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>>>();


        }


        public (Int32 Variations, Int32 Occurrences) this[(String x, String xn, String y, String yn, String z, String zn)i]
        {
            get
            {
                Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>> xD;
                Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>> xnD;
                Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>> yD;
                Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>> ynD;
                Dictionary<String, (Int32 Variations, Int32 Occurrences)> zD;

                (Int32 Variations, Int32 Occurrences) result;
                if (this.CubePatterns.TryGetValue(i.x, out xD)
                    && this.CubePatterns[i.x].TryGetValue(i.xn, out xnD)
                    && this.CubePatterns[i.x][i.xn].TryGetValue(i.y, out yD)
                    && this.CubePatterns[i.x][i.xn][i.y].TryGetValue(i.yn, out ynD)
                    && this.CubePatterns[i.x][i.xn][i.y][i.yn].TryGetValue(i.z, out zD)
                    && this.CubePatterns[i.x][i.xn][i.y][i.yn][i.z].TryGetValue(i.z, out result))
                {
                    return result;
                }

                return default((Int32 Variations, Int32 Occurrences));
            }
        }

     
        public IEnumerator<(String Pattern, Int32 Variations, Int32 Occurrences)> GetEnumerator()
        {
            foreach (String x in this.CubePatterns.Keys)
            {
                foreach (String xn in  this.CubePatterns[x].Keys)
                {
                    foreach (String y in this.CubePatterns[x][xn].Keys)
                    {
                        foreach (String yn in this.CubePatterns[x][xn][y].Keys)
                        {
                            foreach (String z in this.CubePatterns[x][xn][y][yn].Keys)
                            {
                                foreach (String k in this.CubePatterns[x][xn][y][yn][z].Keys)
                                {
                                    var patternStats = this.CubePatterns[x][xn][y][yn][z][k];
                                    yield return ($"{x}{xn}{y}{yn}{z}{k}", patternStats.Variations, patternStats.Occurrences);
                                }
                            }
                        }
                    }
                }
            }
        }

        public (Int32 Variations, Int32 Occurrences) GetOrAdd(String pattern, (Int32 Variations, Int32 Occurrences) value)
        {
            String[] patternArgs = new String[6];
            for (var i = 0; i < 6; i++)
            {
                patternArgs[i] = pattern.Substring((i * 9),  9);
            }

            Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>> xnDictionary = null;
            Dictionary < String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>> yDictionary = null;
            Dictionary < String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>> ynDictionary = null;
            Dictionary < String,  Dictionary<String, (Int32 Variations, Int32 Occurrences)>> zDictionary = null;
            Dictionary<String, (Int32 Variations, Int32 Occurrences)> znDictionary = null;


            if (this.CubePatterns.TryGetValue(patternArgs[0], out xnDictionary))
            {
                if (xnDictionary.TryGetValue(patternArgs[1], out yDictionary))
                {
                    if (yDictionary.TryGetValue(patternArgs[2], out ynDictionary))
                    {
                        if (ynDictionary.TryGetValue(patternArgs[3], out zDictionary))
                        {
                            if (zDictionary.TryGetValue(patternArgs[4], out znDictionary))
                            {
                                (Int32 Variations, Int32 Occurrences) result;
                                if (znDictionary.TryGetValue(patternArgs[5], out result))
                                {
                                    result = (value.Variations, result.Occurrences + value.Occurrences);
                                    znDictionary[patternArgs[5]] = result;
                                    return result;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.CubePatterns.Add(patternArgs[0], new Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>>());
            }

            if (!this.CubePatterns[patternArgs[0]].ContainsKey(patternArgs[1]))
            {
                this.CubePatterns[patternArgs[0]].Add(patternArgs[1], new Dictionary<String, Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>>());
            }

            if (!this.CubePatterns[patternArgs[0]][patternArgs[1]].ContainsKey(patternArgs[2]))
            {
                this.CubePatterns[patternArgs[0]][patternArgs[1]].Add(patternArgs[2], new Dictionary<String, Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>>());
            }

            if (!this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]].ContainsKey(patternArgs[3]))
            {
                this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]].Add(patternArgs[3], new Dictionary<String, Dictionary<String, (Int32 Variations, Int32 Occurrences)>>());
            }

            if (!this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]][patternArgs[3]].ContainsKey(patternArgs[4]))
            {
                this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]][patternArgs[3]].Add(patternArgs[4], new Dictionary<String, (Int32 Variations, Int32 Occurrences)>());
            }

            if (!this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]][patternArgs[3]][patternArgs[4]].ContainsKey(patternArgs[5]))
            {
                this.CubePatterns[patternArgs[0]][patternArgs[1]][patternArgs[2]][patternArgs[3]][patternArgs[4]].Add(patternArgs[5],(value.Variations, value.Occurrences));
            }

            return (value.Variations, value.Occurrences);
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
