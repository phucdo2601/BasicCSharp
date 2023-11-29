using HrAdminstrationApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SchoolHrAdminstration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            //foreach (var employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            //Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");

            Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(e => e.Salary)} ");

            Console.ReadKey();

        }

        public static void SeedData(List<IEmployee> employees)
        {
            //IEmployee teacher1 = new Teacher
            //{
            //    Id = 1,
            //    FirstName = "Phuc",
            //    LastName = "Do Ngoc",
            //    Salary = 400000
            //};employees.Add(teacher1);

            //IEmployee teacher2 = new Teacher
            //{
            //    Id = 2,
            //    FirstName = "test-first-02",
            //    LastName = "test-last-02",
            //    Salary = 123132
            //};
            //employees.Add(teacher2);

            //IEmployee headOfDepartment = new HeadOfDepartment
            //{
            //    Id = 3,
            //    FirstName = "test-first-03",
            //    LastName = "test-last-03",
            //    Salary = 12313
            //};
            //employees.Add(headOfDepartment);

            
            //IEmployee deputyHeadMaster = new DeputyHeadMaster
            //{
            //    Id = 4,
            //    FirstName = "test-first-04",
            //    LastName = "test-last-04",
            //    Salary = 23424
            //};employees.Add(deputyHeadMaster);

            //IEmployee headMaster = new HeadMaster
            //{
            //    Id = 5,
            //    FirstName = "test-first-05",
            //    LastName = "test-last-05",
            //    Salary = 12313
            //};employees.Add(headMaster);

            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "test-first-name-02", "test-last-02", 40000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "test-first-name-03", "test-last-03", 50000);
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "test-first-name-04", "test-last-04", 60000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "test-first-name-05", "test-last-05", 80000);
            employees.Add(headMaster);



        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m);  }
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                //case EmployeeType.Teacher:
                //    employee = new Teacher { 
                //        Id = id,
                //        FirstName = firstName,
                //        LastName = lastName,
                //        Salary = salary
                //    };
                //    break;

                //case EmployeeType.HeadOfDepartment:
                //    employee = new HeadOfDepartment
                //    {
                //        Id = id,
                //        FirstName = firstName,
                //        LastName = lastName,
                //        Salary = salary
                //    };
                //    break;

                //case EmployeeType.DeputyHeadMaster:
                //    employee = new DeputyHeadMaster
                //    {
                //        Id = id,
                //        FirstName = firstName,
                //        LastName = lastName,
                //        Salary = salary
                //    };
                //    break;

                //case EmployeeType.HeadMaster:
                //    employee = new HeadMaster
                //    {
                //        Id = id,
                //        FirstName = firstName,
                //        LastName = lastName,
                //        Salary = salary
                //    };
                //    break;

                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;

                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;

                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;

                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;

                default:
                    break;
            }

            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            } else
            {
                throw new NullReferenceException();
            }

            return employee;
        }
    }
}
