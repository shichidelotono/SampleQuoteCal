using SampleQuoteApi.Domain;
using System.Threading.Tasks;

namespace SampleQuoteApi.Services
{
    public interface IQuoteService
    {
        Task AddQuote(Quote quoteDomain);
    }
}
