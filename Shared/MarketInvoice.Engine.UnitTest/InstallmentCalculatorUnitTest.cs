using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketInvoice.Engine.UnitTest
{
    [TestClass]
    public class InstallmentCalculatorUnitTest
    {
        [TestMethod]
        public void CalculateInstallment1()
        {
            var principal = 50000m;
            var paymentNumbers = 52;
            var interestRate = 0.19d/52d;
            var i = InstallmentCalculator.Calc(principal, paymentNumbers, interestRate);

            var totalAmountRepaid = i * paymentNumbers;
            var totalInterest = totalAmountRepaid - principal;
        }

        [TestMethod]
        public void CalculateInstallment2()
        {
            var principal = 1000m;
            var paymentNumbers = 12;
            var interestRate = 0.2d/12d;
            var i = InstallmentCalculator.Calc(principal, paymentNumbers, interestRate);

            var totalAmountRepaid = i * paymentNumbers;
            var totalInterest = totalAmountRepaid - principal;
        }
    }
}