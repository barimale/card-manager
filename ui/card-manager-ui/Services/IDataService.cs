namespace card_manager_ui.Services
{
    public interface IDataService
    {
        ValueTask<dynamic> GetBySerialNumber(string value);
        ValueTask<dynamic> GetByIdentifier(string value);
        ValueTask<dynamic> GetByAccountNumber(string value);
    }
}
