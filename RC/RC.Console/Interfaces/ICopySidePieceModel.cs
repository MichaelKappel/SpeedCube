using RC.Enumerations;
using RC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Interfaces
{
    public interface ICopySidePieceModel
    {
        PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType);
    }
}
