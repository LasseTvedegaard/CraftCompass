using Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Model;
using BusinessLogic.Interfaces;
using BusinessLogic;
using DataAccess.Interfaces;
using DataAccess;

namespace CraftCompass_REST_Service {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Case
            builder.Services.AddTransient<ICRUD<Case>, CaseControl>();
            builder.Services.AddTransient<ICRUDAccess<Case>, CaseAccess>();

            // Customer
            builder.Services.AddTransient<ICRUD<Customer>, CustomerControl>();
            builder.Services.AddTransient<ICRUDAccess<Customer>, CustomerAccess>();

            // Employee
            builder.Services.AddTransient<ICRUD<Employee>, EmployeeControl>();
            builder.Services.AddTransient<ICRUDAccess<Employee>, EmployeeAccess>();

            // WorkAddress
            builder.Services.AddTransient<ICRUD<WorkAddress>, WorkAddressControl>();
            builder.Services.AddTransient<ICRUDAccess<WorkAddress>, WorkAddressAccess>();

            // CaseWorker
            builder.Services.AddTransient<ICRUD<CaseWorker>, CaseWorkerControl>();
            builder.Services.AddTransient<ICRUDAccess<CaseWorker>, CaseWorkerAccess>();


            builder.Services.AddControllers();

            // Configure Swagger/OpenAPI
            // Learn more about configuring Swagger/OpenAPI at <https://aka.ms/aspnetcore/swashbuckle>
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Serilog
            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));

            var provider = builder.Services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            // CORS
            builder.Services.AddCors(options => {
                var frontendURL = configuration.GetValue<string>("frontend_url");

                options.AddDefaultPolicy(builder => {
                    builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();

            app.UseCors();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
