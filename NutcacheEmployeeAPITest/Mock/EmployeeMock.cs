using NutcacheEmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutcacheEmployeeAPITest.Mock
{
    public static class EmployeeMock
    {
        public static Employee employee1 = new Employee
        {
            Id = 1,
            Name = "Employee 1",
            BirthDate = DateTime.Now,
            Cpf = "123.123.123-12",
            Email = "employee1@email.com",
            Gender = "Female",
            StartDate = DateTime.Now,
            Team = "Mobile"
        };

        public static Employee employee2 = new Employee
        {
            Id = 2,
            Name = "Employee 2",
            BirthDate = DateTime.Now,
            Cpf = "123.123.123-12",
            Email = "employee2@email.com",
            Gender = "Male",
            StartDate = DateTime.Now,
            Team = "Mobile"
        };

        public static List<Employee> getEmployeeList()
        {
            return new List<Employee> { employee1, employee2 };
        }

        public static Employee getEmployee()
        {
            return employee1;
        }
    }
}
