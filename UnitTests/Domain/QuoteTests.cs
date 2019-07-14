using SampleQuoteApi.Domain;
using SampleQuoteApi.Models;
using Xunit;

namespace UnitTests.Domain
{
    public class QuoteTests
    {
        [Fact]
        public void given_quoteformmodel_should_map_to_quote_domain_object_correctly()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 5000,
                Term = 10,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.Equal(givenQuoteFormModel.AmountRequired, result.AmountRequired);
            Assert.Equal(givenQuoteFormModel.Term, result.Term);
            Assert.Equal(givenQuoteFormModel.Title, result.Title);
            Assert.Equal(givenQuoteFormModel.FirstName, result.FirstName);
            Assert.Equal(givenQuoteFormModel.LastName, result.LastName);
            Assert.Equal(givenQuoteFormModel.Mobile, result.Mobile);
            Assert.Equal(givenQuoteFormModel.Email, result.Email);
        }

        [Fact]
        public void given_quote_domain_object_should_map_to_calculatequotedbmodel_correctly()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 5000,
                Term = 10,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };
            var quoteDomain = new QuoteForTest(givenQuoteFormModel);

            // act
            var result = quoteDomain.ToDbEntity();

            // assert
            Assert.Equal(quoteDomain.AmountRequired, result.FinancialAmount);
            Assert.Equal("ShiChang Hou", result.Name);
            Assert.Equal(givenQuoteFormModel.Title, result.Title);
            Assert.Equal(givenQuoteFormModel.Mobile, result.Mobile);
            Assert.Equal(givenQuoteFormModel.Email, result.Email);
            Assert.Equal(200, result.Repayments);
        }

        [Fact]
        public void given_less_than_min_financial_amount_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 1900,
                Term = 10,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_more_than_max_financial_amount_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 10,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_less_than_min_term_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 1,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_more_than_max_term_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_long_title_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mrrrr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_no_firstname_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mr",
                FirstName = "",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_no_lastname_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "",
                Mobile = "0434386289",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_no_mobile_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "  ",
                Email = "shichang@outlook.com"
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public void given_no_email_should_get_invalid_quote_domain_object()
        {
            // setup
            var givenQuoteFormModel = new QuoteFormModel
            {
                AmountRequired = 15001,
                Term = 37,
                Title = "Mr",
                FirstName = "ShiChang",
                LastName = "Hou",
                Mobile = "0434386289",
                Email = null
            };

            // act
            var result = new Quote(givenQuoteFormModel);

            // assert
            Assert.False(result.IsValid);
        }
    }

    public class QuoteForTest : Quote
    {
        public QuoteForTest(QuoteFormModel quoteFormModel): base(quoteFormModel)
        {
        }

        public  override decimal Pmt(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        {
            return 200;
        }
    }
}
