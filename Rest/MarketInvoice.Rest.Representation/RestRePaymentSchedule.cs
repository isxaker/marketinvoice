namespace MarketInvoice.Rest.Representation
{
    public sealed class RestRePaymentSchedule
    {
        public RestInstallment[] Installments { get; }

        public RestRePaymentSchedule(RestInstallment[] installments)
        {
            Installments = installments;
        }
    }
}