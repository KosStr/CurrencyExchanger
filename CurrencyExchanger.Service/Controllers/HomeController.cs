using CurrencyExchanger.Service.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using CurrencyExchanger.Modules.Api;

namespace CurrencyExchanger.Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICurrencyExchangerApi _api;

        public HomeController(ILogger<HomeController> logger, ICurrencyExchangerApi api)
        {
            _logger = logger;
            _api = api;
        }

        public async Task<IActionResult> Index()
        {
            var contract = new HistoryItemToCreateContract
            {
                FromAmount = 1,
                FromCurrency = "USD",
                ToCurrency = "GBP"
            };
            //await _api.Add(contract);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
