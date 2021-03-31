namespace CurrencyExchanger.Modules.Repository.Factories
{
    public interface IHistoryItemReconstructionFactory
    {
        HistoryItem Create(Storage.HistoryItem item);
    }
}