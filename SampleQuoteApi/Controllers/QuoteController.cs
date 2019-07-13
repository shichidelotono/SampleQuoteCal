using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleQuoteApi.Representation;
using SampleQuoteApi.RequestModels;
using SampleQuoteApi.Response;
using SampleQuoteApi.Services;

namespace SampleQuoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            this.quoteService = quoteService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateQuoteRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            quoteService.AddQuote(new Quote());

            return new OkObjectResult($@"https://{Request.Host.Value}");
        }
    }
}
