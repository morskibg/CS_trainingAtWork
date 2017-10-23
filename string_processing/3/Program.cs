using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] banWords = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string inputText = Console.ReadLine();
            foreach (string currBanWord in banWords.Where(x => inputText.Contains(x)))
            {

                int foundedBanWordLength = currBanWord.Length;
                inputText = inputText.Replace(currBanWord, new string('*', foundedBanWordLength));
            }
            Console.WriteLine(inputText);

        }
    }
}
