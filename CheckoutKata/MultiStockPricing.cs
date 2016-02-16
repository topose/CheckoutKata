namespace CheckoutKata
{
    // It does contain duplicate code with from IndividualStockPricing
    // Future iteration should remove such redundancy: i.e. composition, creating base class
    // or whatever
    public class MultiStockPricing: PricingStrategy
    {
        private char stockKeepingUnitId;

        private int singleItemPrice;

        private int multipleItemsPrice;

        private int numberOfItemsForPrice;

        private int numberOfItems;

        public MultiStockPricing(char stockKeepingUnitId, int singleItemPrice, int numberOfItems, int multipleItemsPrice)
        {
            this.stockKeepingUnitId = stockKeepingUnitId;
            this.singleItemPrice = singleItemPrice;
            this.numberOfItemsForPrice = numberOfItems;
            this.multipleItemsPrice = multipleItemsPrice;
        }

        public int Total => 
                ((numberOfItems / numberOfItemsForPrice) * multipleItemsPrice) +
                ((numberOfItems % numberOfItemsForPrice) * singleItemPrice);
            
        public void AddItem(char item)
        {
            if (item == this.stockKeepingUnitId)
                this.numberOfItems++;
        }
    }
}