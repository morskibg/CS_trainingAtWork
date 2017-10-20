using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokDatabase = new List<Pokemon>();
            string input = Console.ReadLine();
            while(input != "wubbalubbadubdub")
            {
                char[] delims = "->".ToCharArray();
                string[] tokens = input.Split(delims, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string pokName = tokens[0].Trim();

                if (tokens.Length > 1)
                {                   
                    string pokEvo = tokens[1].Trim();
                    int evoIndex = int.Parse(tokens[2].Trim());
                    if (!pokDatabase.Any(x => x.Name == pokName))
                    {
                        Pokemon newPok = new Pokemon();
                        newPok.Name = pokName;
                        var currEvo = new KeyValuePair<string, int>(pokEvo, evoIndex);
                        newPok.PokemonEvo.Add(currEvo);
                        pokDatabase.Add(newPok);
                    }
                    else
                    {
                        var currEvo = new KeyValuePair<string, int>(pokEvo, evoIndex);
                        int currPokIdx = pokDatabase.FindIndex(x => x.Name == pokName);
                        if (currPokIdx != -1)
                        {
                            pokDatabase[currPokIdx].PokemonEvo.Add(currEvo);
                        }
                    }
                }
                else
                {
                    if(pokDatabase.Any(x => x.Name == pokName))
                    {
                        Console.WriteLine($"# {pokName}");
                        int pokIdx = pokDatabase.FindIndex(x => x.Name == pokName);
                        if(pokIdx != -1)
                        {
                            foreach (var currEvo in pokDatabase[pokIdx].PokemonEvo)
                            {
                                Console.WriteLine($"{currEvo.Key} <-> {currEvo.Value}");
                            }
                        }
                        
                    }
                }
                input = Console.ReadLine();
            }
            foreach(var pok in pokDatabase)
            {
                Console.WriteLine($"# {pok.Name}");
                foreach(var evo in pok.PokemonEvo.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{evo.Key} <-> {evo.Value}");
                }
            }
        }
    }
    
    class Pokemon
    {
        public string Name { get; set; }
        public List<KeyValuePair<string, int>> PokemonEvo { get; set; }
        public Pokemon()
        {
            Name = "none";
            PokemonEvo = new List<KeyValuePair<string, int>>();
        }
    }
}
