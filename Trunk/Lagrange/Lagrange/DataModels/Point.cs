using System;
using System.Collections.Generic;
using System.Text;

namespace Lagrange.DataModels
{
    public class Point
    {
        public Point(double x,double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public override string ToString()
        {
            return "{x=" + X + ", y=" + Y + "}";
        }
    }
}
