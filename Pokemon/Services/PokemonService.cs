using System.Text.Json;

namespace Pokemon.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon.Models.Pokemon> GetPokemonByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var pokemon = JsonSerializer.Deserialize<Pokemon.Models.Pokemon>(response);
            return pokemon;
        }

        public async Task<List<Pokemon.Models.Pokemon>> GetRandomPokemonsAsync()
        {
            var random = new Random();
            var pokemons = new List<Pokemon.Models.Pokemon>();

            for (int i = 0; i < 10; i++)
            {
                int id = random.Next(1, 899);
                var pokemon = await GetPokemonByIdAsync(id);
                pokemons.Add(pokemon);
            }

            return pokemons;
        }
    }
}
