using RC.Enumerations;
using RC.Model.Pieces;
using RC.Model.Slots; using RC.Model.Stickers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RC.Model
{
    public class CubePatternFaceModel
    {
        public CubePatternFaceModel(
            PaternStickerTypes face52, PaternStickerTypes face60, PaternStickerTypes face_7,
            PaternStickerTypes face15, PaternStickerTypes face00, PaternStickerTypes face22,
            PaternStickerTypes face30, PaternStickerTypes face37, PaternStickerTypes face45
            )
        {
            this.Face52 = face52;
            this.Face60 = face60;
            this.Face07 = face_7;
            this.Face15 = face15;
            this.Face00 = face00;
            this.Face22 = face22;
            this.Face30 = face30;
            this.Face37 = face37;
            this.Face45 = face45;
        }

        public PaternStickerTypes  Face52 { get; protected set; }
        public PaternStickerTypes  Face60 { get; protected set; }
        public PaternStickerTypes  Face07 { get; protected set; }
        public PaternStickerTypes  Face15 { get; protected set; }
        public PaternStickerTypes  Face00 { get; protected set; }
        public PaternStickerTypes  Face22 { get; protected set; }
        public PaternStickerTypes  Face30 { get; protected set; }
        public PaternStickerTypes  Face37 { get; protected set; }
        public PaternStickerTypes  Face45 { get; protected set; }
    }
}