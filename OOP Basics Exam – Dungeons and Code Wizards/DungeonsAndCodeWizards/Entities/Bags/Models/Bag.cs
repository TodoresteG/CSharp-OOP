using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Entities.Bags.Contracts;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Entities.Bags.Models
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;

        private readonly List<Item> items;

        protected Bag(int capacity) : this()
        {
            this.Capacity = capacity;
        }

        protected Bag()
        {
            this.items = new List<Item>();
            this.Capacity = DefaultCapacity;
        }

        public int Capacity { get; private set; }

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items
                .FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}
