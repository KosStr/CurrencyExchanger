using CurrencyExchanger.Modules.Repository;

namespace CurrencyExchanger.Modules.Api.Factories
{
    public interface IHistoryItemContractReconstructionFactory
    {
        HistoryItemContract Create(HistoryItem item);
    }
}