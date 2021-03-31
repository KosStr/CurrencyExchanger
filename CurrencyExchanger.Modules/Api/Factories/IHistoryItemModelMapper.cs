using CurrencyExchanger.Modules.Repository;

namespace CurrencyExchanger.Modules.Api.Factories
{
    public interface IHistoryItemModelMapper
    {
        HistoryItemToCreate Map(HistoryItemToCreateContract contract, decimal toAmount);
    }
}