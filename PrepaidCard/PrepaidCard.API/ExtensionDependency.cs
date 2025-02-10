using PrepaidCard.Core.Interfaces.IRepositories;
using PrepaidCard.Core.Interfaces.IServices;
using PrepaidCard.Data.Repositories;
using PrepaidCard.Data;
using PrepaidCard.Service.Services;
using PrepaidCard.Core;

namespace PrepaidCard.API
{
    public static class ExtensionDependency
    {
        public static void addDependency(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IPurchaseCenterService, PurchaseCenterService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IStoreService, StoreService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPurchaseCenterRepository, PurchaseCenterRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddControllers();
            services.AddSingleton<DataContext>();
            services.AddDbContext<DataContext>();

            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));
            


        }
    }
}
