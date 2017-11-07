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
            Dictionary<string, Dictionary<string, BigInteger>> database = 
                new Dictionary<string, Dictionary<string, BigInteger>>();
            Dictionary<string, Dictionary<string, BigInteger>> cache =
                new Dictionary<string, Dictionary<string, BigInteger>>();
            while (true)
            {
                string line = Console.ReadLine();
                if(line == "thetinggoesskrra")
                {
                    break;
                }
                string pattern = @"^(?<key>[^ \|\-\>]+)[ \-\>]+(?<size>\d+)[ \|]+(?<set>[^ \|\-\>]+)$|^(?<singleSet>[^ \|\-\>]+)$";
                Match parsedInput = Regex.Match(line, pattern);
                if (parsedInput.Groups["singleSet"].Success)
                {
                    string set = parsedInput.Groups["singleSet"].ToString();
                    if (!database.ContainsKey(set))
                    {
                        database[set] = new Dictionary<string, BigInteger>();
                        if (cache.ContainsKey(set))
                        {
                            foreach(var currKey in cache[set])
                            {
                                database[set].Add(currKey.Key, currKey.Value);
                            }
                        }
                    }
                }
                else
                {
                    string set = parsedInput.Groups["set"].ToString();
                    string dataKey = parsedInput.Groups["key"].ToString();
                    BigInteger dataSize = BigInteger.Parse(parsedInput.Groups["size"].ToString());
                    if (database.ContainsKey(set))
                    {
                        database[set].Add(dataKey, dataSize);
                    }
                    else
                    {
                        if (!cache.ContainsKey(set))
                        {
                            cache[set] = new Dictionary<string, BigInteger>();
                        }
                        cache[set][dataKey] = dataSize;
                    }
                }
               

                
            }
            BigInteger maxSum = 0;
            string maxSet = "";
            var maxKeys = new List<string>();
            foreach (var item in database)
            {
                BigInteger innerSum = 0;
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
