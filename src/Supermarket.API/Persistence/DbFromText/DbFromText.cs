using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.DbFromText;
using System;
using System.Collections.Generic;
using System.IO;
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

            foreach (string record in Records)
            {
                (Employee employeeRecord, BusyTime busytimeRecord) = UserManager.EmployeeFromText(record);
                Employees.Add(employeeRecord);
                BusyTimes.Add(busytimeRecord);
            }
            if (!File.Exists(@"lock.txt"))
            {
                Console.WriteLine("Migrating to DataBase, This can take a long time. Please wait.");
                DataBaseWriter.WriteToDb(_context, Employees, BusyTimes);
            }

            Console.WriteLine("Loaded previous DataBase\n\n\n");

        }

        
    }
}
