using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Entities.Items.Models;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IItemFactory
    {
        Item CreateItem(string type);
    }
}
