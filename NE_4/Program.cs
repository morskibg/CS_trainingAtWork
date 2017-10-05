using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_4
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, HashSet<int>> shelsDatabase = new Dictionary<string, HashSet<int>>();
            string input = Console.ReadLine();
            while (input != "Aggregate")
            {
                string[] args = input.Split(' ');
                string region = args[0];
                int shellSize = int.Parse(args[1]);
                if (!shelsDatabase.ContainsKey(region))
                {
                    shelsDatabase[region] = new HashSet<int>();
                }
                shelsDatabase[region].Add(shellSize);
                input = Console.ReadLine();
            }
            foreach( var currRegion in shelsDatabase)
            {
                double shelsAverage = currRegion.Value.Average();
                double shelsSum = currRegion.Value.Sum();
                double giantShell = shelsSum - shelsAverage;
                Console.WriteLine($"{currRegion.Key} -> {string.Join(", ", currRegion.Value)} ({Math.Ceiling(giantShell)})");    
            }
        }
    }
}
