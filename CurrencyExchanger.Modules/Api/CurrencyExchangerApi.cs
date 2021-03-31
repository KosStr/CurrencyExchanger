using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyExchanger.Modules.Api.Factories;
using CurrencyExchanger.Modules.Repository;

namespace CurrencyExchanger.Modules.Api
{
    public class CurrencyExchangerApi : ICurrencyExchangerApi
    {
        private readonly IHistoryItemContractReconstructionFactory _reconstructionFactory;
        private readonly IHistoryItemModelMapper _modelMapper;
        private readonly ICurrencyExchangerRepository _repository;

        public CurrencyExchangerApi(IHistoryItemContractReconstructionFactory reconstructionFactory,
            IHistoryItemModelMapper modelMapper,
            ICurrencyExchangerRepository repository)
        {
            _reconstructionFactory = reconstructionFactory;
            _modelMapper = modelMapper;
            _repository = repository;
        }

        public async Task<HistoryItemContract> Add(HistoryItemToCreateContract contract)
        {
            var httpClient = new HttpClient();
            const string urlAddress = "https://api.exchangeratesapi.io/latest/";
            var parameters = "?symbols=" +
                contract.ToCurrency + "&base=" + contract.FromCurrency;
            var response = await httpClient.GetAsync(urlAddress + parameters);
            var contents = await response.Content.ReadAsStringAsync();
            var ratio = decimal.Parse(contents.Split("\"" + contract.ToCurrency.ToUpper() + "\":")[1]
                    .Split("}")[0],
                CultureInfo.InvariantCulture);
            var item = _modelMapper.Map(contract, ratio*contract.FromAmount);
            var result = await _repository.Add(item);
            return _reconstructionFactory.Create(result);
        }

        public async Task<HistoryItemContract[]> Get()
        {
            var items = await _repository.Get();
            return items.Select(i => _reconstructionFactory.Create(i)).ToArray();
        }
    }
}