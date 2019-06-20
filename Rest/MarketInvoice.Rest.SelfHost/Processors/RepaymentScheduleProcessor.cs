using MarketInvoice.Rest.Representation;
using MarketInvoice.Rest.SelfHost.Extensions;
using MarketInvoice.Types;

namespace MarketInvoice.Rest.SelfHost.Processors
{
    internal static class RepaymentScheduleProcessor
    {
        public static RestRePaymentSchedule Get(decimal amount, double apr)
        {
            var loan = new Loan(amount, 52, apr);
            var rePayments = new RePayments(loan);

            var restInstallments = new RestInstallment[rePayments.Count];
            for (var i = 0; i < rePayments.Count; i++)
            {
                var rePayment = rePayments[i];
                var restInstallment = rePayment.ToRepresentation();
                restInstallments[i] = restInstallment;
            }

            return new RestRePaymentSchedule(restInstallments);
        }
    }
}