using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleApi1.Representation;
using SampleApi1.Requests;
using SampleApi1.Response;

namespace SampleApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        [HttpGet]
        public async Task<UrlResponse> Get(decimal amountRequired, int term, string title,
            string firstName, string lastName, string mobile, string email)
        {
            var baseUrl = $@"https://{Request.Host.Value}";

            return new UrlResponse(baseUrl);
        }
    }
}