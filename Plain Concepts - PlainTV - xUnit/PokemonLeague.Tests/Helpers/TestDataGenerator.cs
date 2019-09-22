using PokemonLeague.Tests.Helpers;
using System.Collections;
using System.Collections.Generic;

namespace PokemonLeague.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data  =
           new List<object[]>
           {
                new object[]
                {
                    PokemonFakeBuilder.Build("Charmander", 20, 100),
                    PokemonFakeBuilder.Build("Pikatxu", 15, 80),
                    85,
                    60
                },
                new object[]
                {
                    PokemonFakeBuilder.Build("Charizard", 40, 90),
                    PokemonFakeBuilder.Build("Squirtle", 10, 90),
                    80,
                    50
                }
           };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
