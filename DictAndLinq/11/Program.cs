using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string, string>> draKons =
                new Dictionary<string, Dictionary<string, string>>();
            for (int i = 0; i < n; i++)
            {
               
                char[] delim = " ".ToCharArray();
                string[] tokens = Console.ReadLine()
                    .Split(delim, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (!draKons.ContainsKey(tokens[0]))
                {
                    draKons[tokens[0]] = new Dictionary<string, string>
                    {
                        { tokens[1], tokens[2]}
                    };
                }

            }
        }
    }
}
