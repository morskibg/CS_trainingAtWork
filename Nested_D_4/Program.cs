using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_D_4
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> uniqueGeoDatabase
                = new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();
            for (int i = 0; i < n; ++i)
            {
                string[] args = Console.ReadLine().Split(' ').ToArray();
                if (!uniqueGeoDatabase.ContainsKey(args[0]))
                {
                    uniqueGeoDatabase[args[0]] = new SortedDictionary<string, SortedSet<string>>
                    {
                        { args[1], new SortedSet<string>
                            {args[2] }
                        }
                    };
                }
                if (!uniqueGeoDatabase[args[0]].ContainsKey(args[1]))
                {
                    uniqueGeoDatabase[args[0]][args[1]] = new SortedSet<string>
                        {
                            {args[2]}
                        };
                }
                else
                {
                    uniqueGeoDatabase[args[0]][args[1]].Add(args[2]);
                }
            }
            foreach(var continent in uniqueGeoDatabase)
            {
                Console.WriteLine($"{continent.Key}: ");
                foreach(var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
