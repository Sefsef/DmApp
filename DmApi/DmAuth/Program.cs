using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DmAuth
{
    public static class Program
    {
        public static void Main(string[] pArgs)
        {
            CreateWebHostBuilder(pArgs).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] pArgs) =>
            WebHost.CreateDefaultBuilder(pArgs)
                .UseStartup<Startup>();
    }
}
