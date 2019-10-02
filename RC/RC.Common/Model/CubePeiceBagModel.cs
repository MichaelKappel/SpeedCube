using RC.Common.Enumerations;
using RC.Common.Model.Pieces;
using RC.Common.Model.Slots;
using RC.Common.Model.Sots;

namespace RC.Common.Model
{
    public class CubePeiceBagModel
    {
        public CubePeiceBagModel(XyzCubeTypes xyzCubeType)
        {
            this.FrontPiece = new PieceFrontModel(xyzCubeType);
            this.BackPiece = new PieceBackModel(xyzCubeType);
            this.NorthPiece = new PieceNorthModel(xyzCubeType);
            this.SouthPiece = new PieceSouthModel(xyzCubeType);
            this.EastPiece = new PieceEastModel(xyzCubeType);
            this.WestPiece = new PieceWestModel(xyzCubeType);

            this.FrontNorthPiece = new PieceFrontNorthModel(xyzCubeType);
            this.FrontEastPiece = new PieceFrontEastModel(xyzCubeType);
            this.FrontSouthPiece = new PieceFrontSouthModel(xyzCubeType);
            this.FrontWestPiece = new PieceFrontWestModel(xyzCubeType);

            this.FrontNorthEastPiece = new PieceFrontNorthEastModel(xyzCubeType);
            this.FrontSouthEastPiece = new PieceFrontSouthEastModel(xyzCubeType);
            this.FrontSouthWestPiece = new PieceFrontSouthWestModel(xyzCubeType);
            this.FrontNorthWestPiece = new PieceFrontNorthWestModel(xyzCubeType);

            this.NorthEastPiece = new PieceNorthEastModel(xyzCubeType);
            this.SouthEastPiece = new PieceSouthEastModel(xyzCubeType);
            this.SouthWestPiece = new PieceSouthWestModel(xyzCubeType);
            this.NorthWestPiece = new PieceNorthWestModel(xyzCubeType);

            this.BackNorthPiece = new PieceBackNorthModel(xyzCubeType);
            this.BackEastPiece = new PieceBackEastModel(xyzCubeType);
            this.BackSouthPiece = new PieceBackSouthModel(xyzCubeType);
            this.BackWestPiece = new PieceBackWestModel(xyzCubeType);

            this.BackNorthEastPiece = new PieceBackNorthEastModel(xyzCubeType);
            this.BackSouthEastPiece = new PieceBackSouthEastModel(xyzCubeType);
            this.BackSouthWestPiece = new PieceBackSouthWestModel(xyzCubeType);
            this.BackNorthWestPiece = new PieceBackNorthWestModel(xyzCubeType);

            this.Sides = new PieceSideModelBase[12];

            this.Sides[0] = this.FrontNorthPiece;
            this.Sides[1] = this.FrontEastPiece;
            this.Sides[2] = this.FrontSouthPiece;
            this.Sides[3] = this.FrontWestPiece;

            this.Sides[4] = this.NorthEastPiece;
            this.Sides[5] = this.SouthEastPiece;
            this.Sides[6] = this.SouthWestPiece;
            this.Sides[7] = this.NorthWestPiece;

            this.Sides[8] = this.BackNorthPiece;
            this.Sides[9] = this.BackEastPiece;
            this.Sides[10] = this.BackSouthPiece;
            this.Sides[11] = this.BackWestPiece;


            this.Corners = new PieceCornerModelBase[8];

            this.Corners[0] = this.FrontNorthEastPiece;
            this.Corners[1] = this.FrontSouthEastPiece;
            this.Corners[2] = this.FrontSouthWestPiece;
            this.Corners[3] = this.FrontNorthWestPiece;
            this.Corners[4] = this.BackNorthEastPiece;
            this.Corners[5] = this.BackSouthEastPiece;
            this.Corners[6] = this.BackSouthWestPiece;
            this.Corners[7] = this.BackNorthWestPiece;
        }

        public PieceSideModelBase[] Sides {
            get;
            protected set;
        }

        public PieceCornerModelBase[] Corners
        {
            get;
            protected set;
        }
        public PieceFrontModel FrontPiece { get; protected set; }
        public PieceBackModel BackPiece { get; protected set; }
        public PieceNorthModel NorthPiece { get; protected set; }
        public PieceSouthModel SouthPiece { get; protected set; }
        public PieceEastModel EastPiece { get; protected set; }
        public PieceWestModel WestPiece { get; protected set; }

        public PieceFrontNorthModel FrontNorthPiece { get; protected set; }
        public PieceFrontEastModel FrontEastPiece { get; protected set; }
        public PieceFrontSouthModel FrontSouthPiece { get; protected set; }
        public PieceFrontWestModel FrontWestPiece { get; protected set; }

        public PieceFrontNorthEastModel FrontNorthEastPiece { get; protected set; }
        public PieceFrontSouthEastModel FrontSouthEastPiece { get; protected set; }
        public PieceFrontSouthWestModel FrontSouthWestPiece { get; protected set; }
        public PieceFrontNorthWestModel FrontNorthWestPiece { get; protected set; }

        public PieceNorthEastModel NorthEastPiece { get; protected set; }
        public PieceSouthEastModel SouthEastPiece { get; protected set; }
        public PieceSouthWestModel SouthWestPiece { get; protected set; }
        public PieceNorthWestModel NorthWestPiece { get; protected set; }

        public PieceBackNorthModel BackNorthPiece { get; protected set; }
        public PieceBackEastModel BackEastPiece { get; protected set; }
        public PieceBackSouthModel BackSouthPiece { get; protected set; }
        public PieceBackWestModel BackWestPiece { get; protected set; }

        public PieceBackNorthEastModel BackNorthEastPiece { get; protected set; }
        public PieceBackSouthEastModel BackSouthEastPiece { get; protected set; }
        public PieceBackSouthWestModel BackSouthWestPiece { get; protected set; }
        public PieceBackNorthWestModel BackNorthWestPiece { get; protected set; }
    }
}
