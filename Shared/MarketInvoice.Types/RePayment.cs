using MarketInvoice.Core.Annotations;
using MarketInvoice.Interfaces;
using MarketInvoice.Types.Round;

namespace MarketInvoice.Types
{
    public class RePayment : IRePayment
    {
        private readonly IRounder _rounder;
        private readonly decimal _amountDue;
        private readonly decimal _principal;
        private readonly decimal _interest;

        public RePayment(int number, decimal amountDue, decimal principal, decimal interest, [CanBeNull] IRounder rounder = null)
        {
            _rounder = rounder;
            Number = number;
            _amountDue = amountDue;
            _principal = principal;
            _interest = interest;

            _rounder = rounder ?? new DefaultRounder();
        }

        public int Number { get; }
        public decimal AmountDue => _rounder.Round(_amountDue);
        public decimal Principal => _rounder.Round(_principal);
        public decimal Interest => _rounder.Round(_interest);
    }
}