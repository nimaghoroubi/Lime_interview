using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Resources;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public ScheduleController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public Dictionary<string, string> IsEmployeeAvailable()
        {
            Dictionary<string, string> returnValue = new Dictionary<string, string>();
            returnValue.Add("user(s)", Request.Query["user"]);
            returnValue.Add("Meeting Length", Request.Query["length"]);
            returnValue.Add("Earliest Meeting date and time", Request.Query["earliest"]);
            returnValue.Add("Latest Meeting date and time", Request.Query["latest"]);
            returnValue.Add("office hours", Request.Query["officehour"]);

            //call to the AvailabilityAsync here...

            return returnValue;
        }

        //public async Task<IEnumerable<EmployeeResource>> GetAllAsync()
        //{
        //    var employee = await _employeeService.ListAsync();
        //    var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employee);

        //    return resources;
        //}
    }
}