using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using TestTask.Hubs;
using TestTask.Services;

namespace TestTask
{
    public class CurrencyQuoteServiceFactory
    {
        private static readonly Lazy<CurrencyQuoteService> _lazy = new Lazy<CurrencyQuoteService>(() =>
        new CurrencyQuoteService(
            ConfigurationManager.AppSettings["CurrencyQuoteApiUrl"],
            ConfigurationManager.AppSettings["CurrencyQuoteApiKey"],
            GlobalHost.ConnectionManager.GetHubContext<CurrencyQuoteHub>()
        )
    );

        public static CurrencyQuoteService Instance => _lazy.Value;
    }
}