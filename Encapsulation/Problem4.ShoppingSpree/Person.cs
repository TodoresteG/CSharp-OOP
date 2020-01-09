using System;
using System.Collections.Generic;
using System.Text;

namespace Problem4.ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;
        private List<Product> bag;

        public Person(string name)
        {
            this.bag = new List<Product>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public int Money
        {
            get { return this.money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get { return this.bag.AsReadOnly(); }
        }

        public string Buy(Person person, Product product)
        {
            if (person.Money >= product.Cost)
            {
                this.bag.Add(product);
                person.Money -= product.Cost;

                return $"{person.Name} bought {product.Name}";
            }

            return $"{person.Name} can't afford {product.Name}";
        }
    }
}
