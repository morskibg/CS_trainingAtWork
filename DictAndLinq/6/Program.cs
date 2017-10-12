using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> logUsers = new SortedDictionary<string, Dictionary<string, int>>();
            string line = Console.ReadLine();
            while (line != "end")
            {
                string[] delim = { "message=", "IP=", "user=" };
                string[] data = line.Split(delim, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string user = data.Last();
                string IP = data.First();
                if (!logUsers.ContainsKey(user))
                {
                    logUsers[user] = new Dictionary<string, int>();
                }
                if (!logUsers[user].ContainsKey(IP))
                {
                    logUsers[user][IP] = 0;
                }
                logUsers[user][IP]++;
                line = Console.ReadLine();
            }
            
            foreach (var currUser in logUsers)
            {
                Console.WriteLine($"{currUser.Key}: ");
                int size = currUser.Value.Count;
                foreach (var curIP in currUser.Value)
                {
                    if (size != 1)
                    {
                        Console.Write($"{curIP.Key}=> {curIP.Value}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{curIP.Key}=> {curIP.Value}.");
                    }
                    --size;
                }
            }
            int t = 0;
        }
    }
}
