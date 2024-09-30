using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Database
{
    public class EmployeeDatabase
    {
        private static EmployeeDatabase? instance;

        public static  object _lock = new object();

        public static EmployeeDatabase Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDatabase();
                    }
                }
                return instance;
            }
        }

        private List<Employee> employeesRegistered;
        private EmployeeDatabase()
        {
            employeesRegistered = new List<Employee>
            {
            new Employee { Id = 1, Name = "Mr. Krab", Notes = "Best Value!", IsActive = true, Rate = 10.0},
            new Employee { Id = 2, Name = "Spongebob", Notes = "I'm Ready!", IsActive = true, Rate = 2.50},
            };
        }

        public List<Employee> EmployeesRegistered
        {
            get { return employeesRegistered; }
        }

        //gets
        public Employee? Get(int id)
        {
            return employeesRegistered.FirstOrDefault(c => c.Id == id);
        }

        //add
        public void Add(Employee? employee)
        {
            if (employee != null)
            {
                employeesRegistered.Add(employee);
            }
        }

        //delete
        public void Delete(int id)
        {
            var employeeToRemove = Get (id);
            if (employeeToRemove != null)
            {
                employeesRegistered.Remove(employeeToRemove);
            }
        }

        //read
        public void Read()
        {
            employeesRegistered.ForEach(Console.WriteLine);
        }
    }
}
