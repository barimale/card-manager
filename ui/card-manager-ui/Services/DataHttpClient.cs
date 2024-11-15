using System.Net.Http;
using System.Net.Http.Json;

namespace card_manager_ui.Services
{
    public class DataHttpClient : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataHttpClient(string api, HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _httpClient.BaseAddress = new Uri(api);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "card-manager");
        }

        public async ValueTask<dynamic> GetBySerialNumber(string peopleId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"people/{peopleId}");
        }

        public async ValueTask<dynamic> GetByIdentifier(string planetId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"planets/{planetId}");
        }

        public async ValueTask<dynamic> GetByAccountNumber(string speciesId)
        {
            return await _httpClient.GetFromJsonAsync<dynamic>($"species/{speciesId}");

        }
    }
}
