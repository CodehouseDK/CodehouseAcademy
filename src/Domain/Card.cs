using System;

namespace Domain
{
    public class Card
    {
        public Card(float balance)
        {
            Balance = balance;
        }

        public float Balance { get; private set; }

        public void Substract(float amountToSubstract)
        {
            var newBalance = Balance - amountToSubstract;
            if (newBalance < 0)
            {
                throw new Exception();
            }
            Balance = Balance - amountToSubstract;
            
        }
    }
}
