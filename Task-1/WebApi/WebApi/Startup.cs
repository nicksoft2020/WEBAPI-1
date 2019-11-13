using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProjectDb.EF;
using ProjectDb.Initial;
using ProjectDb.Storage;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUnitOfWork, EFUnitOfWork>();
            services.AddControllers();
            services.AddMvc();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using(var scope = app.ApplicationServices.CreateScope())
            {
                ApplicationContext db = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
                InitDb.Initial(db);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles(); // <-- Это
            //app.UseStaticFiles(); // <-- Вот это

            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()); //
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyMethod());
            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader());
        }
    }
}
