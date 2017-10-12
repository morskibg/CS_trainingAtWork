using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NE_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, List<string>>> posts = new Dictionary<string, Dictionary<string, List<string>>>();
            Dictionary<string, int> likes = new Dictionary<string, int>();
            Dictionary<string, int> dislikes = new Dictionary<string, int>();
            while (input != "drop the media")
            {
                string[] rawData = input.Split(' ').ToArray();
                string command = rawData[0];
                string postName = rawData[1];

                if (command == "post")
                {
                    if (!posts.ContainsKey(postName))
                    {
                        posts[postName] = new Dictionary<string, List<string>>();
                        likes[postName] = 0;
                        dislikes[postName] = 0;
                    }
                }
                else if (command == "like")
                {
                    likes[postName]++;
                }
                else if (command == "dislike")
                {
                    dislikes[postName]++;
                }
                else
                {
                    string comentorsName = rawData[2];
                    string[] commentWords = input.Split(' ').Skip(3).ToArray();
                    string content = string.Join(" ",commentWords);
                    if (!posts[postName].ContainsKey(comentorsName))
                    {
                        posts[postName][comentorsName] = new List<string>();
                    }
                    posts[postName][comentorsName].Add(content);

                }
                input = Console.ReadLine();
            }
            foreach (var currPost in posts)
            {
                Console.WriteLine($"Post: {currPost.Key} | Likes: {likes[currPost.Key]} | Dislikes: {dislikes[currPost.Key]}");
                Console.WriteLine("Comments:");
                if (currPost.Value.Count == 0)
                {
                    Console.WriteLine("None");
                    continue;
                }
                foreach (var currCommentor in currPost.Value)
                {
                    for (int i = 0; i < currCommentor.Value.Count; ++i)
                    {
                        Console.WriteLine($"*  {currCommentor.Key}: {currCommentor.Value[i]}");
                    }
                }
            }

        }
    }
}
