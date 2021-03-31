using System.Threading.Tasks;

namespace CurrencyExchanger.Modules.Api
{
    public interface ICurrencyExchangerApi
    {
        Task<HistoryItemContract> Add(HistoryItemToCreateContract contract);
        Task<HistoryItemContract[]> Get();
    }
}