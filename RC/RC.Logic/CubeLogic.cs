using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using RC.Common.Enumerations;
using RC.Common.Model;
using RC.Common.Model.Pieces;
using RC.Common.Model.Slots;
using RC.Common.Model.Sots;
using RC.Common.Model.Stickers;

namespace RC.Logic
{
    public class CubeLogic: LogicBase
    {

        /// <summary>
        /// 
        ///                          [B  0] [B  1] [B  2]
        ///                          [BNW ] [ BN ] [ BNE]

        ///                          [B  3] [B  4] [B  5]
        ///                          [NW  ] [  N ] [  NE]

        ///                          [B  6] [B  7] [B  8]
        ///                          [FNW ] [ FN ] [ FNE]


        ///  [a 36] [a 37] [a 38]    [C 18] [C 19] [C 20]       [A 45] [A 46] [A 47]    [c 27] [c 28] [c 29]
        ///  [BNW ] [ NW ] [ FNW]    [FNW ] [ FN ] [ FNE]       [FNE ] [ NE ] [ BNE]    [BNW ] [ BN ] [ BNE]

        ///  [a 39] [a 40] [a 41]    [C 21] [C 22] [C 23]       [A 48] [A 49] [A 50]    [c 30] [c 31] [c 32]
        ///  [BW  ] [  W ] [  FW]    [FW  ] [  F ] [  FE]       [FE  ] [  E ] [  BE]    [BW  ] [  B ] [  BE]

        ///  [a 42] [a 43] [a 44]    [C 24] [C 25] [C 26]       [A 51] [A 52] [A 53]    [c 33] [c 34] [c 35]
        ///  [BSW ] [ SW ] [ FSW]    [FSW ] [ FS ] [ FSE]       [FSE ] [ SE ] [ BSE]    [BSW ] [ BS ] [ BSE]


        ///                          [b  9] [b 10] [b 11]
        ///                          [FSW ] [ FS ] [ FSE]

        ///                          [b 12] [b 13] [b 14]
        ///                          [SW  ] [  S ] [  SE]

        ///                          [b 15] [b 16] [b 17]
        ///                          [BSW ] [ BS ] [ BSE]

        /// </summary>
        public CubeLogic()
        {

        }

        public Boolean PieceIsValid(SlotModelBase<PieceSideModelBase> slot)
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
                    return false;
                }
            }

            return true;
        }

        public void VerifyPieceInSlot(SlotModelBase<PieceSideModelBase> slot)
        {

            if (!this.PieceIsValid(slot))
            {
                throw new Exception($"Side {slot} does not contain  {slot.Piece}");
            }
        }

        public Boolean PieceIsValid(SlotModelBase<PieceCornerModelBase> slot)
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
                    return false;
                }
            }

            return true;
        }

        public void VerifyPieceInSlot(SlotModelBase<PieceCornerModelBase> slot)
        {
            
            if (!this.PieceIsValid(slot))
            {
                throw new Exception("Corner Sticker Wrong");
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



        //slot.Piece = corners.Single(x => x.GetNorthStickerColorType() == north || x.GetFrontStickerColorType() == front || x.GetFrontStickerColorType() == west) == 3);


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

        public MoveTypes GetRandomMove()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[4];
                rng.GetBytes(buffer);
                Int32 seedNumber = BitConverter.ToInt32(buffer, 0);

                Int32 randomMove = new Random(seedNumber).Next(0, 27);

                return (MoveTypes)randomMove;
            }
        }

        public MoveTypes[] Scramble(CubeModel cube, Int32 times)
        {
            var moveTypes = new List<MoveTypes>();

            for (var i = 0; i < times; i++)
            {
                MoveTypes moveType = this.GetRandomMove();
                this.RunMove(cube, moveType);
                moveTypes.Add(moveType);
            }

            return moveTypes.ToArray();
        }

        public void SetCubeState(CubeModel cube, String pattern)
        {
            var patternWithColor = String.Empty;

            if (pattern.Contains("A"))
            {
                Char[] patternArray = pattern.ToCharArray();
                foreach (var item in patternArray)
                {
                    patternWithColor += this.GetStickerAbbreviation(item);
                }
            }
            else
            {
                patternWithColor = pattern;
            }

            String north = $"BNW:{ patternWithColor[0]}|BN:{patternWithColor[1]}|BNE:{ patternWithColor[2]}|NW:{ patternWithColor[3]}|N:{ patternWithColor[4]}|NE:{ patternWithColor[5]}|FNW:{ patternWithColor[6]}|FN:{ patternWithColor[7]}|FNE:{ patternWithColor[8]}";
            String south = $"FSW:{ patternWithColor[9]}|FS:{patternWithColor[10]}|FSE:{ patternWithColor[11]}|SW:{ patternWithColor[12]}|S:{ patternWithColor[13]}|SE:{ patternWithColor[14]}|BSW:{ patternWithColor[15]}|BS:{ patternWithColor[16]}|BSE:{ patternWithColor[17]}";
            String front = $"FNW:{ patternWithColor[18]}|FN:{patternWithColor[19]}|FNE:{ patternWithColor[20]}|FW:{ patternWithColor[21]}|F:{ patternWithColor[22]}|FE:{ patternWithColor[23]}|FSW:{ patternWithColor[24]}|FS:{ patternWithColor[25]}|FSE:{ patternWithColor[26]}";
            String back = $"BNW:{ patternWithColor[27]}|BN:{patternWithColor[28]}|BNE:{ patternWithColor[29]}|BW:{ patternWithColor[30]}|B:{ patternWithColor[31]}|BE:{ patternWithColor[32]}|BSW:{ patternWithColor[33]}|BS:{ patternWithColor[34]}|BSE:{ patternWithColor[35]}";
            String west = $"BNW:{ patternWithColor[36]}|NW:{patternWithColor[37]}|FNW:{ patternWithColor[38]}|BW:{ patternWithColor[39]}|W:{ patternWithColor[40]}|FW:{ patternWithColor[41]}|BSW:{ patternWithColor[42]}|SW:{ patternWithColor[43]}|FSW:{ patternWithColor[44]}";
            String east = $"FNE:{ patternWithColor[45]}|NE:{patternWithColor[46]}|BNE:{ patternWithColor[47]}|FE:{ patternWithColor[48]}|E:{ patternWithColor[49]}|BE:{ patternWithColor[50]}|FSE:{ patternWithColor[51]}|SE:{ patternWithColor[52]}|BSE:{ patternWithColor[53]}";

            String detailedCubeState = $"{north},{south},{front},{back},{west},{east}";
            this.SetDetailedCubeState(cube, detailedCubeState);
        }

        public void SetDetailedCubeState(CubeModel cube, String detailedCubeState)
        {
            Dictionary<String, StickerColorTypes> stickerDictionary = this.ParseStickers(detailedCubeState);

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

        public void RunMove(CubeModel cube, MoveTypes move)
        {
            switch (move)
            {
                case MoveTypes.Up:
                    this.TurnUpClockwise(cube);
                    break;
                case MoveTypes.Equator:
                    this.TurnUpClockwise(cube);
                    this.TurnDownCounterclockwise(cube);
                    break;
                case MoveTypes.Down:
                    this.TurnDownClockwise(cube);
                    break;
                case MoveTypes.Right:
                    this.TurnRightClockwise(cube);
                    break;
                case MoveTypes.MeridianPrime:
                    this.TurnLeftCounterclockwise(cube);
                    this.TurnRightClockwise(cube);
                    break;
                case MoveTypes.Left:
                    this.TurnLeftClockwise(cube);
                    break;
                case MoveTypes.Front:
                    this.TurnFrontClockwise(cube);
                    break;
                case MoveTypes.Meridian90th:
                    this.TurnFrontCounterclockwise(cube);
                    this.TurnBackClockwise(cube);
                    break;
                case MoveTypes.Back:
                    this.TurnBackClockwise(cube);
                    break;
                case MoveTypes.Up2:
                    this.TurnUpClockwise(cube);
                    this.TurnUpClockwise(cube);
                    break;
                case MoveTypes.Equator2:
                    this.TurnUpClockwise(cube);
                    this.TurnDownCounterclockwise(cube);
                    this.TurnUpClockwise(cube);
                    this.TurnDownCounterclockwise(cube);
                    break;
                case MoveTypes.Down2:
                    this.TurnDownClockwise(cube);
                    this.TurnDownClockwise(cube);
                    break;
                case MoveTypes.Right2:
                    this.TurnRightClockwise(cube);
                    this.TurnRightClockwise(cube);
                    break;
                case MoveTypes.MeridianPrime2:
                    this.TurnLeftCounterclockwise(cube);
                    this.TurnRightClockwise(cube);
                    this.TurnLeftCounterclockwise(cube);
                    this.TurnRightClockwise(cube);
                    break;
                case MoveTypes.Left2:
                    this.TurnLeftClockwise(cube);
                    this.TurnLeftClockwise(cube);
                    break;
                case MoveTypes.Front2:
                    this.TurnFrontClockwise(cube);
                    this.TurnFrontClockwise(cube);
                    break;
                case MoveTypes.Meridian90th2:
                    this.TurnFrontCounterclockwise(cube);
                    this.TurnBackClockwise(cube);
                    this.TurnFrontCounterclockwise(cube);
                    this.TurnBackClockwise(cube);
                    break;
                case MoveTypes.Back2:
                    this.TurnBackClockwise(cube);
                    this.TurnBackClockwise(cube);
                    break;
                case MoveTypes.UpReverse:
                    this.TurnUpCounterclockwise(cube);
                    break;
                case MoveTypes.EquatorReverse:
                    this.TurnUpCounterclockwise(cube);
                    this.TurnDownClockwise(cube);
                    break;
                case MoveTypes.DownReverse:
                    this.TurnDownCounterclockwise(cube);
                    break;
                case MoveTypes.RightReverse:
                    this.TurnRightCounterclockwise(cube);
                    break;
                case MoveTypes.MeridianPrimeReverse:
                    this.TurnLeftClockwise(cube);
                    this.TurnRightCounterclockwise(cube);
                    break;
                case MoveTypes.LeftReverse:
                    this.TurnLeftCounterclockwise(cube);
                    break;
                case MoveTypes.FrontReverse:
                    this.TurnFrontCounterclockwise(cube);
                    break;
                case MoveTypes.Meridian90thReverse:
                    this.TurnFrontClockwise(cube);
                    this.TurnBackCounterclockwise(cube);
                    break;
                case MoveTypes.BackReverse:
                    this.TurnBackCounterclockwise(cube);
                    break;

            }
        }

        public void RunMoves(CubeModel[] cubes, String moves)
        {
            foreach (CubeModel cube in cubes)
            {
                this.RunMoves(cube, moves);
            }
        }

        public void RunMoves(CubeModel cube, String moves)
        {
            if (moves.Contains(","))
            {
                foreach (String move in moves.Split(','))
                {
                    this.RunMove(cube, this.Convert(move));
                }
            }
            else
            {
                this.RunMove(cube, this.Convert(moves));
            }
            this.VerifyAllPieces(cube);
        }

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

        public CubeModel CloneCube(CubeModel cube)
        {
            return this.CloneCube(cube, this.GetXyzCubeType(cube));
        }
        public CubeModel CloneCube(CubeModel cube, XyzCubeTypes xyzCubeType)
        {
            CubeModel result = this.Create(xyzCubeType);

            this.VerifyAllPieces(cube);

            String detailedCubeState =  this.GetDetailedCubeState(cube);

            this.SetDetailedCubeState(result, detailedCubeState);

            return result;
        }

        public CubeModel[] CreateAllVariations()
        {
            var result = new List<CubeModel>();

            result.Add(this.Create(XyzCubeTypes.BlueOrangeWhite));

            result.Add(this.Create(XyzCubeTypes.BlueRedYellow));

            result.Add(this.Create(XyzCubeTypes.BlueWhiteRed));

            result.Add(this.Create(XyzCubeTypes.BlueYellowOrange));


            result.Add(this.Create(XyzCubeTypes.GreenOrangeYellow));

            result.Add(this.Create(XyzCubeTypes.GreenRedWhite));

            result.Add(this.Create(XyzCubeTypes.GreenWhiteOrange));

            result.Add(this.Create(XyzCubeTypes.GreenYellowRed));


            result.Add(this.Create(XyzCubeTypes.OrangeBlueYellow));

            result.Add(this.Create(XyzCubeTypes.OrangeGreenWhite));

            result.Add(this.Create(XyzCubeTypes.OrangeWhiteBlue));

            result.Add(this.Create(XyzCubeTypes.OrangeYellowGreen));


            result.Add(this.Create(XyzCubeTypes.RedBlueWhite));

            result.Add(this.Create(XyzCubeTypes.RedGreenYellow));

            result.Add(this.Create(XyzCubeTypes.RedWhiteGreen));

            result.Add(this.Create(XyzCubeTypes.RedYellowBlue));


            result.Add(this.Create(XyzCubeTypes.WhiteBlueOrange));

            result.Add(this.Create(XyzCubeTypes.WhiteGreenRed));

            result.Add(this.Create(XyzCubeTypes.WhiteOrangeGreen));

            result.Add(this.Create(XyzCubeTypes.WhiteRedBlue));

            result.Add(this.Create(XyzCubeTypes.YellowBlueRed));

            result.Add(this.Create(XyzCubeTypes.YellowGreenOrange));

            result.Add(this.Create(XyzCubeTypes.YellowOrangeBlue));

            result.Add(this.Create(XyzCubeTypes.YellowRedGreen));
           
            return result.ToArray();
        }

      
        public CubeModel Create(XyzCubeTypes patternCubeType)
        {
            var cubePeiceBag = new CubePeiceBagModel(patternCubeType);

            var result = new CubeModel(cubePeiceBag);

            //********************************************************
            //      STICKERS
            //********************************************************

            result.Front.StickerFront = cubePeiceBag.FrontPiece.StickerFront;
            result.Back.StickerBack = cubePeiceBag.BackPiece.StickerBack;
            result.North.StickerNorth = cubePeiceBag.NorthPiece.StickerNorth;
            result.East.StickerEast = cubePeiceBag.EastPiece.StickerEast;
            result.South.StickerSouth = cubePeiceBag.SouthPiece.StickerSouth;
            result.West.StickerWest = cubePeiceBag.WestPiece.StickerWest;

            result.NorthEast.StickerNorth = cubePeiceBag.NorthEastPiece.StickerNorth;
            result.NorthEast.StickerEast = cubePeiceBag.NorthEastPiece.StickerEast;

            result.NorthWest.StickerNorth = cubePeiceBag.NorthWestPiece.StickerNorth;
            result.NorthWest.StickerWest = cubePeiceBag.NorthWestPiece.StickerWest;

            result.FrontNorth.StickerFront = cubePeiceBag.FrontNorthPiece.StickerFront;
            result.FrontNorth.StickerNorth = cubePeiceBag.FrontNorthPiece.StickerNorth;

            result.BackNorth.StickerBack = cubePeiceBag.BackNorthPiece.StickerBack;
            result.BackNorth.StickerNorth = cubePeiceBag.BackNorthPiece.StickerNorth;


            result.SouthEast.StickerSouth = cubePeiceBag.SouthEastPiece.StickerSouth;
            result.SouthEast.StickerEast = cubePeiceBag.SouthEastPiece.StickerEast;

            result.SouthWest.StickerSouth = cubePeiceBag.SouthWestPiece.StickerSouth;
            result.SouthWest.StickerWest = cubePeiceBag.SouthWestPiece.StickerWest;

            result.FrontSouth.StickerFront = cubePeiceBag.FrontSouthPiece.StickerFront;
            result.FrontSouth.StickerSouth = cubePeiceBag.FrontSouthPiece.StickerSouth;

            result.BackSouth.StickerBack = cubePeiceBag.BackSouthPiece.StickerBack;
            result.BackSouth.StickerSouth = cubePeiceBag.BackSouthPiece.StickerSouth;


            result.FrontEast.StickerFront = cubePeiceBag.FrontEastPiece.StickerFront;
            result.FrontEast.StickerEast = cubePeiceBag.FrontEastPiece.StickerEast;

            result.FrontWest.StickerFront = cubePeiceBag.FrontWestPiece.StickerFront;
            result.FrontWest.StickerWest = cubePeiceBag.FrontWestPiece.StickerWest;

            result.BackEast.StickerEast = cubePeiceBag.BackEastPiece.StickerEast;
            result.BackEast.StickerBack = cubePeiceBag.BackEastPiece.StickerBack;

            result.BackWest.StickerBack = cubePeiceBag.BackWestPiece.StickerBack;
            result.BackWest.StickerWest = cubePeiceBag.BackWestPiece.StickerWest;


            result.FrontNorthEast.StickerFront = cubePeiceBag.FrontNorthEastPiece.StickerFront;
            result.FrontNorthEast.StickerNorth = cubePeiceBag.FrontNorthEastPiece.StickerNorth;
            result.FrontNorthEast.StickerEast = cubePeiceBag.FrontNorthEastPiece.StickerEast;

            result.FrontSouthEast.StickerFront = cubePeiceBag.FrontSouthEastPiece.StickerFront;
            result.FrontSouthEast.StickerSouth = cubePeiceBag.FrontSouthEastPiece.StickerSouth;
            result.FrontSouthEast.StickerEast = cubePeiceBag.FrontSouthEastPiece.StickerEast;

            result.FrontSouthWest.StickerFront = cubePeiceBag.FrontSouthWestPiece.StickerFront;
            result.FrontSouthWest.StickerSouth = cubePeiceBag.FrontSouthWestPiece.StickerSouth;
            result.FrontSouthWest.StickerWest = cubePeiceBag.FrontSouthWestPiece.StickerWest;

            result.FrontNorthWest.StickerFront = cubePeiceBag.FrontNorthWestPiece.StickerFront;
            result.FrontNorthWest.StickerNorth = cubePeiceBag.FrontNorthWestPiece.StickerNorth;
            result.FrontNorthWest.StickerWest = cubePeiceBag.FrontNorthWestPiece.StickerWest;


            result.BackNorthEast.StickerBack = cubePeiceBag.BackNorthEastPiece.StickerBack;
            result.BackNorthEast.StickerNorth = cubePeiceBag.BackNorthEastPiece.StickerNorth;
            result.BackNorthEast.StickerEast = cubePeiceBag.BackNorthEastPiece.StickerEast;

            result.BackSouthEast.StickerBack = cubePeiceBag.BackSouthEastPiece.StickerBack;
            result.BackSouthEast.StickerSouth = cubePeiceBag.BackSouthEastPiece.StickerSouth;
            result.BackSouthEast.StickerEast = cubePeiceBag.BackSouthEastPiece.StickerEast;

            result.BackSouthWest.StickerBack = cubePeiceBag.BackSouthWestPiece.StickerBack;
            result.BackSouthWest.StickerSouth = cubePeiceBag.BackSouthWestPiece.StickerSouth;
            result.BackSouthWest.StickerWest = cubePeiceBag.BackSouthWestPiece.StickerWest;

            result.BackNorthWest.StickerBack = cubePeiceBag.BackNorthWestPiece.StickerBack;
            result.BackNorthWest.StickerNorth = cubePeiceBag.BackNorthWestPiece.StickerNorth;
            result.BackNorthWest.StickerWest = cubePeiceBag.BackNorthWestPiece.StickerWest;

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
