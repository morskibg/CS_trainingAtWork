using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10
{
    class Program
    {
        static bool TryToParseToInt(out int receptor, string input)
        {
            if (int.TryParse(input, out receptor))
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> opaOpa =
                new Dictionary<string, Dictionary<string, long>>();
            string input = Console.ReadLine();
            while (input != "End")
            {

                char[] delim = " ".ToCharArray();
                string[] tokens = input
                    .Split(delim, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                bool isContain = false;
                for (int i = 0; i < tokens.Length; ++i)
                {
                    if (tokens[i].Contains("@") && tokens[i].Substring(0, 1) == "@")
                    {
                        isContain = true;
                    }
                }
                if (!isContain || tokens.Length < 4)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int ticketsCount = 0;

                if (!TryToParseToInt(out ticketsCount, tokens[tokens.Length - 1]))
                {
                    input = Console.ReadLine();
                    continue;
                }

                int ticketsPrice = 0;

                if (!TryToParseToInt(out ticketsPrice, tokens[tokens.Length - 2]))
                {
                    input = Console.ReadLine();
                    continue;
                }

                string[] names = tokens.TakeWhile(x => !x.Contains("@")).ToArray();

                if (names.Length > 3 && names.Length < 1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string fullName = string.Join(" ", names);
                string[] venueNames = tokens
                    .Skip(names.Length)
                    .Take(tokens.Length - names.Length - 2)
                    .ToArray();

                if (venueNames.Length > 3 && venueNames.Length < 1)
                {
                    input = Console.ReadLine();
                    continue;
                }

                string temp = venueNames[0].Substring(1);
                venueNames[0] = temp;
                string venueName = string.Join(" ", venueNames);

                if (!opaOpa.ContainsKey(venueName))
                {
                    opaOpa[venueName] = new Dictionary<string, long>();
                }

                if (!opaOpa[venueName].ContainsKey(fullName))
                {
                    opaOpa[venueName][fullName] = ticketsCount * ticketsPrice;
                }
                else
                {
                    opaOpa[venueName][fullName] += ticketsCount * ticketsPrice;
                }

                input = Console.ReadLine();
            }
            foreach (var curVenue in opaOpa)
            {
                Console.WriteLine($"{curVenue.Key}");
                foreach (var currSinger in curVenue
                    .Value
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {currSinger.Key} -> {currSinger.Value}");
                }
            }
        }
    }
}
