using System;
namespace ConsoleBookShop.Book
{
    public interface IBook
    {
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }

        public bool Equals(object obj);

        public int GetHashCode();
    }
}
