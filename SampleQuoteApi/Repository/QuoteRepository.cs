using System.Threading.Tasks;

namespace SampleQuoteApi.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        public void SaveQuote(CalculateQuoteDbModel quote)
        {
            Task.Factory.StartNew(() => {
                using (var dbContext = new QuoteDbContext())
                {
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    dbContext.CalculateQuotes.Add(quote);
                    dbContext.SaveChanges();
                }
            });
        }
    }
}
