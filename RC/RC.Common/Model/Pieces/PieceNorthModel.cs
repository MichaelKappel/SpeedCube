﻿using RC.Common.Enumerations;
using RC.Common.Model.Slots;
using RC.Common.Model.Stickers;
using System;

namespace RC.Common.Model.Pieces
{

    public class PieceNorthModel : PieceMiddleModelBase
    {
        public PieceNorthModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerNorth);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.North;

        public StickerNorthModel StickerNorth { get; private set; }


        public SlotBackNorthModel SlotBackNorth { get; set; }

        public SlotNorthWestModel SlotNorthWest { get; set; }

        public SlotFrontNorthModel SlotFrontNorth { get; set; }

        public SlotNorthEastModel SlotNorthEast { get; set; }

        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceNorthModel(patternCubeType);

            return copy;
        }
    }

}