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
            string line = Console.ReadLine();
            int counter = 1;
            string key = "";
            Dictionary<string, string> emailData = new Dictionary<string, string>();
            while(line != "stop")
            {
                if(counter % 2 != 0)
                {
                    //if (!emailData.ContainsKey(line))
                    //{
                    //    emailData[line] = 
                    //}
                    emailData[line] = "";
                    key = line;
                }
                else
                {
                    string[] lettreData = line
                        .Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    string domain = lettreData.Last();
                    if (domain == "uk" || domain == "us")
                    {
                        emailData.Remove(key);
                    }
                    else
                    {
                        emailData[key] = line;
                    }
                }
                ++counter;
                line = Console.ReadLine();
            }
            foreach (var item in emailData)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
