using System.Collections.Generic;

namespace PokemonLeague.Tests.Helpers
{
    public static class MemberDataHelper
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new Pokemon("Charmander", 20, 100),
                    new Pokemon("Pikatxu", 15, 80),
                    85,
                    60
                },
                new object[]
                {
                    new Pokemon("Charizard", 40, 90),
                    new Pokemon("Squirtle", 10, 90),
                    80,
                    50
                }
            };
    }
}
