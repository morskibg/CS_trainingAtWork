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
            if (sequenceToAdd == 0)
            {
                return;
            }

            List<long> numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            for (int i = 0; i < sequenceToAdd - 1; ++i)
            {
                long[] currentSequence = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                List<long> increasedSeq = new List<long>();
                bool isWronSequenceAppear = false;

                increasedSeq.Add(currentSequence[0]);


                for (int j = 0; j < currentSequence.Length - 1; ++j)
                {
                    if (currentSequence[j] > currentSequence[j + 1])
                    {
                        isWronSequenceAppear = true;
                        break;
                    }
                    increasedSeq.Add(currentSequence[j + 1]);
                }

                while (true)
                {

                    long smalestNum = increasedSeq[0];
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
