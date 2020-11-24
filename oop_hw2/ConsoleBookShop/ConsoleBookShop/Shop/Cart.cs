using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleBookShop.Benefit;
using ConsoleBookShop.Benefit.Promo;
using ConsoleBookShop.Benefit.Sale;
using ConsoleBookShop.Book;
using ConsoleBookShop.Shop;

namespace ConsoleBookShop.Shop
{
    public class Cart
    {
        private BookRange bookRange;
        private List<BookCard> booksInCart = new List<BookCard>();
        private List<BookCard> bonusBooks = new List<BookCard>();

        private List<IBenefit> bonuses = new List<IBenefit>();


        private double deliveryCost;
        private double priceSum = 0;

        private double freeDeliveryStart = 1000;
        private double defaultDeliveryPrice = 200;

        private double percentageDiscount = 0;
        private double moneyDiscount = 0;


        public Cart(BookRange bookRange)
        {
            this.bookRange = bookRange;
        }

        public void AddToCart(BookCard book)
        {
            if (!booksInCart.Contains(book) || book.Book is PaperBook)
            {
                booksInCart.Add(book);
                bookRange.deleteBook(book);
            }
        }

        public void addBonusBook(BookCard book)
        {
            if (!bonusBooks.Contains(book) || book.Book is PaperBook)
            {
                bonusBooks.Add(book);
            }
        }

        public List<BookCard> GetAllBooksInCart()
        {
            List<BookCard> result = new List<BookCard>();
            result.AddRange(booksInCart);
            result.AddRange(bonusBooks);
            return result;
        }

        public List<BookCard> GetPaidBooksInCart()
        {
            List<BookCard> result = new List<BookCard>();
            result.AddRange(booksInCart);
            return result;
        }

        public double GetDeliveryCost()
        {
            return deliveryCost;
        }

        public double GetPriceSum()
        {
            double result =
                (priceSum + deliveryCost)
                - ((priceSum + deliveryCost)*(percentageDiscount/100))
                - moneyDiscount;
            if (result < 0) return 0;
            return result;
        }

        public void calculateCost() {
            double sum = 0;
            foreach (BookCard card in booksInCart)
            {
                sum += card.Book.Price;
            }
            //applyAllBenefits();
            priceSum = sum;

            if (sum >= freeDeliveryStart) deliveryCost = 0;
            else deliveryCost = calculateDelivery();
        }

        public double calculateDelivery()
        {
            //if (deliveryCost == 0 && card.Book is PaperBook) deliveryCost = defaultDeliveryPrice;
            //if (sum >= freeDeliveryStart) deliveryCost = 0;
            double delivery = 0;
            foreach (BookCard card in booksInCart)
            {
                if (card.Book is PaperBook) delivery = defaultDeliveryPrice;
            }
            return delivery;
        }

        public List<IBenefit> getBonuses(bool isOnlyApplied)
        {
            List<IBenefit> bonuses = new List<IBenefit>();
            foreach (IBenefit bonus in this.bonuses)
            {
                if (isOnlyApplied)
                {
                    if (!bonus.isApplied) continue;
                }
                bonuses.Add(bonus);
            }
            return bonuses;
        }

        public void applyAllBenefits()
        {
            foreach (IBenefit bonus in bonuses)
            {
                if (!bonus.isApplied)
                {
                    bonus.Apply(this, bookRange);
                }
            }
        }

        public void setFreeDeliveryStart(double sum)
        {
            freeDeliveryStart = sum;
        }

        public void changePriceSum(double sum)
        {
            if (sum >= 0)
            {
                priceSum = sum;
            }
            else priceSum = 0;
        }

        public void MakePurchase(User user)
        {
            user.RBalance(GetPriceSum());
            setDefault();
        }

        private void setDefault()
        {
            booksInCart.Clear();
            bonusBooks.Clear();
            freeDeliveryStart = 1000;
            defaultDeliveryPrice = 200;
            priceSum = 0;
            percentageDiscount = 0;
            moneyDiscount = 0;
            foreach (IBenefit bonus in bonuses)
            {
                bonus.isApplied = false;
            }
        }

        internal object getSize()
        {
            return booksInCart.Count+bonusBooks.Count;
        }

        internal void Clear()
        {
            foreach (BookCard card in booksInCart)
            {
                bookRange.AddBooks(card.Book);
            }
            setDefault();
        }

        public void AddBonus(IBenefit bonus)
        {
            bonuses.Add(bonus);
        }

        internal void clearBonus()
        {
            foreach (IBenefit bonus in bonuses)
            {
                bonus.isApplied = false;
            }
        }

        public void setPercentageDiscount(int percent)
        {
            if(percent > 0 && percent <= 100)
            {
                percentageDiscount = percent;
            }
        }

        public void setMoneyDiscount(double money)
        {
            if (money > 0)
            {
                moneyDiscount = money;
            }
        }
    }
}