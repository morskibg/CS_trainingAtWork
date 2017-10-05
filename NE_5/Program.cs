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
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] delim = new string[] { " -> "}.ToArray();
                string[] namesAndNums = input.Split(delim, StringSplitOptions.RemoveEmptyEntries);
                string name = namesAndNums[0];
                List<int> currNums = new List<int>();
                if (namesAndNums.Contains(" ,"))
                {
                    string[] numsDelim = new string[] { " ", "," }.ToArray();
                    currNums = namesAndNums[1].Split(numsDelim, StringSplitOptions.RemoveEmptyEntries).
                        Select(int.Parse).ToList();
                }
                else
                {
                    if (dict.ContainsKey(namesAndNums[1]) && dict.ContainsKey(name))
                    {
                        dict[name] = dict[namesAndNums[1]];
                    }
                    continue;
                }
                if(!dict.ContainsKey(name))
                {                  
                    dict[name] = currNums;
                    continue;
                }
                
                    int t = 0;
            }
        }
    }
}
