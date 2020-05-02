using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Persistence.Contexts;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Persistence.DbFromText;

namespace Supermarket.API
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            // here the scope and context of host is created, it is used to connect with the instance of db running
            using(var scope = host.Services.CreateScope())
            using(var context = scope.ServiceProvider.GetService<AppDbContext>())
            {
                // here a static variable host is assigned for other parts of the API to use as a context
                // from this other modules can get scope and context so that they can connect to the db without 
                // redoing a whole bunch of steps
                DbScope.host = host;
                // ensures db is created, thank god for EF
                context.Database.EnsureCreated();
                // this function inserts all employee records in db, if lock.txt is there, it will skip loading
                // if there is no lock.txt it will populate the db, takes time, be patient for 6 minutes ish!
                DbFromText.InsertAll(context);
            }
            // you have your api running if you are here
            host.Run();
        }

        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
    }
}