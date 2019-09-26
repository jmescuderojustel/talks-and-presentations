using System.Collections;
using System.Collections.Generic;

namespace PokemonLeague.Tests.Helpers
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data =
           new List<object[]>
           {
                new object[]
                {
                    new Pokemon("Charmander", 20, 100),
                    new Pokemon("Pikatxu", 15, 80),
                    60
                },
                new object[]
                {
                    new Pokemon("Charizard", 40, 90),
                    new Pokemon("Squirtle", 10, 90),
                    50
                }
           };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}