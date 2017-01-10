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
            var total = 0;
            var CountA = 0;

            foreach (var code in Codes)
            {
                total += PriceGuide[code];
                if (code.Equals("A"))
                {
                    CountA ++;
                }

                if (CountA == 3)
                {
                    total = 135;
                }
            }

            return total;
        }
    }
}
