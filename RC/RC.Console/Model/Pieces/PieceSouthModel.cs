﻿using RC.Enumerations;
using RC.Model.Slots; using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceSouthModel : PieceMiddleModelBase
    {
        public PieceSouthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerSouth = new StickerSouthModel(this.GetSouthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerSouth);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.South;

        public StickerSouthModel StickerSouth { get; private set; }


        public SlotBackSouthModel SlotBackSouth { get; set; }

        public SlotSouthWestModel SlotSouthWest { get; set; }

        public SlotFrontSouthModel SlotFrontSouth { get; set; }

        public SlotSouthEastModel SlotSouthEast { get; set; }

        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceSouthModel(patternCubeType);

            return copy;
        }
    }

}