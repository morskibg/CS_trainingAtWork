using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {


        static string GetBeast(string precious)
        {
            switch (precious)
            {
                case "fragments": return "Valanyr";
                case "shards": return "Shadowmourne";
                case "motes": return "Dragonwrath";
                default: return "none";
            }
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> farm = new Dictionary<string, int>
            {
                {"fragments", 0 },
                { "shards", 0},
                { "motes", 0}

            };
            bool isFinished = false;
            while (!isFinished)
            {
                string[] data = Console.ReadLine().ToLower()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] resources = data.Where((x, i) => i % 2 != 0 && i != 0).ToArray();
                string[] resCount = data.Where((x, i) => i % 2 == 0).ToArray();
                for (int i = 0; i < resources.Length; ++i)
                {
                    if (!farm.ContainsKey(resources[i]))
                    {
                        farm[resources[i]] = 0;
                    }
                    int qtyIdx = Array.FindIndex(resources, x => x == resources[i]);
                    farm[resources[i]] += int.Parse(resCount[qtyIdx]);

                    if (farm[resources[i]] >= 250 && ( resources[i] == "fragments" ||
                        resources[i] == "shards" || resources[i] == "motes"))
                    {
                        Console.WriteLine($"{GetBeast(resources[i])} obtained!");
                        farm[resources[i]] -= 250;
                        isFinished = true;
                        break;
                    }
                    resources[i] = "null";
                }
            }
            foreach (var mineral in farm
                    .Where(x => x.Key == "fragments" || x.Key == "shards" || x.Key == "motes")
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{mineral.Key}: {mineral.Value}");
            }
            foreach (var mineral in farm
                .Where(x => x.Key != "fragments" && x.Key != "shards" && x.Key != "motes")
                .OrderBy(x => x.Key))

            {
                Console.WriteLine($"{mineral.Key}: {mineral.Value}");
            }


        }
    }
}
