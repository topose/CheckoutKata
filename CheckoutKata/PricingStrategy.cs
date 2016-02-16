namespace CheckoutKata
{
    /// <summary>
    /// Interface definition for pricing strategies.
    /// It is open for strategies that are not only dependant
    /// on the examples in the kata based mainly in the number 
    /// of items. 
    /// </summary>
    public interface PricingStrategy
    {
        void AddItem(char item);

        int Total { get; }
    }
}