using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static double CalcDistance(Point A, Point B)
        {
            double distance = Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            return distance;
        }
        static void Main(string[] args)
        {
            int[] coordintes = new int[4];
            for (int i = 0; i < 4; i += 2)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                coordintes[i] = int.Parse(tokens[0]);
                coordintes[i + 1] = int.Parse(tokens[1]);
            }
            Point A = new Point(coordintes[0], coordintes[1]);
            Point B = new Point(coordintes[2], coordintes[3]);
            Console.WriteLine($"{CalcDistance(A, B):f3}");

        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
