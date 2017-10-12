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
            string line = Console.ReadLine();
            SortedDictionary<string, string> phoneBook = new SortedDictionary<string, string>();
            while(line != "END")
            {
                string[] commands = line.Split(' ').ToArray();
                if(commands[0] == "A")
                {
                    phoneBook[commands[1]] = commands[2];
                }
                else if(commands[0] == "S")
                {
                    if (phoneBook.ContainsKey(commands[1]))
                    {
                        Console.WriteLine($"{commands[1]} -> {phoneBook[commands[1]]}");
                    }
                    else
                    {
                        Console.WriteLine($"Contact {commands[1]} does not exist.");
                    }
                }
                else if(commands[0] == "ListAll")
                {
                    foreach(var contact in phoneBook)
                    {
                        Console.WriteLine($"{contact.Key} -> {contact.Value}");
                    }
                }
                line = Console.ReadLine();
            }
        }
    }
}
