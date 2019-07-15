using SampleQuoteApi.Domain;

namespace SampleQuoteApi.Models
{
    public class CalculateQuoteViewModel
    {
        public string Name { get; }
        public string Mobile { get; }
        public string Email { get; }
        public decimal FinancialAmount { get; }
        public decimal Repayments { get; }
        public int Term { get; }
        public decimal EstablishmentFee { get; }
        public decimal TotalRepayments { get; }
        public decimal Interest { get; }

        public CalculateQuoteViewModel(Quote quote)
        {
            Name = $@"{quote.FirstName} {quote.LastName}";
            Mobile = quote.Mobile;
            Email = quote.Email;
            FinancialAmount = quote.AmountRequired;
            Repayments = quote.Repayments;
            Term = quote.Term;
            EstablishmentFee = quote.EstablishmentFee();
            TotalRepayments = quote.TotalRepayments;
            Interest = quote.Interest;
        }
    }
}
