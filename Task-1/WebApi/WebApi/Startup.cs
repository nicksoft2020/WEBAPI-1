using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ProjectDb.EF;
using ProjectDb.Initial;
using ProjectDb.Storage;
using WebApi.JWT;

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
            services.Configure<AuthOntions>((Configuration.GetSection("ApplicationSettings")));

            services.AddDbContext<ApplicationContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>(opts => {
                opts.Password.RequiredLength = 5;   // минимальная длина
                opts.Password.RequireNonAlphanumeric = false;   // требуются ли не алфавитно-цифровые символы
                opts.Password.RequireLowercase = false; // требуются ли символы в нижнем регистре
                opts.Password.RequireUppercase = false; // требуются ли символы в верхнем регистре
                opts.Password.RequireDigit = false; // требуются ли цифры
            })
                .AddEntityFrameworkStores<ApplicationContext>();

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=> {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
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
                //InitDb.Initial(db);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDefaultFiles(); // <-- Это
            //app.UseStaticFiles(); // <-- Вот это

            //app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()); //
            app.UseCors(option => option.WithOrigins(Configuration["ApplicationSettings:Client_Url"].ToString()).AllowAnyMethod().AllowAnyHeader()); //
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyMethod());
            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader());
        }
    }
}
