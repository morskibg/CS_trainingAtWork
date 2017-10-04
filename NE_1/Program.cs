using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_1
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, long>> clothDatabase =
                new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < n; ++i)
            {
                string[] separator = new string[] { " -> ", "," };
                string[] args = Console.ReadLine()
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = args[0];
                if (!clothDatabase.ContainsKey(color))
                {
                    clothDatabase.Add(color, new Dictionary<string, long>());
                    
                }
                for (int j = 1; j < args.Length; ++j)
                {
                    if (!clothDatabase[color].ContainsKey(args[j]))
                    {
                        clothDatabase[color].Add(args[j], 0);
                    }
                }
                for (int j = 1; j < args.Length; ++j)
                {
                    if (clothDatabase[color].ContainsKey(args[j]))
                    {
                        clothDatabase[color][args[j]]++;
                    }
                }

            }

            string[] toFind = Console.ReadLine().Split(' ').ToArray();
            string colorToFind = toFind[0];
            string itemTofind = toFind[1];
            foreach (var color in clothDatabase.Keys)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var item in clothDatabase[color])
                {
                    string founded = "";

                    if (item.Key == itemTofind && color == colorToFind)
                    {

                        founded = " (found!)";
                    }
                    Console.WriteLine($"* {item.Key} - {item.Value}{founded}");
                }
            }

        }
    }
}
