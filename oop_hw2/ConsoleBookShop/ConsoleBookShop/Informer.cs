using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBookShop.Book;
using ConsoleBookShop.Discount;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop
{
    class Informer
    {
        private BookRange bookRange;

        public Informer(BookRange bookRange)
        {
            this.bookRange = bookRange;
        }

        public void Buy(User user, IBook book)
        {
            double price = Sale.countPrice(user, book.Price);
            user.RBalance(price);
            if (book is PaperBook) bookRange.deleteBook(book);
            Console.WriteLine($"{user.Name} купил {book.Title} за {price}. Заказ отправлен на склад");
        }
    }
}