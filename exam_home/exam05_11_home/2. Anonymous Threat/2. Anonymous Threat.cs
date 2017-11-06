using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringArr = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            while (true)
            {
                string line = Console.ReadLine();
                if (line == "3:1")
                {
                    break;
                }
                var query = line.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();
                string command = query[0];
                if (command == "merge")
                {
                    int startIdx = int.Parse(query[1]);
                    int endIdx = int.Parse(query[2]);
                    if (startIdx < 0)
                    {
                        startIdx = 0;
                    }
                    if (endIdx > stringArr.Count - 1)
                    {
                        endIdx = stringArr.Count - 1;
                    }
                    if (startIdx >= endIdx)
                    {
                        continue;
                    }
                    StringBuilder merged = new StringBuilder();
                    foreach (var currString in stringArr.Where((x, i) => i >= startIdx && i <= endIdx))
                    {
                        merged.Append(currString);
                    }
                    stringArr.RemoveRange(startIdx, endIdx - startIdx + 1);
                    stringArr.Insert(startIdx, merged.ToString());
                }
                else if (command == "divide")
                {
                    int splitIdx = int.Parse(query[1]);
                    int partitions = int.Parse(query[2]);
                    string itemToSplit = stringArr[splitIdx];
                    string[] splited = new string[partitions];
                    int partitionSize = itemToSplit.Length / partitions;
                    int subStringIdx = 0;
                    for (int i = 0; i < partitions; ++i)
                    {
                        if (i == partitions - 1)
                        {
                            splited[i] = itemToSplit.Substring(subStringIdx);
                        }
                        else
                        {
                            splited[i] = itemToSplit.Substring(subStringIdx, partitionSize);
                            subStringIdx += partitionSize;
                        }
                    }
                    stringArr.RemoveAt(splitIdx);
                    stringArr.InsertRange(splitIdx, splited);
                }
            }
            Console.WriteLine(string.Join(" ", stringArr));
        }
    }
}
