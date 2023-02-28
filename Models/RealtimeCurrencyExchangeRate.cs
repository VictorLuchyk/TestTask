using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class RealtimeCurrencyExchangeRate
    {
        [JsonProperty("1. From_Currency Code", NullValueHandling = NullValueHandling.Ignore)]
        public string FromCurrencyCode { get; set; }

        [JsonProperty("2. From_Currency Name", NullValueHandling = NullValueHandling.Ignore)]
        public string FromCurrencyName { get; set; }

        [JsonProperty("3. To_Currency Code", NullValueHandling = NullValueHandling.Ignore)]
        public string ToCurrencyCode { get; set; }

        [JsonProperty("4. To_Currency Name", NullValueHandling = NullValueHandling.Ignore)]
        public string ToCurrencyName { get; set; }

        [JsonProperty("5. Exchange Rate", NullValueHandling = NullValueHandling.Ignore)]
        public string ExchangeRate { get; set; }

        [JsonProperty("6. Last Refreshed", NullValueHandling = NullValueHandling.Ignore)]
        public string LastRefreshed { get; set; }

        [JsonProperty("7. Time Zone", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeZone { get; set; }

        [JsonProperty("8. Bid Price", NullValueHandling = NullValueHandling.Ignore)]
        public string BidPrice { get; set; }

        [JsonProperty("9. Ask Price", NullValueHandling = NullValueHandling.Ignore)]
        public string AskPrice { get; set; }

    }
}