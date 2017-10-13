using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> citiesPopulations =
                new Dictionary<string, Dictionary<string, long>>();

            while (input != "report")
            {
                string[] data = input.Split('|').ToArray();
                if (!citiesPopulations.ContainsKey(data[1]))
                {
                    citiesPopulations[data[1]] = new Dictionary<string, long>
                    {
                        { data[0], long.Parse(data[2]) }
                    };
                }
                else
                {
                    citiesPopulations[data[1]][data[0]] = long.Parse(data[2]);
                }
                input = Console.ReadLine();
            }
            foreach (var currCountry in citiesPopulations
                .OrderByDescending(kvp => kvp.Value.Values.Sum()))
            {
                long totalPopulation = currCountry.Value.Values.Sum();
                Console.WriteLine($"{currCountry.Key} (total population: {totalPopulation})");
                foreach (var currCity in currCountry.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"=>{currCity.Key}: {currCity.Value} ");
                }
            }

        }
    }
}
