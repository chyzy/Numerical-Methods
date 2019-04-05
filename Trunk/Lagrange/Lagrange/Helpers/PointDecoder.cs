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
                if(!double.TryParse(equation.Split('(')[1].Split(')')[0],out double x))
                    throw new FormatException();
                
                if(!double.TryParse(equation.Split('=')[1],out double y))
                    throw new FormatException();

                yield return new Point(x,y);
            }
        }


        double IPointsDecoder.DecodeToSingleX(string equation)
        {

            if(!double.TryParse(equation.Trim().Split('=')[1],out double result))
                throw new FormatException();
            return result;
        }
    }
}
