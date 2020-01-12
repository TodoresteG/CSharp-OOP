using System;
using System.Collections.Generic;
using System.Text;
using Problem1.VehiclesAndProblem2.Extension.Contracts;

namespace Problem1.VehiclesAndProblem2.Extension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;

        protected Vehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.Type = type;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public string Type { get; private set; }

        public double FuelQuantity { get; protected set; }

        public double FuelConsumption { get; protected set; }

        public double TankCapacity
        {
            get => this.tankCapacity;
            protected set
            {
                this.tankCapacity = value;

                if (this.FuelQuantity > this.tankCapacity)
                {
                    this.tankCapacity = 0;
                }
            }
        }

        public abstract double IncreasedConsumption { get; }

        public abstract string Drive(double distance);

        public abstract void Refuel(double amount);
    }
}
