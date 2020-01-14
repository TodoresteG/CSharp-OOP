using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.CommonCotracts
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(string type, string name, int energy, int happiness, int procedureTime);
    }
}
