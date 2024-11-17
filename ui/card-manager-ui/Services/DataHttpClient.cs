using System.Net.Http;
using System.Net.Http.Json;
using card_manager_ui.Model;

namespace card_manager_ui.Services
{
    public partial class DataHttpClient : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataHttpClient(string api, HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _httpClient.BaseAddress = new Uri(api);
        }

        public async ValueTask<GetCardResult?> GetBySerialNumber(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GetCardResult>($"/api/v1/cards/serial-number/{id}");

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async ValueTask<GetCardResult?> GetByAccountNumber(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GetCardResult>($"/api/v1/cards/account-number/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async ValueTask<GetCardResult?> GetByIdentifier(string id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<GetCardResult>($"/api/v1/cards/identifier/{id}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<GetCardResult?> Create(string accountNumber, string serialNumber, string PIN)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"/api/v1/cards", new RegisterCardRequest()
                {
                    AccountNumber = accountNumber,
                    SerialNumber = serialNumber,
                    PIN = PIN
                });

                response.EnsureSuccessStatusCode();

                RegisterCardResult cardId = await response.Content.ReadFromJsonAsync<RegisterCardResult>();
                return await GetByIdentifier(cardId.Id);
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public async Task<bool> Delete(string cardId)
        {
            try
            {
                var result = await _httpClient.DeleteAsync($"/api/v1/cards/{cardId}");
                return result.IsSuccessStatusCode;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
