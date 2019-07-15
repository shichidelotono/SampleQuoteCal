using Microsoft.Extensions.Options;
using Moq;
using SampleQuoteApi.AppSettings;
using SampleQuoteApi.Domain;
using SampleQuoteApi.Models;
using SampleQuoteApi.Repository;
using SampleQuoteApi.Services;
using Xunit;

namespace UnitTests.Services
{
    public class QuoteServiceTests
    {
        private Mock<IQuoteRepository> _mockQuoteRespository;
        private QuoteService _quoteService; 

        public QuoteServiceTests()
        {
            _mockQuoteRespository = new Mock<IQuoteRepository>();
            _quoteService = new QuoteService(_mockQuoteRespository.Object);
        }

        [Fact]
        public void given_quote_domain_object_should_save_it_to_database()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 35,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };
            var givenQuoteDomainObject = new Quote(givenQuoteFormModel, new Mock<IOptions<QuoteSetting>>().Object);
            var givenDbEntity = givenQuoteDomainObject.ToDbEntity();
            _mockQuoteRespository.Setup(q => q.SaveQuote(It.IsAny<CalculateQuoteDbModel>())).Verifiable();

            // act
            _quoteService.AddQuote(givenQuoteDomainObject);

            // assert
            _mockQuoteRespository.Verify(q => q.SaveQuote(It.IsAny<CalculateQuoteDbModel>()), Times.Once);
        }
    }
}
