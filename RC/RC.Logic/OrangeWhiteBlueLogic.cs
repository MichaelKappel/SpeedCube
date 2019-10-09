using RC.Common.Enumerations;
using RC.Common.Model.Pieces;
using RC.Common.Model.Slots;
using RC.Common.Model.Stickers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC.Common.Model
{
    public class OrangeWhiteBlueLogic
    {

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

        public CubeModel Create(XyzCubeTypes patternCubeType, String[] sides)
        {
            var cubePeiceBag = new CubePeiceBagModel(patternCubeType);

            var result = new CubeModel(cubePeiceBag);

            List<StickerIndexModel> GetCorners(Char[] rawStickers, StickerColorTypes stickerColorType)
            {
                return new List<StickerIndexModel>() {
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[0]), 0, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[2]), 2, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[6]), 6, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[8]), 8, stickerColorType)
                    };
            }

            List<StickerIndexModel> GetSides(Char[] rawStickers, StickerColorTypes stickerColorType)
            {
                return new List<StickerIndexModel>() {
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[1]), 1, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[3]), 3, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[5]), 5, stickerColorType),
                        new StickerIndexModel(this.GetStickerColorType(rawStickers[7]), 7, stickerColorType)
                     };

            }

            String whiteCommand = String.Empty;
            String yellowCommand = String.Empty;
            String blueCommand = String.Empty;
            String greenCommand = String.Empty;
            String redCommand = String.Empty;
            String orangeCommand = String.Empty;
            {


                foreach (var side in sides)
                {
                    switch (side[4])
                    {
                        case 'W':
                            whiteCommand = side;
                            break;
                        case 'Y':
                            yellowCommand = side;
                            break;
                        case 'B':
                            blueCommand = side;
                            break;
                        case 'G':
                            greenCommand = side;
                            break;
                        case 'R':
                            redCommand = side;
                            break;
                        case 'O':
                            orangeCommand = side;
                            break;
                        default:
                            break;
                    }
                }
            }

            this.VerifyRawCube(whiteCommand, yellowCommand, blueCommand, greenCommand, redCommand, orangeCommand);

            Char[] whiteStep = whiteCommand.ToCharArray();
            Char[] yellowStep = yellowCommand.ToCharArray();
            Char[] blueStep = blueCommand.ToCharArray();
            Char[] greenStep = greenCommand.ToCharArray();
            Char[] redStep = redCommand.ToCharArray();
            Char[] orangeStep = orangeCommand.ToCharArray();

            var allStickers = new List<StickerIndexModel>();

            allStickers.AddRange(GetCorners(whiteStep, StickerColorTypes.White));
            allStickers.AddRange(GetCorners(yellowStep, StickerColorTypes.Yellow));
            allStickers.AddRange(GetCorners(blueStep, StickerColorTypes.Blue));
            allStickers.AddRange(GetCorners(greenStep, StickerColorTypes.Green));
            allStickers.AddRange(GetCorners(redStep, StickerColorTypes.Red));
            allStickers.AddRange(GetCorners(orangeStep, StickerColorTypes.Orange));

            allStickers.AddRange(GetSides(whiteStep, StickerColorTypes.White));
            allStickers.AddRange(GetSides(yellowStep, StickerColorTypes.Yellow));
            allStickers.AddRange(GetSides(blueStep, StickerColorTypes.Blue));
            allStickers.AddRange(GetSides(greenStep, StickerColorTypes.Green));
            allStickers.AddRange(GetSides(redStep, StickerColorTypes.Red));
            allStickers.AddRange(GetSides(orangeStep, StickerColorTypes.Orange));

            SlotSideModelBase pieceFrontNorthModel = this.FindSideSlot(result, allStickers);

            return null;

        }

        public SlotSideModelBase FindSideSlot(CubeModel cube,
                  IList<StickerIndexModel> stickers
            )
        {
            SlotSideModelBase result = null;

            PieceFrontNorthModel pieceFrontNorthWest = new PieceFrontNorthModel(XyzCubeTypes.OrangeWhiteBlue);

            IList<StickerIndexModel> orangeStickers = stickers.Where(x => x.SideStickerColorType == StickerColorTypes.Orange).ToList();
            IList<StickerIndexModel> whiteStickers = stickers.Where(x => x.SideStickerColorType == StickerColorTypes.White).ToList();
            IList<StickerIndexModel> blueeStickers = stickers.Where(x => x.SideStickerColorType == StickerColorTypes.Blue).ToList();



            return result;
        }

        public SlotFrontNorthWestModel FindSlotWherePieceFrontNorthWest(
                  List<StickerIndexModel> whiteCorners,
                  List<StickerIndexModel> yellowCorners,
                  List<StickerIndexModel> blueCorners,
                  List<StickerIndexModel> greenCorners,
                  List<StickerIndexModel> redCorners,
                  List<StickerIndexModel> orangeCorners
            )
        {
            SlotFrontNorthWestModel result = null;

            PieceFrontNorthWestModel pieceFrontNorthWest = new PieceFrontNorthWestModel(XyzCubeTypes.OrangeWhiteBlue);

            var posiblePieceOnWhiteSide = whiteCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            var posiblePieceOnYellowSide = yellowCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            var posiblePieceOnBlueSide = blueCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            var posiblePieceOnGreenSide = greenCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            var posiblePieceOnRedSide = redCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            var posiblePieceOnOrangeSide = orangeCorners.Where(x => {
                return x.StickerColorType == pieceFrontNorthWest.StickerFront.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerWest.StickerColorType
                    || x.StickerColorType == pieceFrontNorthWest.StickerNorth.StickerColorType;
            }).ToArray();

            return result;
        }
        public void VerifyRawCube(String whiteCommand, String yellowCommand, String blueCommand, String greenCommand, String redCommand, String orangeCommand)
        {
            Char[] allSides = String.Concat(whiteCommand, yellowCommand, blueCommand, greenCommand, redCommand, orangeCommand).ToCharArray();

            if (allSides.Length != 54)
            {
                throw new Exception("Cube must contain 54 stickers");
            }
            else if (allSides.Where(x => x == 'W').Count() != 9)
            {
                throw new Exception("Cube must contain 9 white stickers");
            }
            else if (allSides.Where(x => x == 'Y').Count() != 9)
            {
                throw new Exception("Cube must contain 9 yellow stickers");
            }
            else if (allSides.Where(x => x == 'B').Count() != 9)
            {
                throw new Exception("Cube must contain 9 blue stickers");
            }
            else if (allSides.Where(x => x == 'G').Count() != 9)
            {
                throw new Exception("Cube must contain 9 green stickers");
            }
            else if (allSides.Where(x => x == 'O').Count() != 9)
            {
                throw new Exception("Cube must contain 9 orange stickers");
            }

            this.VerifyRawCubeSide(StickerColorTypes.White, whiteCommand);
            this.VerifyRawCubeSide(StickerColorTypes.Yellow, yellowCommand);
            this.VerifyRawCubeSide(StickerColorTypes.Blue, blueCommand);
            this.VerifyRawCubeSide(StickerColorTypes.Green, greenCommand);
            this.VerifyRawCubeSide(StickerColorTypes.Red, redCommand);
            this.VerifyRawCubeSide(StickerColorTypes.Orange, orangeCommand);
        }


        public void VerifyRawCubeSide(StickerColorTypes stickerColorType, string sideRaw)
        {
            if (sideRaw.Length != 9)
            {
                throw new Exception($"Expected side length of 9 but got {sideRaw.Length} on {stickerColorType} side");
            }
            else if (this.GetStickerColorType(sideRaw[4]) != stickerColorType)
            {
                throw new Exception($"Expected {stickerColorType} but {sideRaw[4]} was in it's place");
            }
        }

    }
}
