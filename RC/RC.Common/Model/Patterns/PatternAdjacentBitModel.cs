using RC.Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Common.Model.Patterns
{
    public class PatternAdjacentBitModel
    {
        public PatternAdjacentBitModel(PatternAdjacentTypes patternAdjacentType,
            /*                                      */Boolean n,
            /*                                 */Boolean nw, Boolean ne,
            /*                      */Boolean wm, Boolean w, Boolean e, Boolean em,
            /*                                  */Boolean sw, Boolean se,
            /*                                         */Boolean s)
        {
            this.PatternAdjacentType = patternAdjacentType;
            this.N = n;
            this.NW = nw;
            this.NE = ne;
            this.WM = wm;
            this.W = w;
            this.E = e;
            this.EM = em;
            this.SW = sw;
            this.SE = se;
            this.S = s;
        }
        public PatternAdjacentTypes PatternAdjacentType { get; set; }
        public Boolean N { get; set; }
        public Boolean NW { get; set; }
        public Boolean NE { get; set; }
        public Boolean WM { get; set; }
        public Boolean W { get; set; }
        public Boolean E { get; set; }
        public Boolean EM { get; set; }
        public Boolean SW { get; set; }
        public Boolean SE { get; set; }
        public Boolean S { get; set; }

        public override string ToString()
        {
            return $@"{this.PatternAdjacentType}
                        N:{this.AsXO(this.N)}
                    NW:{this.AsXO(this.NW)} | NE:{this.AsXO(this.NE)}
               WM:{this.AsXO(this.WM)} W:{this.AsXO(this.W)} | E:{this.AsXO(this.E)} EM:{this.AsXO(this.EM)}
                    SW:{this.AsXO(this.SW)} | SE:{this.AsXO(this.SE)}
                        S:{this.AsXO(this.S)}";
        }

        protected Char AsXO(Boolean arg)
        {
            return (arg) ? 'O' : 'X';
        }
    }
}
