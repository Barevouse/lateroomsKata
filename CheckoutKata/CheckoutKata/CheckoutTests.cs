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
        public void ScanASingleItemAReturnsTheItemValue(string SKU, int expected)
        {
            _checkout.ScanItem(SKU);

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }
    }
}
