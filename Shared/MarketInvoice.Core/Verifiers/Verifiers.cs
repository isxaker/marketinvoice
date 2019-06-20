using System;

namespace MarketInvoice.Core.Verifiers
{
    public static class Verifiers
    {
        public static void ArgVerify(bool b, string message, string paramName)
        {
            if (!b)
                throw new ArgumentException(message, paramName);
        }

        public static void ArgNullVerify(object obj, string paramName)
        {
            if (obj == null)
                throw new ArgumentNullException(paramName);
        }
    }
}
