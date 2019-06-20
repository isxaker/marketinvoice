namespace MarketInvoice.Interfaces
{
    public interface ILoan
    {
        decimal NetAmount { get; }
        int TotalPaymentsCount { get; }
        double InterestRate { get; }
        decimal Installment { get; }
        decimal TotalAmount { get; }
        decimal TotalInterest { get; }
    }
}