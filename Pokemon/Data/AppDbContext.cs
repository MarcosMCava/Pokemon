using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

namespace Pokemon.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon.Models.Pokemon> Pokemons { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<CapturedPokemon> CapturedPokemons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.Pokemon)
                .WithMany()
                .HasForeignKey(cp => cp.PokemonId);

            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.Master)
                .WithMany()
                .HasForeignKey(cp => cp.MasterId);
        }
    }
}
