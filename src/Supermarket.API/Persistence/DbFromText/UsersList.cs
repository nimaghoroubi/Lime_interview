using Microsoft.Extensions.Configuration.CommandLine;
using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.DbFromText
{
    public class UsersList
    {
        public static List<string> ReadTextFile()
        {
            List<string> list = new List<string>();
            var filestream = new FileStream(@"freebusy.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(filestream, Encoding.UTF8))
            {
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            filestream.Close();
            return list;
        }

        public (Employee employeeRecord, BusyTime busytimeRecord) EmployeeFromText(string record)
        {
            Employee EmployeeRecord = new Employee();
            BusyTime BusyTimeRecord = new BusyTime();

            string[] subRecords = record.Split(';');
            if(subRecords.Length > 3)
            {
                EmployeeRecord.EmployeeIdString = subRecords[0];
                EmployeeRecord.Token = subRecords[3];

                BusyTimeRecord.EmployeeIdString = subRecords[0];
                BusyTimeRecord.EmployeeMeetingStart = DateTime.Parse(subRecords[1]);
                BusyTimeRecord.EmployeeMeetingEnd = DateTime.Parse(subRecords[2]);
                return (employeeRecord: EmployeeRecord, busytimeRecord: BusyTimeRecord);
            } else
            {
                return (null, null);
            }
            
        }

        static List<Employee> NewEmployees = new List<Employee>();
        static List<BusyTime> NewTimes = new List<BusyTime>();
        
    }
}
