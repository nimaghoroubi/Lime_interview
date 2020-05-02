using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
    // main query driver, here all functions are called and a list of available times is returned
    public class Query
    {
        Dictionary<string, string> _userData;
        CultureInfo _cultureInfo;
        public Query(Dictionary<string, string> userData, CultureInfo culture)
        {
            _userData = userData;
            _cultureInfo = culture;
        }
        
        public async Task<List<DateTime>> GetSuggestions()
        {
            // a query is made to db
            QueryBusyTime query = new QueryBusyTime(_userData, _cultureInfo);
            // time where employee is busy is returned
            List<BusyTime> BusyTimeList = await query.BusyTimeDbQueryAsync();
            // available times are returned based on busy times and requested meeting time
            List<DateTime> AvailableTimes = GetAvailableTimes.GetAll(BusyTimeList, _userData, _cultureInfo);
            
            return AvailableTimes; // list of datetimes
        }
        
    }
}
