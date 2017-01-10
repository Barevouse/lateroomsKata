namespace CheckoutKata
{
    public interface ICheckout
    {
        int GetTotalPrice();
        void ScanItem(string SKU);
    }
}