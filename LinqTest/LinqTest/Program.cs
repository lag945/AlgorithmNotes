using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee
            {
                FirstName = "A",
                LastName = "A",
                Age = 25,
                Company = "Tesla"
            });

            employees.Add(new Employee
            {
                FirstName = "B",
                LastName = "B",
                Age = 40,
                Company = "Tesla"
            });

            employees.Add(new Employee
            {
                FirstName = "C",
                LastName = "C",
                Age = 33,
                Company = "Amazon"
            });

            employees.Add(new Employee
            {
                FirstName = "D",
                LastName = "D",
                Age = 42,
                Company = "Amazon"
            });

            employees.Add(new Employee
            {
                FirstName = "Laguna",
                LastName = "Du",
                Age = 38,
                Company = "PilotGaea"
            });

            //https://docs.microsoft.com/zh-tw/dotnet/csharp/linq/query-expression-basics
            AverageAgeForEachCompany(employees);
            CountOfEmployeesForEachCompany(employees);
            OldestAgeForEachCompany(employees);

        }
        
        public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
        {
            var results = from employee in employees group employee by employee.Company into newGroup orderby newGroup.Key select new { Company = newGroup.Key, AverageAge = (from employee2 in newGroup select employee2.Age).Average() };
            Dictionary<string, int> ret = results.ToDictionary(o => o.Company, o => (int)o.AverageAge);
            return ret;
        }

        public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
        {
            var results = from employee in employees group employee by employee.Company into newGroup orderby newGroup.Key select new { Company = newGroup.Key, Count = (from employee2 in newGroup select employee2.Age).Count() };
            Dictionary<string, int> ret = results.ToDictionary(o => o.Company, o => (int)o.Count);
            return ret;
        }

        public static Dictionary<string, int> OldestAgeForEachCompany(List<Employee> employees)
        {
            var results = from employee in employees group employee by employee.Company into newGroup orderby newGroup.Key select new { Company = newGroup.Key, Age = (from employee2 in newGroup select employee2.Age).Max() };
            Dictionary<string, int> ret = results.ToDictionary(o => o.Company, o => (int)o.Age);
            return ret;
        }

        public class Employee
        { 
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string Company { get; set; }
        }
    }
}
