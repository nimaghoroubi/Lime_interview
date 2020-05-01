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
            foreach(Employee employee in UsersList.AddAllEmployees())
            {
                var UserInDb = _context.Employee.Where(p => p.EmployeeIdString.Contains(p.EmployeeIdString))
                    .Select(p => p.EmployeeIdString).ToArray();
                if (!UserInDb.Contains(employee.EmployeeIdString))
                {
                    _context.Employee.Add(employee);
                }
            }
            foreach (BusyTime busyTime in UsersList.AddAllBusyTimes())
            {
                _context.BusyTimes.Add(busyTime);
            }
            _context.SaveChanges();
        }

    }
}
