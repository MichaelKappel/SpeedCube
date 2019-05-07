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
        /// | ? ? ? |
        /// | ? ? ? |
        /// | ? ? ? |
        /// </summary>
        Unknown,

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

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        B7,

        /// <summary>
        /// | O X X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        B8,

        /// <summary>
        /// | O X X |
        /// | X X X |
        /// | X O X |
        /// </summary>
        B9,

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
        C14,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X O X |
        /// </summary>
        C15,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | O X X |
        /// </summary>
        C16,

        /// <summary>
        /// | X O X |
        /// | O O X |
        /// | X X X |
        /// </summary>
        C17,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        C18,

        /// <summary>
        /// | O X X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        C19,

        /// <summary>
        /// | O X X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        C20,

        /// <summary>
        /// | O X X |
        /// | X O X |
        /// | X O X |
        /// </summary>
        C21,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X X X |
        /// </summary>
        D1,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X X X |
        /// </summary>
        D2,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O X X |
        /// </summary>
        D3,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | X O X |
        /// </summary>
        D4,

        /// <summary>
        /// | O O X |
        /// | O X X |
        /// | X O X |
        /// </summary>
        D5,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X O X |
        /// </summary>
        D6,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        D7,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | O O X |
        /// </summary>
        D8,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X O O |
        /// </summary>
        D9,

        /// <summary>
        /// | O O X |
        /// | O O X |
        /// | X X X |
        /// </summary>
        D10,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | O X O |
        /// </summary>
        D11,

        /// <summary>
        /// | X O X |
        /// | O X O |
        /// | X O X |
        /// </summary>
        D12,

        /// <summary>
        /// | X O X |
        /// | O O X |
        /// | X O X |
        /// </summary>
        D13,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X O O |
        /// </summary>
        D14,

        /// <summary>
        /// | X O X |
        /// | O O O |
        /// | X X X |
        /// </summary>
        D15,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | O X X |
        /// </summary>
        D16,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        D17,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | O X X |
        /// </summary>
        D18,

        /// <summary>
        /// | O X X |
        /// | X X O |
        /// | O X O |
        /// </summary>
        D19,

        /// <summary>
        /// | O O X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        D20,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X X X |
        /// </summary>
        E1,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X X X |
        /// </summary>
        E2,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O X X |
        /// </summary>
        E3,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X O X |
        /// </summary>
        E4,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X X O |
        /// </summary>
        E5,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X X O |
        /// </summary>
        E6,

        /// <summary>
        /// | O O O |
        /// | X X O |
        /// | X X O |
        /// </summary>
        E7,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O X O |
        /// </summary>
        E8,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | X O O |
        /// </summary>
        E9,

        /// <summary>
        /// | O O X |
        /// | O X X |
        /// | X O O |
        /// </summary>
        E10,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X O O |
        /// </summary>
        E11,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X O O |
        /// </summary>
        E12,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | O O O |
        /// </summary>
        E13,

        /// <summary>
        /// | O X O |
        /// | X O X |
        /// | O X O |
        /// </summary>
        E14,

        /// <summary>
        /// | X O X |
        /// | O O O |
        /// | X O X |
        /// </summary>
        E15,

        /// <summary>
        /// | O O X |
        /// | O O O |
        /// | X X X |
        /// </summary>
        E16,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X X X |
        /// </summary>
        E17,

        /// <summary>
        /// | O X O |
        /// | X O X |
        /// | X O O |
        /// </summary>
        E18,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X X X |
        /// </summary>
        E19,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O X O |
        /// </summary>
        E20,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | X X X |
        /// </summary>
        F1,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | O X X |
        /// </summary>
        F2,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X O X |
        /// </summary>
        F3,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X X O |
        /// </summary>
        F4,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X X O |
        /// </summary>
        F5,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O X O |
        /// </summary>
        F6,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X O O |
        /// </summary>
        F7,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X O O |
        /// </summary>
        F8,

        /// <summary>
        /// | O O O |
        /// | X X O |
        /// | X O O |
        /// </summary>
        F9,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O O O |
        /// </summary>
        F10,

        /// <summary>
        /// | O O X |
        /// | O X X |
        /// | O O O |
        /// </summary>
        F11,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X O O |
        /// </summary>
        F12,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X O X |
        /// </summary>
        F13,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O X X |
        /// </summary>
        G1,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | X O X |
        /// </summary>
        G2,

        /// <summary>
        /// | X O O |
        /// | O O O |
        /// | O O X |
        /// </summary>
        G3,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | O X O |
        /// </summary>
        G4,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X O O |
        /// </summary>
        G5,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X O O |
        /// </summary>
        G6,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O O O |
        /// </summary>
        G7,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | O O O |
        /// </summary>
        G8,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O O X |
        /// </summary>
        H1,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O X O |
        /// </summary>
        H2,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | O O O |
        /// </summary>
        H3,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O O O |
        /// </summary>
        I1
    }

}

// | X X X |
// | X X X |
// | X X X |