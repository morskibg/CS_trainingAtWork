using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NE_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            string value = Console.ReadLine();
            Dictionary<string, List<string>> database = new Dictionary<string, List<string>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] separator = new[] {" => ", ";"};
                string[] tokens = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string enteredKey = tokens.First();
                tokens = tokens.Where(x => x != enteredKey).ToArray();
                if (enteredKey.Contains(key))
                {
                    if (!database.ContainsKey(enteredKey))
                    {
                        database[enteredKey] = new List<string>();
                    }
                    foreach (var currValue in tokens)
                    {
                        if (currValue.Contains(value))
                        {
                            database[enteredKey].Add(currValue);
                        }
                    }
                }
                
            }
            foreach (var inputKey in database)
            {
                Console.WriteLine($"{inputKey.Key}:");
                foreach (var currValue in inputKey.Value)
                {
                    Console.WriteLine($"-{currValue}");
                }
            }
        }
    }
}
