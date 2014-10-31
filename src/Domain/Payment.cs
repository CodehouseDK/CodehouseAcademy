namespace Domain
{
    public class Payment
    {
        public Payment(float totalPrice)
        {
            TotalPrice = totalPrice;
        }

        public float TotalPrice { get; private set; }
    
    }
}
