using System.Threading.Tasks;

namespace SampleQuoteApi.Repository
{
    public interface IQuoteRepository
    {
        Task SaveQuote(CalculateQuoteDbModel quote);
        CalculateQuoteDbModel GetQuoteBy(int key);
    }
}
