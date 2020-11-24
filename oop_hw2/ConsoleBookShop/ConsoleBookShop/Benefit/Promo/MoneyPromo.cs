using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Promo
{
    public class MoneyPromo : IPromocode
    {
        public bool isApplied { get; set; }
        public string description { get; set; }
        public double amount { get; set; }

        public MoneyPromo(double amount)
        {
            this.amount = amount;
            description = $"Скидка {amount} рублей";
        }

        public void Apply(Cart cart, BookRange allBooks)
        {
            if (!isApplied)
            {
                cart.setMoneyDiscount(amount);
                isApplied = true;
            }
        }
    }
}
