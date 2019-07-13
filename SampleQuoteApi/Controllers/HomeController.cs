using Microsoft.AspNetCore.Mvc;
using SampleQuoteApi.Domain;
using SampleQuoteApi.Models;
using SampleQuoteApi.Services;
using System;
using System.Diagnostics;

namespace SampleQuoteApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuoteService _quoteService;

        public HomeController(QuoteService quoteService)
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
            // todo
            quoteFormModel.AmountRequired = 5000;
            quoteFormModel.Term = 24;
            // todo: validate
            var calculateQuoteViewModel = new CalculateQuoteViewModel
            {
                Name = $@"{quoteFormModel.FirstName} {quoteFormModel.LastName}",
                Mobile = quoteFormModel.Mobile,
                Email = quoteFormModel.Email,
                FinancialAmount = quoteFormModel.AmountRequired,
                Repayments = Pmt(0.0899, quoteFormModel.Term, (double)quoteFormModel.AmountRequired)
            };

            // todo: save to sqlite
            _quoteService.AddQuote(new Quote());

            return View(calculateQuoteViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private decimal Pmt(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        {
            if (yearlyInterestRate > 0)
            {
                var rate = (double)yearlyInterestRate / 100 / 12;
                var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
                return new decimal((rate + (rate / denominator)) * loanAmount);
            }
            return totalNumberOfMonths > 0 ? new decimal(loanAmount / totalNumberOfMonths) : 0;
        }
    }
}
