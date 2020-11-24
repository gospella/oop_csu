using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Promo
{
    public class PercentagePromo : IPromocode
    {
        public bool isApplied { get; set; }
        public string description { get; set; }
        public int amount { get; set; }

        public PercentagePromo(int amount)
        {
            this.amount = amount;
            description = $"Скидка {amount}%";
        }

        public void Apply(Cart cart, BookRange allBooks)
        {
            if (!isApplied)
            {
                cart.setPercentageDiscount(amount);
                isApplied = true;
            }
            
        }
    }
}
