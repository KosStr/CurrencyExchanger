using System;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchanger.Modules.Storage
{
    public class HistoryItem
    {
        [Key] public int Id { get; set; }
        [Required] [StringLength(3)] public string FromCurrency { get; set; }
        [Required] [StringLength(3)] public string ToCurrency { get; set; }
        [Required] public decimal FromAmount { get; set; }
        [Required] public decimal ToAmount { get; set; }
        public DateTime Date { get; set; }

    }
}