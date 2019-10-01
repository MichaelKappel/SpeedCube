using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Common.Enumerations
{

    /// 
    /// Michael Reid's
    /// Rubik's Cube patterns
    /// http://www.cflmath.com/~reid/Rubik/patterns.html
    /// 
    /// W W W 
    /// W W W 
    /// W W W 
    /// 
    /// G G G   R R R   
    /// G G G   R R R   
    /// G G G   R R R   
    /// 
    public enum CommonPatternRecognitionTypes
    {
        /// <summary>
        /// Pons asinorum
        /// 
        /// W B W 
        /// B W B 
        /// W B W 
        /// 
        /// G Y G   O B O   
        /// Y G Y   B O B   
        /// G Y G   O B O   
        /// 
        /// F2 B2 R2 L2 U2 D2	(12q*, 6f*)
        /// </summary>
        PonsAsinorum,

        /// <summary>
        /// Checkerboards of order 3
        /// 
        /// G Y G 
        /// Y G Y 
        /// G Y G 
        /// 
        /// G R G   R W R   
        /// R G R   W R W   
        /// G R G   R W R   
        /// 
        /// F B2 R' D2 B R U D' R L' D' F' R2 D F2 B'	(20q*, 16f*)
        /// </summary>
        CheckerboardsOfOrderThree,

        /// <summary>
        /// Checkerboards of order 6
        /// 
        /// W Y W 
        /// Y W Y 
        /// W Y W 
        /// 
        /// G O G   R B R   
        /// O G O   B R B   
        /// G O G   R B R   
        /// 
        /// R' D' F' D L F U2 B' L U D' R' D' L F L2 U F'	(20q*, 18f)
        /// R2 L2 U B L2 D' F B2 R L' F' B R D F2 L' U'	(17f*, 22q)
        /// </summary>
        CheckerboardsOfOrderSix,

        /// <summary>
        ///  Stripes
        ///  
        /// W W W 
        /// W W W 
        /// W W W 
        /// 
        /// O R R   Y R G   
        /// O R R   Y R G   
        /// O R R   Y R G   
        /// 
        /// F U F R L2 B D' R D2 L D' B R2 L F U F	(20q*, 17f*)
        /// </summary>
        Stripes,

        /// <summary>
        /// Cube in a cube
        /// 
        /// G G G
        /// G W W 
        /// G W W 
        /// 
        /// R G G   R R G   
        /// R G G   R R G   
        /// R R R   G G G  
        /// 
        /// F L F U' R U F2 L2 U' L' B D' B' L2 U	(18q*, 15f*)
        /// </summary>
        CubeInACube,

        /// Cube in a cube in a cube
        ///  
        /// G G G
        /// G W W 
        /// G W G 
        /// 
        /// R G R   W R G   
        /// R G G   R R G   
        /// R R R   G G G  
        /// 
        /// U' L' U' F' R2 B' R F U B2 U B' L U' F U R F'	(20q*, 18f)
        /// F' U B' R' U F2 U2 F' U' F U2 D B' D' R2 B2 U'	(17f*, 22q)
        CubeInACubeInACube,

        /// <summary>
        /// Christman's cross 
        ///   
        /// B W B 
        /// W W W 
        /// B W B 
        /// 
        /// R B R   G R G   
        /// B B B   R R R   
        /// R B R   G R G   
        /// 
        /// U F B' L2 U2 L2 F' B U2 L2 U	(16q*, 11f*)
        /// </summary>
        ChristmansCross,

        /// <summary>
        /// Plummer's cross
        ///   
        /// R W R 
        /// W W W 
        /// R W R 
        /// 
        /// W G W   G R G   
        /// G G G   R R R   
        /// W G W   G R G   
        /// 
        /// R2 L' D F2 R' D' R' L U' D R D B2 R' U D2	(20q*, 16f*)
        /// </summary>
        PlummersCross,

        /// <summary>
        /// Anaconda
        ///   
        /// G W G 
        /// W W G 
        /// G G G 
        /// 
        /// R R R   W W W  
        /// G G R   W R R   
        /// R G R   W R W  
        /// 
        /// L U B' U' R L' B R' F B' D R D' F'	(14q*, 14f*)
        /// </summary>
        Anaconda,

        /// <summary>
        /// Python
        ///     
        /// B W B 
        /// B W B 
        /// B W B 
        /// 
        /// R G R   G G G  
        /// G G R   G R R   
        /// R R R   G R G  
        /// 
        /// F2 R' B' U R' L F' L F' B D' R B L2	(16q*, 14f*)
        /// </summary>
        Python,

        /// <summary>
        /// Black Mamba
        /// 
        /// R W R 
        /// W W R 
        /// R R R 
        /// 
        /// B B B   Y Y Y  
        /// G G G   R R R   
        /// B B B   Y Y Y  
        /// 
        /// R D L F' R L' D R' U D' B U' R' D'	(14q*, 14f*)
        /// </summary>
        BlackMamba,

        /// <summary>
        /// Green Mamba
        /// 
        /// R R R 
        /// W W W 
        /// R R R 
        /// 
        /// B B B   Y Y Y  
        /// G G G   R R R   
        /// B B B   Y Y Y  
        /// 
        /// R D R F R' F' B D R' U' B' U D2	(14q*, 13f*)
        /// </summary>
        GreenMamba,

        /// <summary>
        /// Female Rattlesnake
        /// 
        /// B B B 
        /// W W B 
        /// B W B 
        /// 
        /// R R R   G G G 
        /// R G G   R R G  
        /// R G R   G R G 
        /// 
        /// U2 D' L2 D B U B' R' L2 U2 F U' F R	(18q*, 14f*)
        /// </summary>
        FemaleRattlesnake,

        /// <summary>
        /// Male Rattlesnake
        /// 
        /// B B B 
        /// B B B 
        /// B B B 
        /// 
        /// R R R   G G G 
        /// R G G   R R G  
        /// R G R   G R G 
        /// 
        /// R' F' U F' U2 R L2 B U' B' D' L2 U2 D	(18q*, 14f*)
        /// </summary>
        MaleRattlesnake,

        /// <summary>
        /// Female Boa
        /// 
        /// B B B 
        /// W W W 
        /// B B B 
        /// 
        /// R G R   G G G 
        /// R G G   R R G  
        /// R R R   G R G 
        /// 
        /// R U' R2 U2 F D2 R2 U' D' R D' F'	(16q*, 12f*)
        /// </summary>
        FemaleBoa,

        /// <summary>
        /// Male Boa
        /// 
        /// B B B 
        /// W W W 
        /// B B B 
        /// 
        /// R R R   G G G 
        /// R G G   R R G  
        /// R G R   G R G 
        /// 
        /// F D R' U D R2 D2 F' U2 R2 U R'	(16q*, 12f*)
        /// </summary>
        MaleBoa,

        /// <summary>
        /// Four spot
        /// 
        /// W W W 
        /// W W W 
        /// W W W 
        /// 
        /// Y Y Y   O O O 
        /// Y G Y   O R O  
        /// Y Y Y   O O O 
        /// 
        /// F2 B2 U D' R2 L2 U D'	(12q*, 8f*)
        /// </summary>
        FourSpot,

        /// <summary>
        /// Six spot
        /// 
        /// G G G 
        /// G W G 
        /// G G G 
        /// 
        /// R R R   W W W 
        /// R G R   W R W  
        /// R R R   W W W 
        /// 
        /// U D' R L' F B' U D'	(8q*, 8f*)
        /// </summary>
        SixSpot,

        /// <summary>
        /// Orthogonal bars
        /// 
        /// R W R 
        /// R W W 
        /// R W W 
        /// 
        /// W G G   R R G 
        /// G G G   R R G  
        /// W W W   G R G 
        /// 
        /// F R' U L F' L' F U' R U L' U' L F'	(14q*, 14f*)
        /// </summary>
        OrthogonalBars,

        /// <summary>
        /// Six T's
        /// 
        /// B B W 
        /// W W W 
        /// B B W 
        /// 
        /// G G G   R O O  
        /// Y G Y   R R R  
        /// Y G Y   R O O 
        /// 
        /// F2 R2 U2 F' B D2 L2 F B	(14q*, 9f*)
        /// </summary>
        SixTs,

        /// <summary>
        /// Six-two-one
        /// 
        /// G W W 
        /// G W W 
        /// O W W 
        /// 
        /// G G G   R R Y  
        /// G G G   R R W  
        /// R R B   R R W 
        /// 
        /// U B2 D2 L B' L' U' L' B D2 B2	(15q*, 11f*)
        /// </summary>
        SixTwoOne,

        /// <summary>
        /// Exchanged peaks
        ///  
        /// W W W 
        /// W W B 
        /// W B B
        /// 
        /// G O O   Y Y R   
        /// G G O   Y R R   
        /// G G G   R R R   
        /// 
        /// F U2 L F L' B L U B' R' L' U R' D' F' B R2	(19q*, 17f)
        /// F2 R2 D R2 U D F2 D' R' D' F L2 F' D R U'	(16f*, 21q)
        /// </summary>
        ExchangedPeaks,

        /// <summary>
        /// Two twisted peaks
        /// 
        /// W W W 
        /// W W G 
        /// W G G 
        /// 
        /// G R R   W W R   
        /// G G R   W R R   
        /// G G G   R R R   
        /// 
        /// F B' U F U F U L B L2 B' U F' L U L' B	(18q*, 17f)
        /// F D2 B R B' L' F D' L2 F2 R F' R' F2 L' F'	(16f*, 20q)
        /// </summary>
        TwoTwistedPeaks,

        /// <summary>
        /// Four twisted peaks
        /// 
        /// O O W 
        /// O W R 
        /// W R R 
        /// 
        /// G W W   G G R   
        /// O G W   G R B   
        /// O O G   R B B   
        /// 
        /// U' D B R' F R B' L' F' B L F R' B' R F' U' D	(18q*, 18f*)
        /// </summary>
        FourTwistedPeaks,

        /// <summary>
        /// Exchanged chicken feet
        /// 
        /// B B B 
        /// B W B 
        /// B B W 
        /// 
        /// O O G   R Y Y   
        /// O G O   Y R Y   
        /// O O O   Y Y Y   
        /// 
        /// F L' D' B' L F U F' D' F L2 B' R' U L2 D' F	(19q*, 17f*)
        /// </summary>
        ExchangedChickenFeet,

        /// <summary>
        /// Twisted chicken feet
        /// 
        /// R R R 
        /// R W R 
        /// R R W 
        /// 
        /// W W G   R G G   
        /// W G W   G R G   
        /// W W W   G G G   
        /// 
        /// F L' D F' U' B U F U' F R' F2 L U' R' D2	(18q*, 16f*)
        /// </summary>
        TwistedChickenFeet,

        /// <summary>
        /// Exchanged rings
        ///  
        /// B B B 
        /// B W W 
        /// B W B 
        /// 
        /// O G O   Y R Y   
        /// O G G   R R Y   
        /// O O O   Y Y Y   
        /// 
        /// B' U' B' L' D B U D2 B U L D' L' U' L2 D	(18q*, 16f)
        /// F U D' L' B2 L U' D F U R2 L2 U' L2 F2	(15f*, 20q)
        /// </summary>
        ExchangedRings,

        /// <summary>
        /// Twisted rings   
        ///  
        /// G G G 
        /// G W W 
        /// G W G 
        /// 
        /// R G R   W R W  
        /// R G G   R R W  
        /// R R R   W W W  
        /// 
        /// F D F' D2 L' B' U L D R U L' F' U L U2	(18q*, 16f*)
        /// </summary>
        TwistedRings,

        /// <summary>
        /// Edge hexagon of order 2
        /// 
        /// W B W 
        /// B W W 
        /// W W W 
        /// 
        /// G G G   R R R   
        /// O G G   R R Y   
        /// G O G   R Y R   
        /// 
        /// U B2 U' F' U' D L' D2 L U D' F D' L2 B2 D'	(20q*, 16f*)
        /// </summary>
        EdgeHexagonOfOrderTwo,

        /// <summary>
        /// Edge hexagon of order 3
        /// 
        /// W R W 
        /// R W W 
        /// W W W 
        /// 
        /// G G G   R R R   
        /// W G G   R R G  
        /// G W G   R G R   
        /// 
        /// D L' U R' B' R B U2 D B D' B' L U D'	(16q*, 15f)
        /// F L B U L F2 B2 R' F2 B2 U' B' L' F'	(14f*, 18q)
        /// </summary>
        EdgeHexagonOfOrderThree,

        /// <summary>
        /// Tom Parks' pattern
        /// 
        /// O R B 
        /// O W B 
        /// O W B 
        /// 
        /// Y G R   G R Y   
        /// Y G R   G R Y  
        /// Y G R   G R Y   
        /// 
        /// L U F2 R L' U2 B' U D B2 L F B' R' L F' R	(20q*, 17f*)
        /// </summary>
        TomParksPattern,

        /// <summary>
        /// Ron's cube in a cube
        /// 
        /// W W W 
        /// W W W 
        /// W W W 
        /// 
        /// Y G G   R R O   
        /// Y G G   R R O  
        /// Y Y Y   O O O   
        /// 
        /// F D' F' R D F' R' D R D L' F L D R' F D'	(17q*, 17f)
        /// L2 D2 L' D2 B2 L2 B2 L' D2 L2 B2 L' B2	(13f*, 23q)
        /// </summary>
        RonsCubeInACube,

        /// <summary>
        /// Twisted duck feet
        ///  
        /// R W R
        /// W W R
        /// R R W 
        /// 
        /// Y Y G   R G G   
        /// G G Y   G R R   
        /// Y G Y   G R R   
        /// 
        /// F R' B R U F' L' F' U2 L' U' D2 B D' F B' U2	(20q*, 17f*)
        /// </summary>
        TwistedDuckFeet,

        /// <summary>
        /// Exchanged duck feet
        ///  
        /// W Y W 
        /// O W R 
        /// W G W 
        /// 
        /// G W G   R W R   
        /// O G R   G R Y   
        /// G B G   R B R   
        /// 
        /// U F R2 F' D' R U B2 U2 F' R2 F D B2 R B'	(21q*, 16f*)
        /// </summary>
        ExchangedDuckFeet
    }
}
