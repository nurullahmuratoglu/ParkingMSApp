using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkingMSApp.Application.Repositories;
using ParkingMSApp.Application.UnitOfWork;
using ParkingMSApp.Presistence.Context;
using ParkingMSApp.Presistence.Repositories;
using ParkingMSApp.Presistence.UnitOfWork;

namespace ParkingMSApp.Presistence
{
    public static class ServiceRegistration
    {
        public static void AddPresistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            serviceCollection.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            serviceCollection.AddScoped<IVehicleRepository, VehicleRepository>();
            serviceCollection.AddScoped<IParkingVehicleRepository, ParkingVehicleRepository>();
            serviceCollection.AddScoped<IFixedFeeRepository, FixedFeeRepository>();
            serviceCollection.AddScoped<IVehicleWashServiceRepository, VehicleWashServiceRepository>();
            serviceCollection.AddScoped<ITireChangeServiceRepository, TireChangeServiceRepository>();

            serviceCollection.AddScoped<IUnitOfWorks, UnitOfWorks>();
        }
    }
}
