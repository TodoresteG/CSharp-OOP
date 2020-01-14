using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController controller;

        public Engine()
        {
                this.controller = new RestaurantController();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                try
                {
                    switch (command)
                    {
                        case "AddFood":
                            string type = tokens[1];
                            string name = tokens[2];
                            decimal price = decimal.Parse(tokens[3]);

                            Console.WriteLine(this.controller.AddFood(type, name, price));
                            break;
                        case "AddDrink":
                            type = tokens[1];
                            name = tokens[2];
                            int servingSize = int.Parse(tokens[3]);
                            string brand = tokens[4];

                            Console.WriteLine(this.controller.AddDrink(type, name, servingSize, brand));
                            break;
                        case "AddTable":
                            type = tokens[1];
                            int tableNumber = int.Parse(tokens[2]);
                            int capacity = int.Parse(tokens[3]);

                            Console.WriteLine(this.controller.AddTable(type, tableNumber, capacity));
                            break;
                        case "ReserveTable":
                            int numberOfPeople = int.Parse(tokens[1]);

                            Console.WriteLine(this.controller.ReserveTable(numberOfPeople));
                            break;
                        case "OrderFood":
                            tableNumber = int.Parse(tokens[1]);
                            string foodName = tokens[2];

                            Console.WriteLine(this.controller.OrderFood(tableNumber, foodName));
                            break;
                        case "OrderDrink":
                            tableNumber = int.Parse(tokens[1]);
                            string drinkName = tokens[2];
                            brand = tokens[3];

                            Console.WriteLine(this.controller.OrderDrink(tableNumber, drinkName, brand));
                            break;
                        case "LeaveTable":
                            tableNumber = int.Parse(tokens[1]);

                            Console.WriteLine(this.controller.LeaveTable(tableNumber));
                            break;
                        case "GetFreeTablesInfo":
                            Console.WriteLine(this.controller.GetFreeTablesInfo());
                            break;
                        case "GetOccupiedTablesInfo":
                            Console.WriteLine(this.controller.GetOccupiedTablesInfo());
                            break;

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(this.controller.GetSummary());
        }
    }
}
