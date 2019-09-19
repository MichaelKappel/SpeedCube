using RC.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Model.Patterns
{
    public class PatternFaceBitModel
    {
        public PatternFaceBitModel(PatternFaceTypes patternFaceType,
            Boolean t52, Boolean t60, Boolean t07,
            Boolean t45, Boolean t00, Boolean t15,
            Boolean t37, Boolean t30, Boolean t22)
        {
            this.PatternFaceType = patternFaceType;
            this.T52 = t52;
            this.T60 = t60;
            this.T07 = t07;
            this.T45 = t45;
            this.T00 = t00;
            this.T15 = t15;
            this.T37 = t37;
            this.T30 = t30;
            this.T22 = t22;
        }
        public PatternFaceTypes PatternFaceType { get; set; }
        public Boolean T52 { get; set; }
        public Boolean T60 { get; set; }
        public Boolean T07 { get; set; }
        public Boolean T45 { get; set; }
        public Boolean T00 { get; set; }
        public Boolean T15 { get; set; }
        public Boolean T37 { get; set; }
        public Boolean T30 { get; set; }
        public Boolean T22 { get; set; }

        public override string ToString()
        {
            return $@"{this.PatternFaceType}
                 52:[{this.AsXO(this.T52)} 60:{this.AsXO(this.T60)} 07:{this.AsXO(this.T07)}]
                 45:[{this.AsXO(this.T45)} 00:{this.AsXO(this.T00)} 15:{this.AsXO(this.T15)}]
                 37:[{this.AsXO(this.T37)} 30:{this.AsXO(this.T30)} 22:{this.AsXO(this.T22)}]
            ";
        }

        protected Char AsXO(Boolean arg)
        {
            return (arg) ? 'O' : 'X';
        }
    }
}
