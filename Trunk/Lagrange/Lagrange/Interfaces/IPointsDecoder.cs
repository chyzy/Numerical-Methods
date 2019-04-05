using System;
using System.Collections.Generic;
using System.Text;
using Lagrange.DataModels;

namespace Lagrange.Interfaces
{
    public interface IPointsDecoder
    {
        /// <summary>
        /// Decodes string to <see cref="IEnumerable{Point}"/>
        /// </summary>
        /// <param name="pointsString">Point in format like: L(2)=3, L(4)=2</param>        
        IEnumerable<Point> DecodeToPoints(string pointsString);

        /// <summary>
        /// Extracts the function argument value
        /// </summary>
        /// <param name="equation">Equation.</param>
        /// <exception cref="equation">L(3)=3</exception> 
        double TakeArgument(string equation);

        /// <summary>
        /// Extracts the function value
        /// </summary>
        /// <param name="equation">Equation.</param>
        /// <exception cref="equation">L(3)=3</exception> 
        double TakeValue(string equation);
    }
}
