namespace card_manager_ui.Services
{
    public interface IDataService : IDataReadService, IDataWriteService { }
    public interface IDataReadService
    {
        ValueTask<CardDto> GetBySerialNumber(string value);
        ValueTask<CardDto> GetByIdentifier(string value);
        ValueTask<CardDto> GetByAccountNumber(string value);    }

    public interface IDataWriteService
    {
        Task<CardDto> Create(string accountNumber, string serialNumber, string PIN);
        Task<bool> Delete(string id);
    }
}
