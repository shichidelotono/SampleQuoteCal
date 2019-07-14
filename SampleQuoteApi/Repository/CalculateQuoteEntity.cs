using System;

namespace SampleQuoteApi.Repository
{
    public class CalculateQuoteEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal FinancialAmount { get; set; }
        public decimal Repayments { get; set; }
        public DateTime DateTimeAdded { get; set; }
    }
}
