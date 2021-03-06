using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace InnovaSolTest.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
           .ConfigureAppConfiguration((hostingContext, config) =>
           {
               var env = hostingContext.HostingEnvironment;

               config.AddJsonFile("appsettings.json", optional: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

               config.AddEnvironmentVariables();
           })
            .UseStartup<Startup>();
    }
}
