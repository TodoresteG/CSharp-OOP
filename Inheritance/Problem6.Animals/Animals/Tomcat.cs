﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Problem6.Animals.Animals
{
    public class Tomcat : Animal
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) : base(name, age, gender)
        {
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
