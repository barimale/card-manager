namespace card_manager_ui.Services
{
    public interface IDataService : IDataReadService, IDataWriteService { }
    public interface IDataReadService
    {
        ValueTask<dynamic> GetBySerialNumber(string value);
        ValueTask<dynamic> GetByIdentifier(string value);
        ValueTask<dynamic> GetByAccountNumber(string value);    }

    public interface IDataWriteService
    {
        Task<bool> Create(string accountNumber, string serialNumber, string PIN);
        Task<bool> Delete(string id);
    }
}
