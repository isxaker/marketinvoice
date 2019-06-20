using MarketInvoice.Interfaces;
using MarketInvoice.Rest.Representation;

namespace MarketInvoice.Rest.SelfHost.Extensions
{
    public static class RePaymentExtension
    {
        public static RestInstallment ToRepresentation(this IRePayment model)
        {
            return new RestInstallment()
            {
                InstallmentNumber = model.Number,
                AmountDue = model.AmountDue,
                Principal = model.Principal,
                Interest = model.Interest,
            };
        }
    }
}