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

            var sample = "L(0)=7, L(1)=3, L(2)=-1, L(4)=3, L(5)=-3";
            var sampleResult = lagrangeEngine.CalculateLagrange(pointsDecoder.DecodeToPoints(sample),3);
            Console.WriteLine($"L(3)={sampleResult} where {sample}");



            while (true)
            {
                Console.WriteLine("Press 1 if you want test your own sample");
                var key = Console.ReadKey().Key;
                if(key!=ConsoleKey.D1)
                    break;
                Console.Clear();
               
                Console.WriteLine("Please enter known points in format like: L(1)=2, L(3)=3.5, L(5.2)=6");
                var points = pointsDecoder.DecodeToPoints(Console.ReadLine());

                Console.WriteLine("Please enter the point for which you want to find the value in format like: L(3)=");
                var targetPointString = Console.ReadLine();
                var targetPoint = pointsDecoder.TakeArgument(targetPointString);
                Console.CursorTop--;
                Console.CursorLeft = targetPointString.Length;

                var result = lagrangeEngine.CalculateLagrange(points, targetPoint);
                Console.Write(result);                
            }

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
