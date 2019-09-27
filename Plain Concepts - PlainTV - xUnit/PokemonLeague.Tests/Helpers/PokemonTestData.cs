using Xunit;

namespace PokemonLeague.Tests.Helpers
{
    public class PokemonTestData : TheoryData<Pokemon, Pokemon, int>
    {
        public PokemonTestData()
        {
            Add(
                new Pokemon("Charmander", 20, 100),
                new Pokemon("Pikatxu", 15, 80),
                60);
            Add(
                new Pokemon("Charizard", 40, 90),
                new Pokemon("Squirtle", 10, 90),
                50);
        }
    }
}