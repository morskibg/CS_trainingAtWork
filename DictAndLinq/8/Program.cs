using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> database = 
                new Dictionary<string, Dictionary<string, int>>();
            for(int i = 0; i < n; ++i)
            {
                char[] delim = " ".ToCharArray();
                string[] data = Console.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!database.ContainsKey(data[1]))
                {
                    database[data[1]] = new Dictionary<string, int>
                    {
                        {data[0], int.Parse(data[2])}
                    };
                }
                else
                {
                    if (!database[data[1]].ContainsKey(data[0]))
                    {
                        database[data[1]][data[0]] = 0;
                    }
                    database[data[1]][data[0]] += int.Parse(data[2]);
                }
            }
            foreach(var currUser in database.OrderBy(kvp => kvp.Key))
            {
                long totalDuration = currUser.Value.Values.Sum();
                Console.WriteLine($"{currUser.Key}: {totalDuration} [{string.Join(", ", currUser.Value.Keys.OrderBy(x => x))}]");
            }
        }
    }
}
