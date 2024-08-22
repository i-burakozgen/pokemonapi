using PokemonAPI.Data;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Repository;

public class CategoryRepository:ICategoryRepository
{
    private readonly DataContext _context;
    public CategoryRepository(DataContext context)
    {
        _context = context;

    }
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonsByCategory(int categoryId)
    {
        return _context.PokemonCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}