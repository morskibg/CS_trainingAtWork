using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nested_D_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            for(int i = 0; i < n; ++i)
            {
                string[] nameAndScore = Console.ReadLine().Split(' ').ToArray();
                string name = nameAndScore.First();
                double score = double.Parse(nameAndScore.Last());
                if (!students.ContainsKey(name))
                {
                    students[name] = new List<double> { score };
                }
                else
                {
                    students[name].Add(score);
                }
            }
            foreach(var student in students)
            {
                
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("F2")))} (avg: {student.Value.Average().ToString("F2")})");
            }

        }
    }
}
