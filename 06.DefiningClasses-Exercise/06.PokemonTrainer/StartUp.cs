
namespace PokemonTrainer;

class StartUp
{
    public static void Main()
    {
        string info = string.Empty;

        List<Trainer> trainers = new List<Trainer>();

        while ((info = Console.ReadLine()) != "Tournament")
        {
            string[] trainerPokemonInfo = info
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Pokemon pokemon = CreatePokemon(trainerPokemonInfo);

            string trainerName = trainerPokemonInfo[0];

            if (trainers.Any(n => n.Name == trainerName))
            {
                trainers.First(n => n.Name == trainerName).Pokemons.Add(pokemon);
            }
            else
            {
                Trainer trainer = CreateTrainer(trainerName, pokemon);
                trainers.Add(trainer);
            }
        }

        string command = string.Empty;

        while ((command = Console.ReadLine()) != "End")
        {
            string currentElement = command;

            foreach (Trainer trainer in trainers)
            {
                if (trainer.Pokemons.Any(n => n.Element == currentElement))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    trainer.Pokemons.ForEach(h => h.Health -= 10);
                }

                if (trainer.Pokemons.Any(h => h.Health <= 0))
                {
                    trainer.Pokemons.RemoveAll(h => h.Health <= 0);
                }
            }
        }

        foreach (Trainer trainer in trainers.OrderByDescending(n => n.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count()}");
        }
    }

    private static Trainer CreateTrainer(string trainerName, Pokemon pokemon)
    {
        Trainer trainer = new Trainer(trainerName);
        trainer.Pokemons.Add(pokemon);

        return trainer;
    }

    private static Pokemon CreatePokemon(string[] pokemonInfo)
    {
        string name = pokemonInfo[1];
        string element = pokemonInfo[2];
        int health = int.Parse(pokemonInfo[3]);

        Pokemon pokemon = new Pokemon(name, element, health);

        return pokemon;
    }
}