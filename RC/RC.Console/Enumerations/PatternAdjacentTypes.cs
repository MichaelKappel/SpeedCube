﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Enumerations
{
    public enum PatternAdjacentTypes
    {

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        None,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A1,

        ///  <summary>  
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A2,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A3,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A4,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B1,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B2,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B3,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        B4,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B5,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B6,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B7,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X O ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B8,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B9,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        B10,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B11,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B12,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C1,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C2,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        C3,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C4,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        C5,


        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C6,


        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C7,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C8,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C9,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        D1,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        D2,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D3,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D4,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D5,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D6,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D7,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D8,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D9

        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
    }
}
