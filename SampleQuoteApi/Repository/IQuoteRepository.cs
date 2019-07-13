namespace SampleQuoteApi.Repository
{
    public interface IQuoteRepository
    {
        void SaveQuote(QuoteEntity quote);
    }
}
