using System;
using ConsoleBookShop.Book;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Promo
{
    public class FreeBookPromo : IPromocode
    { 
        private IBook book { get; set; }
        public bool isApplied { get; set; }
        public string description { get; set; } 

        public FreeBookPromo(IBook book)
        {
            this.book = book;
            description = $"Бесплатная книга {book.Author} \"{book.Title}\"";
        }

        public void Apply(Cart cart, BookRange allBooks)
        {
            if (!isApplied)
            {
                if (book is PaperBook)
                {
                    cart.addBonusBook(new Shop.BookCard(book, false, 1));
                }
                else if (book is EBook)
                {
                    cart.addBonusBook(new Shop.BookCard(book, true, 0));
                }

                isApplied = true;
            }
        }
    }
}
