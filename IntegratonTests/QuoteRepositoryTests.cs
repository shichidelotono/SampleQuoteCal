using SampleQuoteApi.Repository;
using System;
using Xunit;

namespace IntegratonTests
{
    public class QuoteRepositoryTests
    {
        [Fact]
        public void SaveQuoteIntegration()
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
    }
}
