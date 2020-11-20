using System;
using System.Collections.Generic;
using ConsoleBookShop.Book;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Customer", 45, 19000, 400);
            EBook book1 = new EBook("Harry Potter 1", "J.K. Rowling", 2, Format.PDF);
            PaperBook book2 = new PaperBook("Harry Potter 2", "J.K. Rowling", 2);

            EBook book11 = new EBook("Harry Potter 1", "J.K. Rowling", 2, Format.PDF);
            PaperBook book22 = new PaperBook("Harry Potter 2", "J.K. Rowling", 2);

            EBook book3 = new EBook("Harry Potter 3", "J.K. Rowling", 2, Format.epub);
            PaperBook book33 = new PaperBook("Harry Potter 3", "J.K. Rowling", 2);

            EBook book4 = new EBook("Harry Potter 4", "J.K. Rowling", 2, Format.epub);
            PaperBook book44 = new PaperBook("Harry Potter 4", "J.K. Rowling", 2);

            PaperBook book5 = new PaperBook("Harry Potter 5", "J.K. Rowling", 2);

            EBook book6 = new EBook("Harry Potter 6", "J.K. Rowling", 2, Format.PDF);

            BookRange bookRange = new BookRange();
            bookRange.AddBooks(
                book1, book2, book11, book22, book3, book33,
                book4, book44, book5, book6);

            Informer informer = new Informer(bookRange);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"Здравствуйте {user1.Name} ваш баланс {user1.Balance}");

                Console.WriteLine();
                Console.WriteLine("Доступные экземпляры:");
                int i = 0;
                List<BookCard> bookList = bookRange.prepareBookCardList();
                foreach (BookCard card in bookList)
                {
                    string digital = card.IsAvailableInDigital ? "В наличии" : "Отсутствует";
                    string availability = $"Бумажный вариант: {card.CountPaperUnits}, Цифровой вид: {digital}";
                    Console.WriteLine($"Товар {++i}: \"{card.Book.Title}\" по цене {card.Book.Price}. {availability}");
                }

                Console.WriteLine($"Всего книг: {bookRange.getBooksCount()}");
                Console.WriteLine("Выберите номер товара и нажмите Enter:");
                string str = Console.ReadLine();
                int productNumber = 0;
                try
                {
                    productNumber = Convert.ToInt32(str);
                }
                catch (Exception e)
                {
                }
                

                if (productNumber > 0 && productNumber <= bookRange.getBooksCount())
                {

                    if (bookList[productNumber - 1].Book.Price < user1.Balance)
                    {
                        informer.Buy(user1, bookList[productNumber - 1].Book);
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }

                }
                else
                {
                    Console.WriteLine("Таких товаров нет");
                }

                Console.WriteLine("Нажмите для продолжения.");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
