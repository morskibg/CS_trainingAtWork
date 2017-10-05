using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> destinationsDatabase = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "ready")
            {
                char[] delimiters = ":,".ToCharArray();
                string[] tokens = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string destination = tokens.First();
                //tokens = tokens.Where(x => x != city).ToArray();
                tokens = tokens.Skip(1).ToArray();
                int totalPasagers = 0;

                foreach (var currVehicle in tokens)
                {
                    string[] vehicle = currVehicle.Split('-');
                    totalPasagers += int.Parse(vehicle.Last());
                }

                if (!destinationsDatabase.ContainsKey(destination))
                {
                    destinationsDatabase[destination] = totalPasagers;
                }
                else
                {
                    destinationsDatabase[destination] += totalPasagers;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "travel time!")
            {
                string[] tokens = input.Split(' ').ToArray();
                string desiredDestination = tokens.First();
                int travelers = int.Parse(tokens.Last());
                if (destinationsDatabase[desiredDestination] >= travelers)
                {
                    Console.WriteLine($"{desiredDestination} -> all {travelers} accommodated");
                }
                else
                {
                    Console.WriteLine($"{desiredDestination} -> all except {Math.Abs(destinationsDatabase[desiredDestination] - travelers)} accommodated");
                }
                input = Console.ReadLine();
            }

        }
    }
}
