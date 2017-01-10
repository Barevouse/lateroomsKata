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

        [Test]
        public void ScanItemAReturns50()
        {
            _checkout.ScanItem("A");

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(50));
        }
    }
}
