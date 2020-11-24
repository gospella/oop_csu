using System;
using System.Collections.Generic;
using ConsoleBookShop.Book;

namespace ConsoleBookShop.Shop
{
    // Карточка, описывающая экзепляр на продаже
    public class BookCard
    {
        private IBook book { get; }
        private bool isDigital { get; set; }
        private int countPaperUnits { get; set; }

        public BookCard(IBook book, bool isDigital, int countPaperUnits)
        {
            this.book = book;
            this.countPaperUnits = countPaperUnits;
            this.isDigital = isDigital;
        }

        public IBook Book { get => book; }
        public int CountPaperUnits
        {
            get => countPaperUnits;
            set
            {
                countPaperUnits = value;
            }
        }
        public bool IsDigital
        {
            get => isDigital;
            set
            {
                isDigital = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BookCard card &&
                   EqualityComparer<IBook>.Default.Equals(book, card.book) &&
                   isDigital == card.isDigital;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(book, isDigital);
        }
    }
}
