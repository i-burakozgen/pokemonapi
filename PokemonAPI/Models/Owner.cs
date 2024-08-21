namespace PokemonAPI.Models;

public class Owner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public String LastName { get; set; }
    public string Gym { get; set; }
    public Country Country { get; set; } 
    public ICollection<PokemonOwner> PokemonOwners { get; set; }
}