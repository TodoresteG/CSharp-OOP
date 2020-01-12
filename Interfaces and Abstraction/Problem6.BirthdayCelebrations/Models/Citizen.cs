using System;
using System.Collections.Generic;
using System.Text;
using Problem6.BirthdayCelebrations.Contracts;

namespace Problem6.BirthdayCelebrations.Models
{
    public class Citizen : IName, IIdentifiable, IBirthable
    {
        private int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Name { get; private set; }

        public string Id { get; private set; }

        public DateTime Birthdate { get; private set; }
    }
}
