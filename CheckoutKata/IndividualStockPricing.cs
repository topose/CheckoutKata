namespace CheckoutKata
{
    public class IndividualStockPricing : PricingStrategy
    {
        private char stockKeepingUnitId;

        private int price;

        private int numberOfItems;

        public IndividualStockPricing(char stockKeepingUnitId, int price)
        {
            this.stockKeepingUnitId = stockKeepingUnitId;
            this.price = price;
        }

        public int Total => numberOfItems * price;
            
        public void AddItem(char item)
        {
            if (item == this.stockKeepingUnitId)
                this.numberOfItems++;
        }
    }
}