using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services
{
    // ignore this, part of initial experiments
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
    }
}