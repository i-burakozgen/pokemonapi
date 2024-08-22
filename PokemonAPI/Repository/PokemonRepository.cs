using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository;

public class PokemonRepository : IPokemonRepository
{
    private readonly DataContext _context;
    public PokemonRepository(DataContext context)
    {
        _context = context;
        
    }

    public ICollection<Pokemon> GetPokemons()
    {
        return _context.Pokemons.OrderBy(p => p.Id).ToList();
    }
    // for id search
    public Pokemon GetPokemon(int id)
    {
        return _context.Pokemons.Where(p => p.Id == id).FirstOrDefault();
    }
    // for getting pokemon by name
    public Pokemon GetPokemon(string name)
    {
        return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
    }
    // return pokemon by review if there isnt any review returning 0 if there is reviews gonna take avarage and return avarage
    public decimal GetPokemonRating(int pokeId)
    {
        var review = _context.Reviews.Where(p => p.Pokemon.Id == pokeId);
        if (review.Count() <= 0)
        {
            return 0;
        }
        return ((decimal)review.Sum(r => r.Rating) / review.Count());
    }

    public bool PokemonExists(int pokeId)
    {
        return _context.Pokemons.Any(p =>p.Id == pokeId);
    }
}