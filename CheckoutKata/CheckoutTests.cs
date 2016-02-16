using System.Collections.Generic;
using Xunit;

namespace CheckoutKata
{
    public class CheckoutTests
    {
        /*
            Item   Unit      Special
                Price     Price
          --------------------------
            A     50       3 for 130
            B     30       2 for 45
            C     20
            D     15
        */

        private Checkout co;

        public CheckoutTests()
        {
            // arrange for all tests
            var prices = new List<PricingStrategy>() {
                new MultiStockPricing('A', 50, 3, 130),
                new MultiStockPricing('B', 30, 2, 45),
                new IndividualStockPricing('C', 20),
                new IndividualStockPricing('D', 15)
            };

            this.co = new Checkout(prices);
        }

        [Fact]
        public void TestIncremental()
        {
            Assert.Equal(0, co.Total);
            co.Scan('A');
            Assert.Equal(50, co.Total);
            co.Scan('B');
            Assert.Equal(80, co.Total);
            co.Scan('A');
            Assert.Equal(130, co.Total);
            co.Scan('A');
            Assert.Equal(160, co.Total);
            co.Scan('B');
            Assert.Equal(175, co.Total);
        }

        [Theory]
        [InlineData(0, "")]
        [InlineData(50, "A")]
        [InlineData(80, "AB")]
        [InlineData(115, "CDBA")]
        [InlineData(100, "AA")]
        [InlineData(130, "AAA")]
        [InlineData(180, "AAAA")]
        [InlineData(230, "AAAAA")]
        [InlineData(260, "AAAAAA")]
        [InlineData(160, "AAAB")]
        [InlineData(175, "AAABB")]
        [InlineData(190, "AAABBD")]
        [InlineData(190, "DABABA")]
        public void TestTotals(int total, string items)
        {
            // 
            // act
            foreach (char c in items)
                this.co.Scan(c);

            // assert
            Assert.Equal(total, co.Total);
        }
    }


}
