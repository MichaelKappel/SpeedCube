using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;
using RC.Model.Pieces;
using RC.Model.Slots;
using RC.Model.Sots;
using RC.Model.Stickers;

namespace RC.Logic
{
    public class CubeLogic
    {
        public CubeLogic()
        {

        }

        public void VerifyPieceInSlot(SlotModelBase<PieceSideModelBase> slot)
        {
            StickerModelBase[] slotStickers = slot.GetStickers();
            if (slotStickers.Length != slot.Piece.Stickers.Count)
            {
                throw new Exception("Side Stickers Wrong");
            }

            foreach (var sticker in slot.Piece.Stickers)
            {
                if (!slotStickers.Contains(sticker))
                {
                    throw new Exception("Side Sticker Wrong");
                }
            }
        }

        public void VerifyPieceInSlot(SlotModelBase<PieceCornerModelBase> slot)
        {
            StickerModelBase[] slotStickers = slot.GetStickers();
            if (slotStickers.Length != slot.Piece.Stickers.Count)
            {
                throw new Exception("Corner Stickers Wrong");
            }

            foreach (var sticker in slot.Piece.Stickers)
            {
                if (!slotStickers.Contains(sticker))
                {
                    throw new Exception("Corner Sticker Wrong");
                }
            }
        }

        public void VerifyAllPieces(CubeModel cube)
        {
            this.VerifyPieceInSlot(cube.FrontNorth);
            this.VerifyPieceInSlot(cube.FrontEast);
            this.VerifyPieceInSlot(cube.FrontSouth);
            this.VerifyPieceInSlot(cube.FrontWest);


            this.VerifyPieceInSlot(cube.FrontNorthEast);
            this.VerifyPieceInSlot(cube.FrontSouthEast);
            this.VerifyPieceInSlot(cube.FrontSouthWest);
            this.VerifyPieceInSlot(cube.FrontNorthWest);


            this.VerifyPieceInSlot(cube.NorthEast);
            this.VerifyPieceInSlot(cube.SouthEast);
            this.VerifyPieceInSlot(cube.SouthWest);
            this.VerifyPieceInSlot(cube.NorthWest);

            this.VerifyPieceInSlot(cube.BackNorth);
            this.VerifyPieceInSlot(cube.BackEast);
            this.VerifyPieceInSlot(cube.BackSouth);
            this.VerifyPieceInSlot(cube.BackWest);

            this.VerifyPieceInSlot(cube.BackNorthEast);
            this.VerifyPieceInSlot(cube.BackSouthEast);
            this.VerifyPieceInSlot(cube.BackSouthWest);
            this.VerifyPieceInSlot(cube.BackNorthWest);

            String patten = this.GetCubePattern(cube);

            if (patten.ToArray().Count(x => x == 'A') > 9
                 || patten.ToArray().Count(x => x == 'B') > 9
                 || patten.ToArray().Count(x => x == 'C') > 9
                 || patten.ToArray().Count(x => x == 'a') > 9
                 || patten.ToArray().Count(x => x == 'b') > 9
                 || patten.ToArray().Count(x => x == 'c') > 9)
            {
                throw new Exception("Invalid GetCubePattern Result: " + patten);
            }
        }


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
                case 'C':
                    return "B";
                case 'c':
                    return "G";
                case 'A':
                    return "O";
                case 'a':
                    return "R";
                case 'B':
                    return "W";
                case 'b':
                    return "Y";
                default:
                    return "#";
            }
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

        internal string GetCubePattern(CubeModel cube)
        {
            String north = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.North.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerNorth.StickerColorType)}";
            String south = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.South.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerSouth.StickerColorType)}";
            String front = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.Front.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerFront.StickerColorType)}";
            String back = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.Back.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerBack.StickerColorType)}";
            String west = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.West.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerWest.StickerColorType)}";
            String east = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.East.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerEast.StickerColorType)}";

            var result = $"{north}{south}{front}{back}{west}{east}";

            if (result.ToArray().Count(x => x == 'A') > 9
                || result.ToArray().Count(x => x == 'B') > 9
                || result.ToArray().Count(x => x == 'C') > 9
                || result.ToArray().Count(x => x == 'a') > 9
                || result.ToArray().Count(x => x == 'b') > 9
                || result.ToArray().Count(x => x == 'c') > 9)
            {
                throw new Exception("Invalid GetCubePattern Result: " + result);
            }

            return result;
        }

        //internal XyzCubeTypes GetXyzCubeType(string cubePattern)
        //{

        //    var stickers = cubePattern.ToCharArray();

        //    Char A = stickers[4];
        //    Char a = stickers[13];
        //    Char B = stickers[22]; 
        //    Char b = stickers[31]; 
        //    Char C = stickers[40];
        //    Char c = stickers[49];



        //    if (A == 'A')
        //    {
        //        return XyzCubeTypes.
        //    }
        //}

        public string[] GetCubeFacePatterns(CubeModel cube)
        {
            String north = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.North.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerNorth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerNorth.StickerColorType)}";
            String south = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.South.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerSouth.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerSouth.StickerColorType)}";
            String front = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.Front.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerFront.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerFront.StickerColorType)}";
            String back = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.Back.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerBack.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerBack.StickerColorType)}";
            String west = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.West.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerWest.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerWest.StickerColorType)}";
            String east = $"{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.East.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerEast.StickerColorType)}{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerEast.StickerColorType)}";

            return new string[] { north, south, front, back, west, east };
        }

        public String[] GetAllCubePatterns(String original)
        {
            var resultWithDups = new List<String>() { original };

            String[] shiftedPatterns = this.ShiftSwitchAndMirrorCubePatterns(original);
            foreach (var shiftedPattern in shiftedPatterns)
            {
                foreach (var rotatedPattern in this.RotateCubePatterns(shiftedPattern))
                {
                    resultWithDups.Add(rotatedPattern);
                    resultWithDups.Add(this.ReversePattern(rotatedPattern));

                    var reversedRotatedPattern = new String(shiftedPattern.Reverse().ToArray());
                    resultWithDups.Add(reversedRotatedPattern);
                    resultWithDups.Add(this.ReversePattern(reversedRotatedPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();

            return results;
        }

        public String[] GetAllFacePatterns(String original)
        {
            var resultWithDups = new List<String>();
            String[] shiftedPatterns = this.ShiftSwitchAndMirrorFacePatterns(original);
            foreach (var shiftedPattern in shiftedPatterns)
            {
                foreach (var rotatedPattern in this.RotateFacePattern(shiftedPattern))
                {
                    resultWithDups.Add(rotatedPattern);
                    resultWithDups.Add(this.ReversePattern(rotatedPattern));

                    var reversedRotatedPattern = new String(shiftedPattern.Reverse().ToArray());
                    resultWithDups.Add(reversedRotatedPattern);
                    resultWithDups.Add(this.ReversePattern(reversedRotatedPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();

            return results;
        }

        public String[] ShiftSwitchAndMirrorCubePatterns(String original)
        {
            var resultWithDups = new List<String>();

            foreach (var shiftedPattern in ShiftPatternComprehensive(original))
            {
                foreach (var switchedOutPattern in this.SwitchOutPatternComprehensive(shiftedPattern))
                {
                    resultWithDups.AddRange(this.GetCubePatternMirrors(switchedOutPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();
            return results;
        }

        public String[] ShiftSwitchAndMirrorFacePatterns(String original)
        {
            var resultWithDups = new List<String>();

            foreach (var shiftedPattern in ShiftPatternComprehensive(original))
            {
                foreach (var switchedOutPattern in this.SwitchOutPatternComprehensive(shiftedPattern))
                {
                    resultWithDups.AddRange(this.GetFacePatternMirrors(switchedOutPattern));
                }
            }

            String[] results = resultWithDups.Distinct().ToArray();
            return results;
        }

        public String[] GetFacePatternMirrors(String original)
        {
            var originalStickers = original.ToCharArray();

            var topToBottom = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            topToBottom += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            topToBottom += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var leftToRight = $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";
            leftToRight += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            leftToRight += $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";

            var leftToRightAndTopToBottom = $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";
            leftToRightAndTopToBottom += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            leftToRightAndTopToBottom += $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";

            return new string[] { original, topToBottom, leftToRight, leftToRightAndTopToBottom };
        }

        public String GetCubePatternNorthBackToFront(String original)
        {
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";
            north += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            north += $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";

            var south = $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";
            south += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            south += $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";

            var front = $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";
            front += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            front += $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";

            var back = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            back += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            back += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var west = $"{originalStickers[38]}{originalStickers[37]}{originalStickers[36]}";
            west += $"{originalStickers[41]}{originalStickers[40]}{originalStickers[39]}";
            west += $"{originalStickers[44]}{originalStickers[43]}{originalStickers[42]}";

            var east = $"{originalStickers[47]}{originalStickers[46]}{originalStickers[45]}";
            east += $"{originalStickers[50]}{originalStickers[49]}{originalStickers[48]}";
            east += $"{originalStickers[53]}{originalStickers[52]}{originalStickers[51]}";


            return $"{north}{south}{front}{back}{west}{east}";
        }

        public String GetCubePatternNorthNorthEastToWest(String original)
        {
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

            var originalStickers = original.ToCharArray();
            var north = $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";
            north += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            north += $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";

            var south = $"{originalStickers[11]}{originalStickers[10]}{originalStickers[9]}";
            south += $"{originalStickers[14]}{originalStickers[13]}{originalStickers[12]}";
            south += $"{originalStickers[17]}{originalStickers[16]}{originalStickers[15]}";

            var front = $"{originalStickers[20]}{originalStickers[19]}{originalStickers[18]}";
            front += $"{originalStickers[23]}{originalStickers[22]}{originalStickers[21]}";
            front += $"{originalStickers[26]}{originalStickers[25]}{originalStickers[24]}";

            var back = $"{originalStickers[29]}{originalStickers[28]}{originalStickers[27]}";
            back += $"{originalStickers[32]}{originalStickers[31]}{originalStickers[30]}";
            back += $"{originalStickers[35]}{originalStickers[34]}{originalStickers[33]}";

            var west = $"{originalStickers[47]}{originalStickers[46]}{originalStickers[45]}";
            west += $"{originalStickers[50]}{originalStickers[49]}{originalStickers[48]}";
            west += $"{originalStickers[53]}{originalStickers[52]}{originalStickers[51]}";

            var east = $"{originalStickers[36]}{originalStickers[37]}{originalStickers[38]}";
            east += $"{originalStickers[39]}{originalStickers[40]}{originalStickers[41]}";
            east += $"{originalStickers[42]}{originalStickers[43]}{originalStickers[44]}";


            return $"{north}{south}{front}{back}{west}{east}";
        }

        public String[] GetCubePatternMirrors(String original)
        {
            String[] rotations = this.RotateCubePatterns(original);

            var rotationMirrors = new List<String>();

            foreach (var rotation in rotations)
            {
                rotationMirrors.Add(this.GetCubePatternNorthNorthEastToWest(rotation));
                rotationMirrors.Add(this.GetCubePatternNorthBackToFront(rotation));
                rotationMirrors.Add(this.GetCubePatternNorthBackToFront(rotation));
            }

            var rotationMirrorRotations = new List<String>();
            foreach (var rotationMirror in rotationMirrors)
            {
                rotationMirrorRotations.AddRange(this.RotateCubePatterns(rotationMirror));
            }

            String[] results = rotationMirrorRotations.Distinct().ToArray();
            return results;
        }

        public String[] RotateCubePatterns(String original)
        {
            var results = new String[] {
                original,
                this.RotateCubePatternNorthClockwise(original),
                this.RotateCubePatternNorthClockwise(original),
                this.RotateCubePatternWestClockwise(original),
                this.RotateCubePatternNorthClockwise(this.RotateCubePatternNorthClockwise(original)),
                this.RotateCubePatternWestClockwise(this.RotateCubePatternWestClockwise(original)),
                this.RotateCubePatternNorthClockwise(this.RotateCubePatternWestClockwise(original)),
                this.RotateCubePatternWestClockwise(this.RotateCubePatternNorthClockwise(original))
                };

            return results;
        }

        public String RotateCubePatternNorthClockwise(String original)
        {
            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[6]}{originalStickers[3]}{originalStickers[0]}";
            north += $"{originalStickers[7]}{originalStickers[4]}{originalStickers[1]}";
            north += $"{originalStickers[8]}{originalStickers[5]}{originalStickers[2]}";

            var south = $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";
            south += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            south += $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";

            var front = $"{originalStickers[47]}{originalStickers[46]}{originalStickers[45]}";
            front += $"{originalStickers[50]}{originalStickers[49]}{originalStickers[48]}";
            front += $"{originalStickers[53]}{originalStickers[52]}{originalStickers[51]}";

            var back = $"{originalStickers[38]}{originalStickers[37]}{originalStickers[36]}";
            back += $"{originalStickers[41]}{originalStickers[40]}{originalStickers[39]}";
            back += $"{originalStickers[44]}{originalStickers[43]}{originalStickers[42]}";

            var west = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            west += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            west += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var east = $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";
            east += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            east += $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";

            var clockwise = $"{north}{south}{front}{back}{west}{east}";

            return clockwise;
        }


        public String RotateCubePatternWestClockwise(String original)
        {
            var originalStickers = original.ToCharArray();

            var north = $"{originalStickers[36]}{originalStickers[37]}{originalStickers[38]}";
            north += $"{originalStickers[39]}{originalStickers[40]}{originalStickers[41]}";
            north += $"{originalStickers[42]}{originalStickers[43]}{originalStickers[44]}";

            var south = $"{originalStickers[45]}{originalStickers[46]}{originalStickers[47]}";
            south += $"{originalStickers[48]}{originalStickers[49]}{originalStickers[50]}";
            south += $"{originalStickers[51]}{originalStickers[52]}{originalStickers[53]}";

            var front = $"{originalStickers[24]}{originalStickers[19]}{originalStickers[18]}";
            front += $"{originalStickers[25]}{originalStickers[22]}{originalStickers[19]}";
            front += $"{originalStickers[26]}{originalStickers[23]}{originalStickers[20]}";

            var back = $"{originalStickers[33]}{originalStickers[30]}{originalStickers[27]}";
            back += $"{originalStickers[34]}{originalStickers[31]}{originalStickers[28]}";
            back += $"{originalStickers[35]}{originalStickers[32]}{originalStickers[27]}";

            var west = $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";
            west += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            west += $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";

            var east = $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";
            east += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            east += $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";


            var clockwise = $"{north}{south}{front}{back}{west}{east}";

            return clockwise;
        }

        public String GetCubePattern(String[] stickers)
        {
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

            String[] originalStickers = stickers;

            var north = $"{originalStickers[0]}{originalStickers[1]}{originalStickers[2]}";
            north += $"{originalStickers[3]}{originalStickers[4]}{originalStickers[5]}";
            north += $"{originalStickers[6]}{originalStickers[7]}{originalStickers[8]}";

            var south = $"{originalStickers[9]}{originalStickers[10]}{originalStickers[11]}";
            south += $"{originalStickers[12]}{originalStickers[13]}{originalStickers[14]}";
            south += $"{originalStickers[15]}{originalStickers[16]}{originalStickers[17]}";

            var front = $"{originalStickers[18]}{originalStickers[19]}{originalStickers[20]}";
            front += $"{originalStickers[21]}{originalStickers[22]}{originalStickers[23]}";
            front += $"{originalStickers[24]}{originalStickers[25]}{originalStickers[26]}";

            var back = $"{originalStickers[27]}{originalStickers[28]}{originalStickers[29]}";
            back += $"{originalStickers[30]}{originalStickers[31]}{originalStickers[32]}";
            back += $"{originalStickers[33]}{originalStickers[34]}{originalStickers[35]}";

            var west = $"{originalStickers[36]}{originalStickers[37]}{originalStickers[38]}";
            west += $"{originalStickers[39]}{originalStickers[40]}{originalStickers[41]}";
            west += $"{originalStickers[42]}{originalStickers[43]}{originalStickers[44]}";

            var east = $"{originalStickers[45]}{originalStickers[46]}{originalStickers[47]}";
            east += $"{originalStickers[48]}{originalStickers[49]}{originalStickers[50]}";
            east += $"{originalStickers[51]}{originalStickers[52]}{originalStickers[53]}";

            var clockwise = $"{north}{south}{front}{back}{west}{east}";

            return clockwise;
        }

        public String GetCube(String stickers)
        {
            //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
            //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
            //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
            //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
            //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
            //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

            Char[] originalStickers = stickers.ToCharArray();

            String north = $"BNW:{ GetStickerAbbreviation(originalStickers[0])}|BN:{ GetStickerAbbreviation(originalStickers[1])}|BNE:{ GetStickerAbbreviation(originalStickers[2])}|NW:{ GetStickerAbbreviation(originalStickers[3])}|N:{ GetStickerAbbreviation(originalStickers[4])}|NE:{ GetStickerAbbreviation(originalStickers[5])}|FNW:{ GetStickerAbbreviation(originalStickers[6])}|FN:{ GetStickerAbbreviation(originalStickers[7])}|FNE:{ GetStickerAbbreviation(originalStickers[8])}";
            String south = $"FSW:{ GetStickerAbbreviation(originalStickers[9])}|FS:{ GetStickerAbbreviation(originalStickers[10])}|FSE:{ GetStickerAbbreviation(originalStickers[11])}|SW:{ GetStickerAbbreviation(originalStickers[12])}|S:{ GetStickerAbbreviation(originalStickers[13])}|SE:{ GetStickerAbbreviation(originalStickers[14])}|BSW:{ GetStickerAbbreviation(originalStickers[15])}|BS:{ GetStickerAbbreviation(originalStickers[16])}|BSE:{ GetStickerAbbreviation(originalStickers[17])}";
            String front = $"FNW:{ GetStickerAbbreviation(originalStickers[18])}|FN:{ GetStickerAbbreviation(originalStickers[19])}|FNE:{ GetStickerAbbreviation(originalStickers[20])}|FW:{ GetStickerAbbreviation(originalStickers[21])}|F:{ GetStickerAbbreviation(originalStickers[22])}|FE:{ GetStickerAbbreviation(originalStickers[23])}|FSW:{ GetStickerAbbreviation(originalStickers[24])}|FS:{ GetStickerAbbreviation(originalStickers[25])}|FSE:{ GetStickerAbbreviation(originalStickers[26])}";
            String back = $"BNW:{ GetStickerAbbreviation(originalStickers[27])}|BN:{ GetStickerAbbreviation(originalStickers[28])}|BNE:{ GetStickerAbbreviation(originalStickers[29])}|BW:{ GetStickerAbbreviation(originalStickers[30])}|B:{ GetStickerAbbreviation(originalStickers[31])}|BE:{ GetStickerAbbreviation(originalStickers[32])}|BSW:{ GetStickerAbbreviation(originalStickers[33])}|BS:{ GetStickerAbbreviation(originalStickers[34])}|BSE:{ GetStickerAbbreviation(originalStickers[35])}";
            String west = $"BNW:{ GetStickerAbbreviation(originalStickers[36])}|NW:{ GetStickerAbbreviation(originalStickers[37])}|FNW:{ GetStickerAbbreviation(originalStickers[38])}|BW:{ GetStickerAbbreviation(originalStickers[39])}|W:{ GetStickerAbbreviation(originalStickers[40])}|FW:{ GetStickerAbbreviation(originalStickers[41])}|BSW:{ GetStickerAbbreviation(originalStickers[42])}|SW:{ GetStickerAbbreviation(originalStickers[43])}|FSW:{ GetStickerAbbreviation(originalStickers[44])}";
            String east = $"FNE:{ GetStickerAbbreviation(originalStickers[45])}|NE:{ GetStickerAbbreviation(originalStickers[46])}|BNE:{ GetStickerAbbreviation(originalStickers[47])}|FE:{ GetStickerAbbreviation(originalStickers[48])}|E:{ GetStickerAbbreviation(originalStickers[49])}|BE:{ GetStickerAbbreviation(originalStickers[50])}|FSE:{ GetStickerAbbreviation(originalStickers[51])}|SE:{ GetStickerAbbreviation(originalStickers[52])}|BSE:{ GetStickerAbbreviation(originalStickers[53])}";

            return $"{north},{south},{front},{back},{west},{east}";

        }

        public String[] SwitchOutPatternComprehensive(String original)
        {

            var results = new List<String>() { original };

            var codedOriginal = original;

            codedOriginal = codedOriginal
                .Replace("A", "A1").Replace("B", "B1").Replace("C", "C1")
                .Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");


            var resultsRaw = new List<String>();

            resultsRaw.Add(codedOriginal.Replace("A1", "B").Replace("a1", "b").Replace("B1", "A").Replace("b1", "a"));
            resultsRaw.Add(codedOriginal.Replace("A1", "C").Replace("a1", "c").Replace("C1", "A").Replace("c1", "a"));

            resultsRaw.Add(codedOriginal.Replace("B1", "C").Replace("b1", "c").Replace("C1", "B").Replace("c1", "b"));
            resultsRaw.Add(codedOriginal.Replace("B1", "A").Replace("b1", "a").Replace("A1", "B").Replace("a1", "b"));

            resultsRaw.Add(codedOriginal.Replace("C1", "A").Replace("c1", "a").Replace("A1", "C").Replace("a1", "c"));
            resultsRaw.Add(codedOriginal.Replace("C1", "B").Replace("c1", "b").Replace("B1", "C").Replace("b1", "c"));


            foreach (var resultRaw in resultsRaw)
            {
                var result = resultRaw.Replace("A1", "A").Replace("B1", "B").Replace("C1", "C").Replace("a1", "a").Replace("b1", "b").Replace("c1", "c");

                if (result.ToArray().Count(x => x == 'A') > 9
                    || result.ToArray().Count(x => x == 'B') > 9
                    || result.ToArray().Count(x => x == 'C') > 9
                    || result.ToArray().Count(x => x == 'a') > 9
                    || result.ToArray().Count(x => x == 'b') > 9
                    || result.ToArray().Count(x => x == 'c') > 9)
                {
                    throw new Exception("Invalid SwitchOutPatternComprehensive Result: " + result);
                }

                results.Add(result);

            }

            return results.ToArray();
        }

        public String[] ShiftPatternComprehensive(String original)
        {
            var codedOriginal = original;

            codedOriginal = codedOriginal
                .Replace("A", "A1").Replace("B", "B1").Replace("C", "C1")
                .Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            var result1 = codedOriginal.Replace("A1", "B").Replace("B1", "C").Replace("C1", "a").Replace("a1", "b").Replace("b1", "c").Replace("c1", "A");
            var result2 = codedOriginal.Replace("A1", "C").Replace("B1", "a").Replace("C1", "b").Replace("a1", "c").Replace("b1", "A").Replace("c1", "B");
            var result3 = codedOriginal.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c").Replace("a1", "A").Replace("b1", "B").Replace("c1", "C");
            var result4 = codedOriginal.Replace("A1", "b").Replace("B1", "c").Replace("C1", "A").Replace("a1", "B").Replace("b1", "C").Replace("c1", "a");
            var result5 = codedOriginal.Replace("A1", "c").Replace("B1", "A").Replace("C1", "B").Replace("a1", "C").Replace("b1", "a").Replace("c1", "b");

            var result = new string[] { original, result1, result2, result3, result3, result4, result5 };
            if (result.ToArray().Count(x => x == "A") > 9
                   || result.ToArray().Count(x => x == "B") > 9
                   || result.ToArray().Count(x => x == "C") > 9
                   || result.ToArray().Count(x => x == "a") > 9
                   || result.ToArray().Count(x => x == "b") > 9
                   || result.ToArray().Count(x => x == "c") > 9)
            {
                throw new Exception("Invalid ShiftPatternComprehensive Result: " + result);
            }

            return result;
        }


        public String ReversePattern(String original)
        {
            var result = original;
            result = result.Replace("A", "A1").Replace("B", "B1").Replace("C", "C1");
            result = result.Replace("a", "a1").Replace("b", "b1").Replace("c", "c1");

            result = result.Replace("A1", "a").Replace("B1", "b").Replace("C1", "c");
            result = result.Replace("a1", "A").Replace("b1", "B").Replace("c1", "C");

            return result;
        }

        public String[] RotateFacePattern(String original)
        {
            var originalStickers = original.ToCharArray();

            var clockwise = $"{originalStickers[6]}{originalStickers[3]}{originalStickers[0]}";
            clockwise += $"{originalStickers[7]}{originalStickers[4]}{originalStickers[1]}";
            clockwise += $"{originalStickers[8]}{originalStickers[5]}{originalStickers[2]}";

            var clockwise2 = $"{originalStickers[8]}{originalStickers[7]}{originalStickers[6]}";
            clockwise2 += $"{originalStickers[5]}{originalStickers[4]}{originalStickers[3]}";
            clockwise2 += $"{originalStickers[2]}{originalStickers[1]}{originalStickers[0]}";

            var clockwise3 = $"{originalStickers[2]}{originalStickers[5]}{originalStickers[8]}";
            clockwise3 += $"{originalStickers[1]}{originalStickers[4]}{originalStickers[7]}";
            clockwise3 += $"{originalStickers[0]}{originalStickers[3]}{originalStickers[6]}";

            return new string[] { original, clockwise, clockwise2, clockwise3 };
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

        public String GetCubeState(CubeModel cube)
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

        //public String GetCubePattern(CubeModel cube)
        //{
        //    //  BNW, BN, BNE, NW, N, NE, FNW, FN, FNE
        //    //  FSW, FS, FSE, SW, S, SE, BSW, BS, BSE
        //    //  FNW, FN, FNE, FW, F, FE, FSW, FS, FSE
        //    //  BNW, BN, BNE, BW, B, BE, BSW, BS, BSE
        //    //  BNW, NW, FNW, BW, W, FW, BSW, SW, FSW
        //    //  FNE, NE, BNE, FE, E, BE, FSE, SE, BSW

        //    String north = $"BNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerNorth.StickerColorType)}|BN:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerNorth.StickerColorType)}|BNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerNorth.StickerColorType)}|NW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerNorth.StickerColorType)}|N:{ GetStickerAbbreviation(cube.XyzCubeType, cube.North.StickerNorth.StickerColorType)}|NE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerNorth.StickerColorType)}|FNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerNorth.StickerColorType)}|FN:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerNorth.StickerColorType)}|FNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerNorth.StickerColorType)}";
        //    String south = $"FSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerSouth.StickerColorType)}|FS:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerSouth.StickerColorType)}|FSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerSouth.StickerColorType)}|SW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerSouth.StickerColorType)}|S:{ GetStickerAbbreviation(cube.XyzCubeType, cube.South.StickerSouth.StickerColorType)}|SE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerSouth.StickerColorType)}|BSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerSouth.StickerColorType)}|BS:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerSouth.StickerColorType)}|BSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerSouth.StickerColorType)}";
        //    String front = $"FNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerFront.StickerColorType)}|FN:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorth.StickerFront.StickerColorType)}|FNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerFront.StickerColorType)}|FW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerFront.StickerColorType)}|F:{ GetStickerAbbreviation(cube.XyzCubeType, cube.Front.StickerFront.StickerColorType)}|FE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerFront.StickerColorType)}|FSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerFront.StickerColorType)}|FS:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouth.StickerFront.StickerColorType)}|FSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerFront.StickerColorType)}";
        //    String back = $"BNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerBack.StickerColorType)}|BN:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorth.StickerBack.StickerColorType)}|BNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerBack.StickerColorType)}|BW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerBack.StickerColorType)}|B:{ GetStickerAbbreviation(cube.XyzCubeType, cube.Back.StickerBack.StickerColorType)}|BE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerBack.StickerColorType)}|BSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerBack.StickerColorType)}|BS:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouth.StickerBack.StickerColorType)}|BSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerBack.StickerColorType)}";
        //    String west = $"BNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthWest.StickerWest.StickerColorType)}|NW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthWest.StickerWest.StickerColorType)}|FNW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthWest.StickerWest.StickerColorType)}|BW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackWest.StickerWest.StickerColorType)}|W:{ GetStickerAbbreviation(cube.XyzCubeType, cube.West.StickerWest.StickerColorType)}|FW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontWest.StickerWest.StickerColorType)}|BSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthWest.StickerWest.StickerColorType)}|SW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthWest.StickerWest.StickerColorType)}|FSW:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthWest.StickerWest.StickerColorType)}";
        //    String east = $"FNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontNorthEast.StickerEast.StickerColorType)}|NE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.NorthEast.StickerEast.StickerColorType)}|BNE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackNorthEast.StickerEast.StickerColorType)}|FE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontEast.StickerEast.StickerColorType)}|E:{ GetStickerAbbreviation(cube.XyzCubeType, cube.East.StickerEast.StickerColorType)}|BE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackEast.StickerEast.StickerColorType)}|FSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.FrontSouthEast.StickerEast.StickerColorType)}|SE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.SouthEast.StickerEast.StickerColorType)}|BSE:{ GetStickerAbbreviation(cube.XyzCubeType, cube.BackSouthEast.StickerEast.StickerColorType)}";

        //    return $"{north},{south},{front},{back},{west},{east}";
        //}

        public (String, StickerColorTypes) ParseSticker(String rawSticker)
        {
            String[] rawStickerArr = rawSticker.Split(':');
            String key = rawStickerArr[0];
            StickerColorTypes value = GetStickerColorType(rawStickerArr[1]);

            return (key, value);
        }

        public Dictionary<String, StickerColorTypes> ParseStickers(String rawCubeState)
        {
            var results = new Dictionary<String, StickerColorTypes>();
            String[] prefixs = new string[6] { "N", "S", "F", "B", "W", "E" };
            String[] cubeSides = rawCubeState.Split(',');
            for (var i = 0; i < 6; i++)
            {
                String prefix = prefixs[i];
                String[] stickers = cubeSides[i].Split('|');
                foreach (String sticker in stickers)
                {
                    String key;
                    StickerColorTypes value;
                    (key, value) = this.ParseSticker(sticker);
                    results.Add(prefix + key, value);
                }
            }
            return results;
        }

        public IList<PieceSideModelBase> GetAllSides(CubeModel cube)
        {
            var sides = new List<PieceSideModelBase>(12);

            sides.Add(cube.FrontNorth.Piece);
            sides.Add(cube.FrontEast.Piece);
            sides.Add(cube.FrontSouth.Piece);
            sides.Add(cube.FrontWest.Piece);

            sides.Add(cube.NorthEast.Piece);
            sides.Add(cube.SouthEast.Piece);
            sides.Add(cube.SouthWest.Piece);
            sides.Add(cube.NorthWest.Piece);

            sides.Add(cube.BackNorth.Piece);
            sides.Add(cube.BackEast.Piece);
            sides.Add(cube.BackSouth.Piece);
            sides.Add(cube.BackWest.Piece);

            return sides;
        }

        public IList<PieceCornerModelBase> GetAllCorners(CubeModel cube)
        {
            var corners = new List<PieceCornerModelBase>(8);

            corners.Add(cube.FrontNorthEast.Piece);
            corners.Add(cube.FrontSouthEast.Piece);
            corners.Add(cube.FrontSouthWest.Piece);
            corners.Add(cube.FrontNorthWest.Piece);

            corners.Add(cube.BackNorthEast.Piece);
            corners.Add(cube.BackSouthEast.Piece);
            corners.Add(cube.BackSouthWest.Piece);
            corners.Add(cube.BackNorthWest.Piece);

            return corners;
        }

        #region Set Middles
        public void SetFrontSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontModel slot)
        {
            StickerColorTypes front = stickerDictionary["FF"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front) == 1);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
        }

        public void SetBackSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackModel slot)
        {
            StickerColorTypes back = stickerDictionary["BB"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back) == 1);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
        }

        public void SetWestSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotWestModel slot)
        {
            StickerColorTypes west = stickerDictionary["WW"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == west) == 1);

            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }

        public void SetEastSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotEastModel slot)
        {
            StickerColorTypes east = stickerDictionary["EE"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == east) == 1);

            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }

        public void SetNorthSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotNorthModel slot)
        {
            StickerColorTypes north = stickerDictionary["NN"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == north) == 1);

            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
        }

        public void SetSouthSlot(IList<PieceMiddleModelBase> middles, Dictionary<String, StickerColorTypes> stickerDictionary, SlotSouthModel slot)
        {
            StickerColorTypes south = stickerDictionary["SS"];

            slot.Piece = middles.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == south) == 1);

            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
        }

        #endregion

        #region Set Corners
        public void SetFrontNorthWestSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontNorthWestModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFNW"];
            StickerColorTypes north = stickerDictionary["NFNW"];
            StickerColorTypes west = stickerDictionary["WFNW"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == north || x2.StickerColorType == west) == 3);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }
        public void SetFrontNorthEastSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontNorthEastModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFNE"];
            StickerColorTypes north = stickerDictionary["NFNE"];
            StickerColorTypes east = stickerDictionary["EFNE"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == north || x2.StickerColorType == east) == 3);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }
        public void SetFrontSouthEastSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontSouthEastModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFSE"];
            StickerColorTypes south = stickerDictionary["SFSE"];
            StickerColorTypes east = stickerDictionary["EFSE"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == south || x2.StickerColorType == east) == 3);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }
        public void SetFrontSouthWestSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontSouthWestModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFSW"];
            StickerColorTypes south = stickerDictionary["SFSW"];
            StickerColorTypes west = stickerDictionary["WFSW"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == south || x2.StickerColorType == west) == 3);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }

        public void SetBackNorthWestSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackNorthWestModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBNW"];
            StickerColorTypes north = stickerDictionary["NBNW"];
            StickerColorTypes west = stickerDictionary["WBNW"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == north || x2.StickerColorType == west) == 3);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }
        public void SetBackNorthEastSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackNorthEastModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBNE"];
            StickerColorTypes north = stickerDictionary["NBNE"];
            StickerColorTypes east = stickerDictionary["EBNE"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == north || x2.StickerColorType == east) == 3);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }
        public void SetBackSouthEastSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackSouthEastModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBSE"];
            StickerColorTypes south = stickerDictionary["SBSE"];
            StickerColorTypes east = stickerDictionary["EBSE"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == south || x2.StickerColorType == east) == 3);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }
        public void SetBackSouthWestSlot(IList<PieceCornerModelBase> corners, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackSouthWestModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBSW"];
            StickerColorTypes south = stickerDictionary["SBSW"];
            StickerColorTypes west = stickerDictionary["WBSW"];

            slot.Piece = corners.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == south || x2.StickerColorType == west) == 3);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }
        #endregion

        #region Set Sides

        public void SetFrontNorthSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontNorthModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFN"];
            StickerColorTypes north = stickerDictionary["NFN"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == north) == 2);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
        }

        public void SetFrontEastSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontEastModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFE"];
            StickerColorTypes east = stickerDictionary["EFE"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == east) == 2);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }

        public void SetFrontSouthSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontSouthModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFS"];
            StickerColorTypes south = stickerDictionary["SFS"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == south) == 2);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
        }

        public void SetFrontWestSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotFrontWestModel slot)
        {
            StickerColorTypes front = stickerDictionary["FFW"];
            StickerColorTypes west = stickerDictionary["WFW"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == front || x2.StickerColorType == west) == 2);

            slot.StickerFront = slot.Piece.Stickers.Single(x => x.StickerColorType == front);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }

        public void SetBackNorthSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackNorthModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBN"];
            StickerColorTypes north = stickerDictionary["NBN"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == north) == 2);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
        }

        public void SetBackEastSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackEastModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBE"];
            StickerColorTypes east = stickerDictionary["EBE"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == east) == 2);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }

        public void SetBackSouthSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackSouthModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBS"];
            StickerColorTypes south = stickerDictionary["SBS"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == south) == 2);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
        }

        public void SetBackWestSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotBackWestModel slot)
        {
            StickerColorTypes back = stickerDictionary["BBW"];
            StickerColorTypes west = stickerDictionary["WBW"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == back || x2.StickerColorType == west) == 2);

            slot.StickerBack = slot.Piece.Stickers.Single(x => x.StickerColorType == back);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }

        public void SetNorthEastSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotNorthEastModel slot)
        {
            StickerColorTypes north = stickerDictionary["NNE"];
            StickerColorTypes east = stickerDictionary["ENE"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == north || x2.StickerColorType == east) == 2);

            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }

        public void SetSouthEastSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotSouthEastModel slot)
        {
            StickerColorTypes south = stickerDictionary["SSE"];
            StickerColorTypes east = stickerDictionary["ESE"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == south || x2.StickerColorType == east) == 2);

            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerEast = slot.Piece.Stickers.Single(x => x.StickerColorType == east);
        }

        public void SetSouthWestSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotSouthWestModel slot)
        {
            StickerColorTypes south = stickerDictionary["SSW"];
            StickerColorTypes west = stickerDictionary["WSW"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == south || x2.StickerColorType == west) == 2);

            slot.StickerSouth = slot.Piece.Stickers.Single(x => x.StickerColorType == south);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }

        public void SetNorthWestSlot(IList<PieceSideModelBase> sides, Dictionary<String, StickerColorTypes> stickerDictionary, SlotNorthWestModel slot)
        {
            StickerColorTypes north = stickerDictionary["NNW"];
            StickerColorTypes west = stickerDictionary["WNW"];

            slot.Piece = sides.Single(x => x.Stickers.Count(x2 => x2.StickerColorType == north || x2.StickerColorType == west) == 2);

            slot.StickerNorth = slot.Piece.Stickers.Single(x => x.StickerColorType == north);
            slot.StickerWest = slot.Piece.Stickers.Single(x => x.StickerColorType == west);
        }
        #endregion


        public void Scramble(CubeModel[] cubes, Int32 times)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                for (var i = 0; i < times; i++)
                {
                    byte[] buffer = new byte[4];
                    rng.GetBytes(buffer);
                    Int32 seedNumber = BitConverter.ToInt32(buffer, 0);

                    Int32 randomMove = new Random(seedNumber).Next(0, 11);

                    foreach (CubeModel cube in cubes)
                    {
                        switch (randomMove)
                        {
                            case 0:
                                this.TurnBackClockwise(cube);
                                break;
                            case 1:
                                this.TurnBackCounterclockwise(cube);
                                break;
                            case 2:
                                this.TurnDownClockwise(cube);
                                break;
                            case 3:
                                this.TurnDownCounterclockwise(cube);
                                break;
                            case 4:
                                this.TurnFrontClockwise(cube);
                                break;
                            case 5:
                                this.TurnFrontCounterclockwise(cube);
                                break;
                            case 6:
                                this.TurnLeftClockwise(cube);
                                break;
                            case 7:
                                this.TurnLeftCounterclockwise(cube);
                                break;
                            case 8:
                                this.TurnRightClockwise(cube);
                                break;
                            case 9:
                                this.TurnRightCounterclockwise(cube);
                                break;
                            case 10:
                                this.TurnUpClockwise(cube);
                                break;
                            case 11:
                                this.TurnUpCounterclockwise(cube);
                                break;
                        }
                    }
                }
            }
            foreach (CubeModel cube in cubes)
            {
                this.VerifyAllPieces(cube);
            }
        }

        public void Scramble(CubeModel cube, Int32 times)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                for (var i = 0; i < times; i++)
                {
                    byte[] buffer = new byte[4];
                    rng.GetBytes(buffer);
                    Int32 seedNumber = BitConverter.ToInt32(buffer, 0);

                    Int32 randomMove = new Random(seedNumber).Next(0, 11);

                    switch (randomMove)
                    {
                        case 0:
                            this.TurnBackClockwise(cube);
                            break;
                        case 1:
                            this.TurnBackCounterclockwise(cube);
                            break;
                        case 2:
                            this.TurnDownClockwise(cube);
                            break;
                        case 3:
                            this.TurnDownCounterclockwise(cube);
                            break;
                        case 4:
                            this.TurnFrontClockwise(cube);
                            break;
                        case 5:
                            this.TurnFrontCounterclockwise(cube);
                            break;
                        case 6:
                            this.TurnLeftClockwise(cube);
                            break;
                        case 7:
                            this.TurnLeftCounterclockwise(cube);
                            break;
                        case 8:
                            this.TurnRightClockwise(cube);
                            break;
                        case 9:
                            this.TurnRightCounterclockwise(cube);
                            break;
                        case 10:
                            this.TurnUpClockwise(cube);
                            break;
                        case 11:
                            this.TurnUpCounterclockwise(cube);
                            break;
                    }
                }
            }
            this.VerifyAllPieces(cube);
        }

        public void SetCubeState(CubeModel cube, String rawCubeState)
        {
            Dictionary<String, StickerColorTypes> stickerDictionary = this.ParseStickers(rawCubeState);

            IList<PieceMiddleModelBase> middles = this.GetAllMiddles(cube);

            this.SetNorthSlot(middles, stickerDictionary, cube.North);
            this.SetSouthSlot(middles, stickerDictionary, cube.South);
            this.SetWestSlot(middles, stickerDictionary, cube.West);
            this.SetEastSlot(middles, stickerDictionary, cube.East);
            this.SetFrontSlot(middles, stickerDictionary, cube.Front);
            this.SetBackSlot(middles, stickerDictionary, cube.Back);


            IList<PieceCornerModelBase> corners = this.GetAllCorners(cube);

            this.SetFrontNorthWestSlot(corners, stickerDictionary, cube.FrontNorthWest);
            this.SetFrontNorthEastSlot(corners, stickerDictionary, cube.FrontNorthEast);
            this.SetFrontSouthEastSlot(corners, stickerDictionary, cube.FrontSouthEast);
            this.SetFrontSouthWestSlot(corners, stickerDictionary, cube.FrontSouthWest);


            this.SetBackNorthWestSlot(corners, stickerDictionary, cube.BackNorthWest);
            this.SetBackNorthEastSlot(corners, stickerDictionary, cube.BackNorthEast);
            this.SetBackSouthEastSlot(corners, stickerDictionary, cube.BackSouthEast);
            this.SetBackSouthWestSlot(corners, stickerDictionary, cube.BackSouthWest);


            IList<PieceSideModelBase> sides = this.GetAllSides(cube);

            this.SetFrontNorthSlot(sides, stickerDictionary, cube.FrontNorth);
            this.SetFrontEastSlot(sides, stickerDictionary, cube.FrontEast);
            this.SetFrontSouthSlot(sides, stickerDictionary, cube.FrontSouth);
            this.SetFrontWestSlot(sides, stickerDictionary, cube.FrontWest);

            this.SetBackNorthSlot(sides, stickerDictionary, cube.BackNorth);
            this.SetBackEastSlot(sides, stickerDictionary, cube.BackEast);
            this.SetBackSouthSlot(sides, stickerDictionary, cube.BackSouth);
            this.SetBackWestSlot(sides, stickerDictionary, cube.BackWest);

            this.SetNorthEastSlot(sides, stickerDictionary, cube.NorthEast);
            this.SetSouthEastSlot(sides, stickerDictionary, cube.SouthEast);
            this.SetSouthWestSlot(sides, stickerDictionary, cube.SouthWest);
            this.SetNorthWestSlot(sides, stickerDictionary, cube.NorthWest);

            this.VerifyAllPieces(cube);
        }

        private IList<PieceMiddleModelBase> GetAllMiddles(CubeModel cube)
        {
            var middles = new List<PieceMiddleModelBase>(6);

            middles.Add(cube.Front.Piece);
            middles.Add(cube.Back.Piece);

            middles.Add(cube.North.Piece);
            middles.Add(cube.South.Piece);

            middles.Add(cube.East.Piece);
            middles.Add(cube.West.Piece);

            return middles;

        }

        public void RunMove(CubeModel cube, String move)
        {
            if (move == "U")
            {
                this.TurnUpClockwise(cube);
            }
            else if (move == "E")
            {
                this.TurnUpClockwise(cube);
                this.TurnDownCounterclockwise(cube);
            }
            else if (move == "D")
            {
                this.TurnDownClockwise(cube);
            }
            else if (move == "R")
            {
                this.TurnRightClockwise(cube);
            }
            else if (move == "M")
            {
                this.TurnLeftCounterclockwise(cube);
                this.TurnRightClockwise(cube);
            }
            else if (move == "L")
            {
                this.TurnLeftClockwise(cube);
            }
            else if (move == "F")
            {
                this.TurnFrontClockwise(cube);
            }
            else if (move == "S")
            {
                this.TurnFrontCounterclockwise(cube);
                this.TurnBackClockwise(cube);
            }
            else if (move == "B")
            {
                this.TurnBackClockwise(cube);
            }
            else if (move == "U2")
            {
                this.TurnUpClockwise(cube);
                this.TurnUpClockwise(cube);
            }
            else if (move == "E2")
            {
                this.TurnUpClockwise(cube);
                this.TurnDownCounterclockwise(cube);

                this.TurnUpClockwise(cube);
                this.TurnDownCounterclockwise(cube);
            }
            else if (move == "D2")
            {
                this.TurnDownClockwise(cube);
                this.TurnDownClockwise(cube);
            }
            else if (move == "R2")
            {
                this.TurnRightClockwise(cube);
                this.TurnRightClockwise(cube);
            }
            else if (move == "M2")
            {
                this.TurnLeftCounterclockwise(cube);
                this.TurnRightClockwise(cube);

                this.TurnLeftCounterclockwise(cube);
                this.TurnRightClockwise(cube);
            }
            else if (move == "L2")
            {
                this.TurnLeftClockwise(cube);
                this.TurnLeftClockwise(cube);
            }
            else if (move == "F2")
            {
                this.TurnFrontClockwise(cube);
                this.TurnFrontClockwise(cube);
            }
            else if (move == "S2")
            {
                this.TurnFrontCounterclockwise(cube);
                this.TurnBackClockwise(cube);

                this.TurnFrontCounterclockwise(cube);
                this.TurnBackClockwise(cube);
            }
            else if (move == "B2")
            {
                this.TurnBackClockwise(cube);
                this.TurnBackClockwise(cube);
            }
            else if (move == "U'")
            {
                this.TurnUpCounterclockwise(cube);
            }
            else if (move == "E'")
            {
                this.TurnUpCounterclockwise(cube);
                this.TurnDownClockwise(cube);
            }
            else if (move == "D'")
            {
                this.TurnDownCounterclockwise(cube);
            }
            else if (move == "R'")
            {
                this.TurnRightCounterclockwise(cube);
            }
            else if (move == "M'")
            {
                this.TurnLeftClockwise(cube);
                this.TurnRightCounterclockwise(cube);
            }
            else if (move == "L'")
            {
                this.TurnLeftCounterclockwise(cube);
            }
            else if (move == "F'")
            {
                this.TurnFrontCounterclockwise(cube);
            }
            else if (move == "S'")
            {
                this.TurnFrontClockwise(cube);
                this.TurnBackCounterclockwise(cube);
            }
            else if (move == "B'")
            {
                this.TurnBackCounterclockwise(cube);
            }
        }

        public void RunMoves(CubeModel[] cubes, String moves)
        {
            foreach (CubeModel cube in cubes)
            {
                if (moves.Contains(","))
                {
                    foreach (String move in moves.Split(','))
                    {
                        this.RunMove(cube, move);
                    }
                }
                else
                {
                    this.RunMove(cube, moves);
                }
            }

            foreach (CubeModel cube in cubes)
            {
                this.VerifyAllPieces(cube);
            }
        }

        public void RunMoves(CubeModel cube, String moves)
        {
            if (moves.Contains(","))
            {
                foreach (String move in moves.Split(','))
                {
                    this.RunMove(cube, move);
                }
            }
            else
            {
                this.RunMove(cube, moves);
            }
            this.VerifyAllPieces(cube);
        }

        //public T1 ShiftCubePiece<T1, T2>(T2 piece) where T1: PieceCornerModelBase where T2 : PieceCornerModelBase
        //{

        //}

        //public T1 ShiftCubePiece<T1, T2>(T2 piece) where T1 : PieceCornerModelBase where T2 : PieceCornerModelBase
        //{

        //}

        public SlotCornerModelBase FindSlotCornerPieceIsIn(CubeModel cube, PieceCornerModelBase piece)
        {
            SlotCornerModelBase result;
            if (cube.FrontNorthEast.Piece == piece)
            {
                result = cube.FrontNorthEast;
            }
            else if (cube.FrontSouthEast.Piece == piece)
            {
                result = cube.FrontSouthEast;
            }
            else if (cube.FrontSouthWest.Piece == piece)
            {
                result = cube.FrontSouthWest;
            }
            else if (cube.FrontNorthWest.Piece == piece)
            {
                result = cube.FrontNorthWest;
            }
            else if (cube.BackNorthEast.Piece == piece)
            {
                result = cube.BackNorthEast;
            }
            else if (cube.BackSouthEast.Piece == piece)
            {
                result = cube.BackSouthEast;
            }
            else if (cube.BackSouthWest.Piece == piece)
            {
                result = cube.BackSouthWest;
            }
            else if (cube.BackNorthWest.Piece == piece)
            {
                result = cube.BackNorthWest;
            }
            else
            {
                throw new Exception("FindSlotCornerPieceIsIn Failed");
            }

            return result;
        }

        public SlotSideModelBase FindSlotSidePieceIsIn(CubeModel cube, PieceSideModelBase piece)
        {
            SlotSideModelBase result;

            if (cube.FrontNorth.Piece == piece)
            {
                result = cube.FrontNorth;
            }
            else if (cube.FrontEast.Piece == piece)
            {
                result = cube.FrontEast;
            }
            else if (cube.FrontSouth.Piece == piece)
            {
                result = cube.FrontSouth;
            }
            else if (cube.FrontWest.Piece == piece)
            {
                result = cube.FrontWest;
            }
            else if (cube.NorthEast.Piece == piece)
            {
                result = cube.NorthEast;
            }
            else if (cube.SouthEast.Piece == piece)
            {
                result = cube.SouthEast;
            }
            else if (cube.SouthWest.Piece == piece)
            {
                result = cube.SouthWest;
            }
            else if (cube.NorthWest.Piece == piece)
            {
                result = cube.NorthWest;
            }
            else if (cube.BackNorth.Piece == piece)
            {
                result = cube.BackNorth;
            }
            else if (cube.BackEast.Piece == piece)
            {
                result = cube.BackEast;
            }
            else if (cube.BackSouth.Piece == piece)
            {
                result = cube.BackSouth;
            }
            else if (cube.BackWest.Piece == piece)
            {
                result = cube.BackWest;
            }
            else
            {
                throw new Exception("FindSlotSidePieceIsIn Failed");
            }

            return result;
        }

        public PositionCornerTypes FindCornerPiece(CubeModel cube, PieceCornerModelBase piece)
        {
            PositionCornerTypes result;
            if (cube.FrontNorthEast.Piece == piece)
            {
                result = PositionCornerTypes.FrontNorthEast;
            }
            else if (cube.FrontSouthEast.Piece == piece)
            {
                result = PositionCornerTypes.FrontSouthEast;
            }
            else if (cube.FrontSouthWest.Piece == piece)
            {
                result = PositionCornerTypes.FrontSouthWest;
            }
            else if (cube.FrontNorthWest.Piece == piece)
            {
                result = PositionCornerTypes.FrontNorthWest;
            }
            else if (cube.BackNorthEast.Piece == piece)
            {
                result = PositionCornerTypes.BackNorthEast;
            }
            else if (cube.BackSouthEast.Piece == piece)
            {
                result = PositionCornerTypes.BackSouthEast;
            }
            else if (cube.BackSouthWest.Piece == piece)
            {
                result = PositionCornerTypes.BackSouthWest;
            }
            else if (cube.BackNorthWest.Piece == piece)
            {
                result = PositionCornerTypes.BackNorthWest;
            }
            else
            {
                throw new Exception("FindCornerPiece Failed");
            }
            return result;
        }

        public PositionSideTypes FindSidePiece(CubeModel cube, PieceSideModelBase piece)
        {
            PositionSideTypes result;
            if (cube.FrontNorth.Piece == piece)
            {
                result = PositionSideTypes.FrontNorth;
            }
            else if (cube.FrontEast.Piece == piece)
            {
                result = PositionSideTypes.FrontEast;
            }
            else if (cube.FrontSouth.Piece == piece)
            {
                result = PositionSideTypes.FrontSouth;
            }
            else if (cube.FrontWest.Piece == piece)
            {
                result = PositionSideTypes.FrontWest;
            }
            else if (cube.NorthEast.Piece == piece)
            {
                result = PositionSideTypes.NorthEast;
            }
            else if (cube.SouthEast.Piece == piece)
            {
                result = PositionSideTypes.SouthEast;
            }
            else if (cube.SouthWest.Piece == piece)
            {
                result = PositionSideTypes.SouthWest;
            }
            else if (cube.NorthWest.Piece == piece)
            {
                result = PositionSideTypes.NorthWest;
            }
            else if (cube.BackNorth.Piece == piece)
            {
                result = PositionSideTypes.BackNorth;
            }
            else if (cube.BackEast.Piece == piece)
            {
                result = PositionSideTypes.BackEast;
            }
            else if (cube.BackSouth.Piece == piece)
            {
                result = PositionSideTypes.BackSouth;
            }
            else if (cube.BackWest.Piece == piece)
            {
                result = PositionSideTypes.BackWest;
            }
            else
            {
                throw new Exception("FindSidePiece Failed");
            }
            return result;
        }

        public void CompareCorner(SlotCornerModelBase slotA, SlotCornerModelBase slotB)
        {

        }

        //public SlotSideModelBase ShiftStickerWyrogbToYwrobg(SlotSideModelBase slotSideModel)
        //{
        //    SlotSideModelBase result = new SlotSideModelBase();
        //    StickerModelBase stricker = slotSideModel.Piece.Stickers.First().Clone();
        //    stricker.StickerColorType;
        //}

        //public void ShiftCubePieceWyrogbToYwrobg(CubeModel cubeToClone)
        //{
        //    var cubeBeingConstucted = new CubeModel();

        //    var result = new CubeModel();



        //    //      AAA
        //    //      AAA
        //    //      AAA
        //    //  BBB CCC bbb ccc
        //    //  BBB CCC bbb ccc
        //    //  BBB CCC bbb ccc
        //    //  BBB CCC bbb ccc
        //    //      aaa
        //    //      aaa
        //    //      aaa

        //    //********************************************************
        //    //      STICKERS
        //    //********************************************************
        //    result.NorthEast.StickerNorth.StickerColorType == StickerColorTypes.Blue){
        //    }


        //    result.NorthEast.StickerNorth = cube.NorthEast.StickerNorth;
        //    result.NorthEast.StickerEast = cube.NorthEast.StickerEast;

        //    result.NorthWest.StickerNorth = cube.NorthWest.StickerNorth;
        //    result.NorthWest.StickerWest = cube.NorthWest.StickerWest;

        //    result.FrontNorth.StickerFront = cube.FrontNorth.StickerFront;
        //    result.FrontNorth.StickerNorth = cube.FrontNorth.StickerNorth;

        //    result.BackNorth.StickerBack = cube.BackNorth.StickerBack;
        //    result.BackNorth.StickerNorth = cube.BackNorth.StickerNorth;


        //    result.SouthEast.StickerSouth = cube.SouthEast.StickerSouth;
        //    result.SouthEast.StickerEast = cube.SouthEast.StickerEast;

        //    result.SouthWest.StickerSouth = cube.SouthWest.StickerSouth;
        //    result.SouthWest.StickerWest = cube.SouthWest.StickerWest;

        //    result.FrontSouth.StickerFront = cube.FrontSouth.StickerFront;
        //    result.FrontSouth.StickerSouth = cube.FrontSouth.StickerSouth;

        //    result.BackSouth.StickerBack = cube.BackSouth.StickerBack;
        //    result.BackSouth.StickerSouth = cube.BackSouth.StickerSouth;


        //    result.FrontEast.StickerFront = cube.FrontEast.StickerFront;
        //    result.FrontEast.StickerEast = cube.FrontEast.StickerEast;

        //    result.FrontWest.StickerFront = cube.FrontWest.StickerFront;
        //    result.FrontWest.StickerWest = cube.FrontWest.StickerWest;

        //    result.BackEast.StickerEast = cube.BackEast.StickerEast;
        //    result.BackEast.StickerBack = cube.BackEast.StickerBack;

        //    result.BackWest.StickerBack = cube.BackWest.StickerBack;
        //    result.BackWest.StickerWest = cube.BackWest.StickerWest;


        //    result.FrontNorthEast.StickerFront = cube.FrontNorthEast.StickerFront;
        //    result.FrontNorthEast.StickerNorth = cube.FrontNorthEast.StickerNorth;
        //    result.FrontNorthEast.StickerEast = cube.FrontNorthEast.StickerEast;

        //    result.FrontSouthEast.StickerFront = cube.FrontSouthEast.StickerFront;
        //    result.FrontSouthEast.StickerSouth = cube.FrontSouthEast.StickerSouth;
        //    result.FrontSouthEast.StickerEast = cube.FrontSouthEast.StickerEast;

        //    result.FrontSouthWest.StickerFront = cube.FrontSouthWest.StickerFront;
        //    result.FrontSouthWest.StickerSouth = cube.FrontSouthWest.StickerSouth;
        //    result.FrontSouthWest.StickerWest = cube.FrontSouthWest.StickerWest;

        //    result.FrontNorthWest.StickerFront = cube.FrontNorthWest.StickerFront;
        //    result.FrontNorthWest.StickerNorth = cube.FrontNorthWest.StickerNorth;
        //    result.FrontNorthWest.StickerWest = cube.FrontNorthWest.StickerWest;


        //    result.BackNorthEast.StickerBack = cube.BackNorthEast.StickerBack;
        //    result.BackNorthEast.StickerNorth = cube.BackNorthEast.StickerNorth;
        //    result.BackNorthEast.StickerEast = cube.BackNorthEast.StickerEast;

        //    result.BackSouthEast.StickerBack = cube.BackSouthEast.StickerBack;
        //    result.BackSouthEast.StickerSouth = cube.BackSouthEast.StickerSouth;
        //    result.BackSouthEast.StickerEast = cube.BackSouthEast.StickerEast;

        //    result.BackSouthWest.StickerBack = cube.BackSouthWest.StickerBack;
        //    result.BackSouthWest.StickerSouth = cube.BackSouthWest.StickerSouth;
        //    result.BackSouthWest.StickerWest = cube.BackSouthWest.StickerWest;

        //    result.BackNorthWest.StickerBack = cube.BackNorthWest.StickerBack;
        //    result.BackNorthWest.StickerNorth = cube.BackNorthWest.StickerNorth;
        //    result.BackNorthWest.StickerWest = cube.BackNorthWest.StickerWest;
        //}


        //public void ShiftCubePattern(CubeModel currentState)
        //{
        //    var solved = new CubeModel();

        //    var result = new CubeModel();

        //    //********************************************************
        //    //      Pieces
        //    //********************************************************
        //    this.Compare(solved.FrontNorthEast, this.FindSlotCornerPieceIsIn(currentState.FrontNorth.Piece));


        //    result.FrontNorth.Piece = cube.FrontNorth.Piece;
        //    result.FrontEast.Piece = cube.FrontEast.Piece;
        //    result.FrontSouth.Piece = cube.FrontSouth.Piece;
        //    result.FrontWest.Piece = cube.FrontWest.Piece;


        //    result.FrontNorthEast.Piece = cube.FrontNorthEast.Piece;
        //    result.FrontSouthEast.Piece = cube.FrontSouthEast.Piece;
        //    result.FrontSouthWest.Piece = cube.FrontSouthWest.Piece;
        //    result.FrontNorthWest.Piece = cube.FrontNorthWest.Piece;


        //    result.NorthEast.Piece = cube.NorthEast.Piece;
        //    result.SouthEast.Piece = cube.SouthEast.Piece;
        //    result.SouthWest.Piece = cube.SouthWest.Piece;
        //    result.NorthWest.Piece = cube.NorthWest.Piece;

        //    result.BackNorth.Piece = cube.BackNorth.Piece;
        //    result.BackEast.Piece = cube.BackEast.Piece;
        //    result.BackSouth.Piece = cube.BackSouth.Piece;
        //    result.BackWest.Piece = cube.BackWest.Piece;

        //    result.BackNorthEast.Piece = cube.BackNorthEast.Piece;
        //    result.BackSouthEast.Piece = cube.BackSouthEast.Piece;
        //    result.BackSouthWest.Piece = cube.BackSouthWest.Piece;
        //    result.BackNorthWest.Piece = cube.BackNorthWest.Piece;


        //    //********************************************************
        //    //      STICKERS
        //    //********************************************************

        //    result.NorthEast.StickerNorth = cube.NorthEast.StickerNorth;
        //    result.NorthEast.StickerEast = cube.NorthEast.StickerEast;

        //    result.NorthWest.StickerNorth = cube.NorthWest.StickerNorth;
        //    result.NorthWest.StickerWest = cube.NorthWest.StickerWest;

        //    result.FrontNorth.StickerFront = cube.FrontNorth.StickerFront;
        //    result.FrontNorth.StickerNorth = cube.FrontNorth.StickerNorth;

        //    result.BackNorth.StickerBack = cube.BackNorth.StickerBack;
        //    result.BackNorth.StickerNorth = cube.BackNorth.StickerNorth;


        //    result.SouthEast.StickerSouth = cube.SouthEast.StickerSouth;
        //    result.SouthEast.StickerEast = cube.SouthEast.StickerEast;

        //    result.SouthWest.StickerSouth = cube.SouthWest.StickerSouth;
        //    result.SouthWest.StickerWest = cube.SouthWest.StickerWest;

        //    result.FrontSouth.StickerFront = cube.FrontSouth.StickerFront;
        //    result.FrontSouth.StickerSouth = cube.FrontSouth.StickerSouth;

        //    result.BackSouth.StickerBack = cube.BackSouth.StickerBack;
        //    result.BackSouth.StickerSouth = cube.BackSouth.StickerSouth;


        //    result.FrontEast.StickerFront = cube.FrontEast.StickerFront;
        //    result.FrontEast.StickerEast = cube.FrontEast.StickerEast;

        //    result.FrontWest.StickerFront = cube.FrontWest.StickerFront;
        //    result.FrontWest.StickerWest = cube.FrontWest.StickerWest;

        //    result.BackEast.StickerEast = cube.BackEast.StickerEast;
        //    result.BackEast.StickerBack = cube.BackEast.StickerBack;

        //    result.BackWest.StickerBack = cube.BackWest.StickerBack;
        //    result.BackWest.StickerWest = cube.BackWest.StickerWest;


        //    result.FrontNorthEast.StickerFront = cube.FrontNorthEast.StickerFront;
        //    result.FrontNorthEast.StickerNorth = cube.FrontNorthEast.StickerNorth;
        //    result.FrontNorthEast.StickerEast = cube.FrontNorthEast.StickerEast;

        //    result.FrontSouthEast.StickerFront = cube.FrontSouthEast.StickerFront;
        //    result.FrontSouthEast.StickerSouth = cube.FrontSouthEast.StickerSouth;
        //    result.FrontSouthEast.StickerEast = cube.FrontSouthEast.StickerEast;

        //    result.FrontSouthWest.StickerFront = cube.FrontSouthWest.StickerFront;
        //    result.FrontSouthWest.StickerSouth = cube.FrontSouthWest.StickerSouth;
        //    result.FrontSouthWest.StickerWest = cube.FrontSouthWest.StickerWest;

        //    result.FrontNorthWest.StickerFront = cube.FrontNorthWest.StickerFront;
        //    result.FrontNorthWest.StickerNorth = cube.FrontNorthWest.StickerNorth;
        //    result.FrontNorthWest.StickerWest = cube.FrontNorthWest.StickerWest;


        //    result.BackNorthEast.StickerBack = cube.BackNorthEast.StickerBack;
        //    result.BackNorthEast.StickerNorth = cube.BackNorthEast.StickerNorth;
        //    result.BackNorthEast.StickerEast = cube.BackNorthEast.StickerEast;

        //    result.BackSouthEast.StickerBack = cube.BackSouthEast.StickerBack;
        //    result.BackSouthEast.StickerSouth = cube.BackSouthEast.StickerSouth;
        //    result.BackSouthEast.StickerEast = cube.BackSouthEast.StickerEast;

        //    result.BackSouthWest.StickerBack = cube.BackSouthWest.StickerBack;
        //    result.BackSouthWest.StickerSouth = cube.BackSouthWest.StickerSouth;
        //    result.BackSouthWest.StickerWest = cube.BackSouthWest.StickerWest;

        //    result.BackNorthWest.StickerBack = cube.BackNorthWest.StickerBack;
        //    result.BackNorthWest.StickerNorth = cube.BackNorthWest.StickerNorth;
        //    result.BackNorthWest.StickerWest = cube.BackNorthWest.StickerWest;

        //}

        public void CloneCube(CubeModel cube, XyzCubeTypes xyzCubeType)
        {
            var result = new CubeModel(xyzCubeType);

            //********************************************************
            //      Pieces
            //********************************************************

            result.FrontNorth.Piece = cube.FrontNorth.Piece.CopyPiece(xyzCubeType);
            result.FrontEast.Piece = cube.FrontEast.Piece.CopyPiece(xyzCubeType);
            result.FrontSouth.Piece = cube.FrontSouth.Piece.CopyPiece(xyzCubeType);
            result.FrontWest.Piece = cube.FrontWest.Piece.CopyPiece(xyzCubeType);

            result.FrontNorthEast.Piece = cube.FrontNorthEast.Piece.CopyPiece(xyzCubeType);
            result.FrontSouthEast.Piece = cube.FrontSouthEast.Piece.CopyPiece(xyzCubeType);
            result.FrontSouthWest.Piece = cube.FrontSouthWest.Piece.CopyPiece(xyzCubeType);
            result.FrontNorthWest.Piece = cube.FrontNorthWest.Piece.CopyPiece(xyzCubeType);

            result.NorthEast.Piece = cube.NorthEast.Piece.CopyPiece(xyzCubeType);
            result.SouthEast.Piece = cube.SouthEast.Piece.CopyPiece(xyzCubeType);
            result.SouthWest.Piece = cube.SouthWest.Piece.CopyPiece(xyzCubeType);
            result.NorthWest.Piece = cube.NorthWest.Piece.CopyPiece(xyzCubeType);

            result.BackNorth.Piece = cube.BackNorth.Piece.CopyPiece(xyzCubeType);
            result.BackEast.Piece = cube.BackEast.Piece.CopyPiece(xyzCubeType);
            result.BackSouth.Piece = cube.BackSouth.Piece.CopyPiece(xyzCubeType);
            result.BackWest.Piece = cube.BackWest.Piece.CopyPiece(xyzCubeType);

            result.BackNorthEast.Piece = cube.BackNorthEast.Piece.CopyPiece(xyzCubeType);
            result.BackSouthEast.Piece = cube.BackSouthEast.Piece.CopyPiece(xyzCubeType);
            result.BackSouthWest.Piece = cube.BackSouthWest.Piece.CopyPiece(xyzCubeType);
            result.BackNorthWest.Piece = cube.BackNorthWest.Piece.CopyPiece(xyzCubeType);

            //********************************************************
            //      STICKERS
            //********************************************************

            result.NorthEast.StickerNorth = cube.NorthEast.StickerNorth;
            result.NorthEast.StickerEast = cube.NorthEast.StickerEast;

            result.NorthWest.StickerNorth = cube.NorthWest.StickerNorth;
            result.NorthWest.StickerWest = cube.NorthWest.StickerWest;

            result.FrontNorth.StickerFront = cube.FrontNorth.StickerFront;
            result.FrontNorth.StickerNorth = cube.FrontNorth.StickerNorth;

            result.BackNorth.StickerBack = cube.BackNorth.StickerBack;
            result.BackNorth.StickerNorth = cube.BackNorth.StickerNorth;


            result.SouthEast.StickerSouth = cube.SouthEast.StickerSouth;
            result.SouthEast.StickerEast = cube.SouthEast.StickerEast;

            result.SouthWest.StickerSouth = cube.SouthWest.StickerSouth;
            result.SouthWest.StickerWest = cube.SouthWest.StickerWest;

            result.FrontSouth.StickerFront = cube.FrontSouth.StickerFront;
            result.FrontSouth.StickerSouth = cube.FrontSouth.StickerSouth;

            result.BackSouth.StickerBack = cube.BackSouth.StickerBack;
            result.BackSouth.StickerSouth = cube.BackSouth.StickerSouth;


            result.FrontEast.StickerFront = cube.FrontEast.StickerFront;
            result.FrontEast.StickerEast = cube.FrontEast.StickerEast;

            result.FrontWest.StickerFront = cube.FrontWest.StickerFront;
            result.FrontWest.StickerWest = cube.FrontWest.StickerWest;

            result.BackEast.StickerEast = cube.BackEast.StickerEast;
            result.BackEast.StickerBack = cube.BackEast.StickerBack;

            result.BackWest.StickerBack = cube.BackWest.StickerBack;
            result.BackWest.StickerWest = cube.BackWest.StickerWest;


            result.FrontNorthEast.StickerFront = cube.FrontNorthEast.StickerFront;
            result.FrontNorthEast.StickerNorth = cube.FrontNorthEast.StickerNorth;
            result.FrontNorthEast.StickerEast = cube.FrontNorthEast.StickerEast;

            result.FrontSouthEast.StickerFront = cube.FrontSouthEast.StickerFront;
            result.FrontSouthEast.StickerSouth = cube.FrontSouthEast.StickerSouth;
            result.FrontSouthEast.StickerEast = cube.FrontSouthEast.StickerEast;

            result.FrontSouthWest.StickerFront = cube.FrontSouthWest.StickerFront;
            result.FrontSouthWest.StickerSouth = cube.FrontSouthWest.StickerSouth;
            result.FrontSouthWest.StickerWest = cube.FrontSouthWest.StickerWest;

            result.FrontNorthWest.StickerFront = cube.FrontNorthWest.StickerFront;
            result.FrontNorthWest.StickerNorth = cube.FrontNorthWest.StickerNorth;
            result.FrontNorthWest.StickerWest = cube.FrontNorthWest.StickerWest;


            result.BackNorthEast.StickerBack = cube.BackNorthEast.StickerBack;
            result.BackNorthEast.StickerNorth = cube.BackNorthEast.StickerNorth;
            result.BackNorthEast.StickerEast = cube.BackNorthEast.StickerEast;

            result.BackSouthEast.StickerBack = cube.BackSouthEast.StickerBack;
            result.BackSouthEast.StickerSouth = cube.BackSouthEast.StickerSouth;
            result.BackSouthEast.StickerEast = cube.BackSouthEast.StickerEast;

            result.BackSouthWest.StickerBack = cube.BackSouthWest.StickerBack;
            result.BackSouthWest.StickerSouth = cube.BackSouthWest.StickerSouth;
            result.BackSouthWest.StickerWest = cube.BackSouthWest.StickerWest;

            result.BackNorthWest.StickerBack = cube.BackNorthWest.StickerBack;
            result.BackNorthWest.StickerNorth = cube.BackNorthWest.StickerNorth;
            result.BackNorthWest.StickerWest = cube.BackNorthWest.StickerWest;


        }

        public CubeModel[] CreateAllVariations()
        {
            var result = new List<CubeModel>();

            try
            {
                result.Add(this.Create(XyzCubeTypes.BlueOrangeWhite));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.BlueRedYellow));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.BlueWhiteRed));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.BlueYellowOrange));
            }
            catch
            {

            }
            try
            {

                result.Add(this.Create(XyzCubeTypes.GreenOrangeYellow));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.GreenRedWhite));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.GreenWhiteOrange));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.GreenYellowRed));
            }
            catch
            {

            }
            try
            {

                result.Add(this.Create(XyzCubeTypes.OrangeBlueYellow));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.OrangeGreenWhite));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.OrangeWhiteBlue));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.OrangeYellowGreen));
            }
            catch
            {

            }
            try
            {

                result.Add(this.Create(XyzCubeTypes.RedBlueWhite));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.RedGreenYellow));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.RedWhiteGreen));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.RedYellowBlue));
            }
            catch
            {

            }
            try
            {

                result.Add(this.Create(XyzCubeTypes.WhiteBlueOrange));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.WhiteGreenRed));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.WhiteOrangeGreen));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.WhiteRedBlue));
            }
            catch
            {

            }
            try
            {

                result.Add(this.Create(XyzCubeTypes.YellowBlueRed));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.YellowGreenOrange));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.YellowOrangeBlue));
            }
            catch
            {

            }
            try
            {
                result.Add(this.Create(XyzCubeTypes.YellowRedGreen));
            }
            catch
            {

            }

            return result.ToArray();
        }
        

        public CubeModel Create(XyzCubeTypes patternCubeType)
        {
            var result = new CubeModel(patternCubeType);

            //********************************************************
            //      Pieces
            //********************************************************

            var frontPiece = new PieceFrontModel(patternCubeType);
            var backPiece = new PieceBackModel(patternCubeType);
            var northPiece = new PieceNorthModel(patternCubeType);
            var southPiece = new PieceSouthModel(patternCubeType);
            var eastPiece = new PieceEastModel(patternCubeType);
            var westPiece = new PieceWestModel(patternCubeType);

            var frontNorthPiece = new PieceFrontNorthModel(patternCubeType);
            var frontEastPiece = new PieceFrontEastModel(patternCubeType);
            var frontSouthPiece = new PieceFrontSouthModel(patternCubeType);
            var frontWestPiece = new PieceFrontWestModel(patternCubeType);

            var frontNorthEastPiece = new PieceFrontNorthEastModel(patternCubeType);
            var frontSouthEastPiece = new PieceFrontSouthEastModel(patternCubeType);
            var frontSouthWestPiece = new PieceFrontSouthWestModel(patternCubeType);
            var frontNorthWestPiece = new PieceFrontNorthWestModel(patternCubeType);

            var northEastPiece = new PieceNorthEastModel(patternCubeType);
            var southEastPiece = new PieceSouthEastModel(patternCubeType);
            var southWestPiece = new PieceSouthWestModel(patternCubeType);
            var northWestPiece = new PieceNorthWestModel(patternCubeType);

            var backNorthPiece = new PieceBackNorthModel(patternCubeType);
            var backEastPiece = new PieceBackEastModel(patternCubeType);
            var backSouthPiece = new PieceBackSouthModel(patternCubeType);
            var backWestPiece = new PieceBackWestModel(patternCubeType);

            var backNorthEastPiece = new PieceBackNorthEastModel(patternCubeType);
            var backSouthEastPiece = new PieceBackSouthEastModel(patternCubeType);
            var backSouthWestPiece = new PieceBackSouthWestModel(patternCubeType);
            var backNorthWestPiece = new PieceBackNorthWestModel(patternCubeType);

            result.Front.Piece = frontPiece;
            result.Back.Piece = backPiece;
            result.North.Piece = northPiece;
            result.East.Piece = eastPiece;
            result.South.Piece = southPiece;
            result.West.Piece = westPiece;

            result.FrontNorth.Piece = frontNorthPiece;
            result.FrontEast.Piece = frontEastPiece;
            result.FrontSouth.Piece = frontSouthPiece;
            result.FrontWest.Piece = frontWestPiece;


            result.FrontNorthEast.Piece = frontNorthEastPiece;
            result.FrontSouthEast.Piece = frontSouthEastPiece;
            result.FrontSouthWest.Piece = frontSouthWestPiece;
            result.FrontNorthWest.Piece = frontNorthWestPiece;


            result.NorthEast.Piece = northEastPiece;
            result.SouthEast.Piece = southEastPiece;
            result.SouthWest.Piece = southWestPiece;
            result.NorthWest.Piece = northWestPiece;

            result.BackNorth.Piece = backNorthPiece;
            result.BackEast.Piece = backEastPiece;
            result.BackSouth.Piece = backSouthPiece;
            result.BackWest.Piece = backWestPiece;

            result.BackNorthEast.Piece = backNorthEastPiece;
            result.BackSouthEast.Piece = backSouthEastPiece;
            result.BackSouthWest.Piece = backSouthWestPiece;
            result.BackNorthWest.Piece = backNorthWestPiece;


            //********************************************************
            //      STICKERS
            //********************************************************

            result.Front.StickerFront = frontPiece.StickerFront;
            result.Back.StickerBack = backPiece.StickerBack;
            result.North.StickerNorth = northPiece.StickerNorth;
            result.East.StickerEast = eastPiece.StickerEast;
            result.South.StickerSouth = southPiece.StickerSouth;
            result.West.StickerWest = westPiece.StickerWest;

            result.NorthEast.StickerNorth = northEastPiece.StickerNorth;
            result.NorthEast.StickerEast = northEastPiece.StickerEast;

            result.NorthWest.StickerNorth = northWestPiece.StickerNorth;
            result.NorthWest.StickerWest = northWestPiece.StickerWest;

            result.FrontNorth.StickerFront = frontNorthPiece.StickerFront;
            result.FrontNorth.StickerNorth = frontNorthPiece.StickerNorth;

            result.BackNorth.StickerBack = backNorthPiece.StickerBack;
            result.BackNorth.StickerNorth = backNorthPiece.StickerNorth;


            result.SouthEast.StickerSouth = southEastPiece.StickerSouth;
            result.SouthEast.StickerEast = southEastPiece.StickerEast;

            result.SouthWest.StickerSouth = southWestPiece.StickerSouth;
            result.SouthWest.StickerWest = southWestPiece.StickerWest;

            result.FrontSouth.StickerFront = frontSouthPiece.StickerFront;
            result.FrontSouth.StickerSouth = frontSouthPiece.StickerSouth;

            result.BackSouth.StickerBack = backSouthPiece.StickerBack;
            result.BackSouth.StickerSouth = backSouthPiece.StickerSouth;


            result.FrontEast.StickerFront = frontEastPiece.StickerFront;
            result.FrontEast.StickerEast = frontEastPiece.StickerEast;

            result.FrontWest.StickerFront = frontWestPiece.StickerFront;
            result.FrontWest.StickerWest = frontWestPiece.StickerWest;

            result.BackEast.StickerEast = backEastPiece.StickerEast;
            result.BackEast.StickerBack = backEastPiece.StickerBack;

            result.BackWest.StickerBack = backWestPiece.StickerBack;
            result.BackWest.StickerWest = backWestPiece.StickerWest;


            result.FrontNorthEast.StickerFront = frontNorthEastPiece.StickerFront;
            result.FrontNorthEast.StickerNorth = frontNorthEastPiece.StickerNorth;
            result.FrontNorthEast.StickerEast = frontNorthEastPiece.StickerEast;

            result.FrontSouthEast.StickerFront = frontSouthEastPiece.StickerFront;
            result.FrontSouthEast.StickerSouth = frontSouthEastPiece.StickerSouth;
            result.FrontSouthEast.StickerEast = frontSouthEastPiece.StickerEast;

            result.FrontSouthWest.StickerFront = frontSouthWestPiece.StickerFront;
            result.FrontSouthWest.StickerSouth = frontSouthWestPiece.StickerSouth;
            result.FrontSouthWest.StickerWest = frontSouthWestPiece.StickerWest;

            result.FrontNorthWest.StickerFront = frontNorthWestPiece.StickerFront;
            result.FrontNorthWest.StickerNorth = frontNorthWestPiece.StickerNorth;
            result.FrontNorthWest.StickerWest = frontNorthWestPiece.StickerWest;


            result.BackNorthEast.StickerBack = backNorthEastPiece.StickerBack;
            result.BackNorthEast.StickerNorth = backNorthEastPiece.StickerNorth;
            result.BackNorthEast.StickerEast = backNorthEastPiece.StickerEast;

            result.BackSouthEast.StickerBack = backSouthEastPiece.StickerBack;
            result.BackSouthEast.StickerSouth = backSouthEastPiece.StickerSouth;
            result.BackSouthEast.StickerEast = backSouthEastPiece.StickerEast;

            result.BackSouthWest.StickerBack = backSouthWestPiece.StickerBack;
            result.BackSouthWest.StickerSouth = backSouthWestPiece.StickerSouth;
            result.BackSouthWest.StickerWest = backSouthWestPiece.StickerWest;

            result.BackNorthWest.StickerBack = backNorthWestPiece.StickerBack;
            result.BackNorthWest.StickerNorth = backNorthWestPiece.StickerNorth;
            result.BackNorthWest.StickerWest = backNorthWestPiece.StickerWest;

            this.VerifyAllPieces(result);

            return result;
        }


        #region Turn Back
        public void TurnBackCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase backNorthPiece = cube.BackWest.Piece;
            PieceSideModelBase backEastPiece = cube.BackNorth.Piece;
            PieceSideModelBase backSouthPiece = cube.BackEast.Piece;
            PieceSideModelBase backWestPiece = cube.BackSouth.Piece;

            PieceCornerModelBase backNorthEastPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase backSouthEastPiece = cube.BackNorthEast.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.BackSouthEast.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.BackSouthWest.Piece;


            StickerModelBase cubeBackNorthStickerBack = cube.BackWest.StickerBack;
            StickerModelBase cubeBackNorthStickerNorth = cube.BackWest.StickerWest;

            StickerModelBase cubeBackEastStickerBack = cube.BackNorth.StickerBack;
            StickerModelBase cubeBackEastStickerEast = cube.BackNorth.StickerNorth;

            StickerModelBase cubeBackSouthStickerBack = cube.BackEast.StickerBack;
            StickerModelBase cubeBackSouthStickerSouth = cube.BackEast.StickerEast;

            StickerModelBase cubeBackWestStickerBack = cube.BackSouth.StickerBack;
            StickerModelBase cubeBackWestStickerWest = cube.BackSouth.StickerSouth;


            StickerModelBase cubeBackNorthEastStickerBack = cube.BackNorthWest.StickerBack;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.BackNorthWest.StickerWest;
            StickerModelBase cubeBackNorthEastStickerEast = cube.BackNorthWest.StickerNorth;

            StickerModelBase cubeBackSouthEastStickerBack = cube.BackNorthEast.StickerBack;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.BackNorthEast.StickerEast;
            StickerModelBase cubeBackSouthEastStickerEast = cube.BackNorthEast.StickerNorth;

            StickerModelBase cubeBackSouthWestStickerBack = cube.BackSouthEast.StickerBack;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.BackSouthEast.StickerEast;
            StickerModelBase cubeBackSouthWestStickerWest = cube.BackSouthEast.StickerSouth;

            StickerModelBase cubeBackNorthWestStickerBack = cube.BackSouthWest.StickerBack;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.BackSouthWest.StickerWest;
            StickerModelBase cubeBackNorthWestStickerWest = cube.BackSouthWest.StickerSouth;

            cube.BackNorth.Piece = backNorthPiece;
            cube.BackEast.Piece = backEastPiece;
            cube.BackSouth.Piece = backSouthPiece;
            cube.BackWest.Piece = backWestPiece;

            cube.BackNorthEast.Piece = backNorthEastPiece;
            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.BackNorth.StickerBack = cubeBackNorthStickerBack;
            cube.BackNorth.StickerNorth = cubeBackNorthStickerNorth;

            cube.BackEast.StickerBack = cubeBackEastStickerBack;
            cube.BackEast.StickerEast = cubeBackEastStickerEast;

            cube.BackSouth.StickerBack = cubeBackSouthStickerBack;
            cube.BackSouth.StickerSouth = cubeBackSouthStickerSouth;

            cube.BackWest.StickerBack = cubeBackWestStickerBack;
            cube.BackWest.StickerWest = cubeBackWestStickerWest;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        public void TurnBackClockwise(CubeModel cube)
        {
            PieceSideModelBase backNorthPiece = cube.BackEast.Piece;
            PieceSideModelBase backEastPiece = cube.BackSouth.Piece;
            PieceSideModelBase backSouthPiece = cube.BackWest.Piece;
            PieceSideModelBase backWestPiece = cube.BackNorth.Piece;

            PieceCornerModelBase backNorthEastPiece = cube.BackSouthEast.Piece;
            PieceCornerModelBase backSouthEastPiece = cube.BackSouthWest.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.BackNorthEast.Piece;


            StickerModelBase cubeBackNorthStickerBack = cube.BackEast.StickerBack;
            StickerModelBase cubeBackNorthStickerNorth = cube.BackEast.StickerEast;

            StickerModelBase cubeBackEastStickerBack = cube.BackSouth.StickerBack;
            StickerModelBase cubeBackEastStickerEast = cube.BackSouth.StickerSouth;

            StickerModelBase cubeBackSouthStickerBack = cube.BackWest.StickerBack;
            StickerModelBase cubeBackSouthStickerSouth = cube.BackWest.StickerWest;

            StickerModelBase cubeBackWestStickerBack = cube.BackNorth.StickerBack;
            StickerModelBase cubeBackWestStickerWest = cube.BackNorth.StickerNorth;


            StickerModelBase cubeBackNorthEastStickerBack = cube.BackSouthEast.StickerBack;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.BackSouthEast.StickerEast;
            StickerModelBase cubeBackNorthEastStickerEast = cube.BackSouthEast.StickerSouth;

            StickerModelBase cubeBackSouthEastStickerBack = cube.BackSouthWest.StickerBack;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.BackSouthWest.StickerWest;
            StickerModelBase cubeBackSouthEastStickerEast = cube.BackSouthWest.StickerSouth;

            StickerModelBase cubeBackSouthWestStickerBack = cube.BackNorthWest.StickerBack;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.BackNorthWest.StickerWest;
            StickerModelBase cubeBackSouthWestStickerWest = cube.BackNorthWest.StickerNorth;

            StickerModelBase cubeBackNorthWestStickerBack = cube.BackNorthEast.StickerBack;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.BackNorthEast.StickerEast;
            StickerModelBase cubeBackNorthWestStickerWest = cube.BackNorthEast.StickerNorth;

            cube.BackNorth.Piece = backNorthPiece;
            cube.BackEast.Piece = backEastPiece;
            cube.BackSouth.Piece = backSouthPiece;
            cube.BackWest.Piece = backWestPiece;

            cube.BackNorthEast.Piece = backNorthEastPiece;
            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.BackNorth.StickerBack = cubeBackNorthStickerBack;
            cube.BackNorth.StickerNorth = cubeBackNorthStickerNorth;

            cube.BackEast.StickerBack = cubeBackEastStickerBack;
            cube.BackEast.StickerEast = cubeBackEastStickerEast;

            cube.BackSouth.StickerBack = cubeBackSouthStickerBack;
            cube.BackSouth.StickerSouth = cubeBackSouthStickerSouth;

            cube.BackWest.StickerBack = cubeBackWestStickerBack;
            cube.BackWest.StickerWest = cubeBackWestStickerWest;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        #endregion

        #region Turn Front

        public void TurnFrontClockwise(CubeModel cube)
        {
            PieceSideModelBase frontNorthPiece = cube.FrontWest.Piece;
            PieceSideModelBase frontEastPiece = cube.FrontNorth.Piece;
            PieceSideModelBase frontSouthPiece = cube.FrontEast.Piece;
            PieceSideModelBase frontWestPiece = cube.FrontSouth.Piece;

            PieceCornerModelBase frontNorthEastPiece = cube.FrontNorthWest.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.FrontNorthEast.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase frontNorthWestPiece = cube.FrontSouthWest.Piece;


            StickerModelBase cubeFrontNorthStickerFront = cube.FrontWest.StickerFront;
            StickerModelBase cubeFrontNorthStickerNorth = cube.FrontWest.StickerWest;

            StickerModelBase cubeFrontEastStickerFront = cube.FrontNorth.StickerFront;
            StickerModelBase cubeFrontEastStickerEast = cube.FrontNorth.StickerNorth;

            StickerModelBase cubeFrontSouthStickerFront = cube.FrontEast.StickerFront;
            StickerModelBase cubeFrontSouthStickerSouth = cube.FrontEast.StickerEast;

            StickerModelBase cubeFrontWestStickerFront = cube.FrontSouth.StickerFront;
            StickerModelBase cubeFrontWestStickerWest = cube.FrontSouth.StickerSouth;


            StickerModelBase cubeFrontNorthEastStickerFront = cube.FrontNorthWest.StickerFront;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.FrontNorthWest.StickerWest;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.FrontNorthWest.StickerNorth;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.FrontNorthEast.StickerFront;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.FrontNorthEast.StickerEast;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.FrontNorthEast.StickerNorth;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.FrontSouthEast.StickerFront;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.FrontSouthEast.StickerEast;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.FrontSouthEast.StickerSouth;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.FrontSouthWest.StickerFront;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.FrontSouthWest.StickerWest;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.FrontSouthWest.StickerSouth;

            cube.FrontNorth.Piece = frontNorthPiece;
            cube.FrontEast.Piece = frontEastPiece;
            cube.FrontSouth.Piece = frontSouthPiece;
            cube.FrontWest.Piece = frontWestPiece;

            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.FrontNorthWest.Piece = frontNorthWestPiece;

            cube.FrontNorth.StickerFront = cubeFrontNorthStickerFront;
            cube.FrontNorth.StickerNorth = cubeFrontNorthStickerNorth;

            cube.FrontEast.StickerFront = cubeFrontEastStickerFront;
            cube.FrontEast.StickerEast = cubeFrontEastStickerEast;

            cube.FrontSouth.StickerFront = cubeFrontSouthStickerFront;
            cube.FrontSouth.StickerSouth = cubeFrontSouthStickerSouth;

            cube.FrontWest.StickerFront = cubeFrontWestStickerFront;
            cube.FrontWest.StickerWest = cubeFrontWestStickerWest;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        public void TurnFrontCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase frontNorthPiece = cube.FrontEast.Piece;
            PieceSideModelBase frontEastPiece = cube.FrontSouth.Piece;
            PieceSideModelBase frontSouthPiece = cube.FrontWest.Piece;
            PieceSideModelBase frontWestPiece = cube.FrontNorth.Piece;

            PieceCornerModelBase frontNorthEastPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.FrontSouthWest.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.FrontNorthWest.Piece;
            PieceCornerModelBase frontNorthWestPiece = cube.FrontNorthEast.Piece;


            StickerModelBase cubeFrontNorthStickerFront = cube.FrontEast.StickerFront;
            StickerModelBase cubeFrontNorthStickerNorth = cube.FrontEast.StickerEast;

            StickerModelBase cubeFrontEastStickerFront = cube.FrontSouth.StickerFront;
            StickerModelBase cubeFrontEastStickerEast = cube.FrontSouth.StickerSouth;

            StickerModelBase cubeFrontSouthStickerFront = cube.FrontWest.StickerFront;
            StickerModelBase cubeFrontSouthStickerSouth = cube.FrontWest.StickerWest;

            StickerModelBase cubeFrontWestStickerFront = cube.FrontNorth.StickerFront;
            StickerModelBase cubeFrontWestStickerWest = cube.FrontNorth.StickerNorth;


            StickerModelBase cubeFrontNorthEastStickerFront = cube.FrontSouthEast.StickerFront;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.FrontSouthEast.StickerEast;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.FrontSouthEast.StickerSouth;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.FrontSouthWest.StickerFront;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.FrontSouthWest.StickerWest;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.FrontSouthWest.StickerSouth;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.FrontNorthWest.StickerFront;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.FrontNorthWest.StickerWest;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.FrontNorthWest.StickerNorth;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.FrontNorthEast.StickerFront;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.FrontNorthEast.StickerEast;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.FrontNorthEast.StickerNorth;

            cube.FrontNorth.Piece = frontNorthPiece;
            cube.FrontEast.Piece = frontEastPiece;
            cube.FrontSouth.Piece = frontSouthPiece;
            cube.FrontWest.Piece = frontWestPiece;

            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.FrontNorthWest.Piece = frontNorthWestPiece;

            cube.FrontNorth.StickerFront = cubeFrontNorthStickerFront;
            cube.FrontNorth.StickerNorth = cubeFrontNorthStickerNorth;

            cube.FrontEast.StickerFront = cubeFrontEastStickerFront;
            cube.FrontEast.StickerEast = cubeFrontEastStickerEast;

            cube.FrontSouth.StickerFront = cubeFrontSouthStickerFront;
            cube.FrontSouth.StickerSouth = cubeFrontSouthStickerSouth;

            cube.FrontWest.StickerFront = cubeFrontWestStickerFront;
            cube.FrontWest.StickerWest = cubeFrontWestStickerWest;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        #endregion


        #region Turn UP
        public void TurnUpClockwise(CubeModel cube)
        {
            PieceSideModelBase backNorthPiece = cube.NorthWest.Piece;
            PieceSideModelBase northEastPiece = cube.BackNorth.Piece;
            PieceSideModelBase frontNorthPiece = cube.NorthEast.Piece;
            PieceSideModelBase northWestPiece = cube.FrontNorth.Piece;

            PieceCornerModelBase backNorthEastPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase frontNorthEastPiece = cube.BackNorthEast.Piece;
            PieceCornerModelBase frontNorthWestPiece = cube.FrontNorthEast.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.FrontNorthWest.Piece;

            StickerModelBase cubeBackNorthStickerNorth = cube.NorthWest.StickerNorth;
            StickerModelBase cubeBackNorthStickerBack = cube.NorthWest.StickerWest;

            StickerModelBase cubeNorthEastStickerEast = cube.BackNorth.StickerBack;
            StickerModelBase cubeNorthEastStickerNorth = cube.BackNorth.StickerNorth;

            StickerModelBase cubeFrontNorthStickerNorth = cube.NorthEast.StickerNorth;
            StickerModelBase cubeFrontNorthStickerFront = cube.NorthEast.StickerEast;

            StickerModelBase cubeNorthWestStickerWest = cube.FrontNorth.StickerFront;
            StickerModelBase cubeNorthWestStickerNorth = cube.FrontNorth.StickerNorth;


            StickerModelBase cubeBackNorthEastStickerBack = cube.BackNorthWest.StickerWest;
            StickerModelBase cubeBackNorthEastStickerEast = cube.BackNorthWest.StickerBack;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.BackNorthWest.StickerNorth;

            StickerModelBase cubeFrontNorthEastStickerFront = cube.BackNorthEast.StickerEast;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.BackNorthEast.StickerBack;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.BackNorthEast.StickerNorth;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.FrontNorthEast.StickerEast;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.FrontNorthEast.StickerNorth;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.FrontNorthEast.StickerFront;

            StickerModelBase cubeBackNorthWestStickerBack = cube.FrontNorthWest.StickerWest;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.FrontNorthWest.StickerNorth;
            StickerModelBase cubeBackNorthWestStickerWest = cube.FrontNorthWest.StickerFront;

            cube.BackNorth.Piece = backNorthPiece;
            cube.NorthEast.Piece = northEastPiece;
            cube.FrontNorth.Piece = frontNorthPiece;
            cube.NorthWest.Piece = northWestPiece;

            cube.BackNorthEast.Piece = backNorthEastPiece;
            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontNorthWest.Piece = frontNorthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.NorthWest.StickerNorth = cubeNorthWestStickerNorth;
            cube.NorthWest.StickerWest = cubeNorthWestStickerWest;

            cube.BackNorth.StickerBack = cubeBackNorthStickerBack;
            cube.BackNorth.StickerNorth = cubeBackNorthStickerNorth;

            cube.NorthEast.StickerNorth = cubeNorthEastStickerNorth;
            cube.NorthEast.StickerEast = cubeNorthEastStickerEast;

            cube.FrontNorth.StickerFront = cubeFrontNorthStickerFront;
            cube.FrontNorth.StickerNorth = cubeFrontNorthStickerNorth;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        public void TurnUpCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase backNorthPiece = cube.NorthEast.Piece;
            PieceSideModelBase northEastPiece = cube.FrontNorth.Piece;
            PieceSideModelBase frontNorthPiece = cube.NorthWest.Piece;
            PieceSideModelBase northWestPiece = cube.BackNorth.Piece;

            PieceCornerModelBase backNorthEastPiece = cube.FrontNorthEast.Piece;
            PieceCornerModelBase frontNorthEastPiece = cube.FrontNorthWest.Piece;
            PieceCornerModelBase frontNorthWestPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.BackNorthEast.Piece;


            StickerModelBase cubeBackNorthStickerNorth = cube.NorthEast.StickerNorth;
            StickerModelBase cubeBackNorthStickerBack = cube.NorthEast.StickerEast;

            StickerModelBase cubeNorthEastStickerEast = cube.FrontNorth.StickerFront;
            StickerModelBase cubeNorthEastStickerNorth = cube.FrontNorth.StickerNorth;

            StickerModelBase cubeFrontNorthStickerNorth = cube.NorthWest.StickerNorth;
            StickerModelBase cubeFrontNorthStickerFront = cube.NorthWest.StickerWest;

            StickerModelBase cubeNorthWestStickerWest = cube.BackNorth.StickerBack;
            StickerModelBase cubeNorthWestStickerNorth = cube.BackNorth.StickerNorth;


            StickerModelBase cubeBackNorthEastStickerBack = cube.FrontNorthEast.StickerEast;
            StickerModelBase cubeBackNorthEastStickerEast = cube.FrontNorthEast.StickerFront;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.FrontNorthEast.StickerNorth;

            StickerModelBase cubeFrontNorthEastStickerFront = cube.FrontNorthWest.StickerWest;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.FrontNorthWest.StickerNorth;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.FrontNorthWest.StickerFront;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.BackNorthWest.StickerWest;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.BackNorthWest.StickerNorth;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.BackNorthWest.StickerBack;

            StickerModelBase cubeBackNorthWestStickerBack = cube.BackNorthEast.StickerEast;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.BackNorthEast.StickerNorth;
            StickerModelBase cubeBackNorthWestStickerWest = cube.BackNorthEast.StickerBack;

            cube.BackNorth.Piece = backNorthPiece;
            cube.NorthEast.Piece = northEastPiece;
            cube.FrontNorth.Piece = frontNorthPiece;
            cube.NorthWest.Piece = northWestPiece;

            cube.BackNorthEast.Piece = backNorthEastPiece;
            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontNorthWest.Piece = frontNorthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.NorthWest.StickerNorth = cubeNorthWestStickerNorth;
            cube.NorthWest.StickerWest = cubeNorthWestStickerWest;

            cube.BackNorth.StickerBack = cubeBackNorthStickerBack;
            cube.BackNorth.StickerNorth = cubeBackNorthStickerNorth;

            cube.NorthEast.StickerNorth = cubeNorthEastStickerNorth;
            cube.NorthEast.StickerEast = cubeNorthEastStickerEast;

            cube.FrontNorth.StickerFront = cubeFrontNorthStickerFront;
            cube.FrontNorth.StickerNorth = cubeFrontNorthStickerNorth;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        #endregion

        #region Turn Down
        public void TurnDownCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase backSouthPiece = cube.SouthWest.Piece;
            PieceSideModelBase southEastPiece = cube.BackSouth.Piece;
            PieceSideModelBase frontSouthPiece = cube.SouthEast.Piece;
            PieceSideModelBase southWestPiece = cube.FrontSouth.Piece;

            PieceCornerModelBase backSouthEastPiece = cube.BackSouthWest.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.BackSouthEast.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.FrontSouthWest.Piece;

            StickerModelBase cubeBackSouthStickerSouth = cube.SouthWest.StickerSouth;
            StickerModelBase cubeBackSouthStickerBack = cube.SouthWest.StickerWest;

            StickerModelBase cubeSouthEastStickerEast = cube.BackSouth.StickerBack;
            StickerModelBase cubeSouthEastStickerSouth = cube.BackSouth.StickerSouth;

            StickerModelBase cubeFrontSouthStickerSouth = cube.SouthEast.StickerSouth;
            StickerModelBase cubeFrontSouthStickerFront = cube.SouthEast.StickerEast;

            StickerModelBase cubeSouthWestStickerWest = cube.FrontSouth.StickerFront;
            StickerModelBase cubeSouthWestStickerSouth = cube.FrontSouth.StickerSouth;


            StickerModelBase cubeBackSouthEastStickerBack = cube.BackSouthWest.StickerWest;
            StickerModelBase cubeBackSouthEastStickerEast = cube.BackSouthWest.StickerBack;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.BackSouthWest.StickerSouth;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.BackSouthEast.StickerEast;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.BackSouthEast.StickerBack;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.BackSouthEast.StickerSouth;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.FrontSouthEast.StickerEast;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.FrontSouthEast.StickerSouth;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.FrontSouthEast.StickerFront;

            StickerModelBase cubeBackSouthWestStickerBack = cube.FrontSouthWest.StickerWest;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.FrontSouthWest.StickerSouth;
            StickerModelBase cubeBackSouthWestStickerWest = cube.FrontSouthWest.StickerFront;

            cube.BackSouth.Piece = backSouthPiece;
            cube.SouthEast.Piece = southEastPiece;
            cube.FrontSouth.Piece = frontSouthPiece;
            cube.SouthWest.Piece = southWestPiece;

            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;

            cube.SouthWest.StickerSouth = cubeSouthWestStickerSouth;
            cube.SouthWest.StickerWest = cubeSouthWestStickerWest;

            cube.BackSouth.StickerBack = cubeBackSouthStickerBack;
            cube.BackSouth.StickerSouth = cubeBackSouthStickerSouth;

            cube.SouthEast.StickerSouth = cubeSouthEastStickerSouth;
            cube.SouthEast.StickerEast = cubeSouthEastStickerEast;

            cube.FrontSouth.StickerFront = cubeFrontSouthStickerFront;
            cube.FrontSouth.StickerSouth = cubeFrontSouthStickerSouth;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        public void TurnDownClockwise(CubeModel cube)
        {
            PieceSideModelBase backSouthPiece = cube.SouthEast.Piece;
            PieceSideModelBase southEastPiece = cube.FrontSouth.Piece;
            PieceSideModelBase frontSouthPiece = cube.SouthWest.Piece;
            PieceSideModelBase southWestPiece = cube.BackSouth.Piece;

            PieceCornerModelBase backSouthEastPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.FrontSouthWest.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.BackSouthWest.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.BackSouthEast.Piece;


            StickerModelBase cubeBackSouthStickerSouth = cube.SouthEast.StickerSouth;
            StickerModelBase cubeBackSouthStickerBack = cube.SouthEast.StickerEast;

            StickerModelBase cubeSouthEastStickerEast = cube.FrontSouth.StickerFront;
            StickerModelBase cubeSouthEastStickerSouth = cube.FrontSouth.StickerSouth;

            StickerModelBase cubeFrontSouthStickerSouth = cube.SouthWest.StickerSouth;
            StickerModelBase cubeFrontSouthStickerFront = cube.SouthWest.StickerWest;

            StickerModelBase cubeSouthWestStickerWest = cube.BackSouth.StickerBack;
            StickerModelBase cubeSouthWestStickerSouth = cube.BackSouth.StickerSouth;


            StickerModelBase cubeBackSouthEastStickerBack = cube.FrontSouthEast.StickerEast;
            StickerModelBase cubeBackSouthEastStickerEast = cube.FrontSouthEast.StickerFront;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.FrontSouthEast.StickerSouth;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.FrontSouthWest.StickerWest;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.FrontSouthWest.StickerSouth;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.FrontSouthWest.StickerFront;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.BackSouthWest.StickerWest;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.BackSouthWest.StickerSouth;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.BackSouthWest.StickerBack;

            StickerModelBase cubeBackSouthWestStickerBack = cube.BackSouthEast.StickerEast;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.BackSouthEast.StickerSouth;
            StickerModelBase cubeBackSouthWestStickerWest = cube.BackSouthEast.StickerBack;

            cube.BackSouth.Piece = backSouthPiece;
            cube.SouthEast.Piece = southEastPiece;
            cube.FrontSouth.Piece = frontSouthPiece;
            cube.SouthWest.Piece = southWestPiece;

            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;

            cube.SouthWest.StickerSouth = cubeSouthWestStickerSouth;
            cube.SouthWest.StickerWest = cubeSouthWestStickerWest;

            cube.BackSouth.StickerBack = cubeBackSouthStickerBack;
            cube.BackSouth.StickerSouth = cubeBackSouthStickerSouth;

            cube.SouthEast.StickerSouth = cubeSouthEastStickerSouth;
            cube.SouthEast.StickerEast = cubeSouthEastStickerEast;

            cube.FrontSouth.StickerFront = cubeFrontSouthStickerFront;
            cube.FrontSouth.StickerSouth = cubeFrontSouthStickerSouth;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        #endregion


        #region Turn Left
        public void TurnLeftClockwise(CubeModel cube)
        {
            PieceSideModelBase northWestPiece = cube.BackWest.Piece;
            PieceSideModelBase frontWestPiece = cube.NorthWest.Piece;
            PieceSideModelBase southWestPiece = cube.FrontWest.Piece;
            PieceSideModelBase backWestPiece = cube.SouthWest.Piece;

            PieceCornerModelBase frontNorthWestPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.FrontNorthWest.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.FrontSouthWest.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.BackSouthWest.Piece;

            StickerModelBase cubeNorthWestStickerNorth = cube.BackWest.StickerBack;
            StickerModelBase cubeNorthWestStickerWest = cube.BackWest.StickerWest;

            StickerModelBase cubeFrontWestStickerFront = cube.NorthWest.StickerNorth;
            StickerModelBase cubeFrontWestStickerWest = cube.NorthWest.StickerWest;

            StickerModelBase cubeSouthWestStickerSouth = cube.FrontWest.StickerFront;
            StickerModelBase cubeSouthWestStickerWest = cube.FrontWest.StickerWest;

            StickerModelBase cubeBackWestStickerBack = cube.SouthWest.StickerSouth;
            StickerModelBase cubeBackWestStickerWest = cube.SouthWest.StickerWest;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.BackNorthWest.StickerNorth;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.BackNorthWest.StickerBack;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.BackNorthWest.StickerWest;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.FrontNorthWest.StickerNorth;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.FrontNorthWest.StickerFront;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.FrontNorthWest.StickerWest;

            StickerModelBase cubeBackSouthWestStickerBack = cube.FrontSouthWest.StickerSouth;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.FrontSouthWest.StickerFront;
            StickerModelBase cubeBackSouthWestStickerWest = cube.FrontSouthWest.StickerWest;

            StickerModelBase cubeBackNorthWestStickerBack = cube.BackSouthWest.StickerSouth;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.BackSouthWest.StickerBack;
            StickerModelBase cubeBackNorthWestStickerWest = cube.BackSouthWest.StickerWest;

            cube.NorthWest.Piece = northWestPiece;
            cube.FrontWest.Piece = frontWestPiece;
            cube.SouthWest.Piece = southWestPiece;
            cube.BackWest.Piece = backWestPiece;

            cube.FrontNorthWest.Piece = frontNorthWestPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.NorthWest.StickerNorth = cubeNorthWestStickerNorth;
            cube.NorthWest.StickerWest = cubeNorthWestStickerWest;

            cube.FrontWest.StickerFront = cubeFrontWestStickerFront;
            cube.FrontWest.StickerWest = cubeFrontWestStickerWest;

            cube.SouthWest.StickerSouth = cubeSouthWestStickerSouth;
            cube.SouthWest.StickerWest = cubeSouthWestStickerWest;

            cube.BackWest.StickerBack = cubeBackWestStickerBack;
            cube.BackWest.StickerWest = cubeBackWestStickerWest;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }

        public void TurnLeftCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase northWestPiece = cube.FrontWest.Piece;
            PieceSideModelBase frontWestPiece = cube.SouthWest.Piece;
            PieceSideModelBase southWestPiece = cube.BackWest.Piece;
            PieceSideModelBase backWestPiece = cube.NorthWest.Piece;

            PieceCornerModelBase frontNorthWestPiece = cube.FrontSouthWest.Piece;
            PieceCornerModelBase frontSouthWestPiece = cube.BackSouthWest.Piece;
            PieceCornerModelBase backSouthWestPiece = cube.BackNorthWest.Piece;
            PieceCornerModelBase backNorthWestPiece = cube.FrontNorthWest.Piece;

            StickerModelBase cubeNorthWestStickerNorth = cube.FrontWest.StickerFront;
            StickerModelBase cubeNorthWestStickerWest = cube.FrontWest.StickerWest;

            StickerModelBase cubeFrontWestStickerFront = cube.SouthWest.StickerSouth;
            StickerModelBase cubeFrontWestStickerWest = cube.SouthWest.StickerWest;

            StickerModelBase cubeSouthWestStickerSouth = cube.BackWest.StickerBack;
            StickerModelBase cubeSouthWestStickerWest = cube.BackWest.StickerWest;

            StickerModelBase cubeBackWestStickerBack = cube.NorthWest.StickerNorth;
            StickerModelBase cubeBackWestStickerWest = cube.NorthWest.StickerWest;

            StickerModelBase cubeFrontNorthWestStickerFront = cube.FrontSouthWest.StickerSouth;
            StickerModelBase cubeFrontNorthWestStickerNorth = cube.FrontSouthWest.StickerFront;
            StickerModelBase cubeFrontNorthWestStickerWest = cube.FrontSouthWest.StickerWest;

            StickerModelBase cubeFrontSouthWestStickerFront = cube.BackSouthWest.StickerSouth;
            StickerModelBase cubeFrontSouthWestStickerSouth = cube.BackSouthWest.StickerBack;
            StickerModelBase cubeFrontSouthWestStickerWest = cube.BackSouthWest.StickerWest;

            StickerModelBase cubeBackSouthWestStickerBack = cube.BackNorthWest.StickerNorth;
            StickerModelBase cubeBackSouthWestStickerSouth = cube.BackNorthWest.StickerBack;
            StickerModelBase cubeBackSouthWestStickerWest = cube.BackNorthWest.StickerWest;

            StickerModelBase cubeBackNorthWestStickerBack = cube.FrontNorthWest.StickerNorth;
            StickerModelBase cubeBackNorthWestStickerNorth = cube.FrontNorthWest.StickerFront;
            StickerModelBase cubeBackNorthWestStickerWest = cube.FrontNorthWest.StickerWest;

            cube.NorthWest.Piece = northWestPiece;
            cube.FrontWest.Piece = frontWestPiece;
            cube.SouthWest.Piece = southWestPiece;
            cube.BackWest.Piece = backWestPiece;

            cube.FrontNorthWest.Piece = frontNorthWestPiece;
            cube.FrontSouthWest.Piece = frontSouthWestPiece;
            cube.BackSouthWest.Piece = backSouthWestPiece;
            cube.BackNorthWest.Piece = backNorthWestPiece;

            cube.NorthWest.StickerNorth = cubeNorthWestStickerNorth;
            cube.NorthWest.StickerWest = cubeNorthWestStickerWest;

            cube.FrontWest.StickerFront = cubeFrontWestStickerFront;
            cube.FrontWest.StickerWest = cubeFrontWestStickerWest;

            cube.SouthWest.StickerSouth = cubeSouthWestStickerSouth;
            cube.SouthWest.StickerWest = cubeSouthWestStickerWest;

            cube.BackWest.StickerBack = cubeBackWestStickerBack;
            cube.BackWest.StickerWest = cubeBackWestStickerWest;

            cube.FrontNorthWest.StickerFront = cubeFrontNorthWestStickerFront;
            cube.FrontNorthWest.StickerNorth = cubeFrontNorthWestStickerNorth;
            cube.FrontNorthWest.StickerWest = cubeFrontNorthWestStickerWest;

            cube.FrontSouthWest.StickerFront = cubeFrontSouthWestStickerFront;
            cube.FrontSouthWest.StickerSouth = cubeFrontSouthWestStickerSouth;
            cube.FrontSouthWest.StickerWest = cubeFrontSouthWestStickerWest;

            cube.BackSouthWest.StickerBack = cubeBackSouthWestStickerBack;
            cube.BackSouthWest.StickerSouth = cubeBackSouthWestStickerSouth;
            cube.BackSouthWest.StickerWest = cubeBackSouthWestStickerWest;

            cube.BackNorthWest.StickerBack = cubeBackNorthWestStickerBack;
            cube.BackNorthWest.StickerNorth = cubeBackNorthWestStickerNorth;
            cube.BackNorthWest.StickerWest = cubeBackNorthWestStickerWest;

            this.VerifyAllPieces(cube);
        }
        #endregion

        #region Turn Right
        public void TurnRightCounterclockwise(CubeModel cube)
        {
            PieceSideModelBase northEastPiece = cube.BackEast.Piece;
            PieceSideModelBase frontEastPiece = cube.NorthEast.Piece;
            PieceSideModelBase southEastPiece = cube.FrontEast.Piece;
            PieceSideModelBase backEastPiece = cube.SouthEast.Piece;

            PieceCornerModelBase frontNorthEastPiece = cube.BackNorthEast.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.FrontNorthEast.Piece;
            PieceCornerModelBase backSouthEastPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase backNorthEastPiece = cube.BackSouthEast.Piece;

            StickerModelBase cubeNorthEastStickerNorth = cube.BackEast.StickerBack;
            StickerModelBase cubeNorthEastStickerEast = cube.BackEast.StickerEast;

            StickerModelBase cubeFrontEastStickerFront = cube.NorthEast.StickerNorth;
            StickerModelBase cubeFrontEastStickerEast = cube.NorthEast.StickerEast;

            StickerModelBase cubeSouthEastStickerSouth = cube.FrontEast.StickerFront;
            StickerModelBase cubeSouthEastStickerEast = cube.FrontEast.StickerEast;

            StickerModelBase cubeBackEastStickerBack = cube.SouthEast.StickerSouth;
            StickerModelBase cubeBackEastStickerEast = cube.SouthEast.StickerEast;

            StickerModelBase cubeFrontNorthEastStickerFront = cube.BackNorthEast.StickerNorth;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.BackNorthEast.StickerBack;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.BackNorthEast.StickerEast;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.FrontNorthEast.StickerNorth;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.FrontNorthEast.StickerFront;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.FrontNorthEast.StickerEast;

            StickerModelBase cubeBackSouthEastStickerBack = cube.FrontSouthEast.StickerSouth;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.FrontSouthEast.StickerFront;
            StickerModelBase cubeBackSouthEastStickerEast = cube.FrontSouthEast.StickerEast;

            StickerModelBase cubeBackNorthEastStickerBack = cube.BackSouthEast.StickerSouth;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.BackSouthEast.StickerBack;
            StickerModelBase cubeBackNorthEastStickerEast = cube.BackSouthEast.StickerEast;

            cube.NorthEast.Piece = northEastPiece;
            cube.FrontEast.Piece = frontEastPiece;
            cube.SouthEast.Piece = southEastPiece;
            cube.BackEast.Piece = backEastPiece;

            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.BackNorthEast.Piece = backNorthEastPiece;

            cube.NorthEast.StickerNorth = cubeNorthEastStickerNorth;
            cube.NorthEast.StickerEast = cubeNorthEastStickerEast;

            cube.FrontEast.StickerFront = cubeFrontEastStickerFront;
            cube.FrontEast.StickerEast = cubeFrontEastStickerEast;

            cube.SouthEast.StickerSouth = cubeSouthEastStickerSouth;
            cube.SouthEast.StickerEast = cubeSouthEastStickerEast;

            cube.BackEast.StickerBack = cubeBackEastStickerBack;
            cube.BackEast.StickerEast = cubeBackEastStickerEast;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;

            this.VerifyAllPieces(cube);
        }

        public void TurnRightClockwise(CubeModel cube)
        {
            PieceSideModelBase northEastPiece = cube.FrontEast.Piece;
            PieceSideModelBase frontEastPiece = cube.SouthEast.Piece;
            PieceSideModelBase southEastPiece = cube.BackEast.Piece;
            PieceSideModelBase backEastPiece = cube.NorthEast.Piece;

            PieceCornerModelBase frontNorthEastPiece = cube.FrontSouthEast.Piece;
            PieceCornerModelBase frontSouthEastPiece = cube.BackSouthEast.Piece;
            PieceCornerModelBase backSouthEastPiece = cube.BackNorthEast.Piece;
            PieceCornerModelBase backNorthEastPiece = cube.FrontNorthEast.Piece;

            StickerModelBase cubeNorthEastStickerNorth = cube.FrontEast.StickerFront;
            StickerModelBase cubeNorthEastStickerEast = cube.FrontEast.StickerEast;

            StickerModelBase cubeFrontEastStickerFront = cube.SouthEast.StickerSouth;
            StickerModelBase cubeFrontEastStickerEast = cube.SouthEast.StickerEast;

            StickerModelBase cubeSouthEastStickerSouth = cube.BackEast.StickerBack;
            StickerModelBase cubeSouthEastStickerEast = cube.BackEast.StickerEast;

            StickerModelBase cubeBackEastStickerBack = cube.NorthEast.StickerNorth;
            StickerModelBase cubeBackEastStickerEast = cube.NorthEast.StickerEast;

            StickerModelBase cubeFrontNorthEastStickerFront = cube.FrontSouthEast.StickerSouth;
            StickerModelBase cubeFrontNorthEastStickerNorth = cube.FrontSouthEast.StickerFront;
            StickerModelBase cubeFrontNorthEastStickerEast = cube.FrontSouthEast.StickerEast;

            StickerModelBase cubeFrontSouthEastStickerFront = cube.BackSouthEast.StickerSouth;
            StickerModelBase cubeFrontSouthEastStickerSouth = cube.BackSouthEast.StickerBack;
            StickerModelBase cubeFrontSouthEastStickerEast = cube.BackSouthEast.StickerEast;

            StickerModelBase cubeBackSouthEastStickerBack = cube.BackNorthEast.StickerNorth;
            StickerModelBase cubeBackSouthEastStickerSouth = cube.BackNorthEast.StickerBack;
            StickerModelBase cubeBackSouthEastStickerEast = cube.BackNorthEast.StickerEast;

            StickerModelBase cubeBackNorthEastStickerBack = cube.FrontNorthEast.StickerNorth;
            StickerModelBase cubeBackNorthEastStickerNorth = cube.FrontNorthEast.StickerFront;
            StickerModelBase cubeBackNorthEastStickerEast = cube.FrontNorthEast.StickerEast;

            cube.NorthEast.Piece = northEastPiece;
            cube.FrontEast.Piece = frontEastPiece;
            cube.SouthEast.Piece = southEastPiece;
            cube.BackEast.Piece = backEastPiece;

            cube.FrontNorthEast.Piece = frontNorthEastPiece;
            cube.FrontSouthEast.Piece = frontSouthEastPiece;
            cube.BackSouthEast.Piece = backSouthEastPiece;
            cube.BackNorthEast.Piece = backNorthEastPiece;

            cube.NorthEast.StickerNorth = cubeNorthEastStickerNorth;
            cube.NorthEast.StickerEast = cubeNorthEastStickerEast;

            cube.FrontEast.StickerFront = cubeFrontEastStickerFront;
            cube.FrontEast.StickerEast = cubeFrontEastStickerEast;

            cube.SouthEast.StickerSouth = cubeSouthEastStickerSouth;
            cube.SouthEast.StickerEast = cubeSouthEastStickerEast;

            cube.BackEast.StickerBack = cubeBackEastStickerBack;
            cube.BackEast.StickerEast = cubeBackEastStickerEast;

            cube.FrontNorthEast.StickerFront = cubeFrontNorthEastStickerFront;
            cube.FrontNorthEast.StickerNorth = cubeFrontNorthEastStickerNorth;
            cube.FrontNorthEast.StickerEast = cubeFrontNorthEastStickerEast;

            cube.FrontSouthEast.StickerFront = cubeFrontSouthEastStickerFront;
            cube.FrontSouthEast.StickerSouth = cubeFrontSouthEastStickerSouth;
            cube.FrontSouthEast.StickerEast = cubeFrontSouthEastStickerEast;

            cube.BackSouthEast.StickerBack = cubeBackSouthEastStickerBack;
            cube.BackSouthEast.StickerSouth = cubeBackSouthEastStickerSouth;
            cube.BackSouthEast.StickerEast = cubeBackSouthEastStickerEast;

            cube.BackNorthEast.StickerBack = cubeBackNorthEastStickerBack;
            cube.BackNorthEast.StickerNorth = cubeBackNorthEastStickerNorth;
            cube.BackNorthEast.StickerEast = cubeBackNorthEastStickerEast;

            this.VerifyAllPieces(cube);
        }
        #endregion
    }
}
