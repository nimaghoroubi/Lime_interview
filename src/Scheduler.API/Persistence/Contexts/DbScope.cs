using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Supermarket.API.Domain.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Contexts
{
    public class DbScope
    {
        public static IWebHost host;
        public static IServiceScope Scope { get; set; }
        public static AppDbContext Context { get; set; }
    }
}
