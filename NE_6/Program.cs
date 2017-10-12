using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string,HashSet<string>> topicDatabase = new Dictionary<string, HashSet<string>>();
            string input = Console.ReadLine();
            while (input != "filter")
            {
                char[] delimiter = " ->,".ToCharArray();
                string[] tags = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string topic = tags[0];
                tags = tags.Skip(1).Select(x => "#" + x).ToArray();
                if (!topicDatabase.ContainsKey(topic))
                {
                    topicDatabase[topic] = new HashSet<string>(tags);
                }
                else
                {
                    foreach (string tag in tags)
                    {
                        topicDatabase[topic].Add(tag);
                    }
                    
                }
                input = Console.ReadLine();
            }
            //input = Console.ReadLine();
            char[] delimiter2 = ", ".ToCharArray();
            List<string> keyTags = Console.ReadLine()
                .Split(delimiter2, StringSplitOptions.RemoveEmptyEntries)
                .Distinct()
                .Select(x => "#" + x)
                .ToList();
            foreach (var currTopic in topicDatabase)
            {
                bool hasToPrint = true;
                foreach (var keyTag in keyTags)
                {
                    if (!currTopic.Value.Contains(keyTag))
                    {
                        hasToPrint = false;
                        break;
                    }
                    
                }
                if (hasToPrint)
                {
                    Console.WriteLine($"{currTopic.Key} | {string.Join(", ", currTopic.Value)}");
                }
                
            }
        } 
        
    }
}
