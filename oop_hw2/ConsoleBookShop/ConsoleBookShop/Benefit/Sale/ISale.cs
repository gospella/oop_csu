using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Sale
{
    public interface ISale : IBenefit
    {
        public enum SaleType
        {
            OnePlusOneEqThreeSale,
        }
    }
}
