using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
    public class QueryBusyTime
    {
        Dictionary<string, string> _userData;
        public QueryBusyTime(Dictionary<string, string> userData)
        {
            _userData = userData;
        }

        public async Task<List<BusyTime>> BusyTimeDbQueryAsync()
        {
            var host = DbScope.host;
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                var query = await context.BusyTimes.Where(p => p.EmployeeIdString == _userData["user(s)"]).ToListAsync();
                return query;
            }
            
        }
    }
}
