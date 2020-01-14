using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Models.Tables.TableModels
{
    public class OutsideTable : Table
    {
        public const decimal InitialPricePerPerson = 3.50m;

        public OutsideTable(int tableNumber, int capaciy) : base(tableNumber, capaciy, InitialPricePerPerson)
        {
        }
    }
}
