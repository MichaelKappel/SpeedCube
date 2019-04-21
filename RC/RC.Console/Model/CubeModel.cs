using RC.Enumerations;
using RC.Model.Pieces;
using RC.Model.Slots;
using RC.Model.Sots;
using RC.Model.Stickers;
using System.Linq;

namespace RC.Model
{
    public class CubeModel
    {
        public CubeModel()
        {
            this.FrontNorthWest.AdjacentSideSlots.Add(this.FrontNorth);
            this.FrontNorthWest.AdjacentSideSlots.Add(this.NorthWest);
            this.FrontNorthWest.AdjacentSideSlots.Add(this.FrontWest);

            this.FrontNorth.AdjacentCornerSlots.Add(this.FrontNorthWest);
            this.FrontNorth.AdjacentCornerSlots.Add(this.FrontNorthEast);
            this.FrontNorth.AdjacentMiddlePieces.Add(this.Front);
            this.FrontNorth.AdjacentMiddlePieces.Add(this.North);

            this.FrontNorthEast.AdjacentSideSlots.Add(this.FrontNorth);
            this.FrontNorthEast.AdjacentSideSlots.Add(this.NorthEast);
            this.FrontNorthEast.AdjacentSideSlots.Add(this.FrontEast);

            this.NorthEast.AdjacentCornerSlots.Add(this.BackNorthWest);
            this.NorthEast.AdjacentCornerSlots.Add(this.BackNorthEast);
            this.NorthEast.AdjacentMiddlePieces.Add(this.North);
            this.NorthEast.AdjacentMiddlePieces.Add(this.East);


            this.BackNorthEast.AdjacentSideSlots.Add(this.FrontNorth);
            this.BackNorthEast.AdjacentSideSlots.Add(this.BackNorth);
            this.BackNorthEast.AdjacentSideSlots.Add(this.FrontEast);

            this.BackNorth.AdjacentCornerSlots.Add(this.BackNorthEast);
            this.BackNorth.AdjacentCornerSlots.Add(this.BackNorthWest);
            this.BackNorth.AdjacentMiddlePieces.Add(this.Back);
            this.BackNorth.AdjacentMiddlePieces.Add(this.North);

            this.BackNorthWest.AdjacentSideSlots.Add(this.FrontNorth);
            this.BackNorthWest.AdjacentSideSlots.Add(this.BackNorth);
            this.BackNorthWest.AdjacentSideSlots.Add(this.FrontEast);



            this.FrontWest.AdjacentCornerSlots.Add(this.FrontNorthWest);
            this.FrontWest.AdjacentCornerSlots.Add(this.FrontSouthWest);
            this.FrontWest.AdjacentMiddlePieces.Add(this.Front);
            this.FrontWest.AdjacentMiddlePieces.Add(this.West);

            this.FrontEast.AdjacentCornerSlots.Add(this.FrontNorthEast);
            this.FrontEast.AdjacentCornerSlots.Add(this.FrontSouthEast);
            this.FrontEast.AdjacentMiddlePieces.Add(this.Front);
            this.FrontEast.AdjacentMiddlePieces.Add(this.East);


            this.BackWest.AdjacentCornerSlots.Add(this.BackNorthWest);
            this.BackWest.AdjacentCornerSlots.Add(this.BackSouthWest);
            this.BackWest.AdjacentMiddlePieces.Add(this.Back);
            this.BackWest.AdjacentMiddlePieces.Add(this.West);

            this.BackEast.AdjacentCornerSlots.Add(this.BackNorthEast);
            this.BackEast.AdjacentCornerSlots.Add(this.BackSouthEast);
            this.BackEast.AdjacentMiddlePieces.Add(this.Back);
            this.BackEast.AdjacentMiddlePieces.Add(this.East);

            this.FrontSouthWest.AdjacentSideSlots.Add(this.FrontSouth);
            this.FrontSouthWest.AdjacentSideSlots.Add(this.SouthWest);
            this.FrontSouthWest.AdjacentSideSlots.Add(this.FrontWest);

            this.FrontSouth.AdjacentCornerSlots.Add(this.FrontSouthWest);
            this.FrontSouth.AdjacentCornerSlots.Add(this.FrontSouthEast);
            this.FrontSouth.AdjacentMiddlePieces.Add(this.Front);
            this.FrontSouth.AdjacentMiddlePieces.Add(this.South);

            this.FrontSouthEast.AdjacentSideSlots.Add(this.FrontSouth);
            this.FrontSouthEast.AdjacentSideSlots.Add(this.SouthEast);
            this.FrontSouthEast.AdjacentSideSlots.Add(this.FrontEast);

            this.SouthEast.AdjacentCornerSlots.Add(this.FrontSouthEast);
            this.SouthEast.AdjacentCornerSlots.Add(this.BackSouthEast);
            this.SouthEast.AdjacentMiddlePieces.Add(this.South);
            this.SouthEast.AdjacentMiddlePieces.Add(this.East);

            this.BackSouthEast.AdjacentSideSlots.Add(this.BackEast);
            this.BackSouthEast.AdjacentSideSlots.Add(this.BackSouth);
            this.BackSouthEast.AdjacentSideSlots.Add(this.SouthEast);

            this.BackSouth.AdjacentCornerSlots.Add(this.BackSouthEast);
            this.BackSouth.AdjacentCornerSlots.Add(this.BackSouthWest);
            this.BackSouth.AdjacentMiddlePieces.Add(this.Back);
            this.BackSouth.AdjacentMiddlePieces.Add(this.South);

            this.BackSouthWest.AdjacentSideSlots.Add(this.BackSouth);
            this.BackSouthWest.AdjacentSideSlots.Add(this.BackWest);
            this.BackSouthWest.AdjacentSideSlots.Add(this.SouthWest);

            this.North.AdjacentSideSlots.Add(this.BackNorth);
            this.North.AdjacentSideSlots.Add(this.NorthEast);
            this.North.AdjacentSideSlots.Add(this.FrontNorth);
            this.North.AdjacentSideSlots.Add(this.NorthWest);

            this.South.AdjacentSideSlots.Add(this.BackSouth);
            this.South.AdjacentSideSlots.Add(this.SouthEast);
            this.South.AdjacentSideSlots.Add(this.FrontSouth);
            this.South.AdjacentSideSlots.Add(this.SouthWest);

            this.East.AdjacentSideSlots.Add(this.NorthEast);
            this.East.AdjacentSideSlots.Add(this.FrontEast);
            this.East.AdjacentSideSlots.Add(this.SouthEast);
            this.East.AdjacentSideSlots.Add(this.BackEast);

            this.West.AdjacentSideSlots.Add(this.NorthWest);
            this.West.AdjacentSideSlots.Add(this.FrontWest);
            this.West.AdjacentSideSlots.Add(this.SouthWest);
            this.West.AdjacentSideSlots.Add(this.BackWest);

            this.Front.AdjacentSideSlots.Add(this.FrontNorth);
            this.Front.AdjacentSideSlots.Add(this.FrontEast);
            this.Front.AdjacentSideSlots.Add(this.FrontSouth);
            this.Front.AdjacentSideSlots.Add(this.FrontWest);

            this.Back.AdjacentSideSlots.Add(this.BackNorth);
            this.Back.AdjacentSideSlots.Add(this.BackEast);
            this.Back.AdjacentSideSlots.Add(this.BackSouth);
            this.Back.AdjacentSideSlots.Add(this.BackWest);
        }

        //Middles
        public SlotNorthModel North { get; } = new SlotNorthModel();
        public SlotSouthModel South { get; } = new SlotSouthModel();
        public SlotWestModel West { get; } = new SlotWestModel();
        public SlotEastModel East { get; } = new SlotEastModel();
        public SlotFrontModel Front { get; } = new SlotFrontModel();
        public SlotBackModel Back { get; } = new SlotBackModel();

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
