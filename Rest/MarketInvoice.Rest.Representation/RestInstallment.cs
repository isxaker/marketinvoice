namespace MarketInvoice.Rest.Representation
{
    public sealed class RestInstallment
    {
        public int InstallmentNumber { get; set; }
        public decimal AmountDue{ get; set; }
        public decimal Principal{ get; set; }
        public decimal Interest{ get; set; }
    }
}