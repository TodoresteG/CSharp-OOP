using System;

namespace Problem3.Ferrari
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Ferrari ferrari = new Ferrari(name);

            Console.WriteLine(ferrari);
        }
    }
}
