using System;
using System.Collections.Generic;
using System.Text;

namespace Problem1.VehiclesAndProblem2.Extension.Contracts
{
    public interface IVehicle
    {
        string Type { get; }

        double FuelQuantity { get; }

        double FuelConsumption { get; }

        double IncreasedConsumption { get; }

        double TankCapacity { get; }

        string Drive(double distance);

        void Refuel(double amount);
    }
}
