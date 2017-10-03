using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method1
{
    class Program
    {
        static bool IsPrime(int num)
        {            
            int upperBond = (int)Math.Sqrt((double)num);
            if(num == 0 || num == 1)
            {
                return false;
            }
            for(int i = 2; i <= upperBond; ++i)
            {
                if(num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static List<int> FindPrimesInRange(int startNum, int endNum)
        {
            List<int> PrimesInRange = new List<int>();
            for (int i = startNum; i <= endNum; ++i)
            {
               
                if (IsPrime(i))
                {
                    PrimesInRange.Add(i);
                }
            }
            return PrimesInRange;
        }
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int endNum = int.Parse(Console.ReadLine());
            List<int> primesInRange = FindPrimesInRange(startNum, endNum);
            Console.WriteLine(string.Join(", ", primesInRange));
            
        }
    }
}
