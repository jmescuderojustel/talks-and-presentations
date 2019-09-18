namespace PokemonLeague
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Life { get; set; }

        public void FightAgainst(Pokemon otherPokemon)
        {
            otherPokemon.Life -= Strength;
            Life -= otherPokemon.Strength;
        }
    }
}