using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Models;

namespace Pokemon.Services
{
    public class MasterService
    {
        private readonly AppDbContext _context;

        public MasterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Master> AddMasterAsync(Master master)
        {
            _context.Masters.Add(master);
            await _context.SaveChangesAsync();
            return master;
        }

        public async Task<List<Master>> GetMastersAsync()
        {
            return await _context.Masters.ToListAsync();
        }
    }
}
