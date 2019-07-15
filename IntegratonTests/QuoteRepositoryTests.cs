using Microsoft.Extensions.Options;
using Moq;
using SampleQuoteApi.AppSettings;
using SampleQuoteApi.Controllers;
using SampleQuoteApi.Models;
using SampleQuoteApi.Repository;
using SampleQuoteApi.Services;
using System;
using Xunit;

namespace IntegratonTests
{
    public class QuoteRepositoryTests
    {
        private QuoteRepository _repository;
        private HomeController _homeController;
        private Mock<IOptions<QuoteSetting>> _mockQuoteSetting;

        public QuoteRepositoryTests()
        {
            _repository = new QuoteRepository();
            var service = new QuoteService(_repository);
            _mockQuoteSetting = new Mock<IOptions<QuoteSetting>>();
            var _quoteSetting = new QuoteSetting
            {
                MinAmountRequired = 2100,
                MaxAmountRequired = 15000,
                MinTerm = 3,
                MaxTerm = 36
            };
            _mockQuoteSetting.Setup(q => q.Value).Returns(_quoteSetting);

            _homeController = new HomeController(service, _mockQuoteSetting.Object);
        }

        [Fact]
        public void given_quote_db_entity_quote_repository_should_save_to_database()
        {
            // setup
            var repository = new QuoteRepository();
            var quote = new CalculateQuoteDbModel {
                Title = "Mr",
                Name = "BumbleBee",
                Mobile = "0838386288",
                Email = "bumblebee@outlook.com",
                FinancialAmount = 5500,
                Repayments = 300,
                DateTimeAdded = DateTime.Now
            };

            // act
            repository.SaveQuote(quote);

            // assert
            var result = repository.GetQuoteBy(1);
            Assert.Equal(quote.Title, result.Title);
            Assert.Equal(quote.Mobile, result.Mobile);
            Assert.Equal(quote.Name, result.Name);
            Assert.Equal(quote.Repayments, result.Repayments);
        }

        [Fact]
        public void given_quote_calling_calculate_quote_should_save_quote_to_database()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel {
                AmountRequired = 8000,
                Term = 30,
                Title = "Mr",
                FirstName = "bumble",
                LastName = "bee",
                Mobile = "0838386289",
                Email = "bumblebee@outlook.com"
            };

            // act
            _homeController.CalculateQuote(givenQuoteFormModel);

            // assert
            var result = _repository.GetQuoteBy(1);
            Assert.Equal(givenQuoteFormModel.AmountRequired, result.FinancialAmount);
            Assert.Equal(givenQuoteFormModel.Title, result.Title);
            Assert.Equal(givenQuoteFormModel.Mobile, result.Mobile);
            Assert.Equal($@"{givenQuoteFormModel.FirstName} {givenQuoteFormModel.LastName}", result.Name);
        }
    }
}

