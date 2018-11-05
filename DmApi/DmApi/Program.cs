using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DnDApi
{
    public static class Program
    {
        public static void Main(string[] pArgs)
        {
            CreateWebHostBuilder(pArgs).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] pArgs)
        {
            return WebHost.CreateDefaultBuilder(pArgs).UseStartup<Startup>();
        }
    }
}
