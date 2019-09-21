using RC.Common.Enumerations;
using RC.Common.Model.Pieces;
using RC.Common.Model.Slots;
using RC.Common.Model.Sots;
using RC.Common.Model.Stickers;
using System.Linq;

namespace RC.Common.Model
{
    public class CubeAbstractorModel
    {
        public CubeAbstractorModel()
        {

        }

        public SlotBackModel North { get; } = new SlotBackModel();
        public SlotSouthModel South { get; } = new SlotSouthModel();
        public SlotWestModel West { get; } = new SlotWestModel();
        public SlotEastModel East { get; } = new SlotEastModel();
        public SlotFrontModel Front { get; } = new SlotFrontModel();
        public SlotBackModel Back { get; } = new SlotBackModel();

        public SlotFrontNorthModel FrontNorth { get; } = new SlotFrontNorthModel();
        public SlotFrontNorthEastModel FrontNorthEast { get; } = new SlotFrontNorthEastModel();
        public SlotFrontEastModel FrontEast { get; } = new SlotFrontEastModel();
        public SlotFrontSouthEastModel FrontSouthEast { get; } = new SlotFrontSouthEastModel();
        public SlotFrontSouthModel FrontSouth { get; } = new SlotFrontSouthModel();
        public SlotFrontSouthWestModel FrontSouthWest { get; } = new SlotFrontSouthWestModel();
        public SlotFrontWestModel FrontWest { get; } = new SlotFrontWestModel();
        public SlotFrontNorthWestModel FrontNorthWest { get; } = new SlotFrontNorthWestModel();

        public SlotNorthEastModel NorthEast { get; } = new SlotNorthEastModel();
        public SlotSouthEastModel SouthEast { get; } = new SlotSouthEastModel();
        public SlotSouthWestModel SouthWest { get; } = new SlotSouthWestModel();
        public SlotNorthWestModel NorthWest { get; } = new SlotNorthWestModel();

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
