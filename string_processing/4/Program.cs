using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([A-Z]|[a-z])\w*";
            //Regex regex = new Regex(pattern);
            MatchCollection words = Regex.Matches(input, pattern);
            List<string> palli = new List<string>();
            foreach (var word in words)
            {
                string currWord = word.ToString();
                bool isPoli = true;
                for (int i = 0; i < currWord.Length / 2; i++)
                {
                    if (currWord[i] != currWord[currWord.Length - 1 - i])
                    {
                        isPoli = false;
                        break;
                    }
                }
                if (isPoli)
                {
                    palli.Add(currWord);
                }
            }
            Console.WriteLine(string.Join(", ", palli.Distinct().OrderBy(x => x)));

        }
    }
}
