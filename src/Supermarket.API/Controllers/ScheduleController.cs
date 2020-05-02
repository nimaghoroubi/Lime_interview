using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Persistence.queries;
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
        public async Task<List<DateTime>> IsEmployeeAvailable()
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = locale.RequestCulture.Culture;

            Dictionary<string, string> QueryParameters = new Dictionary<string, string>();
            QueryParameters.Add("user(s)", Request.Query["user"]);
            QueryParameters.Add("Length", Request.Query["length"]);
            QueryParameters.Add("Earliest", Request.Query["earliest"]);
            QueryParameters.Add("Latest", Request.Query["latest"]);
            QueryParameters.Add("Office Hours", Request.Query["officehour"]);

            Query query = new Query(QueryParameters, culture);

            List<DateTime> SuggestedTimes = await query.GetSuggestions();


            return SuggestedTimes;
        }

        //public async Task<IEnumerable<EmployeeResource>> GetAllAsync()
        //{
        //    var employee = await _employeeService.ListAsync();
        //    var resources = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(employee);

        //    return resources;
        //}
    }
}