using RC.Enumerations;
using RC.Model.Stickers;
using System;

namespace RC.Model.Pieces
{

    public class PieceBackNorthEastModel : PieceCornerModelBase       //<PieceBackNorthEastModel>
    {
        public PieceBackNorthEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerBack = new StickerBackModel(this.GetBackStickerColorType(patternCubeType));
            this.StickerNorth = new StickerNorthModel(this.GetNorthStickerColorType(patternCubeType));
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerBack);
            this.Stickers.Add(this.StickerNorth);
            this.Stickers.Add(this.StickerEast);
        }

        public override PositionCornerTypes InitialCornerType { get; protected set; } = PositionCornerTypes.BackNorthEast;


        public StickerBackModel StickerBack { get; private set; }

        public StickerNorthModel StickerNorth { get; private set; }

        public StickerEastModel StickerEast { get; private set; }

        public override PieceCornerModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceBackNorthEastModel(patternCubeType);

            return copy;
        }
    }

}