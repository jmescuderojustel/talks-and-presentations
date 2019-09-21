using System.Collections.Generic;
using Xunit;

namespace PokemonLeague.Tests
{
    public class FactVersionPokemonShould
    {
        [Fact]
        public void CharmanderFightAgainstPikatxu()
        {
            var charmander = new Pokemon
            {
                Name = "Charmander",
                Life = 100,
                Strength = 20
            };

            var pikatxu = new Pokemon
            {
                Name = "Pikatxu",
                Life = 80,
                Strength = 15
            };

            charmander.FightAgainst(pikatxu);

            Assert.Equal(85, charmander.Life);
            Assert.Equal(60, pikatxu.Life);
        }

        [Fact]
        public void CharizardFightAgainstSquirtle()
        {
            var charizard = new Pokemon
            {
                Name = "Charizard",
                Life = 90,
                Strength = 40
            };

            var squirtle = new Pokemon
            {
                Name = "Squirtle",
                Life = 90,
                Strength = 10
            };

            charizard.FightAgainst(squirtle);

            Assert.Equal(80, charizard.Life);
            Assert.Equal(50, squirtle.Life);
        }

        [Theory]
        [InlineData("Charmander", "Pikatxu", 100, 20, 80, 15, 85, 60)]
        [InlineData("Charizard", "Squirtle", 90, 40, 90, 10, 80, 50)]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf(string pokemon1Name, string pokemon2Name, int pokemon1Life, int pokemon1Strength, int pokemon2Life, int pokemon2Strength, int pokemon1ExpectedLife, int pokemon2ExcpectedLife)
        {
            var pokemon1 = new Pokemon
            {
                Name = pokemon1Name,
                Life = pokemon1Life,
                Strength = pokemon1Strength
            };

            var pokemon2 = new Pokemon
            {
                Name = pokemon2Name,
                Life = pokemon2Life,
                Strength = pokemon2Strength
            };

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

        public static IEnumerable<object[]> Data =>
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
    }
}