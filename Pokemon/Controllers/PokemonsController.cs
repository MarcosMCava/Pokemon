using Microsoft.AspNetCore.Mvc;
using Pokemon.Models;
using Pokemon.Services;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonsController : ControllerBase
    {
        private readonly PokemonService _pokemonService;
        private readonly CaptureService _captureService;

        public PokemonsController(PokemonService pokemonService, CaptureService captureService)
        {
            _pokemonService = pokemonService;
            _captureService = captureService;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandomPokemons()
        {
            var pokemons = await _pokemonService.GetRandomPokemonsAsync();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPokemonById(int id)
        {
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

        [HttpPost("capture")]
        public async Task<IActionResult> CapturePokemon(CapturedPokemon capture)
        {
            var captured = await _captureService.CapturePokemonAsync(capture);
            return Ok(captured);
        }

        [HttpGet("captured")]
        public async Task<IActionResult> GetCapturedPokemons()
        {
            var capturedPokemons = await _captureService.GetCapturedPokemonsAsync();
            return Ok(capturedPokemons);
        }
    }
}





