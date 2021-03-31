namespace CurrencyExchanger.Modules.Repository.Factories
{
    public class HistoryItemStorageMapper : IHistoryItemStorageMapper
    {
        public Storage.HistoryItem Map(HistoryItemToCreate historyItem)
        {
            return new()
            {
                FromCurrency = historyItem.FromCurrency,
                ToCurrency = historyItem.ToCurrency,
                FromAmount = historyItem.FromAmount,
                ToAmount = historyItem.ToAmount
            };
        }
    }
}