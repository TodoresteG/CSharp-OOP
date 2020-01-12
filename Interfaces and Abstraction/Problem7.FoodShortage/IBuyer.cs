using System;
using System.Collections.Generic;
using System.Text;

namespace Problem7.FoodShortage
{
    public interface IBuyer
    {
        void BuyFood();

        string Name { get; }

        int Food { get; }
    }
}
