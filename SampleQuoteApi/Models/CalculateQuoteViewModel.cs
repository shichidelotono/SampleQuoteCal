using SampleQuoteApi.Repository;
using System;

namespace SampleQuoteApi.Models
{
    public class CalculateQuoteViewModel
    {
        public string Name { get; }
        public string Mobile { get; }
        public string Email { get; }
        public decimal FinancialAmount { get; }
        public decimal Repayments { get; }

        public CalculateQuoteViewModel(string name, string mobile, string email, decimal financialAmount, decimal repayments)
        {
            Name = name;
            Mobile = mobile;
            Email = email;
            FinancialAmount = financialAmount;
            Repayments = repayments;
        }
    }
}
