using System.Web.Http;
using MarketInvoice.Rest.SelfHost.Processors;

namespace MarketInvoice.Rest.SelfHost.Controllers
{
    public class CustomerController : ApiController
    {
        [Route("api/loansummary/{amount:decimal}/{apr:double}")]
        [HttpGet]
        public IHttpActionResult Get(decimal amount, double apr)
        {
            var result = LoanSummaryProcessor.Get(amount, apr);
            return Ok(result);
        }

        [Route("api/test")]
        [HttpGet]
        public string Test()
        {
            return "hello world;";
        }
    }
}