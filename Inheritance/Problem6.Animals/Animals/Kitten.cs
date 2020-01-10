using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6.Animals.Animals
{
    public class Kitten : Animal
    {
        private const string gender = "Female";

        public Kitten(string name, int age) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
