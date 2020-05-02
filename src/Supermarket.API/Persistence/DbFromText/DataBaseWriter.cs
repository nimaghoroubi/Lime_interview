using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.DbFromText
{
    // writes the data from txt file to db
    public class DataBaseWriter
    {
        public static void WriteToDb(AppDbContext _context, List<Employee> Employees, List<BusyTime> BusyTimes)
        {
            foreach (Employee employee in Employees)
            {
                if (employee != null)
                {
                    // here we use the context of our database, to add users to it if they are not already there
                    // the save changes saves the change we just made :)))) 
                    var UserInDb = _context.Employee.Where(p => p.EmployeeIdString.Contains(p.EmployeeIdString))
                    .Select(p => p.EmployeeIdString).ToArray();
                    if (!UserInDb.Contains(employee.EmployeeIdString))
                    {
                        _context.Employee.Add(employee);
                        _context.SaveChanges();

                    }
                }
            }
            // adding records of meetings to busytimes table in db
            foreach (BusyTime busyTime in BusyTimes)
            {
                if (busyTime != null)
                {
                    _context.BusyTimes.Add(busyTime);
                    _context.SaveChanges();
                }
            }
        }
    }
}
