using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.DbFromText
{
    public class UsersList
    {
        readonly static Employee employee1 = new Employee
        {
            EmployeeIdString = "11111111",
            EmployeeName = "Jack Daniels"
        };

        readonly static Employee employee2 = new Employee
        {
            EmployeeIdString = "11111111",
            EmployeeName = "Jack Daniels"
        };

        readonly static Employee employee3 = new Employee
        {
            EmployeeIdString = "11111112",
            EmployeeName = "Jack Daniels"
        };

        readonly static Employee employee4 = new Employee
        {
            EmployeeIdString = "11111113",
            EmployeeName = "Jack Daniels"
        };

        readonly static BusyTime busytime1 = new BusyTime
        {
            EmployeeIdString = "11111111",
            EmployeeMeetingStart = DateTime.Parse("05/29/2015 5:00 AM"),
            EmployeeMeetingEnd = DateTime.Parse("05/29/2015 6:0 AM")
        };

        readonly static BusyTime busytime2 = new BusyTime
        {
            EmployeeIdString = "11111111",
            EmployeeMeetingStart = DateTime.Parse("05/29/2015 7:00 AM"),
            EmployeeMeetingEnd = DateTime.Parse("05/29/2015 6:0 AM")
        };

        static List<Employee> NewEmployees = new List<Employee>();
        static List<BusyTime> NewTimes = new List<BusyTime>();
        public static List<Employee> AddAllEmployees()
        {
            NewEmployees.Add(employee1);
            NewEmployees.Add(employee2);
            NewEmployees.Add(employee3);
            NewEmployees.Add(employee4);

            return NewEmployees;
        }        
        public static List<BusyTime> AddAllBusyTimes()
        {
            NewTimes.Add(busytime1);
            NewTimes.Add(busytime2);

            return NewTimes;
        }
    }
}
