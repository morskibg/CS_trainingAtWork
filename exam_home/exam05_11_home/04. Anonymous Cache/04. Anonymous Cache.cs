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

                string pattern = @"^(?<key>[^\s\|\-\>]*)[\s\-\>]*(?<size>[0-9]+)[\s\|]*(?<set>[^\s\|\-\>]*)$";
                Match parsedInput = Regex.Match(line, pattern);
                
                
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
                    
                    string set = parsedInput.Groups["set"].ToString();
                    string dataKey = parsedInput.Groups["key"].ToString();
                    string rawSize = parsedInput.Groups["size"].ToString();
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
            long maxSum = -1;
            string maxSet = "";
            var maxKeys = new List<string>();
            foreach (var item in database)
            {
                long innerSum = 0;
                foreach (var innerItem in item.Value)
                {
                    innerSum += innerItem.Value;
                }
                if(innerSum > maxSum)
                {
                    maxSum = innerSum;
                    maxSet = item.Key;
                    maxKeys.Clear();
                    maxKeys.AddRange(item.Value.Keys);
                }
            }
            Console.WriteLine($"Data Set: {maxSet}, Total Size: {maxSum}");
            foreach(var item in maxKeys)
            {
                Console.WriteLine($"$.{item}");
            }
        }
    }
}
