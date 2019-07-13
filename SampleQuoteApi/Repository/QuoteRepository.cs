using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SampleQuoteApi.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        public void SaveQuote(QuoteEntity quote)
        {
            //var dbName = "QuoteDatabase.db";

            //if (File.Exists(dbName))
            //    File.Delete(dbName);

            //using(var dbContext = new QuoteDbContext())
            //{
            //    dbContext.Database.EnsureCreated();
            //    if (!dbContext.Quotes.Any())
            //    {
            //        dbContext.Quotes.AddRange(new List<QuoteDbModel>  
            //            {
            //                 new QuoteDbModel { 
            //                     AmountRequired = quote.AmountRequired,
            //                     Term
            //                     Title ="Blog 1", SubTitle="Blog 1 subtitle" }
            //            });
            //        dbContext.SaveChanges();
            //    }


            //    foreach (var blog in dbContext.Blogs)
            //    {
            //        Console.WriteLine($"BlogID={blog.BlogId}\tTitle={blog.Title}\t{blog.SubTitle}\tDateTimeAdd={blog.DateTimeAdd}");
            //    }
            //}
        }
    }
}
