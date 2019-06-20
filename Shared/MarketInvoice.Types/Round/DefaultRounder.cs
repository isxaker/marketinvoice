using System;

namespace MarketInvoice.Types.Round
{
    internal class DefaultRounder : IRounder
    {
        private const int Decimals = 2;
        private const MidpointRounding AwayFromZero = MidpointRounding.AwayFromZero;

        public decimal Round(decimal val)
        {
            return decimal.Round(val, Decimals, AwayFromZero);
        }
    }
}