using MarketInvoice.Rest.Representation;
using MarketInvoice.Rest.SelfHost.Extensions;
using MarketInvoice.Types;

namespace MarketInvoice.Rest.SelfHost.Processors
{
    internal static class LoanSummaryProcessor
    {
        public static RestLoan Get(decimal amount, double apr)
        {
            var loan = new Loan(amount, 52, apr);
            return loan.ToRepresentation();
        }
    }
}