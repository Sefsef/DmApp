using DmApi.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DmApi.Services;
using AutoMapper;

namespace DmApi
{
    public class Startup
    {
        private readonly string _connection = "Data Source=DmAPI.db";

        public Startup(IConfiguration pConfig)
        {
            Configuration = pConfig;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection pServices)
        {
            pServices.AddCors();
            pServices.AddDbContext<DataContext>
                (options => options.UseSqlite(_connection));
            pServices.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            pServices.AddAutoMapper();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            pServices.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            pServices.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        var userID = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetById(userID);
                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            pServices.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim("Admin"));
                options.AddPolicy("Dm", policy => policy.RequireClaim("Admin, Dm"));
                options.AddPolicy("Player", policy => policy.RequireClaim("Admin, Dm, Player"));
            });

            // configure DI for application services
            pServices.AddScoped<IUserService, UserService>();
            pServices.AddScoped<ISpellService, SpellService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder pApp, IHostingEnvironment pEnv, ILoggerFactory pLoggerFactory)
        {
            pLoggerFactory.AddConsole(Configuration.GetSection("Logging"));
            pLoggerFactory.AddDebug();

            if (pEnv.IsDevelopment())
                pApp.UseDeveloperExceptionPage();

            pApp.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            pApp.UseAuthentication();

            pApp.UseMvc();
        }
    }
}
