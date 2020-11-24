using System;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit
{
    public interface IBenefit
    {
        public bool isApplied { get; set; }
        public string description { get; set; }

        public void Apply(Cart cart, BookRange allBooks);
    }
}
