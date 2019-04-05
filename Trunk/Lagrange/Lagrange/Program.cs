using System;
using Lagrange.Engines;
using Lagrange.Helpers;
using Lagrange.Interfaces;

namespace Lagrange
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            IPointsDecoder pointsDecoder = new PointDecoder();
            ILagrangeEngine lagrangeEngine = new DefaultLagrangeEngine();

            Console.WriteLine("Please enter known points in format like: L(1)=2, L(3)=3.5, L(5.2)=6");         
            var points = pointsDecoder.DecodeToPoints(Console.ReadLine());

            Console.WriteLine("Please enter the point for which you want to find the value in format like: x=4");
            var targetPoint = pointsDecoder.DecodeToSingleX(Console.ReadLine());

            var result = lagrangeEngine.CalculateLagrange(points, targetPoint);
            Console.WriteLine($"L({targetPoint})={result}");        
            Console.ReadLine();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if(e.ExceptionObject is FormatException)
                Console.WriteLine((e.ExceptionObject as FormatException).Message);
            else
                Console.WriteLine("Something went wrong.");
        }

        
    }
}
