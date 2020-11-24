using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Promo
{
    public class FreeDeliveryPromo : IPromocode
    {
        public bool isApplied { get; set; }
        public string description { get; set; } = "Бесплатная доставка";

        public void Apply(Cart cart, BookRange allBooks)
        {
            if (!isApplied)
            {
                cart.setFreeDeliveryStart(0);
                isApplied = true;
            }
                
        }
    }
}
