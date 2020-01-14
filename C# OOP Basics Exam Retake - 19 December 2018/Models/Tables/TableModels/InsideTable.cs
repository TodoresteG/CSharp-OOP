using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.TableModels
{
    public  class InsideTable : Table
    {
        public const decimal InitialPricePerPerson = 2.50m;

        public InsideTable(int tableNumber, int capaciy) : base(tableNumber, capaciy, InitialPricePerPerson)
        {
        }
    }
}
