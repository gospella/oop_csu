using System;
using System.Collections.Generic;
using ConsoleBookShop.Book;

namespace ConsoleBookShop.Shop
{
    // Карточка, описывающая экзепляр на продаже
    public class BookCard
    {
        private IBook book { get; }
        private int countPaperUnits { get; set; }
        private bool isAvailableInDigital { get; set; }

        public BookCard(IBook book, int countPaperUnits, bool isAvailableInDigital)
        {
            this.book = book;
            this.countPaperUnits = countPaperUnits;
            this.isAvailableInDigital = isAvailableInDigital;
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
        public bool IsAvailableInDigital
        {
            get => isAvailableInDigital;
            set
            {
                isAvailableInDigital = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BookCard card &&
                   EqualityComparer<IBook>.Default.Equals(book, card.book);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(book);
        }
    }
}
