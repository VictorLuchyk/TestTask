using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using TestTask.Hubs;
using TestTask.Models;

namespace TestTask.Services
{
     public class CurrencyQuoteService
    {
        private string _fromCurrency;
        private string _toCurrency;
        private Timer _timer;
        private readonly string _currencyQuoteApiUrl;
        private readonly string _apiKey;
        private readonly IHubContext  _currencyQuoteHub;

        public CurrencyQuoteService(string currencyQuoteApiUrl, string apiKey, IHubContext currencyQuoteHub)
        {
            _currencyQuoteApiUrl = currencyQuoteApiUrl;
            _apiKey = apiKey;
            _currencyQuoteHub = currencyQuoteHub;
        }


        public void StartTimer(OuoteModel ouoteModel)
        {
            _fromCurrency = ouoteModel.From;
            _toCurrency = ouoteModel.To;

            var interval = int.Parse(ConfigurationManager.AppSettings["QuoteIntervalInMinutes"]);
            _timer = new Timer(GetCurrencyQuote, null, 0, interval * 60 * 1000);
        }

        public void StopTimer()
        {
                _timer.Dispose();
                _timer = null;
        }

        public async Task<CurrencyQuote> GetCurrencyQuote(string fromCurrency, string toCurrency)
        {
            using (var client = new HttpClient())
            {
                var url = $"{_currencyQuoteApiUrl}?function=CURRENCY_EXCHANGE_RATE&apikey={_apiKey}&from_currency={fromCurrency}&to_currency={toCurrency}";

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to retrieve currency quote from API. Status code: {response.StatusCode}");
                }

                var responseContent = await response.Content.ReadAsStringAsync();
                var currencyQuote = JsonConvert.DeserializeObject<CurrencyQuote>(responseContent);

                if (currencyQuote == null || currencyQuote.RealtimeCurrencyExchangeRate == null)
                {
                    throw new Exception("Failed to deserialize currency quote response from API.");
                }

                return currencyQuote;
            }
        }
        public void GetCurrencyQuote(object state)
        {
            var currencyQuote = GetCurrencyQuote(_fromCurrency, _toCurrency).Result;
            var currencyQouteDto = CurrencyQuoteDto.FromQuote(currencyQuote);
            _currencyQuoteHub.Clients.All.UpdateCurrencyQuote(currencyQouteDto);
        }
    }

}
