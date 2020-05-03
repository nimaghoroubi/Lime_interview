using System;

namespace Supermarket.API.Domain.Models
{
    // a model for the object that models the employee's meeting times
    public class BusyTime
    {
        public int Id { set; get; }
        public string EmployeeIdString { get; set; }
        public DateTime EmployeeMeetingStart { get; set; }
        public DateTime EmployeeMeetingEnd { get; set; }

        public Employee Employee { get; set; }
    }
}