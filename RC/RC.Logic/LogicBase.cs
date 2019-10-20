using RC.Common.Enumerations;
using RC.Common.Model;
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
            return GetStickerAbbreviation(sticker.StickerColorType).ToString();
        }

        public Char GetStickerAbbreviation(StickerColorTypes stickerColor)
        {
            switch (stickerColor)
            {
                case StickerColorTypes.Blue:
                    return 'B';
                case StickerColorTypes.Green:
                    return 'G';
                case StickerColorTypes.Orange:
                    return 'O';
                case StickerColorTypes.Red:
                    return 'R';
                case StickerColorTypes.White:
                    return 'W';
                case StickerColorTypes.Yellow:
                    return 'Y';
                default:
                    return '#';
            }
        }

        public String GetStickerAbbreviation(Char sticker)
        {
            //TODO: This needs to take current colors into account
            switch (sticker)
            {
                case 'A':
                    return "O";
                case 'B':
                    return "W";
                case 'C':
                    return "B";
                case 'X':
                    return "R";
                case 'Y':
                    return "Y";
                case 'Z':
                    return "G";
                default:
                    return sticker.ToString();
            }
        }

        public String GetDetailedCubeState(CubeModel cube)
        {
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE

            String east =   $"{PositionTypes.EFNE}:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerEast) }|{PositionTypes.ENE}:{ GetStickerAbbreviation(cube.NorthEast.StickerEast)  }|{PositionTypes.EBNE}:{ GetStickerAbbreviation(cube.BackNorthEast.StickerEast)  }|{PositionTypes.EFE}:{ GetStickerAbbreviation(cube.FrontEast.StickerEast) }|{PositionTypes.EE}:{ GetStickerAbbreviation(cube.East.StickerEast)  }|{PositionTypes.EBE}:{ GetStickerAbbreviation(cube.BackEast.StickerEast)  }|{PositionTypes.EFSE}:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerEast) }|{PositionTypes.ESE}:{ GetStickerAbbreviation(cube.SouthEast.StickerEast)  }|{PositionTypes.EBSE}:{ GetStickerAbbreviation(cube.BackSouthEast.StickerEast)}";
            String north =  $"{PositionTypes.NBNW}:{ GetStickerAbbreviation(cube.BackNorthWest.StickerNorth) }|{PositionTypes.NBN}:{ GetStickerAbbreviation(cube.BackNorth.StickerNorth) }|{PositionTypes.NBNE}:{ GetStickerAbbreviation(cube.BackNorthEast.StickerNorth) }|{PositionTypes.NNW}:{ GetStickerAbbreviation(cube.NorthWest.StickerNorth)}|{PositionTypes.NN}:{ GetStickerAbbreviation(cube.North.StickerNorth)}|{PositionTypes.NNE}:{ GetStickerAbbreviation(cube.NorthEast.StickerNorth)}|{PositionTypes.NFNW}:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerNorth)}|{PositionTypes.NFN}:{ GetStickerAbbreviation(cube.FrontNorth.StickerNorth)}|{PositionTypes.NFNE}:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerNorth)}";
            String front =  $"{PositionTypes.FFNW}:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerFront)}|{PositionTypes.FFN}:{ GetStickerAbbreviation(cube.FrontNorth.StickerFront)}|{PositionTypes.FFNE}:{ GetStickerAbbreviation(cube.FrontNorthEast.StickerFront)}|{PositionTypes.FFW}:{ GetStickerAbbreviation(cube.FrontWest.StickerFront)}|{PositionTypes.FF}:{ GetStickerAbbreviation(cube.Front.StickerFront)}|{PositionTypes.FFE}:{ GetStickerAbbreviation(cube.FrontEast.StickerFront)}|{PositionTypes.FFSW}:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerFront)}|{PositionTypes.FFS}:{ GetStickerAbbreviation(cube.FrontSouth.StickerFront)}|{PositionTypes.FFSE}:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerFront)}";
            String west =   $"{PositionTypes.WBNW}:{ GetStickerAbbreviation(cube.BackNorthWest.StickerWest)  }|{PositionTypes.WNW}:{ GetStickerAbbreviation(cube.NorthWest.StickerWest)  }|{PositionTypes.WFNW}:{ GetStickerAbbreviation(cube.FrontNorthWest.StickerWest) }|{PositionTypes.WBW}:{ GetStickerAbbreviation(cube.BackWest.StickerWest)  }|{PositionTypes.WW}:{ GetStickerAbbreviation(cube.West.StickerWest)  }|{PositionTypes.WFW}:{ GetStickerAbbreviation(cube.FrontWest.StickerWest) }|{PositionTypes.WBSW}:{ GetStickerAbbreviation(cube.BackSouthWest.StickerWest)  }|{PositionTypes.WSW}:{ GetStickerAbbreviation(cube.SouthWest.StickerWest)  }|{PositionTypes.WFSW}:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerWest)}";
            String south =  $"{PositionTypes.SFSW}:{ GetStickerAbbreviation(cube.FrontSouthWest.StickerSouth)}|{PositionTypes.SFS}:{ GetStickerAbbreviation(cube.FrontSouth.StickerSouth)}|{PositionTypes.SFSE}:{ GetStickerAbbreviation(cube.FrontSouthEast.StickerSouth)}|{PositionTypes.SSW}:{ GetStickerAbbreviation(cube.SouthWest.StickerSouth)}|{PositionTypes.SS}:{ GetStickerAbbreviation(cube.South.StickerSouth)}|{PositionTypes.SSE}:{ GetStickerAbbreviation(cube.SouthEast.StickerSouth)}|{PositionTypes.SBSW}:{ GetStickerAbbreviation(cube.BackSouthWest.StickerSouth) }|{PositionTypes.SBS}:{ GetStickerAbbreviation(cube.BackSouth.StickerSouth) }|{PositionTypes.SBSE}:{ GetStickerAbbreviation(cube.BackSouthEast.StickerSouth)}";
            String back =   $"{PositionTypes.BBNE}:{ GetStickerAbbreviation(cube.BackNorthEast.StickerBack)  }|{PositionTypes.BBN}:{ GetStickerAbbreviation(cube.BackNorth.StickerBack)  }|{PositionTypes.BBNW}:{ GetStickerAbbreviation(cube.BackNorthWest.StickerBack)  }|{PositionTypes.BBE}:{ GetStickerAbbreviation(cube.BackEast.StickerBack)  }|{PositionTypes.BB}:{ GetStickerAbbreviation(cube.Back.StickerBack)  }|{PositionTypes.BBW}:{ GetStickerAbbreviation(cube.BackWest.StickerBack)  }|{PositionTypes.BBSE}:{ GetStickerAbbreviation(cube.BackSouthEast.StickerBack)  }|{PositionTypes.BBS}:{ GetStickerAbbreviation(cube.BackSouth.StickerBack)  }|{PositionTypes.BBSW}:{ GetStickerAbbreviation(cube.BackSouthWest.StickerBack)}";

            return $"{east},{north},{front},{west},{south},{back}";
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
                    return (stickerColorType == StickerColorTypes.White) ? "A" : "X";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                   || xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                   || xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                   || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                   )
                {
                    return (stickerColorType == StickerColorTypes.White) ? "B" : "Y";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                  || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                  || xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                  || xyzCubeTypes == XyzCubeTypes.RedBlueWhite)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "C" : "Z";
                }
                else if (xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue
                    || xyzCubeTypes == XyzCubeTypes.YellowRedGreen
                    || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange
                    || xyzCubeTypes == XyzCubeTypes.YellowBlueRed)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "X" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                   || xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen
                   || xyzCubeTypes == XyzCubeTypes.BlueYellowOrange
                   || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                   )
                {
                    return (stickerColorType == StickerColorTypes.White) ? "Y" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                  || xyzCubeTypes == XyzCubeTypes.RedGreenYellow
                  || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow
                  || xyzCubeTypes == XyzCubeTypes.BlueRedYellow)
                {
                    return (stickerColorType == StickerColorTypes.White) ? "Z" : "C";
                }

            }
            else if (stickerColorType == StickerColorTypes.Blue || stickerColorType == StickerColorTypes.Green)
            {

                if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                    || xyzCubeTypes == XyzCubeTypes.BlueRedYellow
                    || xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                    || xyzCubeTypes == XyzCubeTypes.BlueYellowOrange)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "A" : "X";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                   || xyzCubeTypes == XyzCubeTypes.RedBlueWhite
                   || xyzCubeTypes == XyzCubeTypes.WhiteBlueOrange
                   || xyzCubeTypes == XyzCubeTypes.YellowBlueRed
                   )
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "B" : "Y";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                  || xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                  || xyzCubeTypes == XyzCubeTypes.WhiteRedBlue
                  || xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "C" : "Z";
                }
                else if (xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                 || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                 || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                 || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "X" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                  || xyzCubeTypes == XyzCubeTypes.RedGreenYellow
                  || xyzCubeTypes == XyzCubeTypes.WhiteGreenRed
                  || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange
                   )
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "Y" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen
                   || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                   || xyzCubeTypes == XyzCubeTypes.WhiteOrangeGreen
                   || xyzCubeTypes == XyzCubeTypes.YellowRedGreen)
                {
                    return (stickerColorType == StickerColorTypes.Blue) ? "Z" : "C";
                }
            }
            else if (stickerColorType == StickerColorTypes.Red || stickerColorType == StickerColorTypes.Orange)
            {

                if (xyzCubeTypes == XyzCubeTypes.RedYellowBlue
                    || xyzCubeTypes == XyzCubeTypes.RedWhiteGreen
                    || xyzCubeTypes == XyzCubeTypes.RedBlueWhite
                    || xyzCubeTypes == XyzCubeTypes.RedGreenYellow)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "A" : "X";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueRedYellow
                   || xyzCubeTypes == XyzCubeTypes.GreenRedWhite
                   || xyzCubeTypes == XyzCubeTypes.WhiteRedBlue
                   || xyzCubeTypes == XyzCubeTypes.YellowRedGreen)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "B" : "Y";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueWhiteRed
                  || xyzCubeTypes == XyzCubeTypes.GreenYellowRed
                  || xyzCubeTypes == XyzCubeTypes.WhiteGreenRed
                  || xyzCubeTypes == XyzCubeTypes.YellowBlueRed)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "C" : "Z";
                }
                else if (xyzCubeTypes == XyzCubeTypes.OrangeBlueYellow
                   || xyzCubeTypes == XyzCubeTypes.OrangeGreenWhite
                   || xyzCubeTypes == XyzCubeTypes.OrangeWhiteBlue
                   || xyzCubeTypes == XyzCubeTypes.OrangeYellowGreen)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "X" : "A";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueOrangeWhite
                  || xyzCubeTypes == XyzCubeTypes.GreenOrangeYellow
                  || xyzCubeTypes == XyzCubeTypes.WhiteOrangeGreen
                  || xyzCubeTypes == XyzCubeTypes.YellowOrangeBlue
                   )
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "Y" : "B";
                }
                else if (xyzCubeTypes == XyzCubeTypes.BlueYellowOrange
                   || xyzCubeTypes == XyzCubeTypes.GreenWhiteOrange
                   || xyzCubeTypes == XyzCubeTypes.WhiteBlueOrange
                   || xyzCubeTypes == XyzCubeTypes.YellowGreenOrange)
                {
                    return (stickerColorType == StickerColorTypes.Red) ? "Z" : "C";
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

        public StickerColorTypes GetStickerColorType(String rawStickerColor)
        {
            return this.GetStickerColorType(rawStickerColor.ToCharArray()[0]);
        }

        public StickerColorTypes GetStickerColorType(Char rawStickerColor)
        {
            switch (rawStickerColor)
            {
                case 'B':
                    return StickerColorTypes.Blue;
                case 'G':
                    return StickerColorTypes.Green;
                case 'O':
                    return StickerColorTypes.Orange;
                case 'R':
                    return StickerColorTypes.Red;
                case 'W':
                    return StickerColorTypes.White;
                case 'Y':
                    return StickerColorTypes.Yellow;
                default:
                    return StickerColorTypes.None;
            }
        }

        public String Convert(MoveTypes move)
        {
            String result;

            switch (move)
            {
                case MoveTypes.Up:
                    result = "U";
                    break;
                case MoveTypes.Equator:
                    result = "E";
                    break;
                case MoveTypes.Down:
                    result = "D";
                    break;
                case MoveTypes.Right:
                    result = "R";
                    break;
                case MoveTypes.MeridianPrime:
                    result = "M";
                    break;
                case MoveTypes.Left:
                    result = "L";
                    break;
                case MoveTypes.Front:
                    result = "F";
                    break;
                case MoveTypes.Meridian90th:
                    result = "S";
                    break;
                case MoveTypes.Back:
                    result = "B";
                    break;
                case MoveTypes.Up2:
                    result = "U2";
                    break;
                case MoveTypes.Equator2:
                    result = "E2";
                    break;
                case MoveTypes.Down2:
                    result = "D2";
                    break;
                case MoveTypes.Right2:
                    result = "R2";
                    break;
                case MoveTypes.MeridianPrime2:
                    result = "M2";
                    break;
                case MoveTypes.Left2:
                    result = "L2";
                    break;
                case MoveTypes.Front2:
                    result = "F2";
                    break;
                case MoveTypes.Meridian90th2:
                    result = "S2";
                    break;
                case MoveTypes.Back2:
                    result = "B2";
                    break;
                case MoveTypes.UpReverse:
                    result = "U'";
                    break;
                case MoveTypes.EquatorReverse:
                    result = "E'";
                    break;
                case MoveTypes.DownReverse:
                    result = "D'";
                    break;
                case MoveTypes.RightReverse:
                    result = "R'";
                    break;
                case MoveTypes.MeridianPrimeReverse:
                    result = "M'";
                    break;
                case MoveTypes.LeftReverse:
                    result = "L'";
                    break;
                case MoveTypes.FrontReverse:
                    result = "F'";
                    break;
                case MoveTypes.Meridian90thReverse:
                    result = "S'";
                    break;
                case MoveTypes.BackReverse:
                    result = "B'";
                    break;
                default:
                    throw new Exception("Unkown Move");
            }
            return result;
        }

        public MoveTypes Reverse(MoveTypes move)
        {
            MoveTypes result;
            switch (move)
            {
                case MoveTypes.UpReverse:
                    result = MoveTypes.Up;
                    break;
                case MoveTypes.EquatorReverse:
                    result = MoveTypes.Equator;
                    break;
                case MoveTypes.DownReverse:
                    result = MoveTypes.Down;
                    break;
                case MoveTypes.RightReverse:
                    result = MoveTypes.Right;
                    break;
                case MoveTypes.MeridianPrimeReverse:
                    result = MoveTypes.MeridianPrime;
                    break;
                case MoveTypes.LeftReverse:
                    result = MoveTypes.Left;
                    break;
                case MoveTypes.FrontReverse:
                    result = MoveTypes.Front;
                    break;
                case MoveTypes.Meridian90thReverse:
                    result = MoveTypes.Meridian90th;
                    break;
                case MoveTypes.BackReverse:
                    result = MoveTypes.Back;
                    break;
                case MoveTypes.Up2:
                    result = MoveTypes.Up2;
                    break;
                case MoveTypes.Equator2:
                    result = MoveTypes.Equator2;
                    break;
                case MoveTypes.Down2:
                    result = MoveTypes.Down2;
                    break;
                case MoveTypes.Right2:
                    result = MoveTypes.Right2;
                    break;
                case MoveTypes.MeridianPrime2:
                    result = MoveTypes.MeridianPrime2;
                    break;
                case MoveTypes.Left2:
                    result = MoveTypes.Left2;
                    break;
                case MoveTypes.Front2:
                    result = MoveTypes.Front2;
                    break;
                case MoveTypes.Meridian90th2:
                    result = MoveTypes.Meridian90th2;
                    break;
                case MoveTypes.Back2:
                    result = MoveTypes.Back2;
                    break;
                case MoveTypes.Up:
                    result = MoveTypes.UpReverse;
                    break;
                case MoveTypes.Equator:
                    result = MoveTypes.EquatorReverse;
                    break;
                case MoveTypes.Down:
                    result = MoveTypes.DownReverse;
                    break;
                case MoveTypes.Right:
                    result = MoveTypes.RightReverse;
                    break;
                case MoveTypes.MeridianPrime:
                    result = MoveTypes.MeridianPrimeReverse;
                    break;
                case MoveTypes.Left:
                    result = MoveTypes.LeftReverse;
                    break;
                case MoveTypes.Front:
                    result = MoveTypes.FrontReverse;
                    break;
                case MoveTypes.Meridian90th:
                    result = MoveTypes.Meridian90thReverse;
                    break;
                case MoveTypes.Back:
                    result = MoveTypes.BackReverse;
                    break;
                default:
                    throw new Exception("Unkown Move");
            }
            return result;
        }

        public MoveTypes Convert(String move)
        {
            MoveTypes result;
            switch (move)
            {
                case "U":
                    result = MoveTypes.Up;
                    break;
                case "E":
                    result = MoveTypes.Equator;
                    break;
                case "D":
                    result = MoveTypes.Down;
                    break;
                case "R":
                    result = MoveTypes.Right;
                    break;
                case "M":
                    result = MoveTypes.MeridianPrime;
                    break;
                case "L":
                    result = MoveTypes.Left;
                    break;
                case "F":
                    result = MoveTypes.Front;
                    break;
                case "S":
                    result = MoveTypes.Meridian90th;
                    break;
                case "B":
                    result = MoveTypes.Back;
                    break;
                case "U2":
                    result = MoveTypes.Up2;
                    break;
                case "E2":
                    result = MoveTypes.Equator2;
                    break;
                case "D2":
                    result = MoveTypes.Down2;
                    break;
                case "R2":
                    result = MoveTypes.Right2;
                    break;
                case "M2":
                    result = MoveTypes.MeridianPrime2;
                    break;
                case "L2":
                    result = MoveTypes.Left2;
                    break;
                case "F2":
                    result = MoveTypes.Front2;
                    break;
                case "S2":
                    result = MoveTypes.Meridian90th2;
                    break;
                case "B2":
                    result = MoveTypes.Back2;
                    break;
                case "U'":
                    result = MoveTypes.UpReverse;
                    break;
                case "E'":
                    result = MoveTypes.EquatorReverse;
                    break;
                case "D'":
                    result = MoveTypes.DownReverse;
                    break;
                case "R'":
                    result = MoveTypes.RightReverse;
                    break;
                case "M'":
                    result = MoveTypes.MeridianPrimeReverse;
                    break;
                case "L'":
                    result = MoveTypes.LeftReverse;
                    break;
                case "F'":
                    result = MoveTypes.FrontReverse;
                    break;
                case "S'":
                    result = MoveTypes.Meridian90thReverse;
                    break;
                case "B'":
                    result = MoveTypes.BackReverse;
                    break;
                default:
                    throw new Exception("Unkown Move");
            }
            return result;
        }

    }
}
