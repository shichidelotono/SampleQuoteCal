namespace SampleQuoteApi.Repository
{
    public interface IQuoteRepository
    {
        void SaveQuote(CalculateQuoteDbModel quote);
    }
}
