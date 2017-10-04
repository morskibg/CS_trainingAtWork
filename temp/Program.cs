using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nums = Console.ReadLine().Split(' ').ToList();
            nums = nums.Where((val, i) => i % 2 != 0).ToList();
            Console.WriteLine(string.Join("", nums));
        }
    }
}
