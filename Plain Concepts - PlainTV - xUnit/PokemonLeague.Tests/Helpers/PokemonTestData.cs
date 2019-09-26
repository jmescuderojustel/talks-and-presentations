using Xunit;

namespace PokemonLeague.Tests.Helpers
{
    public class PokemonTestData : TheoryData<Pokemon, Pokemon, int>
    {
        public PokemonTestData()
        {
            var charmander = new Pokemon("Charmander", 20, 100);
            var pikatxu = new Pokemon("Pikatxu", 15, 80);
            var charizard = new Pokemon("Charizard", 40, 90);
            var squirtle = new Pokemon("Squirtle", 10, 90);

            Add(charmander, pikatxu, 60);
            Add(charizard, squirtle, 50);
        }
    }
}