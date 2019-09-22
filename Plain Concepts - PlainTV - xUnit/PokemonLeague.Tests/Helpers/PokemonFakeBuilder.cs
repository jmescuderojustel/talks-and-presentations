using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonLeague.Tests.Helpers
{
    public static class PokemonFakeBuilder
    {
        public static Pokemon Build(string name, int strength, int life)
        {
            return new Pokemon
            {
                Name = name,
                Strength = strength,
                Life = life
            };
        }
    }
}
