using System;
using static ConsoleBookShop.Benefit.Sale.ISale;

namespace ConsoleBookShop.Benefit.Sale
{
    public class SaleFactory
    {
        public static ISale createPromo(SaleType type)
        {
            ISale instance = null;
            switch (type)
            {
                case SaleType.OnePlusOneEqThreeSale:
                    instance = new OnePlusOneEqThreeSale();
                    break;
                default:
                    break;
            }

            return instance;
        }
    }
}
