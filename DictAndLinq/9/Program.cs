using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> farm = new Dictionary<string, int>();
                            
            while (true)
            {
                string[] data = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] resources = data.Where((x, i) => i % 2 != 0 && i != 0).ToArray();
                string[] resCount = data.Where((x, i) => i % 2 == 0).ToArray();
                for(int i = 0; i < resources.Length; ++i)
                {
                    if (!farm.ContainsKey(resources[i]))
                    {
                        farm[resources[i]] = 0;
                    }
                    farm[resources[i]] = int.Parse(Array.)
                }
                

                int t = 0;
            }
        }
    }
}
