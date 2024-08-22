using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Interfaces;
using PokemonAPI.Models;

namespace PokemonAPI.Controllers;
[Route("api/[controller]")]
[ApiController]

public class PokemonController : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository;

    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _pokemonRepository.GetPokemons();
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(pokemons);
    }

    [HttpGet("{pokeId}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    // this goingto return a detalied pokemon
    public IActionResult GetPokemon(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
        {
            return NotFound();
        }
        var pokemon = _pokemonRepository.GetPokemon(pokeId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
            
            
        }
        return Ok(pokemon);
    }

    [HttpGet("{pokeId}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonRating(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
        {
            return NotFound();
        }
        var rating = _pokemonRepository.GetPokemonRating(pokeId);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(rating);
        
    }
    
    
    
    
    
}