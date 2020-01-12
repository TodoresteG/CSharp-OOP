using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Problem1.VehiclesAndProblem2.Extension.Factories;
using Problem1.VehiclesAndProblem2.Extension.Models;

namespace Problem1.VehiclesAndProblem2.Extension.Core
{
    public class Engine
    {
        private readonly VehicleFactory vehicleFactory;
        private readonly List<Vehicle> vehicles;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
            this.vehicles = new List<Vehicle>();
        }

        public void Run()
        {
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = vehicleInfo[0];
                double fuelQuantity = double.Parse(vehicleInfo[1]);
                double fuelConsumption = double.Parse(vehicleInfo[2]);
                double tankCapacity = double.Parse(vehicleInfo[3]);

                this.vehicles.Add(this.vehicleFactory.GetVehicle(type, fuelQuantity, fuelConsumption, tankCapacity));
            }

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string type = tokens[1];
                double amount = double.Parse(tokens[2]);

                Vehicle vehicle = this.vehicles.FirstOrDefault(x => x.Type == type);

                switch (command)
                {
                    case "Drive":

                        if (type == vehicle.Type)
                        {
                            Console.WriteLine(vehicle.Drive(amount).Trim());
                        }
                        break;
                    case "Refuel":

                        if (type == vehicle.Type)
                        {
                            try
                            {
                                vehicle.Refuel(amount);
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }

                        break;
                    case "DriveEmpty":
                        //Console.WriteLine(vehicle.DriveEmpty(amount).TrimEnd());
                        break;
                }
            }

            Console.WriteLine($"Car: {this.vehicles.First(x => x.Type == "Car").FuelQuantity:f2}");
            Console.WriteLine($"Truck: {this.vehicles.First(x => x.Type == "Truck").FuelQuantity:f2}");
            Console.WriteLine($"Bus: {this.vehicles.First(x => x.Type == "Bus").FuelQuantity:f2}");
        }
    }
}
