using DnDApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DnDApi
{
    public class Startup
    {
        private readonly string _connection = "Data Source=SpellDB";
        private readonly string _cors = "CorsPolicy";

        public Startup(IConfiguration pConfig)
        {
            Configuration = pConfig;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection pServices)
        {
            pServices.AddDbContext<SpellContext>
                (options => options.UseSqlite(_connection));
            pServices.AddCors(options =>
            {
                options.AddPolicy(_cors,
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            pServices.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder pApp, IHostingEnvironment pEnv)
        {
            if (pEnv.IsDevelopment())
                pApp.UseDeveloperExceptionPage();

            pApp.UseCors(_cors);
            pApp.UseMvc();
        }
    }
}
