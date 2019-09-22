using PokemonLeague.Tests.Helpers;
using System.Collections.Generic;
using Xunit;

namespace PokemonLeague.Tests
{
    public class FactVersionPokemonShould
    {
        [Fact]
        public void CharmanderFightAgainstPikatxu()
        {
            var charmander = PokemonFakeBuilder.Build("Charmander", 20, 100);
            var pikatxu = PokemonFakeBuilder.Build("Pikatxu", 15, 80);

            charmander.FightAgainst(pikatxu);

            Assert.Equal(85, charmander.Life);
            Assert.Equal(60, pikatxu.Life);
        }

        [Fact]
        public void CharizardFightAgainstSquirtle()
        {
            var charizard = PokemonFakeBuilder.Build("Charizard", 40, 90);
            var squirtle = PokemonFakeBuilder.Build("Squirtle", 10, 90);

            charizard.FightAgainst(squirtle);

            Assert.Equal(80, charizard.Life);
            Assert.Equal(50, squirtle.Life);
        }

        [Theory]
        [InlineData("Charmander", "Pikatxu", 100, 20, 80, 15, 85, 60)]
        [InlineData("Charizard", "Squirtle", 90, 40, 90, 10, 80, 50)]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf(string pokemon1Name, string pokemon2Name, int pokemon1Life, int pokemon1Strength, int pokemon2Life, int pokemon2Strength, int pokemon1ExpectedLife, int pokemon2ExcpectedLife)
        {
            var pokemon1 = PokemonFakeBuilder.Build(pokemon1Name, pokemon1Strength, pokemon1Life);
            var pokemon2 = PokemonFakeBuilder.Build(pokemon2Name, pokemon2Strength, pokemon2Life);

            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon1ExpectedLife, pokemon1.Life);
            Assert.Equal(pokemon2ExcpectedLife, pokemon2.Life);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf_MemberData(Pokemon pokemon1, Pokemon pokemon2, int pokemon1ExpectedLife, int pokemon2ExpectedLife)
        {
            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon1ExpectedLife, pokemon1.Life);
            Assert.Equal(pokemon2ExpectedLife, pokemon2.Life);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf_ClassData(Pokemon pokemon1, Pokemon pokemon2, int pokemon1ExpectedLife, int pokemon2ExpectedLife)
        {
            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon1ExpectedLife, pokemon1.Life);
            Assert.Equal(pokemon2ExpectedLife, pokemon2.Life);
        }

        public static IEnumerable<object[]> Data =>
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
    }
}