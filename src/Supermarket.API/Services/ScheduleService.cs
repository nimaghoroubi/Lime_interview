using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Services
{
    // dont mind this, not really related to anything, part of my early experiments (too afraid to delete :D )
    public class ScheduleService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public ScheduleService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }
    }
}