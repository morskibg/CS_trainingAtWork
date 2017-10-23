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
            string matchStr = Console.ReadLine().ToLower();
            int matchCounter = 0;
            int lastIdx = input.LastIndexOf(matchStr);
            while (lastIdx != -1)
            {
                ++matchCounter;                
                lastIdx = input.LastIndexOf(matchStr, lastIdx + 1);
            }
            Console.WriteLine(matchCounter);
        }
    }
}
