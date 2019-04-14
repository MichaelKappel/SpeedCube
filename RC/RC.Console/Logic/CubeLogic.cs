using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RC.Enumerations;
using RC.Model;
using RC.Model.Pieces;

namespace RC.Logic
{
    public class CubeLogic
    {
        public CubeLogic()
        {

        }

        public void VerifyPieceInSlot(SlotModelBase<PieceSideModelBase> slot)
        {
            HashSet<StickerModelBase> slotStickers = slot.GetStickers();
            if (slotStickers.Count != slot.Piece.Stickers.Count)
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
            HashSet<StickerModelBase> slotStickers = slot.GetStickers();
            if (slotStickers.Count != slot.Piece.Stickers.Count)
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

        }

        public String GetCubeState(CubeModel cube)
        {
            String north = $"BNW:{cube.BackNorthWest.StickerNorth}|BN:{cube.BackNorth.StickerNorth}|BNE:{cube.BackNorthEast.StickerNorth}|NW:{cube.NorthWest.StickerNorth}|N:{cube.North.StickerNorth}|NE:{cube.NorthEast.StickerNorth}|FNW:{cube.FrontNorthWest.StickerNorth}|FN:{cube.FrontNorth.StickerNorth}|FNE:{cube.FrontNorthEast.StickerNorth}";

            String south = $"FSW:{cube.FrontSouthWest.StickerSouth}|FS:{cube.FrontSouth.StickerSouth}|FSE:{cube.FrontSouthEast.StickerSouth}|SW:{cube.FrontSouthEast.StickerSouth}|S:{cube.South.StickerSouth}|SE:{cube.SouthEast.StickerSouth}|BSW:{cube.BackSouthWest.StickerSouth}|BS:{cube.BackSouth.StickerSouth}|BSE:{cube.BackSouthEast.StickerSouth}";

            String front = $"FNW:{cube.FrontNorthWest.StickerFront}|FN:{cube.FrontNorth.StickerFront}|FNE:{cube.FrontNorth.StickerFront}|FW:{cube.FrontWest.StickerFront}|F:{cube.Front.StickerFront}|FE:{cube.FrontEast.StickerFront}|FSW:{cube.FrontNorthWest.StickerFront}|FS:{cube.FrontNorth.StickerFront}|FSE:{cube.FrontNorth.StickerFront}";
        
            String back = $"BNW:{cube.BackNorthWest.StickerBack}|BN:{cube.BackNorth.StickerBack}|BNE:{cube.BackNorth.StickerBack}|BW:{cube.BackWest.StickerBack}|B:{cube.Back.StickerBack}|BE:{cube.BackEast.StickerBack}|BSW:{cube.BackNorthWest.StickerBack}|BS:{cube.BackNorth.StickerBack}|BSE:{cube.BackNorth.StickerBack}";
        
            String west = $"BNW:{cube.BackNorthWest.StickerWest}|NW:{cube.NorthWest.StickerWest}|FNW:{cube.FrontNorthWest.StickerWest}|BW:{cube.BackWest.StickerWest}|W:{cube.West.StickerWest}|FW:{cube.FrontWest.StickerWest}|BSW:{cube.BackSouthWest.StickerWest}|SW:{cube.SouthWest.StickerWest}|FSW:{cube.FrontSouthWest.StickerWest}";

            String east = $"FNE:{cube.FrontNorthEast.StickerEast}|NE:{cube.NorthEast.StickerEast}|BNE:{cube.BackNorthEast.StickerEast}|FE:{cube.FrontEast.StickerEast}|E:{cube.East.StickerEast}|BE:{cube.BackEast.StickerEast}|FSE:{cube.FrontSouthEast.StickerEast}|SE:{cube.SouthEast.StickerEast}|BSW:{cube.BackSouthEast.StickerEast}";

            return $"{north},{south},{front},{back},{west},{east}";
        }

        public void SetCubeState(CubeModel cube)
        {

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
        }

        //public void GetStickerCode(StickerModelBase sticker)
        //{
        //    switch (sticker.StickerColorType)
        //    {
        //        case StickerColorTypes.Blue:
        //            return "B"
        //    }
        //}

        public CubeModel Create()
        {
            var result = new CubeModel();

            //********************************************************
            //      Pieces
            //********************************************************

            var frontNorthPiece = new PieceFrontNorthModel();
            var frontEastPiece = new PieceFrontEastModel();
            var frontSouthPiece = new PieceFrontSouthModel();
            var frontWestPiece = new PieceFrontWestModel();

            var frontNorthEastPiece = new PieceFrontNorthEastModel();
            var frontSouthEastPiece = new PieceFrontSouthEastModel();
            var frontSouthWestPiece = new PieceFrontSouthWestModel();
            var frontNorthWestPiece = new PieceFrontNorthWestModel();

            var northEastPiece = new PieceNorthEastModel();
            var southEastPiece = new PieceSouthEastModel();
            var southWestPiece = new PieceSouthWestModel();
            var northWestPiece = new PieceNorthWestModel();

            var backNorthPiece = new PieceBackNorthModel();
            var backEastPiece = new PieceBackEastModel();
            var backSouthPiece = new PieceBackSouthModel();
            var backWestPiece = new PieceBackWestModel();

            var backNorthEastPiece = new PieceBackNorthEastModel();
            var backSouthEastPiece = new PieceBackSouthEastModel();
            var backSouthWestPiece = new PieceBackSouthWestModel();
            var backNorthWestPiece = new PieceBackNorthWestModel();

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

            result.NorthEast.StickerNorth = northEastPiece.StickerNorthEastWhite;
            result.NorthEast.StickerEast = northEastPiece.StickerNorthEastOrange;

            result.NorthWest.StickerNorth = northWestPiece.StickerNorthWestWhite;
            result.NorthWest.StickerWest = northWestPiece.StickerNorthWestRed;

            result.FrontNorth.StickerFront = frontNorthPiece.StickerFrontNorthBlue;
            result.FrontNorth.StickerNorth = frontNorthPiece.StickerFrontNorthWhite;

            result.BackNorth.StickerBack = backNorthPiece.StickerBackNorthGreen;
            result.BackNorth.StickerNorth = backNorthPiece.StickerBackNorthWhite;


            result.SouthEast.StickerSouth = southEastPiece.StickerSouthEastYellow;
            result.SouthEast.StickerEast = southEastPiece.StickerSouthEastOrange;

            result.SouthWest.StickerSouth = southWestPiece.StickerSouthWestYellow;
            result.SouthWest.StickerWest = southWestPiece.StickerSouthWestRed;

            result.FrontSouth.StickerFront = frontSouthPiece.StickerFrontSouthBlue;
            result.FrontSouth.StickerSouth = frontSouthPiece.StickerFrontSouthYellow;

            result.BackSouth.StickerBack = backSouthPiece.StickerBackSouthGreen;
            result.BackSouth.StickerSouth = backSouthPiece.StickerBackSouthYellow;


            result.FrontEast.StickerFront = frontEastPiece.StickerFrontEastBlue;
            result.FrontEast.StickerEast = frontEastPiece.StickerFrontEastOrange;

            result.FrontWest.StickerFront = frontWestPiece.StickerFrontWestBlue;
            result.FrontWest.StickerWest = frontWestPiece.StickerFrontWestRed;

            result.BackEast.StickerEast = backEastPiece.StickerBackEastOrange;
            result.BackEast.StickerBack = backEastPiece.StickerBackEastGreen;

            result.BackWest.StickerBack = backWestPiece.StickerBackWestGreen;
            result.BackWest.StickerWest = backWestPiece.StickerBackWestRed;


            result.FrontNorthEast.StickerFront = frontNorthEastPiece.StickerFrontNorthEastBlue;
            result.FrontNorthEast.StickerNorth = frontNorthEastPiece.StickerFrontNorthEastWhite;
            result.FrontNorthEast.StickerEast = frontNorthEastPiece.StickerFrontNorthEastOrange;

            result.FrontSouthEast.StickerFront = frontSouthEastPiece.StickerFrontSouthEastBlue;
            result.FrontSouthEast.StickerSouth = frontSouthEastPiece.StickerFrontSouthEastYellow;
            result.FrontSouthEast.StickerEast = frontSouthEastPiece.StickerFrontSouthEastOrange;

            result.FrontSouthWest.StickerFront = frontSouthWestPiece.StickerFrontSouthWestBlue;
            result.FrontSouthWest.StickerSouth = frontSouthWestPiece.StickerFrontSouthWestYellow;
            result.FrontSouthWest.StickerWest = frontSouthWestPiece.StickerFrontSouthWestRed;

            result.FrontNorthWest.StickerFront = frontNorthWestPiece.StickerFrontNorthWestBlue;
            result.FrontNorthWest.StickerNorth = frontNorthWestPiece.StickerFrontNorthWestWhite;
            result.FrontNorthWest.StickerWest = frontNorthWestPiece.StickerFrontNorthWestRed;


            result.BackNorthEast.StickerBack = backNorthEastPiece.StickerBackNorthEastGreen;
            result.BackNorthEast.StickerNorth = backNorthEastPiece.StickerBackNorthEastWhite;
            result.BackNorthEast.StickerEast = backNorthEastPiece.StickerBackNorthEastOrange;

            result.BackSouthEast.StickerBack = backSouthEastPiece.StickerBackSouthEastGreen;
            result.BackSouthEast.StickerSouth = backSouthEastPiece.StickerBackSouthEastYellow;
            result.BackSouthEast.StickerEast = backSouthEastPiece.StickerBackSouthEastOrange;

            result.BackSouthWest.StickerBack = backSouthWestPiece.StickerBackSouthWestGreen;
            result.BackSouthWest.StickerSouth = backSouthWestPiece.StickerBackSouthWestYellow;
            result.BackSouthWest.StickerWest = backSouthWestPiece.StickerBackSouthWestRed;

            result.BackNorthWest.StickerBack = backNorthWestPiece.StickerBackNorthWestGreen;
            result.BackNorthWest.StickerNorth = backNorthWestPiece.StickerBackNorthWestWhite;
            result.BackNorthWest.StickerWest = backNorthWestPiece.StickerBackNorthWestRed;

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
