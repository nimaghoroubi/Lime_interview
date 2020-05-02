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
        
        public async Task<Dictionary<string, string>> GetSuggestions()
        {
            Dictionary<string, string> test = new Dictionary<string, string>();
            test.Add("1", "2");
            return test;
        }
        
    }
}
