using System;

namespace CurrencyExchanger.Modules.Repository
{
    public class HistoryItem
    {
        public int Id { get; }
        public string FromCurrency { get; }
        public string ToCurrency { get; }
        public decimal FromAmount { get; }
        public decimal ToAmount { get; }
        public DateTime Date { get; }

        public HistoryItem(int id,
            string fromCurrency,
            string toCurrency,
            decimal fromAmount,
            decimal toAmount,
            DateTime date)
        {
            Id = id;
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromAmount = fromAmount;
            ToAmount = toAmount;
            Date = date;
        }
    }
}