using System;

namespace ConsoleBookShop.Book
{
    public class PaperBook : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public PaperBook(string name, string material, double price)
        {
            Title = name;
            Author = material;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is IBook book &&
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
