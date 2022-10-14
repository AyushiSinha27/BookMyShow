using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Movie_Business.services;
using Movie_Data;
using Movie_Data.repository;
using Movie_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MovieAPI_Core
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
            string connectionStr = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<MoviesDb>(options => options.UseSqlServer(connectionStr));
            services.AddControllers();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<MovieService, MovieService>();
            services.AddTransient<IShowTimingRepository, ShowTimingRepository>();
            services.AddTransient<ShowtimingService, ShowtimingService>();
            services.AddTransient<ITheaterRepository, TheaterRepository>();
            services.AddTransient<TheaterService, TheaterService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserService,UserService>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<BookingService, BookingService>();


            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Movie API",
                    Description = "Movie Management System API",
                });
            });
            
          
        


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
