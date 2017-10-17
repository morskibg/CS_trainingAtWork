using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string, List<int>>> draKons =
                new Dictionary<string, Dictionary<string, List<int>>>();
            for (int i = 0; i < n; i++)
            {
               
                char[] delim = " ".ToCharArray();
                string[] tokens = Console.ReadLine()
                    .Split(delim, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (!draKons.ContainsKey(tokens[0]))
                {
                    draKons[tokens[0]] = new Dictionary<string, List<int>>
                    {
                        {tokens[1], new List<int> {45, 250, 10} }
                    };
                }
                //if (!draKons[tokens[0]].ContainsKey(tokens[1]))
                //{
                    draKons[tokens[0]][tokens[1]] = new List<int> {45, 250, 10};
               // }
                
                for (int j = 2; j < 5; j++)
                {
                    int currStats = 0;
                    if (int.TryParse(tokens[j], out currStats))
                    {
                        draKons[tokens[0]][tokens[1]][j - 2] = currStats;
                    }
                }
            }
            
            foreach (var colorDraKon in draKons)
            {
                double averageDamage = colorDraKon.Value.Values.Average(x => x.ElementAt(0));
                double averageHealth = colorDraKon.Value.Values.Average(x => x.ElementAt(1));
                double averageArmor = colorDraKon.Value.Values.Average(x => x.ElementAt(2));
                Console.WriteLine($"{colorDraKon.Key}::({averageDamage:f2}/{averageHealth:f2}/{averageArmor:f2})");
                foreach (var name in colorDraKon.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{name.Key} -> damage: {name.Value[0]}, health: {name.Value[1]}, armor: {name.Value[2]}"); 
                }
            }
            
        }
    }
}
