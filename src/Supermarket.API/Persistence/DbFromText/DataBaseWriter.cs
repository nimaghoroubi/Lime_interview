using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.DbFromText
{
    public class DataBaseWriter
    {
        public static void WriteToDb(AppDbContext _context, List<Employee> Employees, List<BusyTime> BusyTimes)
        {
            foreach (Employee employee in Employees)
            {
                if (employee != null)
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
                if (busyTime != null)
                {
                    _context.BusyTimes.Add(busyTime);
                    _context.SaveChanges();
                }
            }
        }
    }
}
