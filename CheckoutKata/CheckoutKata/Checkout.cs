using System.Collections.Generic;
using System.Linq;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public class PriceRule
        {
            public string Code { get; set; }
            public int Cost { get; set; }
            public int DiscountAmount { get; set; }
            public int Discount { get; set; }
        }

        public List<string> Codes = new List<string>();
        public List<PriceRule> Rules;

        public Checkout(List<PriceRule> priceRule)
        {
            Rules = priceRule;
        }

        public void ScanItem(string SKU)
        {
            Codes.Add(SKU);
        }

        public int GetTotalPrice()
        {
            var total = 0;

            foreach (var rule in Rules)
            {
                var numberOfCode = Codes.Count(x => x == rule.Code);
                total += numberOfCode*rule.Cost;
                if (rule.DiscountAmount > 0)
                {
                    var discountTimes = numberOfCode/rule.DiscountAmount;
                    total -= discountTimes*rule.Discount;
                }
            }

            return total;
        }
    }
}
