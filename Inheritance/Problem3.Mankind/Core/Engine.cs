using System;
using System.Collections.Generic;
using System.Text;
using Problem3.Mankind.People;

namespace Problem3.Mankind.Core
{
    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] studentArgs = Console.ReadLine().Split();

                string fisrtName = studentArgs[0];
                string lastName = studentArgs[1];
                string facultyNumber = studentArgs[2];

                Student student = new Student(fisrtName, lastName, facultyNumber);

                string[] workerArgs = Console.ReadLine().Split();

                fisrtName = workerArgs[0];
                lastName = workerArgs[1];
                double weekSalatry = double.Parse(workerArgs[2]);
                double workingHours = double.Parse(workerArgs[3]);

                Worker worker = new Worker(fisrtName, lastName, weekSalatry, workingHours);

                Console.WriteLine(student);
                Console.WriteLine();
                Console.WriteLine(worker);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
