using System.ComponentModel.DataAnnotations;

namespace CurrencyExchanger.Modules.Api
{
    public class HistoryItemToCreateContract
    {
        [Required] [StringLength(3)] public string FromCurrency { get; set; }
        [Required] [StringLength(3)] public string ToCurrency { get; set; }
        [Required] public decimal FromAmount { get; set; }
    }
}