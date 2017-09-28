using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int currentListIdx = 0;
            int sequenceToAdd = int.Parse(Console.ReadLine());
            for(int i = 0; i < sequenceToAdd; ++i)
            {
                if(i == 0)
                {
                    List<int> tempList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                    numbers = tempList;
                    currentListIdx = numbers.Count - 1;
                    continue;
                }
                List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                sequence.Select((a, b) => a < b);

            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
