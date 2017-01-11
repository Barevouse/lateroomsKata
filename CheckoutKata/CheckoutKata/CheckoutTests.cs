using System.Collections.Generic;
using NUnit.Framework;

namespace CheckoutKata
{
    public class CheckoutTests
    {
        private ICheckout _checkout;

        [SetUp]
        public void setup()
        {
            var rules = new List<Checkout.PriceRule>();
            rules.Add(new Checkout.PriceRule
            {
               Code = "A",
               Cost = 50,
               Discount = 15,
               DiscountAmount = 3
            });
            rules.Add(new Checkout.PriceRule
            {
               Code = "B",
               Cost = 30,
               Discount = 15,
               DiscountAmount = 2
            });
            rules.Add(new Checkout.PriceRule
            {
               Code = "C",
               Cost = 20
            });
            rules.Add(new Checkout.PriceRule
            {
               Code = "D",
               Cost = 15
            });

            _checkout = new Checkout(rules);       
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
        [TestCase("A", "B", 80)]
        [TestCase("C", "D", 35)]
        public void ScanMultipleItemsReturnsCombinedValue(string val1, string val2, int expected)
        {
            _checkout.ScanItem(val1);
            _checkout.ScanItem(val2);

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }

        [TestCase("A", 3, 135)]
        [TestCase("B", 2, 45)]
        [TestCase("A", 6, 270)]
        [TestCase("B", 4, 90)]
        public void ShouldApplyDiscountsIfMultipleValuesPassedThrough(string value, int times, int expected)
        {
            for (var i = 0; i < times; i++)
            {
                _checkout.ScanItem(value);
            }

            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }

        [TestCase("A", 3, "B", 1, 165)]
        [TestCase("B", 2, "C", 1, 65)]
        public void ShouldApplyDiscountsIfMultipleValuesPassedThroughWithMultipleCodes(string value, int times, string value2, int value2times, int expected)
        {
            for (var i = 0; i < times; i++)
            {
                _checkout.ScanItem(value);
            }

            for (var i = 0; i < value2times; i++)
            {
                _checkout.ScanItem(value2);
            }



            Assert.That(_checkout.GetTotalPrice(), Is.EqualTo(expected));
        }
    }
}
