namespace Logic.Prices
{
    public class Change
    {
        public Change(float amount)
        {
            Amount = amount;
        }

        public float Amount { get; private set; }
    }
}