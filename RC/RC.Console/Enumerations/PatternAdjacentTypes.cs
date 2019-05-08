using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Enumerations
{
    public enum PatternAdjacentTypes
    {

        ///  <summary>
        /// [ - - ? - - ]
        /// [ - ? | ? - ]
        /// [ ? ? | ? ? ]
        /// [ - ? | ? - ]
        /// [ - - ? - - ]
        ///  </summary>
        Unknown,

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
        A01,

        ///  <summary>  
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A02,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A03,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        A04,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B01,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B02,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B03,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        B04,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B05,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B06,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B07,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X O ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B08,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        B09,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - O | X - ]
        /// [ X X | X X ]
        /// [ - X | X - ]
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
        C01,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C02,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        C03,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C04,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        C05,


        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C06,


        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C07,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C08,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C09,       
        
        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O O ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C10,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X O ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C11,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C12,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C13,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | X O ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        C14,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        C15,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        C16,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - X - - ]
        ///  </summary>
        C17,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        C18,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        D01,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | X - ]
        /// [ - - O - - ]
        ///  </summary>
        D02,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D03,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O O | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D04,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D05,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D06,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D07,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X O | X O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D08,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O O | X X ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D09,

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ X X | O O ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D10, 

        ///  <summary>
        /// [ - - X - - ]
        /// [ - O | X - ]
        /// [ O X | O X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D11,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ X O | X O ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D12,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - O | X - ]
        /// [ X O | X O ]
        /// [ - X | O - ]
        /// [ - - X - - ]
        ///  </summary>
        D13,

        ///  <summary>
        /// [ - - O - - ]
        /// [ - X | X - ]
        /// [ O X | O X ]
        /// [ - O | X - ]
        /// [ - - X - - ]
        ///  </summary>
        D14,
    }
}
