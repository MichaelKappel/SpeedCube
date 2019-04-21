using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Enumerations
{


    public enum PatternFaceTypes
    {
        /// <summary>
        /// | X X X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        None,

        /// <summary>
        /// | X X X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        A1,

        /// <summary>
        /// | O X X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        A2,

        /// <summary>
        /// | X O X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        A3,

        /// <summary>
        /// | O X X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        B1,

        /// <summary>
        /// | X O X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        B2,

        /// <summary>
        /// | X O X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        B3,

        /// <summary>
        /// | X O X |
        /// | X X X |
        /// | X O X |
        /// </summary>
        B4,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | X X X |
        /// </summary>
        B5,

        /// <summary>
        /// | O X X |
        /// | X X X |
        /// | X X O |
        /// </summary>
        B6,

        // 3 
        // With Middle

        /// <summary>
        /// | X O X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        C1,

        /// <summary>
        /// | X O X |
        /// | X O X |
        /// | X O X |
        /// </summary>
        C2,

        /// <summary>
        /// | O X O |
        /// | X O X |
        /// | X X X |
        /// </summary>
        C3,

        /// <summary>
        /// | O X X |
        /// | X O X |
        /// | X X O |
        /// </summary>
        C4,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        C5,

        /// <summary>
        /// | O X X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        C6,

        // 3 
        // Without Middle

        /// <summary>
        /// | X O X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        C7,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | X X O |
        /// </summary>
        C8,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C9,


        /// <summary>
        /// | X O O |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C10,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C11,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | X X X |
        /// </summary>
        C12,

        /// <summary>
        /// | O X O |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C13,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | X O X |
        /// </summary>
        C14

        // | X X X |
        // | X X X |
        // | X X X |
    }

}
