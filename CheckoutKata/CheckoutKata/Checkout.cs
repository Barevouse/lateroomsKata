using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<string> Codes = new List<string>();
        public Dictionary<string, int> PriceGuide = new Dictionary<string, int>();

        public Checkout()
        {
            PriceGuide.Add("A", 50);
            PriceGuide.Add("B", 30);
            PriceGuide.Add("C", 20);
            PriceGuide.Add("D", 15);
        }

        public void ScanItem(string SKU)
        {
            Codes.Add(SKU);
        }

        public int GetTotalPrice()
        {
            var value = PriceGuide[Codes[0]];

            return value;
        }
    }
}
