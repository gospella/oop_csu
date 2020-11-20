using System;
namespace ConsoleBookShop.Discount
{
    public class Sale
    {
        public static double countPrice(User user, double price)
        {
            if (user.Spent < 500)
            {
                return price;
            }
            if (user.Spent < 1000)
            {
                return price * 0.9;
            }
            return price * 0.5;
        }
    }
}
