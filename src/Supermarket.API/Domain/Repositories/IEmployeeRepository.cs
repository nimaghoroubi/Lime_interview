using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Repositories
{
    // ignore this, not doing much
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
    }
}