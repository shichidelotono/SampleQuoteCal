using System;
using System.Threading.Tasks;

namespace SampleQuoteApi.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        public void SaveQuote(CalculateQuoteDbModel quote)
        {
            var task = new Task(() => {
                using (var dbContext = new QuoteDbContext())
                {
                    dbContext.Database.EnsureDeleted();
                    dbContext.Database.EnsureCreated();
                    dbContext.CalculateQuotes.Add(quote);
                    dbContext.SaveChanges();
                }
            });

            task.Start();

            try
            {
                Task.WaitAll(task);
            }
            catch (AggregateException ex)
            {
                throw ex;
            }
        }

        public CalculateQuoteDbModel GetQuoteBy(int key)
        {
            CalculateQuoteDbModel dbResult;
            using (var dbContext = new QuoteDbContext())
            {
                dbResult = dbContext.CalculateQuotes.Find(key);
            }
            return dbResult;
        }
    }
}
