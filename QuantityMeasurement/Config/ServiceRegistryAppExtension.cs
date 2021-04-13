using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuantityMeasurement.Config
{
    public static class ServiceRegistryAppExtension
    {
        public static IServiceCollection AddConsulConfig(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulconfig =>
               {
                   consulconfig.Address = new Uri(configuration.GetSection("Configuration").GetSection("ConsulAddress").Value);
               }));
            return services;
        }

        [Obsolete]
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app,IConfiguration configuration)
        {
            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
            var logger = app.ApplicationServices.GetRequiredService<ILoggerFactory>().CreateLogger("AppExtension");
            var lifeTime = app.ApplicationServices.GetRequiredService<IApplicationLifetime>();

            var registration = new AgentServiceRegistration()
            {
                ID = configuration.GetSection("Configuration").GetSection("ServiceName").Value,
                Name = configuration.GetSection("Configuration").GetSection("ServiceName").Value,
                Address = configuration.GetSection("Configuration").GetSection("ServiceHost").Value,
                Port = int.Parse(configuration.GetSection("Configuration").GetSection("ServicePort").Value)
            };
            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).ConfigureAwait(true);
            consulClient.Agent.ServiceRegister(registration).ConfigureAwait(true);

            lifeTime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Unregistering from Consul");
            });
            return app;
        }
    }
}
