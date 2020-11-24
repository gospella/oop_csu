using System;
using System.Collections.Generic;
using ConsoleBookShop.Benefit;
using ConsoleBookShop.Benefit.Promo;
using ConsoleBookShop.Benefit.Sale;
using ConsoleBookShop.Book;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Customer", 22, 5000, 0);
            EBook book1 = new EBook("Harry Potter 1", "J.K. Rowling", 499, Format.PDF);
            PaperBook book2 = new PaperBook("Harry Potter 2", "J.K. Rowling", 499);

            EBook book11 = new EBook("Harry Potter 1", "J.K. Rowling", 499, Format.PDF);
            PaperBook book22 = new PaperBook("Harry Potter 2", "J.K. Rowling", 499);

            EBook book3 = new EBook("Harry Potter 3", "J.K. Rowling", 499, Format.epub);
            PaperBook book33 = new PaperBook("Harry Potter 3", "J.K. Rowling", 499);

            EBook book4 = new EBook("Harry Potter 4", "J.K. Rowling", 499, Format.epub);
            PaperBook book44 = new PaperBook("Harry Potter 4", "J.K. Rowling", 499);

            PaperBook book5 = new PaperBook("Harry Potter 5", "J.K. Rowling", 499);

            EBook book6 = new EBook("Harry Potter 7", "J.K. Rowling", 499, Format.PDF);

            BookRange bookRange = new BookRange();
            bookRange.AddBooks(
                book1, book2, book11, book22, book3, book33,
                book4, book44, book5, book6);

            // Создание корзины
            Cart cart = new Cart(bookRange);
            // Добавление промокодов и акций
            cart.AddBonus(PromoFactory.createPromo(IPromocode.PromoType.FreeBookPromo));
            cart.AddBonus(PromoFactory.createPromo(IPromocode.PromoType.FreeDeliveryPromo));
            cart.AddBonus(PromoFactory.createPromo(IPromocode.PromoType.MoneyPromo));
            cart.AddBonus(PromoFactory.createPromo(IPromocode.PromoType.PercentagePromo));
            cart.AddBonus(SaleFactory.createPromo(ISale.SaleType.OnePlusOneEqThreeSale));

            while (true)
            {
                // Стартовое меню
                Console.Clear();
                List<BookCard> bookList = bookRange.prepareBookCardList();
                bookList.Sort((x, y) => x.Book.Title.CompareTo(y.Book.Title));
                PrintStartInfo(user1, bookRange, cart, bookList);
                int option = readKey();

                if (option == 0) // Корзина
                {
                    Console.Clear();
                    cart.calculateCost();
                    List<BookCard> bookCards = cart.GetAllBooksInCart();
                    bool isCartEmpty = bookCards.Count == 0;
                    if (isCartEmpty) Console.WriteLine("Корзина пуста");

                    while (!isCartEmpty)
                    {
                        Console.Clear();
                        bookCards = cart.GetAllBooksInCart();
                        cart.calculateCost();
                        PrintCartInfo(bookCards, cart.getBonuses(true), cart.GetPriceSum());
                        option = readKey();
                        switch (option)
                        {
                            case 0:
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Выход в главное меню");
                                    isCartEmpty = true;
                                    break;
                                }
                            case 1:
                                {
                                    // Оплата товаров
                                    double price = cart.GetPriceSum();
                                    if (price < user1.Balance)
                                    {
                                        PrintPaymentInfo(user1, bookCards, price);
                                        cart.MakePurchase(user1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас недостаточно средств");
                                    }
                                    isCartEmpty = true;
                                    break;
                                }
                            case 2:
                                {
                                    // Активация бонусов
                                    List<IBenefit> bonuses = cart.getBonuses(false);
                                    PrintBonusSelectionInfo(bonuses);
                                    while (true)
                                    {
                                        option = readKey();
                                        //bonuses.Sort((x, y) => x.CompareTo(y));
                                        if (option == 0) break;
                                        else if (option > 0 && option <= bonuses.Count)
                                        {
                                            bonuses[option - 1].Apply(cart, bookRange);
                                            Console.WriteLine("Бонус активирован");
                                            break;
                                        }
                                        else Console.WriteLine("Такого бонуса не существует");
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    // Очистка бонусов
                                    cart.clearBonus();
                                    Console.WriteLine();
                                    Console.WriteLine("Бонусы очищены");
                                    break;
                                }
                            case 9:
                                {
                                    // Очистка корзины
                                    cart.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("Корзина очищена");
                                    isCartEmpty = true;
                                    break;
                                }
                            default:
                                continue;
                        }
                    }

                }
                else if (option > 0 && option <= bookRange.getBooksCount())
                {
                    cart.AddToCart(bookList[option - 1]);
                    Console.WriteLine("Товар добавлен в корзину");
                }
                else
                {
                    Console.WriteLine("Такого товара не существует");
                }

                Console.WriteLine("Нажмите Enter для продолжения.");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                Console.Clear();
            }
        }

        private static void PrintBonusSelectionInfo(List<IBenefit> bonuses)
        {
            Console.Clear();
            Console.WriteLine("Список доступных бонусов:");
            PrintBonusesList(bonuses);
            Console.WriteLine();
            Console.WriteLine("Для активации бонуса введите номер и нажмите Enter");
            Console.WriteLine("Для перехода в корзину введите 0");
            Console.WriteLine();
        }

        private static void PrintPaymentInfo(User user1, List<BookCard> bookCards, double price)
        {
            Console.Clear();
            Console.WriteLine($"{user1.Name} оплатил {price}");
            Console.WriteLine($"Список оплаченных товаров:");
            PrintBookList(bookCards);
            Console.WriteLine("Заказ готовится, ожидайте");
            Console.WriteLine();
        }

        private static void PrintCartInfo(List<BookCard> bookCards, List<IBenefit> bonuses, double price)
        {
            PrintBookList(bookCards);
            Console.WriteLine($"Общая сумма заказа включая доставку: {price} ");
            if (bonuses.Count != 0)
            {
                Console.WriteLine("Активированные бонусы: ");
                PrintBonusesList(bonuses);
            }
            Console.WriteLine();
            Console.WriteLine("Для выхода в главное меню введите 0");
            Console.WriteLine("Для оплаты товаров введите 1");
            Console.WriteLine("Для перехода к окну активации бонусов нажмите 2");
            Console.WriteLine("Для очистки бонусов введите 8");
            Console.WriteLine("Для очистки корзины введите 9");
        }

        private static void PrintStartInfo(User user1, BookRange bookRange, Cart cart, List<BookCard> bookList)
        {
            Console.WriteLine($"Здравствуйте, {user1.Name}, ваш баланс {user1.Balance}");
            Console.WriteLine();
            Console.WriteLine("Доступные экземпляры:");
            PrintBookList(bookList);
            Console.WriteLine($"Всего книг: {bookRange.getBooksCount()}");
            Console.WriteLine($"Всего товаров в корзине: {cart.getSize()}");
            Console.WriteLine();
            Console.WriteLine("Для добавления в корзину выберите введите номер товара и нажмите Enter");
            Console.WriteLine("Для перехода в корзину введите 0");
        }

        private static int readKey()
        {
            string str = Console.ReadLine();
            int option = -1;
            try
            {
                option = Convert.ToInt32(str);
            }
            catch (Exception e)
            {
                option = readKey();
            }
            return option;
        }

        private static bool PrintBookList(List<BookCard> bookList)
        {
            if(bookList.Count == 0)
            { 
                return true;
            }
            int i = 0;
            foreach (BookCard card in bookList)
            {
                string availability = card.IsDigital ? "Цифровой вариант" : $"Бумажный вариант: {card.CountPaperUnits}";
                Console.WriteLine($"Товар {++i}: {card.Book.Author} \"{card.Book.Title}\" по цене {card.Book.Price}. {availability}");
            }
            return false;
        }

        private static bool PrintBonusesList(List<IBenefit> bonuses)
        {
            if (bonuses.Count == 0)
            {
                return true;
            }
            int i = 0;
            foreach (IBenefit bonus in bonuses)
            {
                Console.WriteLine($"Бонус {++i}: {bonus.description}");
            }
            return false;
        }
    }
}
