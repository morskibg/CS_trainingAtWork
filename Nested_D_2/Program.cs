using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_D_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> geoDatabase = 
                     new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; ++i)
            {
                string[] words = Console.ReadLine().Split(' ').ToArray();
                if (!geoDatabase.ContainsKey(words[0]))
                {
                    geoDatabase[words[0]] = new Dictionary<string, List<string>>
                    {
                        {words[1], new List<string>
                        { words[2] }
                        }
                    };
                }
                else
                {
                    if (!geoDatabase[words[0]].ContainsKey(words[1]))
                    {
                        geoDatabase[words[0]].Add(words[1], new List<string> { words[2] });
                    }
                    else
                    {
                        geoDatabase[words[0]][words[1]].Add(words[2]);
                    }
                }
            }
            foreach(var continent in geoDatabase)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach(var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
