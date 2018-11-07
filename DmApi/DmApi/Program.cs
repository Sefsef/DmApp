using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace DmApi
{
    public static class Program
    {
        static void Main(string[] pArgs)
        {
            BuildWebHost(pArgs).Run();
        }

        public static IWebHost BuildWebHost(string[] pArgs)
        {
            return WebHost.CreateDefaultBuilder(pArgs)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:4000")
                .Build();
        }
    }
}
