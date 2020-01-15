using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Entities.Bags.Models
{
    public class Satchel : Bag
    {
        private const int InitialCapacity = 20;

        public Satchel() : base(InitialCapacity)
        {
        }
    }
}
