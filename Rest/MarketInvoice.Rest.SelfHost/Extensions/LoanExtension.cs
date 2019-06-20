using MarketInvoice.Interfaces;
using MarketInvoice.Rest.Representation;

namespace MarketInvoice.Rest.SelfHost.Extensions
{
    internal static class LoanExtension
    {
        public static RestLoan ToRepresentation(this ILoan model)
        {
            return new RestLoan()
            {
                WeeklyRepayment = model.Installment,
                TotalRepaid = model.TotalAmount,
                TotalInterest = model.TotalInterest,
            };
        }
    }
}