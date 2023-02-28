using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class CurrencyQuoteDto
    {
        public string ExchangeRate { get; set; }
        public string LastRefreshed { get; set; }

        public static CurrencyQuoteDto FromQuote(CurrencyQuote currencyQuote)
        {
            if (currencyQuote?.RealtimeCurrencyExchangeRate == null)
            {
                return null;
            }

            return new CurrencyQuoteDto
            {
                ExchangeRate = currencyQuote.RealtimeCurrencyExchangeRate.ExchangeRate,
                LastRefreshed = currencyQuote.RealtimeCurrencyExchangeRate.LastRefreshed,
            };
        }
    }
}