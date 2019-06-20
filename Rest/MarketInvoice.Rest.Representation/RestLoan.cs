namespace MarketInvoice.Rest.Representation
{
    public sealed class RestLoan
    {
        public decimal WeeklyRepayment { get; set;}
        public decimal TotalRepaid { get; set;}
        public decimal TotalInterest { get; set;}
    }
}