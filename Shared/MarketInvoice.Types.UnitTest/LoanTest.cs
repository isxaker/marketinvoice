using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketInvoice.Types.UnitTest
{
    [TestClass]
    public class LoanTest
    {
        [TestMethod]
        public void CheckCalculatedFieldsTest1()
        {
            var principal = 50000m;
            var paymentNumbers = 52;
            var interestRate = 19d;

            var loan = new Loan(principal, paymentNumbers, /*LoanPeriodType.Week,*/ interestRate);
            
            Assert.AreEqual(loan.Installment,1057.53m);
            Assert.AreEqual(loan.TotalInterest,4991.56m);
            Assert.AreEqual(loan.TotalAmount, 54991.56m);
        }

        [TestMethod]
        public void CheckCalculatedFieldsTest2()
        {
            var principal = 1000m;
            var paymentNumbers = 12;
            var interestRate = 20d;

            var loan = new Loan(principal, paymentNumbers, /*LoanPeriodType.Month,*/ interestRate);
            
            Assert.AreEqual(loan.Installment,92.63m);
            Assert.AreEqual(loan.TotalInterest,111.56m);
            Assert.AreEqual(loan.TotalAmount, 1111.56m);
        }
    }
}