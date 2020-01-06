using System.Collections.Generic;
using Composição_exercício_resolvido.Entities.Enums;

namespace Composição_exercício_resolvido.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public HourContract hourContract { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
            

        }
        
        public void AddContract (HourContract contract)
        {
            Contracts.Add(contract);

        }
        public void RemoveContract (HourContract contract)
        {
            Contracts.Remove(contract);

        }
        public double Income (int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}
