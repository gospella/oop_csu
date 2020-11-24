using System;
using ConsoleBookShop.Book;
using static ConsoleBookShop.Benefit.Promo.IPromocode;

namespace ConsoleBookShop.Benefit.Promo
{ 
    public class PromoFactory
    {
        public static IPromocode createPromo(PromoType type)
        {
            IPromocode instance = null;
            switch (type)
            {
                case PromoType.FreeBookPromo:
                    instance = new FreeBookPromo(new PaperBook("Harry Potter 10", "J.K. Rowling", 0));
                    break;
                case PromoType.FreeDeliveryPromo:
                    instance = new FreeDeliveryPromo();
                    break;
                case PromoType.PercentagePromo:
                    instance = new PercentagePromo(20);
                    break;
                case PromoType.MoneyPromo:
                    instance = new MoneyPromo(100);
                    break;
                default:
                    break;
            }

            return instance;
        }
    }
}
