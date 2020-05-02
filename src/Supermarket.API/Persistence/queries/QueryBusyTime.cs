using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
    public class QueryBusyTime
    {
        Dictionary<string, string> _userData;
        CultureInfo _cultureInfo;
        public QueryBusyTime(Dictionary<string, string> userData, CultureInfo culture)
        {
            _userData = userData;
            _cultureInfo = culture;
        }

        public async Task<List<BusyTime>> BusyTimeDbQueryAsync()
        {
            List<BusyTime> query = new List<BusyTime>();
            List<string> userIds = new List<string>();
            foreach (string userId in _userData["user(s)"].Split(","))
            {
                userIds.Add(userId);
            }

            foreach (string userId in userIds)
            {
                var host = DbScope.host;
                using (var scope = host.Services.CreateScope())
                using (var context = scope.ServiceProvider.GetService<AppDbContext>())
                {
                    var newQuery = await context.BusyTimes.Where(p => p.EmployeeIdString == userId).ToListAsync();
                    query.AddRange(newQuery);
                }
            }

            return query;
            
        }
    }
}
