using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method_9
{
    class Program
    {
        static void PrintCloserPoint(double x1, double y1, double x2, double y2)
        {
            double firstPointDistance = Math.Sqrt(x1 * x1 + y1 * y1);
            double secondPointDistance = Math.Sqrt(x2 * x2 + y2 * y2);
            if (firstPointDistance < secondPointDistance)
            {
                Console.Write($"({x1}, {y1})");
                Console.WriteLine($"({x2}, {y2})");
            }
            else
            {
                Console.Write($"({x2}, {y2})");
                Console.WriteLine($"({x1}, {y1})");
            }
        }
        static void FindLonger2Dline(double x1, double y1, double x2, double y2,
            double x3, double y3, double x4, double y4)
        {
            double firstLine = Calculate2DLine(x1, y1, x2, y2);
            double secondLine = Calculate2DLine(x3, y3, x4, y4);
            if(firstLine >= secondLine)
            {
                PrintCloserPoint(x1, y1, x2, y2);
            }
            else
            {
                PrintCloserPoint(x3, y3, x4, y4);
            }
        }
        static double Calculate2DLine(double x1, double y1, double x2, double y2)
        {
            double LineA = Math.Abs(x1 - x2);
            double LineB = Math.Abs(y1 - y2);
            double LineC = Math.Sqrt(LineA * LineA + LineB * LineB);
            return LineC;
        }
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());           
            double Y2 = double.Parse(Console.ReadLine());
            double X3 = double.Parse(Console.ReadLine());            
            double Y3 = double.Parse(Console.ReadLine());
            double X4 = double.Parse(Console.ReadLine());
            double Y4 = double.Parse(Console.ReadLine());
            FindLonger2Dline(X1, Y1, X2, Y2, X3, Y3, X4, Y4);
        }
    }
}
