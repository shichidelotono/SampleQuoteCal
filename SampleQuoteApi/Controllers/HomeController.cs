using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SampleQuoteApi.AppSettings;
using SampleQuoteApi.Domain;
using SampleQuoteApi.Models;
using SampleQuoteApi.Services;
using System;
using System.Diagnostics;

namespace SampleQuoteApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuoteService _quoteService;
        private readonly IOptions<QuoteSetting> _quoteSetting;

        public HomeController(IQuoteService quoteService, IOptions<QuoteSetting> quoteSetting)
        {
            _quoteService = quoteService;
            _quoteSetting = quoteSetting;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quote(QuoteFormModel model)
        {
            model.MinTerm = _quoteSetting.Value.MinTerm;
            model.MaxTerm = _quoteSetting.Value.MaxTerm;
            model.MinAmountRequired = _quoteSetting.Value.MinAmountRequired;
            model.MaxAmountRequired = _quoteSetting.Value.MaxAmountRequired;

            return View(model);
        }

        public IActionResult CalculateQuote(QuoteFormModel quoteFormModel)
        {
            var quoteDomain = new Quote(quoteFormModel, _quoteSetting);

            if (!quoteDomain.IsValid)
                return Error();

            var calculateQuoteViewModel = new CalculateQuoteViewModel(quoteDomain);

            try
            {
                _quoteService.AddQuote(quoteDomain);
            }
            catch (Exception ex)
            {
                return Error();
            }

            return View(calculateQuoteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
