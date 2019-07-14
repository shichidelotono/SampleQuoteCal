using Microsoft.AspNetCore.Mvc;
using SampleQuoteApi.RequestModels;
using SampleQuoteApi.ResponseModels;

namespace SampleQuoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] CreateQuoteRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var query = $@"amountRequired={model.AmountRequired}&term={model.Term}&title={model.Title}&firstName={model.FirstName}&lastName={model.LastName}&mobile={model.Mobile}&email={model.Email}";
            var url = $@"https://{Request.Host.Value}/home/quote?{query}";

            return Ok(new QuoteUrlResponseModel { Url = url });
        }
    }
}
