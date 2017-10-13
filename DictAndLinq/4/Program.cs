using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static int ReturnPowerFactor(string input)
        {
            int parsedInt = 0;
            if (int.TryParse(input, out parsedInt))
            {
                return parsedInt;
            }
            switch (input)
            {
                case "J": return 11;
                case "Q": return 12;
                case "K": return 13;
                case "A": return 14;
                case "S": return 4;
                case "H": return 3;
                case "D": return 2;
                case "C": return 1;
                default:  return -1;
            }
        }

        static int CalculateCardValue(string powerAndType)
        {
            string Type = powerAndType[powerAndType.Length - 1].ToString();
            string Power = powerAndType.Substring(0, powerAndType.Length - 1);
            int power = ReturnPowerFactor(Power);
            int type = ReturnPowerFactor(Type);
            return power * type;
        }
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> playersCards = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();
            while (input != "JOKER")
            {
                string[] rawData = input.Split(':').ToArray();
                string cards = rawData[rawData.Length - 1];
                
                string playerName = string.Join("", rawData.Where((x, i) => i != rawData.Length - 1));
                char[] delimiter = ", ".ToCharArray();
                string[] manyCards = cards.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                if (!playersCards.ContainsKey(playerName))
                {
                    playersCards[playerName] = new HashSet<string>();
                }
                foreach (string card in manyCards)
                {
                    playersCards[playerName].Add(card);
                }
                input = Console.ReadLine();
            }
            foreach (var currPlayer in playersCards)
            {
                int totalCardsPower = currPlayer.Value.Select(x => CalculateCardValue(x)).ToArray().Sum();
                Console.WriteLine($"{currPlayer.Key}: {totalCardsPower}");
                
            }
        }
    }
}
