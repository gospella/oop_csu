using System;
namespace ConsoleBookShop.Book
{
    public enum Format { PDF, epub }
    public class EBook : IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public Format Format { get; set; }

        public EBook(string name, string material, double price, Format format)
        {
            Title = name;
            Author = material;
            Price = price;
            Format = format;
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
