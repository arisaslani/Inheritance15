using System;
using System.Collections.Generic;

namespace Inheritance15
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pay an hourly employee Bob who works for 40 hours
            // Bob's hourly rate is $27.50
            HourlyEmployee bob = new HourlyEmployee
            {
                Name = "Bob",
                HourlyRate = 27.50,
                WorkedHours = 40.0
            };


            // Pay a salaried employee Steve who works one week.
            // Steve's yearly salary is $50,000

            SalaryEmployee steve = new SalaryEmployee
            {
                Name = "Steve",
                Salary = 50000.0,
                WorkedInWeeks = 1
            };

            List<Employee> employees = new List<Employee>
            {
                bob,
                steve
            };

            PayEmployees(employees);

            Console.ReadLine();


        }

        static void PayEmployees(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                employee.PayEmployee();
            }
        }
    }

    abstract class Employee
    {
        public string Name { get; set; }

        public abstract void PayEmployee();
    }

    class HourlyEmployee : Employee
    {
        public double WorkedHours { get; set; }
        public double HourlyRate { get; set; }
        public override void PayEmployee()
        {
            double amount = this.WorkedHours * this.HourlyRate;
            Console.WriteLine($"{this.Name} has worked {this.WorkedHours} and is getting {amount :C0} paid.");
        }
    }

    class SalaryEmployee : Employee
    {
        public double Salary { get; set; }
        public double WorkedInWeeks { get; set; }

        public override void PayEmployee()
        {
            var weeklySalary = this.Salary / 52;
            double amount = weeklySalary * this.WorkedInWeeks;
            Console.WriteLine($"{this.Name} worked for {this.WorkedInWeeks} Days and is getting {amount :C0} Paid(based on yearly Salary of: {this.Salary :C0}).");
        }
    }
}
