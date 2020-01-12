using System;
using System.Collections.Generic;
using System.Text;
using Problem6.BirthdayCelebrations.Contracts;
using Problem6.BirthdayCelebrations.Models;

namespace Problem6.BirthdayCelebrations.Factories
{
    public class BirthdateFactory
    {
        public IBirthable GetBirthable(string type, params string[] parameters)
        {
            string name = "";
            string id = "";
            string birthdate = "";

            switch (type)
            {
                case "Citizen":
                    name = parameters[0];
                    int age = int.Parse(parameters[1]);
                    id = parameters[2];
                    birthdate = parameters[3];

                    return new Citizen(name, age, id, birthdate);
                case "Pet":
                    name = parameters[0];
                    birthdate = parameters[1];

                    return new Pet(name, birthdate);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
