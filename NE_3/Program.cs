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
            Dictionary<string, Dictionary<string, int>> travelDatabase = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while(input != "ready")
            {
                string[] cityAndVehicles = input.Split(':').ToArray();
                string city = cityAndVehicles[0];
                string[] vehiclesAndCapacities = cityAndVehicles[1].Split(',').ToArray();
                
                if (!travelDatabase.ContainsKey(city))
                {
                    travelDatabase[city] = new Dictionary<string, int>();
                }
                foreach(string currVehicleAndCapacity in vehiclesAndCapacities)
                {
                    string[] currVehicleData = currVehicleAndCapacity.Split('-').ToArray();
                    string vehicle = currVehicleData[0];
                    int capacity = int.Parse(currVehicleData[1]);
                    if (!travelDatabase[city].ContainsKey(vehicle))
                    {
                        travelDatabase[city][vehicle] = 0;
                    }
                    travelDatabase[city][vehicle] = capacity;
                }
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while(input != "travel time!")
            {
                string[] cityAndCapacityDemand = input.Split(' ').ToArray();
                string demandCity = cityAndCapacityDemand[0];
                int demandCapacity = int.Parse(cityAndCapacityDemand[1]);
                int actualCapacity = travelDatabase[demandCity].Values.Sum();
                if(actualCapacity >= demandCapacity)
                {
                    Console.WriteLine($"{demandCity} -> all {demandCapacity} accommodated");
                }
                else
                {
                    Console.WriteLine($"{demandCity} -> all except {Math.Abs(demandCapacity - actualCapacity)} accommodated");
                }
                input = Console.ReadLine();
            }
      
        }
    }
}
