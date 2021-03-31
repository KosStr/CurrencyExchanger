using CurrencyExchanger.Modules.Repository;

namespace CurrencyExchanger.Modules.Api.Factories
{
    public class HistoryItemContractReconstructionFactory : IHistoryItemContractReconstructionFactory
    {
        public HistoryItemContract Create(HistoryItem item) =>
            new()
            {
                Id = item.Id,
                FromAmount = item.FromAmount,
                ToAmount = item.ToAmount,
                FromCurrency = item.FromCurrency,
                ToCurrency = item.ToCurrency,
                Date = item.Date
            };
    }
}