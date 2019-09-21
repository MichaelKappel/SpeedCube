using RC.Common.Enumerations;
using RC.Common.Model.Slots; using RC.Common.Model.Stickers;


namespace RC.Common.Model.Pieces
{

    public class PieceEastModel : PieceMiddleModelBase
    {
        public PieceEastModel(XyzCubeTypes patternCubeType) : base()
        {
            this.StickerEast = new StickerEastModel(this.GetEastStickerColorType(patternCubeType));

            this.Stickers.Add(this.StickerEast);
        }

        public override PositionMiddleTypes InitialMiddleType { get; protected set; } = PositionMiddleTypes.East;

        public StickerEastModel StickerEast { get; private set; }

        public SlotNorthEastModel SlotNorthEast { get; set; }

        public SlotFrontEastModel SlotFrontEast { get; set; }

        public SlotSouthEastModel SlotSouthEast { get; set; }

        public SlotBackEastModel SlotBackEast { get; set; }
        public override PieceMiddleModelBase CopyPiece(XyzCubeTypes patternCubeType)
        {
            var copy = new PieceEastModel(patternCubeType);

            return copy;
        }
    }

}