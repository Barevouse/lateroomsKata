using NUnit.Framework;

namespace CheckoutKata
{
    public class CheckoutTests
    {
        private ICheckout _checkout;

        [SetUp]
        public void setup()
        {
            _checkout = new Checkout();       
        }

        [TestCase("A", 50)]
        [TestCase("B", 30)]
        [TestCase("C", 20)]
        [TestCase("D", 15)]
        public void ScanASingleItemAReturnsTheItemValue(string SKU, int expected)
        {
            _checkout.ScanItem(SKU);

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }

        [TestCase("A", "A", 100)]
        public void ScanMultipleItemsReturnsCombinedValue(string val1, string val2, int expected)
        {
            _checkout.ScanItem(val1);
            _checkout.ScanItem(val2);

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }
    }
}
