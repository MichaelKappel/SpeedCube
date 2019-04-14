using RC.Enumerations;
using RC.Model.Pieces;
using RC.Model.Slots;
using System.Linq;

namespace RC.Model
{
    public class CubeModel
    {
        public CubeModel()
        {

        }

        //Side
        public PieceNorthModel North { get; } = new PieceNorthModel();
        public PieceSouthModel South { get; } = new PieceSouthModel();
        public PieceWestModel West { get; } = new PieceWestModel();
        public PieceEastModel East { get; } = new PieceEastModel();
        public PieceFrontModel Front { get; } = new PieceFrontModel();
        public PieceBackModel Back { get; } = new PieceBackModel();

        //Front
        public SlotFrontNorthModel FrontNorth { get; } = new SlotFrontNorthModel();
        public SlotFrontNorthEastModel FrontNorthEast { get; } = new SlotFrontNorthEastModel();
        public SlotFrontEastModel FrontEast { get; } = new SlotFrontEastModel();
        public SlotFrontSouthEastModel FrontSouthEast { get; } = new SlotFrontSouthEastModel();
        public SlotFrontSouthModel FrontSouth { get; } = new SlotFrontSouthModel();
        public SlotFrontSouthWestModel FrontSouthWest { get; } = new SlotFrontSouthWestModel();
        public SlotFrontWestModel FrontWest { get; } = new SlotFrontWestModel();
        public SlotFrontNorthWestModel FrontNorthWest { get; } = new SlotFrontNorthWestModel();

        //Sides
        public SlotNorthEastModel NorthEast { get; } = new SlotNorthEastModel();
        public SlotSouthEastModel SouthEast { get; } = new SlotSouthEastModel();
        public SlotSouthWestModel SouthWest { get; } = new SlotSouthWestModel();
        public SlotNorthWestModel NorthWest { get; } = new SlotNorthWestModel();

        //Back
        public SlotBackNorthModel BackNorth { get; } = new SlotBackNorthModel();
        public SlotBackNorthEastModel BackNorthEast { get; } = new SlotBackNorthEastModel();
        public SlotBackEastModel BackEast { get; } = new SlotBackEastModel();
        public SlotBackSouthEastModel BackSouthEast { get; } = new SlotBackSouthEastModel();
        public SlotBackSouthModel BackSouth { get; } = new SlotBackSouthModel();
        public SlotBackSouthWestModel BackSouthWest { get; } = new SlotBackSouthWestModel();
        public SlotBackWestModel BackWest { get; } = new SlotBackWestModel();
        public SlotBackNorthWestModel BackNorthWest { get; } = new SlotBackNorthWestModel();

    }
}
