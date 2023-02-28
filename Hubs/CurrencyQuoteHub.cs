using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Hubs
{
    public class CurrencyQuoteHub : Hub
    {
        //private readonly CurrencyQuoteService _currencyQuoteService;

        //public CurrencyQuoteHub(CurrencyQuoteService currencyQuoteService)
        //{
        //    _currencyQuoteService = currencyQuoteService;
        //}

        //public async Task UpdateCurrencyQuote(CurrencyQuoteDto currencyQuoteDto)
        //{
        //    // Send the updated currency quote to the clients connected to the hub
        //    await Clients.All.SendAsync("ReceiveCurrencyQuote", currencyQuoteDto);
        //}
        public CurrencyQuoteHub()
        {
        }
    }
}