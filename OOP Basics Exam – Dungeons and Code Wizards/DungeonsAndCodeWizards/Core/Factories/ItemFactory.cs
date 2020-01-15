using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Core.Factories
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateItem(string type)
        {
            string validType = type.ToLower();

            Type itemType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == validType);

            if (itemType == null)
            {
                throw new ArgumentException($"Invalid item \"{type}\"!");
            }

            Item itemInstance = (Item)Activator
                .CreateInstance(itemType, new object[0]);

            return itemInstance;
        }
    }
}
