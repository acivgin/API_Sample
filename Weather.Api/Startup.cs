using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Weather.Clients;
using Weather.Core;
using Weather.Core.Clients;
using Weather.Core.Common;
using Weather.Core.Services;
using Weather.Data;
using Weather.Services;
using Swashbuckle.AspNetCore.Swagger;
using NLog;
using System;
using System.IO;
using Weather.Api.Middlewares;

namespace Weather.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        private readonly string AllowedSpecificOrigins = "AllowedSpecificOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMemoryCache();

            services.AddConfig(Configuration);

            services.ConfigureCORS(Configuration.GetValue<string>("AllowedOrigins").Split(','));

            services.AddAutoMapper(typeof(Startup));

            services.ConfigureDatabase(Configuration.GetConnectionString("LocationDb"));

            services.ConfigureLogger();

            services.ConfigureSwagger();

            services.AddClients();

            services.AddRepositories();

            services.AddBusinessServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowedSpecificOrigins);

            app.AddMiddlewares();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Weather Forecast V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            return app;
        }
    }

    public static class IServiceCollectionExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<LocationDbContext>(options =>
            {
                options.UseSqlite(ConnectionString,
                    x => x.MigrationsAssembly("Weather.Data"));
            });
        }

        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureCORS(this IServiceCollection services, string[] AllowedOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowedSpecificOrigins",
                    builder =>
                    {
                        builder.WithOrigins(AllowedOrigins);
                    });
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Weather Forecast", Version = "v1" });
            });
        }

        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration configuration)
        {
            AppConfig appConfig = new AppConfig();
            configuration.Bind(appConfig);
            services.AddSingleton(appConfig);
            return services;
        }

        public static IServiceCollection AddClients(this IServiceCollection services)
        {
            services.AddSingleton<IOpenWeatherClient, OpenWeatherClient>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<ILocationService, LocationService>();
            return services;
        }
    }
}
