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
            string[] words = Console.ReadLine().Split().ToArray();
            HashSet<int> indices = new HashSet<int>();
            Random rand = new Random();
            while(indices.Count < words.Length)
            {
                indices.Add(rand.Next(0, words.Length));
            }
            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine(words[indices.ElementAt(i)]);
            }
           
        }
    }
}
