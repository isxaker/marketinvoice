using System.Collections.Generic;

namespace MarketInvoice.Interfaces
{
    public interface IRepayments : IEnumerable<IRePayment>
    {
        int Count { get; }
        IRePayment this[int i] { get; }
    }
}
