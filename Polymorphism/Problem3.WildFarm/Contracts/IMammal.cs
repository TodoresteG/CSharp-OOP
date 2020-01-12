using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3.WildFarm.Contracts
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
