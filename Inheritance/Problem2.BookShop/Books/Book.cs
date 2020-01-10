using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2.BookShop.Books
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string auhtor, string title, decimal price)
        {
            this.Author = auhtor;
            this.Title = title;
            this.Price = price;
        }

        public string Author
        {
            get { return this.author; }
            private set
            {
                string[] tokens = value.Split(' ');

                if (tokens.Length > 1)
                {
                    if (Char.IsDigit(tokens[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }

                this.author = value;
            }
        }

        public string Title
        {
            get { return this.title; }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                this.title = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Price not valid!");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}" + Environment.NewLine +
                   $"Title: {this.Title}" + Environment.NewLine +
                   $"Author: {this.Author}" + Environment.NewLine +
                   $"Price: {this.Price:f2}";
        }
    }
}
