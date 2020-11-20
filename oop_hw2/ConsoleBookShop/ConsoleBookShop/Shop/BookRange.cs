using System;
using System.Collections.Generic;
using ConsoleBookShop.Book;

namespace ConsoleBookShop.Shop
{
    // Ассортимент
    public class BookRange
    {
        private readonly List<BookCard> bookList = new List<BookCard>();
        private int booksCount { get; set; } = 0;

        public BookRange()
        {
            //paperBooks = new Dictionary<IBook, int>();
            //ebooks = new List<IBook>();
        }

        //public Dictionary<IBook, int> PaperBooks { get => paperBooks; }
        //public List<IBook> Ebooks { get => ebooks; }

        public void AddBooks(params IBook[] books)
        {
            foreach (IBook book in books)
            {
                if (book is PaperBook)
                {
                    BookCard bc = new BookCard(book, 1, false);
                    if (bookList.Contains(bc))
                    {
                        bookList[bookList.IndexOf(bc)].CountPaperUnits += 1;
                    }
                    else
                    {
                        bookList.Add(bc);
                        booksCount++;
                    }
                    
                }
                else if (book is EBook)
                {
                    BookCard bc = new BookCard(book, 0, true);
                    if (bookList.Contains(bc))
                    {
                        bookList[bookList.IndexOf(bc)].IsAvailableInDigital = true;
                    }
                    else
                    {
                        bookList.Add(bc);
                        booksCount++;
                    }
                }
            }
            
        }

        public void deleteBook(IBook book)
        {
            BookCard bc = new BookCard(book, 0, false);
            if (book is PaperBook && bookList.Contains(bc))
            {
                booksCount--;
                int id = bookList.IndexOf(bc);
                if (bookList[id].CountPaperUnits > 1)
                {
                    bookList[id].CountPaperUnits -= 1;
                }
                else if (bookList[id].CountPaperUnits == 1)
                {
                    bookList.Remove(bc);
                } else
                {
                    throw new Exception();
                }
            }
        }

        public List<BookCard> prepareBookCardList()
        { 
            return bookList;
        }

        public int getBooksCount()
        {
            return booksCount;
        }
    }
}
