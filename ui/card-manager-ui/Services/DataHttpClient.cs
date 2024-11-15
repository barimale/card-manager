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

        public async Task<bool> Create(string accountNumber, string serialNumber, string PIN)
        {
            var result = await _httpClient.PostAsJsonAsync($"api/v1/cards", new RegisterCardRequest()
            {
                AccountNumber = accountNumber,
                SerialNumber = serialNumber,
                PIN = PIN
            });

            return result.IsSuccessStatusCode;
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}
