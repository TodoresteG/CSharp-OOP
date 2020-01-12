using System;
using System.Collections.Generic;
using System.Text;
using Problem1.VehiclesAndProblem2.Extension.Contracts;

namespace Problem1.VehiclesAndProblem2.Extension.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedFuel = 0.9;

        public Car(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(type, fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double IncreasedConsumption => this.FuelConsumption + IncreasedFuel;

        public override string Drive(double distance)
        {
            double neededAmount = this.IncreasedConsumption * distance;

            if (this.FuelQuantity >= neededAmount)
            {
                this.FuelQuantity -= neededAmount;
                return $"Car travelled {distance} km";
            }

            return "Car needs refueling";
        }

        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.TankCapacity < amount)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            this.FuelQuantity += amount;
        }
    }
}
