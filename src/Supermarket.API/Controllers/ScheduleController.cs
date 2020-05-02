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
    // THE FUN PART, the endpoint is designed here
    // http://localhost:5000/api/schedule?user=1&user=57646786307395936680161735716561753784&length=30&earliest=3-13-2015 10:00 am&latest=3-13-2015 11:00 am&officehour=08-18
    // this is a sample endpoint request, user = 'userid' is the users you need
    // length is the length in minutes
    // earliest is the earliest date and time you need, latest same thing for the latest, format is your own locale, look at your taskbar, do the same
    // officehour is the office hours, 8-15 , just write it like this


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
        // an async call to query and find available times
        public async Task<List<DateTime>> IsEmployeeAvailable()
        {
            var locale = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = locale.RequestCulture.Culture;

            // parsing query parameters from API call 
            Dictionary<string, string> QueryParameters = new Dictionary<string, string>();
            QueryParameters.Add("user(s)", Request.Query["user"]);
            QueryParameters.Add("Length", Request.Query["length"]);
            QueryParameters.Add("Earliest", Request.Query["earliest"]);
            QueryParameters.Add("Latest", Request.Query["latest"]);
            QueryParameters.Add("Office Hours", Request.Query["officehour"]);

            // querying the data we have for results
            Query query = new Query(QueryParameters, culture);

            // looking for time suggestions with the query
            List<DateTime> SuggestedTimes = await query.GetSuggestions();

            // this is what you see as API response
            return SuggestedTimes;
        }
    }
}