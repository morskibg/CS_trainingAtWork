using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method_8
{
    class Program
    {
        static void PrintCloserPoint(double x1, double x2, double y1, double y2)
        {
            double firstPointDistance = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointDistance = Math.Sqrt(x2 * x2 + y2 * y2);
            if (firstPointDistance < secondPointDistance)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
            
        }
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());
            PrintCloserPoint(X1, Y1, X2, Y2);
        }
    }
}
