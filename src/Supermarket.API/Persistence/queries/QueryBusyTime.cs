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
    // here we look for the users in the database and get back their information of records
    public class QueryBusyTime
    {
        // the list of query parameters from api call and culture info is injected here
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
            // for each user in request, we separate them to be queried against db
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
                    // looks for users we asked for and their record of meetings
                    var newQuery = await context.BusyTimes.Where(p => p.EmployeeIdString == userId).ToListAsync();
                    query.AddRange(newQuery);
                }
            }

            return query;
            
        }
    }
}
