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
        A01,

        /// <summary>
        /// | O X X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        A02,

        /// <summary>
        /// | X O X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        A03,

        /// <summary>
        /// | O X X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        B01,

        /// <summary>
        /// | X O X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        B02,

        /// <summary>
        /// | X O X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        B03,

        /// <summary>
        /// | X O X |
        /// | X X X |
        /// | X O X |
        /// </summary>
        B04,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | X X X |
        /// </summary>
        B05,

        /// <summary>
        /// | O X X |
        /// | X X X |
        /// | X X O |
        /// </summary>
        B06,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X X X |
        /// </summary>
        B07,

        /// <summary>
        /// | O X X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        B08,

        /// <summary>
        /// | X O X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        C01,

        /// <summary>
        /// | X O X |
        /// | X O X |
        /// | X O X |
        /// </summary>
        C02,

        /// <summary>
        /// | O X O |
        /// | X O X |
        /// | X X X |
        /// </summary>
        C03,

        /// <summary>
        /// | O X X |
        /// | X O X |
        /// | X X O |
        /// </summary>
        C04,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X X X |
        /// </summary>
        C05,

        /// <summary>
        /// | O X X |
        /// | X O O |
        /// | X X X |
        /// </summary>
        C06,

        /// <summary>
        /// | X O X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        C07,

        /// <summary>
        /// | O X O |
        /// | X X X |
        /// | X X O |
        /// </summary>
        C08,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C09,

        /// <summary>
        /// | X O O |
        /// | X X O |
        /// | X X X |
        /// </summary>
        C10,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X X O |
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
        /// | X X X |
        /// | X O X |
        /// </summary>
        C13,

        /// <summary>
        /// | O X X |
        /// | X X O |
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
        /// | O O O |
        /// | O X X |
        /// | X X X |
        /// </summary>
        D01,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X X X |
        /// </summary>
        D02,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O X X |
        /// </summary>
        D03,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | X O X |
        /// </summary>
        D04,

        /// <summary>
        /// | O O X |
        /// | O X X |
        /// | X O X |
        /// </summary>
        D05,

        /// <summary>
        /// | O O X |
        /// | X O X |
        /// | X O X |
        /// </summary>
        D06,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X O X |
        /// </summary>
        D07,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | O O X |
        /// </summary>
        D08,

        /// <summary>
        /// | O O X |
        /// | X X X |
        /// | X O O |
        /// </summary>
        D09,

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
        /// | O X O |
        /// | X O X |
        /// | X X O |
        /// </summary>
        D14,

        /// <summary>
        /// | O O X |
        /// | O X X |
        /// | X X O |
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
        /// | X O X |
        /// | X X O |
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
        /// | O X O |
        /// | X X O |
        /// | X X O |
        /// </summary>
        D20,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | X X O |
        /// </summary>
        D21,

        /// <summary>
        /// | O X O |
        /// | X O X |
        /// | X O X |
        /// </summary>
        D22,

        /// <summary>
        /// | O X X |
        /// | X O O |
        /// | X O X |
        /// </summary>
        D23,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X X X |
        /// </summary>
        E01,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O X X |
        /// </summary>
        E02,

        /// <summary>
        /// | O O X |
        /// | O O X |
        /// | X X O |
        /// </summary>
        E03,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X O X |
        /// </summary>
        E04,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X X O |
        /// </summary>
        E05,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X X O |
        /// </summary>
        E06,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | O O X |
        /// </summary>
        E07,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O X O |
        /// </summary>
        E08,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | X O O |
        /// </summary>
        E09,

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
        /// | X O O |
        /// | O X X |
        /// </summary>
        E12,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X O X |
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
        /// | X O O |
        /// | O X O |
        /// | X O X |
        /// </summary>
        E19,

        /// <summary>
        /// | O X O |
        /// | O O O |
        /// | X X X |
        /// </summary>
        E20,

        /// <summary>
        /// | O O X |
        /// | X X O |
        /// | O X O |
        /// </summary>
        E21,

        /// <summary>
        /// | O O X |
        /// | X O O |
        /// | X O X |
        /// </summary>
        E22,

        /// <summary>
        /// | O O X |
        /// | X O O |
        /// | X X O |
        /// </summary>
        E23,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | X X X |
        /// </summary>
        F01,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | O X X |
        /// </summary>
        F02,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X O X |
        /// </summary>
        F03,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X X O |
        /// </summary>
        F04,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X X O |
        /// </summary>
        F05,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O X O |
        /// </summary>
        F06,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | X O O |
        /// </summary>
        F07,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | X O O |
        /// </summary>
        F08,

        /// <summary>
        /// | O O X |
        /// | O O O |
        /// | X O X |
        /// </summary>
        F09,

        /// <summary>
        /// | O O O |
        /// | X X X |
        /// | O O O |
        /// </summary>
        F10,

        /// <summary>
        /// | O O X |
        /// | O X O |
        /// | X O O |
        /// </summary>
        F11,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | O X O |
        /// </summary>
        F12,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X O X |
        /// </summary>
        F13,

        /// <summary>
        /// | O O X |
        /// | O O X |
        /// | X O O |
        /// </summary>
        F14,

        /// <summary>
        /// | O O X |
        /// | X O O |
        /// | O O X |
        /// </summary>
        F15,

        /// <summary>
        /// | O O X |
        /// | X O O |
        /// | O X O |
        /// </summary>
        F16,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O X X |
        /// </summary>
        G01,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | X O X |
        /// </summary>
        G02,

        /// <summary>
        /// | O O O |
        /// | X O X |
        /// | O O O |
        /// </summary>
        G03,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | O X O |
        /// </summary>
        G04,

        /// <summary>
        /// | O O O |
        /// | O O X |
        /// | X O O |
        /// </summary>
        G05,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | X O O |
        /// </summary>
        G06,

        /// <summary>
        /// | O O O |
        /// | O X X |
        /// | O O O |
        /// </summary>
        G07,

        /// <summary>
        /// | O O X |
        /// | O O O |
        /// | X O O |
        /// </summary>
        G08,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O O X |
        /// </summary>
        H01,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O X O |
        /// </summary>
        H02,

        /// <summary>
        /// | O O O |
        /// | O X O |
        /// | O O O |
        /// </summary>
        H03,

        /// <summary>
        /// | O O O |
        /// | O O O |
        /// | O O O |
        /// </summary>
        I01
    }

}