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
    }
}