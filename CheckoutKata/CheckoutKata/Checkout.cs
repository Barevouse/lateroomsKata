using System.Collections.Generic;

namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        public List<string> Codes = new List<string>();
        public void ScanItem(string SKU)
        {
            Codes.Add(SKU);
        }

        public int GetTotalPrice()
        {
            if (Codes[0] == "A")
            {
                return 50;
            }
            else
            {
                return 30;
            }
        }
    }
}
