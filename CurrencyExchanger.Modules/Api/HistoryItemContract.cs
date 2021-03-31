using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchanger.Modules.Api
{
    public class HistoryItemContract
    {
        [Required] public int Id { get; set; }
        [Required] [StringLength(3)] public string FromCurrency { get; set; }
        [Required] [StringLength(3)] public string ToCurrency { get; set; }
        [Required] public decimal FromAmount { get; set; }
        [Required] public decimal ToAmount { get; set; }
        [Required] public DateTime Date { get; set; }
    }
}