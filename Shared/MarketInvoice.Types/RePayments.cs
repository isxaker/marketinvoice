using System;
using System.Collections;
using System.Collections.Generic;
using MarketInvoice.Core.Annotations;
using MarketInvoice.Core.Verifiers;
using MarketInvoice.Interfaces;

namespace MarketInvoice.Types
{
    public class RePayments : IRepayments
    {
        private readonly ILoan _loan;
        private readonly IRePayment[] _rePayments;

        public RePayments([NotNull]ILoan loan)
        {
            Verifiers.ArgNullVerify(loan, nameof(loan));

            _loan = loan;
            _rePayments = new IRePayment[_loan.TotalPaymentsCount];
            
            Calculate();
        }

        public IRePayment this[int i] => _rePayments[i];
        public int Count => _rePayments.Length;

        private void Calculate()
        {
            var amountDue = _loan.NetAmount;
            var installment = _loan.Installment;

            for (var i = 0; i < _loan.TotalPaymentsCount; i++)
            {
                var currentInterest = amountDue * Convert.ToDecimal(_loan.InterestRate);
                var currentPrincipal = installment - currentInterest;

                _rePayments[i] = new RePayment(i + 1, amountDue, currentPrincipal, currentInterest);

                amountDue -= currentPrincipal;
            }
        }

        public IEnumerator<IRePayment> GetEnumerator()
        {
            IEnumerable<IRePayment> enumerable = _rePayments;
            return enumerable.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}