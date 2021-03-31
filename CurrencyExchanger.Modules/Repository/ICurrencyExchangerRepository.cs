using System.Threading.Tasks;

namespace CurrencyExchanger.Modules.Repository
{
    public interface ICurrencyExchangerRepository
    {
        Task<HistoryItem> Add(HistoryItemToCreate item);
        Task<HistoryItem[]> Get();
    }
}