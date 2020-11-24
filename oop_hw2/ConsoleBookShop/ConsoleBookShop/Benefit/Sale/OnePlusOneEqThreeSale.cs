using System;
using System.Collections.Generic;
using ConsoleBookShop.Book;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Benefit.Sale
{
    public class OnePlusOneEqThreeSale : ISale
    {
        public bool isApplied { get; set; }
        public string description { get; set; } = "1+1=3";

        public OnePlusOneEqThreeSale()
        {
        }

        public void Apply(Cart cart, BookRange allBooks)
        {
            List<BookCard> books = cart.GetPaidBooksInCart();
            Dictionary<string, int> authors = new Dictionary<string, int>();
            if (books.Count >= 2)
            {
                foreach (BookCard card in books)
                {
                    if(card.Book is PaperBook)
                    {
                        if (authors.ContainsKey(card.Book.Author))
                        {
                            authors[card.Book.Author] += 1;
                        }
                        else
                        {
                            authors.Add(card.Book.Author, 1);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> entry in authors)
                {
                    if(entry.Value >= 2)
                    {
                        addEbookWithAuthorToCard(entry.Key, allBooks.prepareBookCardList(), cart);
                    }
                }
                isApplied = true;
            }
        }

        public void addEbookWithAuthorToCard(String author, List<BookCard> books, Cart cart)
        {
            foreach (BookCard book in books)
            {
                if(book.Book is EBook && ((EBook)book.Book).Author == author)
                {
                    cart.addBonusBook(new BookCard(((EBook)book.Book).makeFreeCopy(), true, 0));
                    return;
                }
            }
        }
    }
}
