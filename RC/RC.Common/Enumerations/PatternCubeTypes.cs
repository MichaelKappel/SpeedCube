using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Common.Enumerations
{

    //	        Y Y Y
    //	        Y Y Y
    //	        Y Y Y

    //	x x x	Z Z Z	X X X	z z z 
    //	x x x	Z Z Z	X X X   z z z 
    //	x x x	Z Z Z	X X X	z z z 

    //	        y y y 
    //	        y y y 
    //	        y y y
    public enum XyzCubeTypes
    {
        //****************************//
        //  White Side Up
        //****************************//

        /// <summary>
        /// X=Orange
        /// Y=White
        /// Z=Blue
        /// </summary>
        OrangeWhiteBlue,

        /// <summary>
        /// X=Green
        /// Y=White
        /// Z=Orange
        /// </summary>
        GreenWhiteOrange,

        /// <summary>
        /// X=Red
        /// Y=White
        /// Z=Green
        /// </summary>
        RedWhiteGreen,

        /// <summary>
        /// X=Blue
        /// Y=White
        /// Z=Red
        /// </summary>
        BlueWhiteRed,

        //****************************//
        //  Yellow Side Up
        //****************************//

        /// <summary>
        /// X=Blue
        /// Y=Yellow
        /// Z=Orange
        /// </summary>
        BlueYellowOrange,

        /// <summary>
        /// X=Red
        /// Y=Yellow
        /// Z=Blue
        /// </summary>
        RedYellowBlue,

        /// <summary>
        /// X=Green
        /// Y=Yellow
        /// Z=Red
        /// </summary>
        GreenYellowRed,

        /// <summary>
        /// X=Orange
        /// Y=Yellow
        /// Z=Green
        /// </summary>
        OrangeYellowGreen,

        //****************************//
        //  Blue Side Up
        //****************************//

        /// <summary>
        /// X=Yellow
        /// Y=Blue
        /// Z=Red
        /// </summary>
        YellowBlueRed,

        /// <summary>
        /// X=Orange
        /// Y=Blue
        /// Z=Yellow
        /// </summary>
        OrangeBlueYellow,

        /// <summary>
        /// X=White
        /// Y=Blue
        /// Z=Orange
        /// </summary>
        WhiteBlueOrange,

        /// <summary>
        /// X=Red
        /// Y=Blue
        /// Z=White
        /// </summary>
        RedBlueWhite,

        //****************************//
        //  Green Side Up
        //****************************//

        /// <summary>
        /// X=Yellow
        /// Y=Green
        /// Z=Orange
        /// </summary>
        YellowGreenOrange,

        /// <summary>
        /// X=Red
        /// Y=Green
        /// Z=Yellow
        RedGreenYellow,

        /// <summary>
        /// X=White
        /// Y=Green
        /// Z=Red
        WhiteGreenRed,

        /// <summary>
        /// X=Orange
        /// Y=Green
        /// Z=White
        OrangeGreenWhite,

        //****************************//
        //  Red Side Up
        //****************************//

        /// <summary>
        /// X=Yellow
        /// Y=Red
        /// Z=Green
        /// </summary>
        YellowRedGreen,

        /// <summary>
        /// X=Blue
        /// Y=Red
        /// Z=Yellow
        /// </summary>
        BlueRedYellow,

        /// <summary>
        /// X=White
        /// Y=Red
        /// Z=Blue
        /// </summary>
        WhiteRedBlue,
        
        /// <summary>
        /// X=Green
        /// Y=Red
        /// Z=White
        /// </summary>
        GreenRedWhite,


        //****************************//
        //  Orange Side Up
        //****************************//

        /// <summary>
        /// X=Yellow
        /// Y=Orange
        /// Z=Blue
        /// </summary>
        YellowOrangeBlue,

        /// <summary>
        /// X=Green
        /// Y=Orange
        /// Z=Yellow
        /// </summary>
        GreenOrangeYellow,

        /// <summary>
        /// X=White
        /// Y=Orange
        /// Z=Green
        /// </summary>
        WhiteOrangeGreen,

        /// <summary>
        /// X=Blue
        /// Y=Orange
        /// Z=White
        /// </summary>
        BlueOrangeWhite,
    }
}
