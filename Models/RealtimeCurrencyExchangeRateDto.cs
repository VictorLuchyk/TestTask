using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class RealtimeCurrencyExchangeRateDto
    {

        public string FromCurrencyCode { get; set; }

        public string FromCurrencyName { get; set; }

        public string ToCurrencyCode { get; set; }

        public string ToCurrencyName { get; set; }

        public string ExchangeRate { get; set; }

        public string LastRefreshed { get; set; }

        public string TimeZone { get; set; }

        public string BidPrice { get; set; }

        public string AskPrice { get; set; }

    }
}