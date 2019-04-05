using System;
using System.Collections.Generic;
using System.Text;
using Lagrange.DataModels;

namespace Lagrange.Interfaces
{
    public interface ILagrangeEngine
    {
        double CalculateLagrange(IEnumerable<Point> knownPoins, double target);
    }
}
