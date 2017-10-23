using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
            string matchingStr = Console.ReadLine().ToLower();
            int count = 0;
            int idx = input.IndexOf(matchingStr);
            while (idx != -1)
            {
                ++count;
                idx = input.IndexOf(matchingStr, idx + 1);
            }
            Console.WriteLine(count);
        }
    }
}
