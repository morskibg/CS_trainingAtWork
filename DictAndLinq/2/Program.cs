using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            Dictionary<string, int> mineData = new Dictionary<string, int>();
            string key = "";
            while (line != "stop")
            {
                int parsedQTY = 0;
                
                if (!int.TryParse(line, out parsedQTY))
                {
                    if (!mineData.ContainsKey(line))
                    {
                        mineData[line] = 0;
                    }
                    key = line;
                }
                else
                {
                    mineData[key] += parsedQTY;
                }
                line = Console.ReadLine();
            }
            foreach(var metal in mineData)
            {
                Console.WriteLine($"{metal.Key} -> {metal.Value}");
            }
        }
    }
}
