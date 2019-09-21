using RC.Common.Enumerations;
using RC.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RC.Common.Interfaces
{
    public interface ICopySidePieceModel
    {
        PieceSideModelBase CopyPiece(XyzCubeTypes patternCubeType);
    }
}
