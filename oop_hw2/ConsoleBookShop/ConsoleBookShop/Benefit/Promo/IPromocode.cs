using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Promo
{
    public interface IPromocode : IBenefit
    {
        public enum PromoType
        {
            FreeBookPromo,
            FreeDeliveryPromo,
            MoneyPromo,
            PercentagePromo,
        }
    }
}
