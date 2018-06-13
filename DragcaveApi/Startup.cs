using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DragcaveSqlRepository;
using DragcaveEntities;
using DragcaveIdentity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DragcaveRepository;

namespace DragcaveApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"Config/appsettings.{env.EnvironmentName}.json");

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DragcaveContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DragcaveDatabase")));

            services.AddMvc();

            services.AddIdentity<DragcaveAccount, DragcaveRole>()
                .AddEntityFrameworkStores<DragcaveContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(DragcaveIdentityConfigurator.Setup);
            services.ConfigureApplicationCookie(DragcaveIdentityConfigurator.SetupCookie);

            services.AddCors();

            services.AddScoped<IRepository, SqlRepository>();

            services.AddSingleton(new DataSeeder(new DummyDataGenerator()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            DataSeeder dataSeeder,
            IRepository repository)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            //if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

            dataSeeder.SeedAsync(repository).Wait();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.UseMvc();
        }
    }
}
