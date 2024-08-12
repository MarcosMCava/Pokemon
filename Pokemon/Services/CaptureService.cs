using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Models;


namespace Pokemon.Services
{
    public class CaptureService
    {
        private readonly AppDbContext _context;

        public CaptureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CapturedPokemon> CapturePokemonAsync(CapturedPokemon capture)
        {
            _context.CapturedPokemons.Add(capture);
            await _context.SaveChangesAsync();
            return capture;
        }

        public async Task<List<CapturedPokemon>> GetCapturedPokemonsAsync()
        {
            return await _context.CapturedPokemons
                .Include(cp => cp.Pokemon)
                .Include(cp => cp.Master)
                .ToListAsync();
        }
    }
}
