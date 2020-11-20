using System;
namespace ConsoleBookShop.Book
{
    public interface IBook
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

        public bool Equals(object obj);

        public int GetHashCode();
    }
}
