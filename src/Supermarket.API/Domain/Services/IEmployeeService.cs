using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<Dictionary<string, string>> AvailabilityAsync();
    }
}