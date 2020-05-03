using AutoMapper.Configuration.Conventions;
using System.Collections.Generic;


namespace Supermarket.API.Domain.Models
{
    // a model for the employees themselves, token I have no idea it is, it was in the freebusy.txt and no info on it
    // the rest is self explanatory
    public class Employee
    {
        public int Id { set; get; }
        public string EmployeeIdString { get; set; }
        public string EmployeeName { get; set; }
        public string Token { get; set; }
        public IList<BusyTime> BusyTimes { get; set; } = new List<BusyTime>();

    }

}
