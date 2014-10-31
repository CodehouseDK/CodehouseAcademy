namespace Domain
{
    public class Percent
    {
        public Percent(int percentInteger)
        {
            if (percentInteger < 0 || percentInteger > 100)
            {
                throw new PercentException();
            }
            PercentInteger = percentInteger;
        }

        public int PercentInteger { get; private set; }

        public float ZeroBasedPrecent
        {
            get { return ((float)PercentInteger) / 100; }
        }
    }
}