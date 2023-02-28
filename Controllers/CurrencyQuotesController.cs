using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestTask.Hubs;
using TestTask.Models;
using TestTask.Services;

namespace TestTask.Controllers
{
    public class CurrencyQuotesController : ApiController
    {

        private readonly CurrencyQuoteService _currencyQuoteService;

        public CurrencyQuotesController()
        {
            _currencyQuoteService = GlobalHost.DependencyResolver.Resolve<CurrencyQuoteService>();
        }

        [HttpPost]
        public IHttpActionResult Start(OuoteModel ouoteModel)
        {
            _currencyQuoteService.StartTimer(ouoteModel);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Stop()
        {
            try
            {
              _currencyQuoteService.StopTimer();
              return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Кнопка старт ще не була натиснута");
            }
            
        }

        [HttpPost]
        public async Task<CurrencyQuoteDto> GetQuotes(OuoteModel ouoteModel)
        {
            var currencyQuote = await _currencyQuoteService.GetCurrencyQuote(ouoteModel.From, ouoteModel.To);
            var currencyQuoteDto = CurrencyQuoteDto.FromQuote(currencyQuote);
            return currencyQuoteDto;
        }


    }
}
