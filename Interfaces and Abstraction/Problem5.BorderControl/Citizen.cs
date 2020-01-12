using System;
using System.Collections.Generic;
using System.Text;

namespace Problem5.BorderControl
{
    public class Citizen : IIdentifiable
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.name = name;
            this.age = age;
            this.Id = id;
        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
