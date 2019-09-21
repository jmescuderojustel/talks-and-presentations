using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PokemonLeague.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data  =
           new List<object[]>
           {
                new object[]
                {
                    new Pokemon
                    {
                        Name = "Charmander",
                        Life = 100,
                        Strength = 20
                    },
                    new Pokemon
                    {
                        Name = "Pikatxu",
                        Life = 80,
                        Strength = 15
                    },
                    85,
                    60
                },
                new object[]
                {
                    new Pokemon
                    {
                        Name = "Charizard",
                        Life = 90,
                        Strength = 40
                    },
                    new Pokemon
                    {
                        Name = "Squirtle",
                        Life = 90,
                        Strength = 10
                    },
                    80,
                    50
                }
           };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
