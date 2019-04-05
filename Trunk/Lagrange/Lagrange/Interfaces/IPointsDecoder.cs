using System;
using System.Collections.Generic;
using System.Text;
using Lagrange.DataModels;

namespace Lagrange.Interfaces
{
    public interface IPointsDecoder
    {
        IEnumerable<Point> DecodeToPoints(string pointsString);

        double DecodeToSingleX(string pointString);
    }
}
