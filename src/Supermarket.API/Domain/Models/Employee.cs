using AutoMapper.Configuration.Conventions;
using System.Collections.Generic;

/// <summary>
/// Summary description for Class1
/// </summary>
namespace Supermarket.API.Domain.Models
{
    public class Employee
    {
        public int Id { set; get; }
        public string EmployeeIdString { get; set; }
        public string EmployeeName { get; set; }
        public string Token { get; set; }
        public IList<BusyTime> BusyTimes { get; set; } = new List<BusyTime>();

    }

}
