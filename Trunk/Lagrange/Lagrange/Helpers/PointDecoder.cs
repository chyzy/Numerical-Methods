using System;
using System.Collections.Generic;
using System.Text;
using Lagrange.DataModels;
using Lagrange.Interfaces;

namespace Lagrange.Helpers
{
    public class PointDecoder : IPointsDecoder
    {
        IEnumerable<Point> IPointsDecoder.DecodeToPoints(string pointsString)
        {
            foreach (var equation in pointsString.Trim().Split(','))
            {
                var x = (this as IPointsDecoder).TakeArgument(equation);
                var y = (this as IPointsDecoder).TakeValue(equation);

                yield return new Point(x,y);
            }
        }

        double IPointsDecoder.TakeArgument(string equation)
        {
            if (!double.TryParse(equation.Split('(')[1].Split(')')[0], out double x))
                throw new FormatException();
            return x;
        }

        double IPointsDecoder.TakeValue(string equation)
        {
            if (!double.TryParse(equation.Split('=')[1], out double y))
                throw new FormatException();
            return y;
        }
    }
}
