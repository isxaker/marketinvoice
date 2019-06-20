namespace MarketInvoice.Interfaces
{
    public interface IRePayment
    {
        int Number { get; }
        decimal AmountDue { get; }
        decimal Principal { get; }
        decimal Interest { get; }
    }
}