using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags.Models
{
    public class Backpack : Bag
    {
        private const int InitialCapacity = 100;

        public Backpack() : base(InitialCapacity)
        {
        }
    }
}
