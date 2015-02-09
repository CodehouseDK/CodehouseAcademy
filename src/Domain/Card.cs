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
            if (IsCardInvalid(amountToSubstract))
            {
                throw new Exception();
            }
            Balance = Balance - amountToSubstract;
            
        }

        private  bool IsCardInvalid(float am)
        {
            var newBalance = Balance - am;
            return newBalance < 0;
        }
    }
}
