using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.DbFromText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Supermarket.API.Persistence.DbFromText
{
    public class DbFromText
    {
        
        public static void InsertAll(AppDbContext _context)
        {
            UsersList UserManager = new UsersList();


            List<string> Records = UsersList.ReadTextFile();
            List<Employee> Employees = new List<Employee>();
            List<BusyTime> BusyTimes = new List<BusyTime>();

            foreach(string record in Records)
            {
                (Employee employeeRecord, BusyTime busytimeRecord) = UserManager.EmployeeFromText(record);
                Employees.Add(employeeRecord);
                BusyTimes.Add(busytimeRecord);
            }


            foreach(Employee employee in Employees)
            {
                if(employee != null)
                {
                    var UserInDb = _context.Employee.Where(p => p.EmployeeIdString.Contains(p.EmployeeIdString))
                    .Select(p => p.EmployeeIdString).ToArray();
                    if (!UserInDb.Contains(employee.EmployeeIdString))
                    {
                        _context.Employee.Add(employee);
                        _context.SaveChanges();

                    }
                }
            }
            foreach (BusyTime busyTime in BusyTimes)
            {
               if(busyTime != null)
                {
                    _context.BusyTimes.Add(busyTime);
                    _context.SaveChanges();
                }
            }
        }

    }
}
