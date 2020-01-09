using System;

namespace Problem1.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double heigth = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, heigth);

                Console.WriteLine(box.FindSurfaceArea());
                Console.WriteLine(box.FindLateralArea());
                Console.WriteLine(box.FindVolume());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
