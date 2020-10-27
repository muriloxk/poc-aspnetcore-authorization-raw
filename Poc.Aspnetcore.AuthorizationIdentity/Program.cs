using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Poc.AspnetCore.AuthorizationIdentity;

namespace Poc.Aspnetcore.AuthorizationIdentity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
