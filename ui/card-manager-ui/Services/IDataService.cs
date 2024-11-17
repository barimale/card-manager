using static card_manager_ui.Services.DataHttpClient;

namespace card_manager_ui.Services
{
    public interface IDataService : IDataReadService, IDataWriteService { }
    public interface IDataReadService
    {
        ValueTask<GetCardResult?> GetBySerialNumber(string value);
        ValueTask<GetCardResult?> GetByIdentifier(string value);
        ValueTask<GetCardResult?> GetByAccountNumber(string value);    }

    public interface IDataWriteService
    {
        Task<GetCardResult?> Create(string accountNumber, string serialNumber, string PIN);
        Task<bool> Delete(string id);
    }
}
