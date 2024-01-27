using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }

        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
    }
}
