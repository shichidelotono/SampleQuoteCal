using Microsoft.AspNetCore.Mvc;
using SampleQuoteApi.Domain;
using SampleQuoteApi.Models;
using SampleQuoteApi.Services;
using System.Diagnostics;

namespace SampleQuoteApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuoteService _quoteService;

        public HomeController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quote(QuoteFormModel model)
        {
            return View(model);
        }

        public IActionResult CalculateQuote(QuoteFormModel quoteFormModel)
        {
            var quoteDomain = new Quote(quoteFormModel);

            if (!quoteDomain.IsValid)
                Error();

            var calculateQuoteViewModel = new CalculateQuoteViewModel(
                $@"{quoteDomain.FirstName} {quoteDomain.LastName}",
                quoteDomain.Mobile,
                quoteDomain.Email,
                quoteDomain.AmountRequired,
                quoteDomain.Repayments);

            _quoteService.AddQuote(quoteDomain);

            return View(calculateQuoteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
