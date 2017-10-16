using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime today = DateTime.ParseExact(Console.ReadLine(), "d-M-yyyy", null);
            Console.WriteLine(today.DayOfWeek);
        }
    }
}
