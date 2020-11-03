using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ModelLayer;
using RepositoryLayer;
using ServiceLayer;

namespace QuantityMeasurement
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
            String ConnctionString = Configuration.GetConnectionString("DatabaseConnection");
            services.AddDbContext<QuantityMeasurementDBContext>(opt => opt.UseSqlServer(ConnctionString, b => b.MigrationsAssembly("QuantityMeasurement")));
            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });
            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<IQuantityMeasurementRepository, QuantityMeasurementRepository>();
            services.AddTransient<IQuantityMeasurementService, QuantityMeasurementService>();
            services.AddSwaggerGen(swagger =>
            {
                // This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Parkinglot Api",
                    Version = "v1",
                    Description = "Asp.net Core Web Api for QuantityMeasurement App",
                    TermsOfService = new Uri("https://github.com/vishal-patil01"),
                    Contact = new OpenApiContact
                    {
                        Name = "Vishal Rajput",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/vishal-patil01"),
                    },
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


            app.UseRouting();

            app.UseAuthorization();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
