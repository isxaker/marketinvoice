using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketInvoice.Types.UnitTest
{
    [TestClass]
    public class RePaymentsTest
    {

        [TestMethod]
        public void CheckCalculatedFieldsTest1()
        {
            var principal = 50000m;
            var paymentNumbers = 52;
            var interestRate = 19d;

            var loan = new Loan(principal, paymentNumbers, /*LoanPeriodType.Week,*/ interestRate);
            var rePayments = new RePayments(loan);

            Assert.AreEqual(rePayments.Count, 52);


            var rePayment0 = rePayments[0];

            Assert.AreEqual(rePayment0.Number, 1);
            Assert.AreEqual(rePayment0.AmountDue, 50000m);
            Assert.AreEqual(rePayment0.Principal, 874.84m);
            Assert.AreEqual(rePayment0.Interest, 182.69m);

            var rePayment10 = rePayments[9];

            Assert.AreEqual(rePayment10.Number, 10);
            Assert.AreEqual(rePayment10.AmountDue, 42010.40m);
            Assert.AreEqual(rePayment10.Principal, 904.03m);
            Assert.AreEqual(rePayment10.Interest, 153.50m);

            var rePayment52 = rePayments[51];

            Assert.AreEqual(rePayment52.Number, 52);
            Assert.AreEqual(rePayment52.AmountDue, 1053.44m);
            Assert.AreEqual(rePayment52.Principal, 1053.68m);
            Assert.AreEqual(rePayment52.Interest, 3.85m);
        }
    }
}