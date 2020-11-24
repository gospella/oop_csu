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

        public void AddBooks(params IBook[] books)
        {
            foreach (IBook book in books)
            {
                if (book is PaperBook)
                {
                    BookCard bc = new BookCard(book, false, 1);
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
                    BookCard bc = new BookCard(book, true, 0);
                    if (bookList.Contains(bc))
                    {
                        EBook ebook = (EBook) bookList[bookList.IndexOf(bc)].Book;
                        foreach (Format format in ((EBook)book).getFormats())
                        {
                            ebook.addFormat(format);
                        }
                    }
                    else
                    {
                        bookList.Add(bc);
                        booksCount++;
                    }
                }
            }
            
        }

        public void deleteBook(BookCard bookCard)
        {
            if (bookCard.Book is PaperBook)
            {
                if (bookList.Contains(bookCard))
                {
                    int id = bookList.IndexOf(bookCard);
                    if (bookList[id].CountPaperUnits > 1)
                    {
                        bookList[id].CountPaperUnits -= 1;
                    }
                    else if (bookList[id].CountPaperUnits == 1)
                    {
                        bookList.Remove(bookCard);
                        booksCount--;
                    }
                    else
                    {
                        throw new Exception();
                    }
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
