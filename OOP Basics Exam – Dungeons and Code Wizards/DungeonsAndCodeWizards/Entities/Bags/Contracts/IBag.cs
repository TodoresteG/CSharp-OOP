using System.Collections.Generic;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Entities.Bags.Contracts
{
    public interface IBag
    {
        int Capacity { get; }

        int Load { get; }

        IReadOnlyCollection<Item> Items { get; }

        void AddItem(Item item);

        Item GetItem(string name);
    }
}
