using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lagrange.DataModels;
using Lagrange.Interfaces;

namespace Lagrange.Engines
{
    public class DefaultLagrangeEngine : ILagrangeEngine
    {
        public double CalculateLagrange(IEnumerable<Point> knownPoints, double target)
        {
            double result = 0;
            foreach (var knownPoint in knownPoints)
            {
                double ratio = knownPoint.Y;
                foreach (var point in knownPoints.Where(p=>p.X!=knownPoint.X))
                {
                    ratio *= (target - point.X) / (knownPoint.X - point.X);
                }

                result += ratio;
            }

            return result;
        }
    }
}
