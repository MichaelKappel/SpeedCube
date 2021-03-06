﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Common.Enumerations;

namespace RC.Common.Model.Patterns
{
    public abstract class PatternResultModelBase<T>
    {
        public Int32 Stickers { get; set; }
        public Int32 Corners { get; set; }
        public Int32 Sides { get; set; }
        public Int32 Middles { get; set; }

        public T Pattern { get; set; }

        public override string ToString()
        {
            return this.Pattern.ToString();
        }
    }
}
