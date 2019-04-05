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
            
            do
            {
                Console.Clear();
                IPointsDecoder pointsDecoder = new PointDecoder();
                ILagrangeEngine lagrangeEngine = new DefaultLagrangeEngine();

                Console.WriteLine("Please enter known points in format like: L(1)=2, L(3)=3.5, L(5.2)=6");
                var points = pointsDecoder.DecodeToPoints(Console.ReadLine());

                Console.WriteLine("Please enter the point for which you want to find the value in format like: L(3)=");
                var targetPointString = Console.ReadLine();
                var targetPoint = pointsDecoder.TakeArgument(targetPointString);
                Console.CursorTop--;
                Console.CursorLeft = targetPointString.Length;

                var result = lagrangeEngine.CalculateLagrange(points, targetPoint);
                Console.Write(result);

                Console.WriteLine("\n\nPress any key to try again or ESCAPE to exit");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

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
