using System;
using System.Collections.Generic;

namespace ConsoleBookShop.Book
{
    public enum Format { PDF, epub }
    public class EBook : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public double Price { get; }
        public HashSet<Format> Formats = new HashSet<Format>();

        public EBook(string name, string material, double price, params Format[] formats)
        {
            Title = name;
            Author = material;
            Price = price;
            foreach(Format format in formats)
            {
                Formats.Add(format);
            }
        }

        public void addFormat(Format format)
        {
            Formats.Add(format);
        }

        public HashSet<Format> getFormats()
        {
            return Formats;
        }

        public override bool Equals(object obj)
        {
            return obj is EBook book &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Price == book.Price;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, Author, Price);
        }

        public EBook makeFreeCopy()
        {
            Format[] formats = new Format[this.Formats.Count];
            this.Formats.CopyTo(formats);
            EBook other = new EBook(this.Title, this.Author, 0, formats);
            return other;
        }
    }
}
