using Breadr.Service.Gate;
using DataAccess.DBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Service.Report;
using Breadr.Service.Statistic;

namespace Breadr
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BreadrDbContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));
            builder.Services.AddScoped<IReportService, ReportService>();
            builder.Services.AddScoped<IGateService, GateService>();
            builder.Services.AddScoped<IStatisticService, StatisticService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}