namespace CurrencyExchanger.Modules.Repository.Factories
{
    public interface IHistoryItemStorageMapper
    {
        Storage.HistoryItem Map(HistoryItemToCreate historyItem);
    }
}