using System;

namespace CurrencyExchanger.Modules.Repository
{
    public class HistoryItemToCreate
    {
        public string FromCurrency { get; }
        public string ToCurrency { get; }
        public decimal FromAmount { get; }
        public decimal ToAmount { get; }

        public HistoryItemToCreate(string fromCurrency, string toCurrency, decimal fromAmount, decimal toAmount)
        {
            if (fromAmount < 0) throw new ArgumentException(nameof(FromAmount));
            if (toAmount < 0) throw new ArgumentException(nameof(ToAmount));
            if (fromCurrency.Length != 3) throw new ArgumentException(FromCurrency);
            if (toCurrency.Length != 3) throw new ArgumentException(ToCurrency);
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            FromAmount = fromAmount;
            ToAmount = toAmount;
        }
    }
}