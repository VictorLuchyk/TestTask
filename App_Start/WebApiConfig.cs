using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestTask.Hubs;
using TestTask.Services;

namespace TestTask
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services



            //var currencyQuoteService = new CurrencyQuoteService();
            //config.DependencyResolver.RegisterSingleton<IQuotesService>(quotesService);
            // config.Services.AddSingleton<CurrencyQuoteService>();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
