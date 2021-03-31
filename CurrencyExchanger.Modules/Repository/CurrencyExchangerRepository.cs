using System.Linq;
using System.Threading.Tasks;
using CurrencyExchanger.Modules.Repository.Factories;
using CurrencyExchanger.Modules.Storage;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchanger.Modules.Repository
{
    public class CurrencyExchangerRepository : ICurrencyExchangerRepository
    {
        private readonly IHistoryItemStorageMapper _storageMapper;
        private readonly IHistoryItemReconstructionFactory _reconstructionFactory;
        private readonly CurrencyExchangerStorage _storage;

        public CurrencyExchangerRepository(IHistoryItemStorageMapper storageMapper,
            CurrencyExchangerStorage storage,
            IHistoryItemReconstructionFactory reconstructionFactory)
        {
            _storageMapper = storageMapper;
            _storage = storage;
            _reconstructionFactory = reconstructionFactory;
        }

        public async Task<HistoryItem> Add(HistoryItemToCreate item)
        {
            var storageItemToSave = _storageMapper.Map(item);
            await _storage.AddAsync(storageItemToSave);
            await _storage.SaveChangesAsync();
            var storageItem = await _storage.HistoryItems.LastAsync();
            return _reconstructionFactory.Create(storageItem);
        }

        public async Task<HistoryItem[]> Get()
        {
            var items = await _storage.HistoryItems.ToListAsync();
            return items.Select(i => _reconstructionFactory.Create(i)).ToArray();
        }
    }
}