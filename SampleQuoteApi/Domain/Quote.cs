using Microsoft.Extensions.Options;
using SampleQuoteApi.AppSettings;
using SampleQuoteApi.Models;
using SampleQuoteApi.Repository;
using System;

namespace SampleQuoteApi.Domain
{
    public class Quote
    {
        private readonly int maxTitleLength = 2;
        private readonly double _interestRate = 0.0899;
        private decimal _repayments = -1;
        private bool? _isValid;
        private readonly IOptions<QuoteSetting> _quoteSetting;

        public decimal AmountRequired { get; }
        public int Term { get; }
        public string Title { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Mobile { get; }
        public string Email { get; }
        public decimal Repayments => _repayments >= 0 ? _repayments : Pmt(_interestRate, Term, (double)AmountRequired);
        public decimal TotalRepayments => Repayments * Term + _quoteSetting.Value.EstablishmentFee;
        public decimal Interest => Repayments * Term - AmountRequired;
        public bool IsValid => _isValid != null ? _isValid.Value : Validate();
        public decimal EstablishmentFee() => _quoteSetting.Value.EstablishmentFee;

        public Quote(QuoteFormModel quoteFormModel, IOptions<QuoteSetting> quoteSetting)
        {
            AmountRequired = quoteFormModel.AmountRequired;
            Term = quoteFormModel.Term;
            Title = quoteFormModel.Title;
            FirstName = quoteFormModel.FirstName;
            LastName = quoteFormModel.LastName;
            Mobile = quoteFormModel.Mobile;
            Email = quoteFormModel.Email;
            _quoteSetting = quoteSetting;
        }   

        public CalculateQuoteDbModel ToDbEntity()
        {
            return new CalculateQuoteDbModel
            {
                Name = $@"{FirstName} {LastName}",
                Title = Title,
                Mobile = Mobile,
                Email = Email,
                FinancialAmount = AmountRequired,
                Repayments = Repayments,
                DateTimeAdded = DateTime.Now
            };
        }

        public virtual decimal Pmt(double yearlyInterestRate, int totalNumberOfMonths, double loanAmount)
        {
            if (yearlyInterestRate > 0)
            {
                var rate = yearlyInterestRate / 100 / 12;
                var denominator = Math.Pow((1 + rate), totalNumberOfMonths) - 1;
                return new decimal((rate + (rate / denominator)) * loanAmount);
            }
            return totalNumberOfMonths > 0 ? new decimal(loanAmount / totalNumberOfMonths) : 0;
        }

        private bool Validate()
        {
            return (AmountRequired >= _quoteSetting.Value.MinAmountRequired && AmountRequired < _quoteSetting.Value.MaxAmountRequired)
                && (Term >= _quoteSetting.Value.MinTerm && Term < _quoteSetting.Value.MaxTerm)
                && Title.Length == maxTitleLength
                && !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName)
                && !string.IsNullOrWhiteSpace(Mobile)
                && !string.IsNullOrWhiteSpace(Email);
        }
    }
}
