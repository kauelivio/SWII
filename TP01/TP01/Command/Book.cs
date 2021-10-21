//Kauê de Jesus Livio CB3005461
//Pedro Paulo dos Reis Faria CB3007278
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP01.Command;

namespace TP01.Entidades
{
    public class Book
    {
        public string Name { get; set; }
        public Author[] Authors2 { get; set; }
        public Author Authors { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }

        public Book(string name, Author authors, double price)
        {
            Name = name;
            Authors = authors;
            Price = price;
        }

        public Book(string name, Author authors, double price, int qty)
        {
            Name = name;
            Authors = authors;
            Price = price;
            Qty = qty;
        }

        public Book()
        {
        }

        public string getName()
        {
            return null;
        }
        public Author getAuthors()
        {
            return null;
        }

        public double getPrice()
        {
            return 0;
        }

        public void setPrice(double price)
        {
            
        }

        public int getQty()
        {
            return 0;
        }

        public void setQty(int qty)
        {

        }

        public string ToString(Book book)
        {
            return "Nome: " + book.Name + ", Autor: " + book.Authors.Name + ", Price: " + book.Price.ToString() + ", Quantidade: " + book.Qty.ToString();
        }

        public string getAuthorNames()
        {
            foreach(Author au in Authors2)
            {
                return au.Name;
            }

            return "";
        }
    }
}
