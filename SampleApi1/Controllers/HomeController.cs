using Microsoft.AspNetCore.Mvc;
using SampleApi1.Models;
using System;
using System.Diagnostics;

namespace SampleApi1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quote()
        {
            var model = new QuoteFormModel
            {
                AmountRequired = 5000,
                Term = 2,
                Title = "Mr.",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "houshichang@hotmail.com"
            };

            return View(model);
        }

        public IActionResult CalculateQuote(QuoteFormModel quoteFormModel)
        {

            quoteFormModel.AmountRequired = 5000;
            quoteFormModel.Term = 24;

            var calculateQuoteViewModel = new CalculateQuoteViewModel
            {
                Name = $@"{quoteFormModel.FirstName} {quoteFormModel.LastName}",
                Mobile = quoteFormModel.Mobile,
                Email = quoteFormModel.Email,
                FinancialAmount = quoteFormModel.AmountRequired,
                Repayments = Pmt(0.0899, quoteFormModel.Term, (double)quoteFormModel.AmountRequired)
            };

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
