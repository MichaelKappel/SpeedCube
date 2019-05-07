using RC.Enumerations;
using RC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Logic
{
    public abstract class LogicBase
    {

        public String GetStickerAbbreviation(StickerModelBase sticker)
        {
            switch (sticker.StickerColorType)
            {
                case StickerColorTypes.Blue:
                    return "B";
                case StickerColorTypes.Green:
                    return "G";
                case StickerColorTypes.Orange:
                    return "O";
                case StickerColorTypes.Red:
                    return "R";
                case StickerColorTypes.White:
                    return "W";
                case StickerColorTypes.Yellow:
                    return "Y";
                default:
                    return "#";
            }
        }

        public String GetStickerAbbreviation(Char sticker)
        {
            switch (sticker)
            {
                case 'A':
                    return "O";
                case 'a':
                    return "R";
                case 'B':
                    return "W";
                case 'b':
                    return "Y";
                case 'C':
                    return "B";
                case 'c':
                    return "G";
                default:
                    return "#";
            }
        }

        public String GetDetailedCubeState(CubeModel cube)
        {
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

            String north = $"BNW:{ GetStickerAbbreviation(cube.BackNorthWest.StickerNorth)}|BN:{ GetStickerAbbreviation(cube.BackNorth.StickerNorth)}|BNE:{ GetStickerAbbreviation(cube.BackNorthEast.StickerNorth)}|NW:{ GetStickerAbbreviation(cube.NorthWest.StickerNorth)}|N:{ GetStickerAbbreviation(cube.North.StickerNorth)}|NE:{ GetStickerAbbreviation(cube.NorthEast.StickerNorth)}|FNW:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerNorth)}|FN:{ GetStickerAbbreviation(cube.FrontNorth.StickerNorth)}|FNE:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerNorth)}";
            String south = $"FSW:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerSouth)}|FS:{ GetStickerAbbreviation(cube.FrontSouth.StickerSouth)}|FSE:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerSouth)}|SW:{ GetStickerAbbreviation(cube.SouthWest.StickerSouth)}|S:{ GetStickerAbbreviation(cube.South.StickerSouth)}|SE:{ GetStickerAbbreviation(cube.SouthEast.StickerSouth)}|BSW:{ GetStickerAbbreviation(cube.BackSouthWest.StickerSouth)}|BS:{ GetStickerAbbreviation(cube.BackSouth.StickerSouth)}|BSE:{ GetStickerAbbreviation(cube.BackSouthEast.StickerSouth)}";
            String front = $"FNW:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerFront)}|FN:{ GetStickerAbbreviation(cube.FrontNorth.StickerFront)}|FNE:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerFront)}|FW:{ GetStickerAbbreviation(cube.FrontWest.StickerFront)}|F:{ GetStickerAbbreviation(cube.Front.StickerFront)}|FE:{ GetStickerAbbreviation(cube.FrontEast.StickerFront)}|FSW:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerFront)}|FS:{ GetStickerAbbreviation(cube.FrontSouth.StickerFront)}|FSE:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerFront)}";
            String back = $"BNW:{ GetStickerAbbreviation(cube.BackNorthWest.StickerBack)}|BN:{ GetStickerAbbreviation(cube.BackNorth.StickerBack)}|BNE:{ GetStickerAbbreviation(cube.BackNorthEast.StickerBack)}|BW:{ GetStickerAbbreviation(cube.BackWest.StickerBack)}|B:{ GetStickerAbbreviation(cube.Back.StickerBack)}|BE:{ GetStickerAbbreviation(cube.BackEast.StickerBack)}|BSW:{ GetStickerAbbreviation(cube.BackSouthWest.StickerBack)}|BS:{ GetStickerAbbreviation(cube.BackSouth.StickerBack)}|BSE:{ GetStickerAbbreviation(cube.BackSouthEast.StickerBack)}";
            String west = $"BNW:{ GetStickerAbbreviation(cube.BackNorthWest.StickerWest)}|NW:{ GetStickerAbbreviation(cube.NorthWest.StickerWest)}|FNW:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerWest)}|BW:{ GetStickerAbbreviation(cube.BackWest.StickerWest)}|W:{ GetStickerAbbreviation(cube.West.StickerWest)}|FW:{ GetStickerAbbreviation(cube.FrontWest.StickerWest)}|BSW:{ GetStickerAbbreviation(cube.BackSouthWest.StickerWest)}|SW:{ GetStickerAbbreviation(cube.SouthWest.StickerWest)}|FSW:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerWest)}";
            String east = $"FNE:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerEast)}|NE:{ GetStickerAbbreviation(cube.NorthEast.StickerEast)}|BNE:{ GetStickerAbbreviation(cube.BackNorthEast.StickerEast)}|FE:{ GetStickerAbbreviation(cube.FrontEast.StickerEast)}|E:{ GetStickerAbbreviation(cube.East.StickerEast)}|BE:{ GetStickerAbbreviation(cube.BackEast.StickerEast)}|FSE:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerEast)}|SE:{ GetStickerAbbreviation(cube.SouthEast.StickerEast)}|BSE:{ GetStickerAbbreviation(cube.BackSouthEast.StickerEast)}";

            return $"{north},{south},{front},{back},{west},{east}";
        }


        public String GetStickerAbbreviation(XyzCubeTypes xyzCubeTypes, StickerColorTypes stickerColorType)
        {
            if (stickerColorType == StickerColorTypes.White || stickerColorType == StickerColorTypes.Yellow)
            {
                if (xyzCubeTypes == XyzCubeTypes.WhiteBlueOrange
                    || xyzCubeTypes == XyzCubeTypes.WhiteGreenRed
                    || xyzCubeTypes == XyzCubeTypes.WhiteOrangeGreen
                    || xyzCubeTypes == XyzCubeTypes.WhiteRedBlue)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "A" : "a";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                   || xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                   || xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                   || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                   )
                {
                    return (stickerColorType == StickerColorTypes.White) ? "B" : "b";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                  || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                  || xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                  || xyzCubeTypes == XyzCubeTypes.RedBlueWhite)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "C" : "c";
                }
                else if (xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue
                    || xyzCubeTypes == XyzCubeTypes.YellowRedGreen
                    || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange
                    || xyzCubeTypes == XyzCubeTypes.YellowBlueRed)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "a" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                   || xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen
                   || xyzCubeTypes == XyzCubeTypes.BlueYellowOrange
                   || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                   )
                {
                    return (stickerColorType == StickerColorTypes.White) ? "b" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                  || xyzCubeTypes == XyzCubeTypes.RedGreenYellow
                  || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow
                  || xyzCubeTypes == XyzCubeTypes.BlueRedYellow)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "c" : "C";
                }

            }
            else if (stickerColorType == StickerColorTypes.Blue || stickerColorType == StickerColorTypes.Green)
            {

                if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                    || xyzCubeTypes == XyzCubeTypes.BlueRedYellow
                    || xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                    || xyzCubeTypes == XyzCubeTypes.BlueYellowOrange)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "A" : "a";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                   || xyzCubeTypes == XyzCubeTypes.RedBlueWhite
                   || xyzCubeTypes == XyzCubeTypes.WhiteBlueOrange
                   || xyzCubeTypes == XyzCubeTypes.YellowBlueRed
                   )
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "B" : "b";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                  || xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                  || xyzCubeTypes == XyzCubeTypes.WhiteRedBlue
                  || xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "C" : "c";
                }
                else if (xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                 || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                 || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                 || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "a" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                  || xyzCubeTypes == XyzCubeTypes.RedGreenYellow
                  || xyzCubeTypes == XyzCubeTypes.WhiteGreenRed
                  || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange
                   )
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "b" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen
                   || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                   || xyzCubeTypes == XyzCubeTypes.WhiteOrangeGreen
                   || xyzCubeTypes == XyzCubeTypes.YellowRedGreen)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "c" : "C";
                }
            }
            else if (stickerColorType == StickerColorTypes.Red || stickerColorType == StickerColorTypes.Orange)
            {

                if (xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                    || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                    || xyzCubeTypes == XyzCubeTypes.RedBlueWhite
                    || xyzCubeTypes == XyzCubeTypes.RedGreenYellow)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "A" : "a";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueRedYellow
                   || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                   || xyzCubeTypes == XyzCubeTypes.WhiteRedBlue
                   || xyzCubeTypes == XyzCubeTypes.YellowRedGreen)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "B" : "b";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                  || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                  || xyzCubeTypes == XyzCubeTypes.WhiteGreenRed
                  || xyzCubeTypes == XyzCubeTypes.YellowBlueRed)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "C" : "c";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                   || xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                   || xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                   || xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "a" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                  || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow
                  || xyzCubeTypes == XyzCubeTypes.WhiteOrangeGreen
                  || xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue
                   )
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "b" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueYellowOrange
                   || xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                   || xyzCubeTypes == XyzCubeTypes.WhiteBlueOrange
                   || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "c" : "C";
                }
            }
            throw new Exception("GetStickerAbbreviation Error");
        }


        public XyzCubeTypes GetXyzCubeType(CubeModel cube)
        {

            if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Blue
                 && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Orange
                 && cube.Front.StickerFront.StickerColorType == StickerColorTypes.White)
            {
                return XyzCubeTypes.BlueOrangeWhite;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Blue
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Red
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Yellow)
            {
                return XyzCubeTypes.BlueRedYellow;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Blue
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.White
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Red)
            {
                return XyzCubeTypes.BlueWhiteRed;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Blue
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Yellow
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Orange)
            {
                return XyzCubeTypes.BlueYellowOrange;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Green
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Orange
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Yellow)
            {
                return XyzCubeTypes.GreenOrangeYellow;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Green
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Red
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.White)
            {
                return XyzCubeTypes.GreenRedWhite;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Green
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.White
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Orange)
            {
                return XyzCubeTypes.GreenWhiteOrange;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Green
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Yellow
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Red)
            {
                return XyzCubeTypes.GreenYellowRed;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Orange
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Blue
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Yellow)
            {
                return XyzCubeTypes.OrangeBlueYellow;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Orange
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Green
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.White)
            {
                return XyzCubeTypes.OrangeGreenWhite;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Orange
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.White
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Blue)
            {
                return XyzCubeTypes.OrangeWhiteBlue;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Orange
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Yellow
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Green)
            {
                return XyzCubeTypes.OrangeYellowGreen;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Red
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Blue
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.White)
            {
                return XyzCubeTypes.RedBlueWhite;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Red
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Green
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Yellow)
            {
                return XyzCubeTypes.RedGreenYellow;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Red
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.White
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Green)
            {
                return XyzCubeTypes.RedWhiteGreen;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Red
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Yellow
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Blue)
            {
                return XyzCubeTypes.RedYellowBlue;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.White
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Blue
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Orange)
            {
                return XyzCubeTypes.WhiteBlueOrange;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.White
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Green
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Red)
            {
                return XyzCubeTypes.WhiteGreenRed;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.White
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Orange
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Green)
            {
                return XyzCubeTypes.WhiteOrangeGreen;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.White
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Red
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Blue)
            {
                return XyzCubeTypes.WhiteRedBlue;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Yellow
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Blue
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Red)
            {
                return XyzCubeTypes.YellowBlueRed;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Yellow
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Green
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Orange)
            {
                return XyzCubeTypes.YellowGreenOrange;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Yellow
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Orange
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Blue)
            {
                return XyzCubeTypes.YellowOrangeBlue;
            }
            else if (cube.East.StickerEast.StickerColorType == StickerColorTypes.Yellow
              && cube.North.StickerNorth.StickerColorType == StickerColorTypes.Red
              && cube.Front.StickerFront.StickerColorType == StickerColorTypes.Green)
            {
                return XyzCubeTypes.YellowRedGreen;
            }
            else
            {
                throw new Exception("GetXyzCubeType Color combination not found");
            }
        }

        public StickerColorTypes GetStickerColorType(String stickerColorType)
        {
            switch (stickerColorType)
            {
                case "B":
                    return StickerColorTypes.Blue;
                case "G":
                    return StickerColorTypes.Green;
                case "O":
                    return StickerColorTypes.Orange;
                case "R":
                    return StickerColorTypes.Red;
                case "W":
                    return StickerColorTypes.White;
                case "Y":
                    return StickerColorTypes.Yellow;
                default:
                    return StickerColorTypes.None;
            }
        }

    }
}
