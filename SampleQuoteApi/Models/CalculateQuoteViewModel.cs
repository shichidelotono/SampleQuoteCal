using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleQuoteApi.Models
{
    public class CalculateQuoteViewModel
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal FinancialAmount { get; set; }
        public decimal Repayments { get; set; }
    }
}
