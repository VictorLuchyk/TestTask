using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class CurrencyQuote
    {


        [JsonProperty("Realtime Currency Exchange Rate", NullValueHandling = NullValueHandling.Ignore)]
        public RealtimeCurrencyExchangeRate RealtimeCurrencyExchangeRate { get; set; }
    }

}