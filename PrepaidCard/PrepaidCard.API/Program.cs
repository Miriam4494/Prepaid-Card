using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces;
using PrepaidCard.Data;
using PrepaidCard.Data.Repositories;
using PrepaidCard.Service.Services;

namespace PrepaidCard.API
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

            builder.Services.AddScoped<CardIService, CardService>();
            builder.Services.AddScoped<CustomerIService, CustomerService>();
            builder.Services.AddScoped<PurchaseCenterIService, PurchaseCenterService>();
            builder.Services.AddScoped<PurchaseIService, PurchaseService>();
            builder.Services.AddScoped<StoreIService, StoreService>();
            //builder.Services.AddScoped<IRepository<CardEntity>, CardRepository>();
            //builder.Services.AddScoped<IRepository<CustomerEntity>, CustomerRepository>();
            //builder.Services.AddScoped<IRepository<PurchaseCenterEntity>, PurchaseCenterRepository>();
            //builder.Services.AddScoped<IRepository<PurchaseEntity>, PurchaseRepository>();
            //builder.Services.AddScoped<IRepository<StoreEntity>, StoreRepository>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

            builder.Services.AddControllers();
            //builder.Services.AddSingleton<DataContext>();
            builder.Services.AddDbContext<DataContext>();


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
