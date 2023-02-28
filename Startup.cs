using Microsoft.AspNet.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Owin;
using System;
using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using TestTask.Hubs;
using TestTask.Services;

[assembly: OwinStartup(typeof(TestTask.Startup))]

namespace TestTask
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            GlobalHost.DependencyResolver.Register(typeof(CurrencyQuoteService), () => CurrencyQuoteServiceFactory.Instance);
            GlobalHost.DependencyResolver.Register(typeof(CurrencyQuoteHub), () => new CurrencyQuoteHub());
           // GlobalHost.DependencyResolver.Register(typeof(CurrencyQuoteHub), () => new CurrencyQuoteHub(GlobalHost.DependencyResolver.Resolve<CurrencyQuoteService>()));

            app.MapSignalR();
        }
        
    }
}
