using System;
using System.Collections.Generic;
using System.Text;

namespace Problem2.BookShop.Books
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string auhtor, string title, decimal price) : base(auhtor, title, price)
        {
        }

        public override decimal Price
        {
            get
            {
                return base.Price * 1.3m;
            }
        }
    }
}
