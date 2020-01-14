using System;
using System.Collections.Generic;
using System.Text;
using SoftUniRestaurant.Models.Tables.Contracts;
using SoftUniRestaurant.Models.Tables.TableModels;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable GeTable(string type, int tableNumber, int capacity)
        {
            type = type.ToLower();

            switch (type)
            {
                case "inside":
                    return new InsideTable(tableNumber, capacity);
                case "outside":
                    return  new OutsideTable(tableNumber, capacity);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
