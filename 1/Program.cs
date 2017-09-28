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
            int sequenceToAdd = int.Parse(Console.ReadLine());
            
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < sequenceToAdd - 1; ++i)
            {
                int[] currentSequence = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                List<int> increasedSeq = new List<int>();
                bool isWronSequenceAppear = false;

                increasedSeq.Add(currentSequence[0]);


                for (int j = 0; j < currentSequence.Length - 1; ++j)
                {
                    if (currentSequence[j] > currentSequence[j + 1])
                    {
                        if (j < currentSequence.Length - 1)
                        {
                            isWronSequenceAppear = true;
                        }
                        break;
                    }
                    increasedSeq.Add(currentSequence[j + 1]);
                }

                while (true)
                {
                    int smalestNum = increasedSeq[0];
                    int smallIndex = numbers.FindIndex(x => x >= smalestNum);
                    if (smallIndex == -1)
                    {
                        numbers.Add(smalestNum);
                    }
                    else
                    {
                        numbers.Insert(smallIndex, smalestNum);
                    }
                    if (increasedSeq.Count > 0)
                    {
                        increasedSeq.RemoveAt(0);
                        if (increasedSeq.Count == 0)
                        {
                            if (isWronSequenceAppear && smalestNum != numbers.Last())
                            {
                                int indexToRemove = numbers.FindIndex(x => x > smalestNum);
                                int lengthToRemove = numbers.Count - indexToRemove;
                                numbers.RemoveRange(indexToRemove, lengthToRemove);
                            }
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
