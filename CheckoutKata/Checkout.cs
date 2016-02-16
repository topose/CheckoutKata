using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout
    {
        private IEnumerable<PricingStrategy> princings;

        public Checkout(IEnumerable<PricingStrategy> prices)
        {
            this.princings = prices;
        }

        public int Total => this.princings.Sum(_ => _.Total);

        public void Scan(char c)
        {
            foreach (var princing in this.princings)
                princing.AddItem(c);
        }
    }
}
