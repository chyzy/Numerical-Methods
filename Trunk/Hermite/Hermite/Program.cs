using System;
using System.Collections.Generic;
using System.Linq;

namespace Hermite
{
    class Program
    {
        static void Main(string[] args)
        {
            _precision = 1e-10;

            var input = new List<List<double>>()
            {
                new List<double>() {0,7,3}, //x1,f(x1), f'(x1)...
                new List<double>() {1,3},    //x2,f(x2), f'(x2)...
                new List<double>() {2,-1},
                new List<double>() {4,3},
                new List<double>() {5,-3,1,2},
            };

            var hermitResult = Hermite(input);
            Console.WriteLine(HermiteValue(hermitResult, 3));

            Console.ReadKey();
        }

        private static double _precision;

        /// <summary>
        /// Calculates Hermit interpolation polynomial
        /// </summary>      
        private static KeyValuePair<List<double>, List<KeyValuePair<double, int>>> Hermite(List<List<double>> table)
        {
            var firstColumn = table.SelectMany(p => p.Skip(1).Select(i => p.First())).ToArray(); 
            var secondColumn = table.SelectMany(p => p.Skip(1).Select(i => p.Skip(1).First())).ToArray();
            var size = firstColumn.Length;

            var m = new double[size + 1, size]; 

            for (int i = 0; i < size; i++)
            {
                m[0, i] = firstColumn[i];
                m[1, i] = secondColumn[i];
            }

            for (int x = 2; x < size + 1; x++)
            {
                for (int y = x - 1; y < size; y++)
                {
                    if (Math.Abs(m[0, y] - m[0, y - x + 1]) > _precision)
                    {
                        m[x, y] = (m[x - 1, y] - m[x - 1, y - 1]) / (m[0, y] - m[0, y - x + 1]);
                    }
                    else
                    {
                        var d = TakeDerivative(m[0, y], x - 1, table);
                        m[x, y] = d / Factorial(x - 1);
                    }
                }
            }
            
            var result = new KeyValuePair<List<double>, List<KeyValuePair<double, int>>>(new List<double>(), new List<KeyValuePair<double, int>>());

            for (int x = 1; x < size + 1; x++)
            {
                result.Value.Add(new KeyValuePair<double, int>(m[x, x - 1], x - 1));
            }

            for (int i = 0; i < size; i++)
            {
                result.Key.Add(m[0, i]);
            }
            return result;
        }

        static double HermiteValue(KeyValuePair<List<double>, List<KeyValuePair<double, int>>> w, double x)
        {
            return w.Value.Select(i => i.Key * w.Key.Take(i.Value).Select(j => x - j).Aggregate(1.0, (a, b) => a * b)).Sum();
        }

        static double TakeDerivative(double x, int n, List<List<double>> xys)
        {
            return xys.Find(i => Math.Abs(i.First() - x) < _precision).ToArray()[n + 1];
        }

        static int Factorial(int n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}
