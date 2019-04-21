using System;
using System.Collections.Generic;
using RC.Enumerations;
using RC.Interfaces;

namespace RC.Model
{
    public abstract class PieceModelBase
    {
        public PieceModelBase()
        {

        }

        public HashSet<StickerModelBase> Stickers { get; private set; } = new HashSet<StickerModelBase>();


        public StickerColorTypes GetNorthStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Red;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount"); 
            }

            return result;
        }

        public StickerColorTypes GetEastStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Yellow;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount");
            }

            return result;
        }

        public StickerColorTypes GetFrontStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Green;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount");
            }

            return result;
        }

        public StickerColorTypes GetSouthStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Orange;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount");
            }

            return result;
        }

        public StickerColorTypes GetWestStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Yellow;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount");
            }

            return result;
        }

        public StickerColorTypes GetBackStickerColorType(XyzCubeTypes patternCubeType)
        {
            StickerColorTypes result;

            if (patternCubeType == XyzCubeTypes.BlueOrangeWhite)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.BlueRedYellow)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.BlueWhiteRed)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.BlueYellowOrange)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.GreenOrangeYellow)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.GreenRedWhite)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.GreenWhiteOrange)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.GreenYellowRed)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeBlueYellow)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeGreenWhite)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeWhiteBlue)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.OrangeYellowGreen)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.RedBlueWhite)
            {
                result = StickerColorTypes.Yellow;
            }
            else if (patternCubeType == XyzCubeTypes.RedGreenYellow)
            {
                result = StickerColorTypes.White;
            }
            else if (patternCubeType == XyzCubeTypes.RedWhiteGreen)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.RedYellowBlue)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteBlueOrange)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteGreenRed)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteOrangeGreen)
            {
                result = StickerColorTypes.Blue;
            }
            else if (patternCubeType == XyzCubeTypes.WhiteRedBlue)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.YellowBlueRed)
            {
                result = StickerColorTypes.Orange;
            }
            else if (patternCubeType == XyzCubeTypes.YellowGreenOrange)
            {
                result = StickerColorTypes.Red;
            }
            else if (patternCubeType == XyzCubeTypes.YellowOrangeBlue)
            {
                result = StickerColorTypes.Green;
            }
            else if (patternCubeType == XyzCubeTypes.YellowRedGreen)
            {
                result = StickerColorTypes.Blue;
            }
            else
            {
                throw new Exception($"GetNorthStickerColorType {patternCubeType} not fount");
            }

            return result;
        }

        public override string ToString()
        {
            string stickerString = String.Empty;
            foreach (var s in this.Stickers)
            {
                stickerString += s.ToString() + " ";
            }
            return stickerString;
        }

        
    }
}
