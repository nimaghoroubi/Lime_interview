using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.queries
{
    public class Query
    {
        Dictionary<string, string> _userData;
        public Query(Dictionary<string, string> userData)
        {
            _userData = userData;
        }
        
        public async Task<List<BusyTime>> GetSuggestions()
        {
            QueryBusyTime query = new QueryBusyTime(_userData);
            List<BusyTime> test = await query.BusyTimeDbQueryAsync();
             
            //test.Add("1", "2");
            return test;
        }
        
    }
}
