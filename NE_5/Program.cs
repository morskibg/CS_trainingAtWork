using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_5
{
    class Program
    {
       
        static void Main()
        {
            Dictionary<string, List<long>> dict = new Dictionary<string, List<long>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] firstDilim = new string[] {" -> "}.ToArray();
                string[] firstSplit = input.Split(firstDilim, StringSplitOptions.RemoveEmptyEntries);
                string firstName = firstSplit[0];
                List<long> currNums = new List<long>();
                long singleNum = 0;
                if (firstSplit[1].Contains(", ") || long.TryParse(firstSplit[1], out singleNum))
                {
                    if (long.TryParse(firstSplit[1], out singleNum))
                    {
                        currNums.Add(singleNum);
                    }
                    else
                    {
                        string[] secondDilim = new string[] {", "};
                        currNums = firstSplit[1]
                            .Split(secondDilim, StringSplitOptions.RemoveEmptyEntries)
                            .Select(long.Parse)
                            .ToList();
                    }

                    if (!dict.ContainsKey(firstName))
                    {
                        dict[firstName] = new List<long>();
                    }
                    dict[firstName].AddRange(currNums);
                }
                else
                {
                    string secondName = firstSplit[1];
                    if (dict.ContainsKey(secondName))
                    {
                        dict[firstName] = new List<long> (dict[secondName]); 
                    }

                }
                input = Console.ReadLine();
            }
            foreach (string currName in dict.Keys)
            {
                Console.WriteLine($"{currName} === {string.Join(", ", dict[currName])}");
            }
        }
    }
}
