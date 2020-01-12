using System;
using System.Collections.Generic;
using System.Text;
using Problem1.VehiclesAndProblem2.Extension.Models;

namespace Problem1.VehiclesAndProblem2.Extension.Factories
{
    public class VehicleFactory
    {
        public Vehicle GetVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(type, fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(type, fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(type, fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
