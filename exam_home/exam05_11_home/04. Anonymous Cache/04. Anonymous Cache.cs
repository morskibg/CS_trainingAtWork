using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.Anonymous_Cache
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> database = 
                new Dictionary<string, Dictionary<string, long>>();
            Dictionary<string, Dictionary<string, long>> cache =
                new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "thetinggoesskrra")
                {
                    break;
                }

                //string pattern = @"^(?<key>[^\s\|\-\>]*)[\s\-\>]*(?<size>[0-9]+)[\s\|]*(?<set>[^\s\|\-\>]*)$";
                //Match parsedInput = Regex.Match(line, pattern);

                var parsedInput = line.Split(" |->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!line.Contains("|"))
                {
                    string set = line.Trim();
                    if (!database.ContainsKey(set))
                    {
                        database[set] = new Dictionary<string, long>();
                        if (cache.ContainsKey(set))
                        {
                            foreach(var currKey in cache[set])
                            {
                                database[set].Add(currKey.Key, currKey.Value);
                            }
                            cache.Remove(set);
                        }
                    }
                }
                else
                {                    
                    string set = parsedInput[2];
                    string dataKey = parsedInput[0];
                    string rawSize = parsedInput[1];
                    long dataSize = long.Parse(rawSize);
                    if (database.ContainsKey(set))
                    {
                        database[set].Add(dataKey, dataSize);
                    }
                    else
                    {
                        if (!cache.ContainsKey(set))
                        {
                            cache[set] = new Dictionary<string, long>();
                        }
                        cache[set][dataKey] = dataSize;
                    }
                }
            }
            if(database.Count == 0)
            {
                return;
            }
            var maxSum = database.OrderByDescending(x => x.Value.Values.Sum()).First();
            Console.WriteLine($"Data Set: {maxSum.Key}, Total Size: {maxSum.Value.Values.Sum()}");
            foreach(var key in maxSum.Value)
            {
                Console.WriteLine($"$.{key.Key}");
            }
          
        }
    }
}
