using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
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
            QueryBusyTime query = new QueryBusyTime(_userData, _cultureInfo);
            List<BusyTime> BusyTimeList = await query.BusyTimeDbQueryAsync();
            List<DateTime> AvailableTimes = GetAvailableTimes.GetAll(BusyTimeList, _userData, _cultureInfo);
            
            return AvailableTimes; // list of datetimes
        }
        
    }
}
