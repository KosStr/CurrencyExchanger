using CurrencyExchanger.Modules.Repository;

namespace CurrencyExchanger.Modules.Api.Factories
{
    public class HistoryItemModelMapper: IHistoryItemModelMapper
    {
        public HistoryItemToCreate Map(HistoryItemToCreateContract contract, decimal toAmount) =>
            new(contract.FromCurrency,
                contract.ToCurrency,
                contract.FromAmount,
                toAmount);
    }
}