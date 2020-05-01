using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;

namespace Supermarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IEmployeeRepository _categoryRepository;

        public CategoryService(IEmployeeRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }
    }
}