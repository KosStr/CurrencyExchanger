namespace CurrencyExchanger.Modules.Repository.Factories
{
    public class HistoryItemReconstructionFactory: IHistoryItemReconstructionFactory
    {
        public HistoryItem Create(Storage.HistoryItem item) =>
            new(item.Id,
                item.FromCurrency,
                item.ToCurrency,
                item.FromAmount,
                item.ToAmount,
                item.Date);
    }
}