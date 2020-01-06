using System;
using Composição_exercício_resolvido.Entities.Enums;
using Composição_exercício_resolvido.Entities;
using System.Globalization;
using System.Collections.Generic;

namespace Composição_exercício_resolvido
{
    class Program
    {
        static void Main(string[] args)
        {
                      
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("ENTER WORKER DATA:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior, MidLevel, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
      
            Department department = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("How many  contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} conctract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract conctract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(conctract);

            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY); ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
            
        }
    }
}
