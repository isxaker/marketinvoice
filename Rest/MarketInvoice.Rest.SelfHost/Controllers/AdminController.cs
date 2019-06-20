using System.Web.Http;
using MarketInvoice.Rest.SelfHost.Processors;

namespace MarketInvoice.Rest.SelfHost.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/repaymentSchedule/{amount:decimal}/{apr:double}")]
        public IHttpActionResult Get(decimal amount, double apr)
        {
            var result = RepaymentScheduleProcessor.Get(amount, apr);
            return Ok(result);
        }
    }
}