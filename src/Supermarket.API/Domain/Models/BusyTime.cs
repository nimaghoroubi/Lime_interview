using System;

namespace Supermarket.API.Domain.Models
{
    public class BusyTime
    {
        public int Id { set; get; }
        public string EmployeeIdString { get; set; }
        public DateTime EmployeeMeetingStart { get; set; }
        public DateTime EmployeeMeetingEnd { get; set; }

        public Employee Employee { get; set; }
    }
}