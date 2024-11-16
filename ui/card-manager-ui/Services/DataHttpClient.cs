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

        public async ValueTask<CardDto> GetBySerialNumber(string id)
        {
            return await _httpClient.GetFromJsonAsync<CardDto>($"/api/v1/cards/serial-number/{id}");
        }

        public async ValueTask<CardDto> GetByAccountNumber(string id)
        {
            return await _httpClient.GetFromJsonAsync<CardDto>($"/api/v1/cards/account-number/{id}");
        }

        public async ValueTask<CardDto> GetByIdentifier(string id)
        {
            return await _httpClient.GetFromJsonAsync<CardDto>($"/api/v1/cards/identifier/{id}");
        }

        public async Task<bool> Create(string accountNumber, string serialNumber, string PIN)
        {
            var result = await _httpClient.PostAsJsonAsync($"/api/v1/cards", new RegisterCardRequest()
            {
                AccountNumber = accountNumber,
                SerialNumber = serialNumber,
                PIN = PIN
            });

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string cardId)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/cards/delete/{cardId}");

            return result.IsSuccessStatusCode;
        }
    }
}
