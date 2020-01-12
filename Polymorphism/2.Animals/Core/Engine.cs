using System;
using System.Collections.Generic;
using System.Text;
using Animals.Models;

namespace Animals.Core
{
    public class Engine
    {
        public void Run()
        {
            Animal cat = new Cat("Pesho", "Whiskas");
            Animal dog = new Dog("Gosho", "Meat");

            Console.WriteLine(cat);
            Console.WriteLine(dog);

        }
    }
}
