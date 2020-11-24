using System;

namespace ConsoleBookShop.Book
{
    public class PaperBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }

        public PaperBook(string name, string material, double price)
        {
            Title = name;
            Author = material;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is PaperBook book &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Price == book.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Price);
        }
    }
}
