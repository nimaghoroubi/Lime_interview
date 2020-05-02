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
        // file handling part of reading the txt file of records.
        public static List<string> ReadTextFile()
        {
            List<string> list = new List<string>();
            var filestream = new FileStream(@"freebusy.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(filestream, Encoding.UTF8))
            {
                string line;
                // reading line by line and stopping at the end of file (null return)
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

            // spliting each line by the divider ";" and if there is less than 3 records, its a faulty record
            // and we will skip it as it does not contain all the timings we need
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

        // skip this, part of initial experiment
        static List<Employee> NewEmployees = new List<Employee>();
        static List<BusyTime> NewTimes = new List<BusyTime>();
        
    }
}
