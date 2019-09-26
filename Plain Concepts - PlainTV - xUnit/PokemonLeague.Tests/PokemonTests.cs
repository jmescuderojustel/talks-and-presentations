using PokemonLeague.Tests.Helpers;
using System.Collections.Generic;
using Xunit;

namespace PokemonLeague.Tests
{
    public class PokemonTests
    {
        [Fact]
        public void CharmanderFightAgainstPikatxu()
        {
            var charmander = new Pokemon("Charmander", 20, 100);
            var pikatxu = new Pokemon("Pikatxu", 15, 80);

            charmander.FightAgainst(pikatxu);

            Assert.Equal(60, pikatxu.Life);
        }

        [Fact]
        public void CharizardFightAgainstSquirtle()
        {
            var charizard = new Pokemon("Charizard", 40, 90);
            var squirtle = new Pokemon("Squirtle", 10, 90);

            charizard.FightAgainst(squirtle);

            Assert.Equal(50, squirtle.Life);
        }

        [Theory]
        [InlineData("Charmander", "Pikatxu", 100, 20, 80, 15, 60)]
        [InlineData("Charizard", "Squirtle", 90, 40, 90, 10, 50)]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf(string pokemon1Name, string pokemon2Name, int pokemon1Life, int pokemon1Strength, int pokemon2Life, int pokemon2Strength, int pokemon2ExcpectedLife)
        {
            var pokemon1 = new Pokemon(pokemon1Name, pokemon1Strength, pokemon1Life);
            var pokemon2 = new Pokemon(pokemon2Name, pokemon2Strength, pokemon2Life);

            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon2ExcpectedLife, pokemon2.Life);
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf_ClassData(Pokemon pokemon1, Pokemon pokemon2, int pokemon2ExpectedLife)
        {
            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon2ExpectedLife, pokemon2.Life);
        }

        [Theory]
        [MemberData(nameof(MemberDataHelper.Data))]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf_MemberData_WithHelper(Pokemon pokemon1, Pokemon pokemon2, int pokemon2ExpectedLife)
        {
            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon2ExpectedLife, pokemon2.Life);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void FightAgainst_ShouldWeakenTheAdversaryAndOneSelf_MemberData(Pokemon pokemon1, Pokemon pokemon2, int pokemon2ExpectedLife)
        {
            pokemon1.FightAgainst(pokemon2);

            Assert.Equal(pokemon2ExpectedLife, pokemon2.Life);
        }

        public static IEnumerable<object[]> Data =>
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
    }
}