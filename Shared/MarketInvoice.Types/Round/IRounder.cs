namespace MarketInvoice.Types.Round
{
    public interface IRounder
    {
        decimal Round(decimal val);
    }
}