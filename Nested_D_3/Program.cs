using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_D_3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> uniqueNames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; ++i)
            {
                uniqueNames.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join("\n",uniqueNames));
        }
    }
}
