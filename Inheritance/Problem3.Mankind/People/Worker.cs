using System;
using System.Collections.Generic;
using System.Text;

namespace Problem3.Mankind.People
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workingHours;

        public Worker(string firstName, string lastName, double weekSalary, double workingHours) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHours = workingHours;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkingHours
        {
            get { return this.workingHours; }
            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHours = value;
            }
        }

        public double SalaryPerHour
        {
            get { return (this.WeekSalary / this.WorkingHours) / 5; }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine +
                   $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
                   $"Hours per day: {this.WorkingHours:f2}" + Environment.NewLine +
                   $"Salary per hour: {this.SalaryPerHour:f2}";
        }
    }
}
