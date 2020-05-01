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
    public class CategoriesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public CategoriesController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<string> IsEmployeeAvailable()
        {
            List<string> returnValue = new List<string>();
            returnValue.Add(Request.Query["page"]);
            returnValue.Add(Request.Query["time"]);

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