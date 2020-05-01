using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Services
{
    public class ScheduleService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ScheduleService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<Dictionary<string, string>> AvailabilityAsync()
        {
            return await _employeeRepository.AvailabilityAsync();
        }
    }
}