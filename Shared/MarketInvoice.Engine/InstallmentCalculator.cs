using System;

namespace MarketInvoice.Engine
{
    public static class InstallmentCalculator
    {
        //  I = P * ( r + r/((1+r)^n -1) )
        public static decimal Calc(decimal principal, int paymentNumbers, double interestRate)
        {
            var installment =
                principal * Convert.ToDecimal(interestRate +
                                              interestRate / (Math.Pow(1d + interestRate, paymentNumbers) - 1d));
            return installment;
        }
    }
}
