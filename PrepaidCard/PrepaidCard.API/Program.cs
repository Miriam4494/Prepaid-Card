using Microsoft.EntityFrameworkCore;
using PrepaidCard.Core.Entities;
using PrepaidCard.Core.Interfaces.IRepositories;
using PrepaidCard.Core.Interfaces.IServices;
using PrepaidCard.Data;
using PrepaidCard.Data.Repositories;
using PrepaidCard.Service.Services;
using System.Text.Json.Serialization;

namespace PrepaidCard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.addDependency();
            
            //builder.Services.AddScoped<ICardService, CardService>();
            //builder.Services.AddScoped<ICustomerService, CustomerService>();
            //builder.Services.AddScoped<IPurchaseCenterService, PurchaseCenterService>();
            //builder.Services.AddScoped<IPurchaseService, PurchaseService>();
            //builder.Services.AddScoped<IStoreService, StoreService>();

            //builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            //builder.Services.AddScoped<ICardRepository, CardRepository>();
            //builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            //builder.Services.AddScoped<IPurchaseCenterRepository, PurchaseCenterRepository>();
            //builder.Services.AddScoped<IStoreRepository, StoreRepository>();
      
            //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

            //builder.Services.AddControllers();
            //builder.Services.AddSingleton<DataContext>();
            //builder.Services.AddDbContext<DataContext>();


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
