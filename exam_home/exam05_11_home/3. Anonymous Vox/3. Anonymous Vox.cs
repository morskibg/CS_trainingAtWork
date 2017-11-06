using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.Anonymous_Vox
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
            string placeHolders = Console.ReadLine();
            string placeholderPattern = @"(?<start>[A-Za-z]+)(?<placeholder>.+)(?<end>\k<start>)";


            var toReplace = Regex.Matches(encrypted, @"(?<start>[A-Za-z]+)(?<placeholder>.*)(?<end>\k<start>)")
                .Cast<Match>()
                .Select(x => x.Groups["placeholder"])
                .ToList();
            var placeholdersRaw = Regex.Matches(placeHolders, @"[\{](?<value>.*?)[\}]")
                .Cast<Match>()
                .Select(x => x.Groups["value"])
                .ToList();
          
            int smallerSize = Math.Min(toReplace.Count, placeholdersRaw.Count);
            
            for (int i = 0; i < smallerSize; i++)
            {
                int occurence = encrypted.IndexOf(toReplace[i].ToString());
                int sizeToRemove = toReplace[i].Length;
                StringBuilder sb = new StringBuilder();
                sb.Append(encrypted.Substring(0, occurence));
                sb.Append(placeholdersRaw[i].ToString());
                sb.Append(encrypted.Substring(occurence + sizeToRemove));
                encrypted = sb.ToString();
            }
            Console.WriteLine(string.Join(" ", encrypted));

        }
    }
}
