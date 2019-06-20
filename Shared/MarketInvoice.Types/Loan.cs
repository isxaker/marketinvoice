using MarketInvoice.Core.Annotations;
using MarketInvoice.Core.Verifiers;
using MarketInvoice.Engine;
using MarketInvoice.Interfaces;
using MarketInvoice.Types.Round;

namespace MarketInvoice.Types
{
    public class Loan : ILoan
    {
        private decimal? _totalAmount;
        private decimal? _installment;
        private decimal? _totalInterest;

        //private readonly LoanPeriodType _periodType;
        private readonly IRounder _rounder;
        private readonly decimal _netAmount;

        public Loan(decimal netAmount, int totalPaymentsCount,/* LoanPeriodType periodType,*/ double annualInterestRate, [CanBeNull] IRounder rounder = null)
        {
            Verifiers.ArgVerify(netAmount > 0, "The amount of the loan can't be less or equal to 0", nameof(netAmount));
            Verifiers.ArgVerify(totalPaymentsCount > 0, "The number of payments over the life of the loan can't be less or equal to 0", nameof(netAmount));
            Verifiers.ArgVerify(annualInterestRate > 0, "(The Annual Percentage Rate can't be less or equal to 0", nameof(netAmount));

            _netAmount = netAmount;
            TotalPaymentsCount = totalPaymentsCount;
            //_periodType = periodType;
            InterestRate = annualInterestRate / 100 / TotalPaymentsCount;

            _rounder = rounder ?? new DefaultRounder();
        }

        public decimal NetAmount => _rounder.Round(_netAmount);
        public int TotalPaymentsCount { get; }
        public double InterestRate { get; }

        public decimal Installment
        {
            get
            {
                if (!_installment.HasValue)
                {
                    _installment = InstallmentCalculator.Calc(NetAmount, TotalPaymentsCount, InterestRate);
                }

                return _rounder.Round(_installment.Value);
            }
        }

        public decimal TotalAmount
        {
            get
            {
                if (!_totalAmount.HasValue)
                {
                    _totalAmount = Installment * TotalPaymentsCount;
                }

                return _rounder.Round(_totalAmount.Value);
            }
        }

        public decimal TotalInterest
        {
            get
            {
                if (!_totalInterest.HasValue)
                {
                    _totalInterest = TotalAmount - NetAmount;
                }

                return _rounder.Round(_totalInterest.Value);
            }
        }
    }
}